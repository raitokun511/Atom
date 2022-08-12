using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkle {

	GameObject sparkle;
	public int Type;
	Sprite[] listSprite;
	int timeLive;
	int render = 80;
	public bool isDie = false;
	public string Name;
	public Vector3 randomMoveVec;
	ArrayList listEffect;
	int numberEffect = 0;
	int timeEffect = 0;


	public Sparkle (string name, Vector3 pos, Vector3 scale, Vector3 rotation, int type = 1, int renderNum = 80) {
		this.Type = type;

		sparkle = new GameObject ("sparkle "+ name);
		if (Type == 1)
			listSprite = Resources.LoadAll<Sprite> ("Effect/slash");
		if (Type == 2)
			listSprite = Resources.LoadAll<Sprite> ("Effect/superSlash");
		sparkle.AddComponent<SpriteRenderer> ().sprite = listSprite [0];
		sparkle.transform.position = pos;
		//Debug.Log ("len " + scale.y + "  " + listSprite [0].bounds.size.y + "  " + GM.unit * 4 + "   " + listSprite [0].bounds.size.y * GM.unit * 4);
		float scalelen = scale.y > listSprite [0].bounds.size.y * GM.unit * 4 ? GM.unit * 4 : scale.y / (listSprite [0].bounds.size.y * GM.unit * 4);
		//Debug.Log ("sclaelen " + scalelen);
		sparkle.transform.localScale = new Vector3 (GM.unit, scalelen, 1);
		sparkle.transform.localRotation = Quaternion.Euler (rotation);

		timeLive = (int)(Time.timeSinceLevelLoad * 1000);
		timeEffect = (int)(Time.timeSinceLevelLoad * 1000) + Random.Range (0, 20);
		this.Name = name;
		this.render = renderNum;
		listEffect = new ArrayList ();
		if (Type == 2)
			numberEffect = 5;
	}

	public float Scale {
		get { return sparkle.transform.localScale.x; }
		set{
			sparkle.transform.localScale = new Vector3 (value, value, 1);

		}
	}
	public Vector3 ExtraScale {
		get { return sparkle.transform.localScale; }
		set{
			sparkle.transform.localScale = value;

		}
	}

	public Vector3 Position
	{
		get { return sparkle.transform.position; }
		set {
			this.sparkle.transform.position = value;
		}
	}

	public Vector3 Size
	{
		get { return sparkle.GetComponent<SpriteRenderer> ().bounds.size; }

	}

	// Update is called once per frame
	public void Update () {
		if (isDie)
			return;
		int index = (((int)(Time.timeSinceLevelLoad * 1000) - timeLive) / render) % listSprite.Length;
		this.sparkle.GetComponent<SpriteRenderer> ().sprite = listSprite [index];

		if (Type == 2 && numberEffect > 0 && (int)(Time.timeSinceLevelLoad * 1000) > timeEffect) {
			float ranX = Random.Range (-this.Size.x / 3, this.Size.x / 3);
			float ranY = Random.Range (-this.Size.y / 3, this.Size.y / 3);
			listEffect.Add (new Effect (6, this.Position + new Vector3 (ranX, ranY, -0.1f),Vector3.one, false));
			timeEffect = (int)(Time.timeSinceLevelLoad * 1000) + Random.Range (10, 30);
			numberEffect--;
		}

		foreach (Effect eff in listEffect)
			if (eff != null)
				eff.Update();
		if (listEffect.Count > 0)
		for (int i = listEffect.Count - 1; i >= 0; i--)
			if (!((Effect)listEffect [i]).isLive)
				listEffect.RemoveAt (i);

		if (index == listSprite.Length - 1)
			this.Destroy ();
	}


	public void Destroy()
	{
		//Debug.Log ("del sparkle " + Name);
		if (sparkle != null)
			GameObject.Destroy (sparkle);
		isDie = true;
		for (int i = listEffect.Count - 1; i >= 0; i--)
			if (((Effect)listEffect [i]).isLive) {
				((Effect)listEffect [i]).Destroy ();
				listEffect.RemoveAt (i);
			}
	}
}