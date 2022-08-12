using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin {

	protected GameObject image;
	public static Sprite[] listSprite;
	int effectTime;
	bool die = false;
	public int timePerform = 0;
	public Vector3 targetMove;
	public bool isMove = false;
	bool destroyToTarget = false;
	public AudioSource auBG;
	public GameObject auBGObj;
	int Type;

	public Coin (string spritePath, Vector3 pos, Vector3 scale, int type = 1) {

		image = new GameObject ("image");
		if (listSprite == null || listSprite.Length <= 0)
			listSprite =  Resources.LoadAll<Sprite> (spritePath);
		image.AddComponent<SpriteRenderer> ().sprite = listSprite[0];
		image.transform.position = pos;
		image.transform.localScale = scale;
		effectTime = (int)(Time.timeSinceLevelLoad * 1000);

		auBGObj = new GameObject ("coinSound");
		auBG = auBGObj.AddComponent<AudioSource> ();
		auBG.loop = false;
		auBG.volume = 0.7f;
		auBG.clip = (AudioClip)Resources.Load("Sound/clearcoins");
		//timeSound = (int)(Time.timeSinceLevelLoad * 1000);
		this.Type = type;
		if (type >= 2) {
			timePerform = (int)(Time.timeSinceLevelLoad * 1000);
		}
	}

	public Vector3 Scale 
	{
		get { return image.transform.localScale; }
		set {
			image.transform.localScale = value;
		}
	}
	public Vector3 Position
	{
		get { return this.image.transform.position; }
		set {
			image.transform.position = value;
		}
	}
	public Vector3 Size
	{
		get { return image.GetComponent<SpriteRenderer> ().bounds.size; }

	}
	public bool isDie
	{
		get { return die; }
		set{ die = value; }
	}
	Vector3 moveVec;
	public void MoveAndDestroy(Vector3 targetVec,int step)
	{
		targetMove = targetVec;
		destroyToTarget = true;
		this.moveVec = (targetMove - this.Position) / step;
		Debug.Log ("moveVec " + moveVec.x + "  " + moveVec.y);
	}

	public void Update () {

		if (isDie)
			return;

		if (isMove) {
			Vector3 tmpvec = (targetMove - this.Position);
			float len = Mathf.Sqrt (tmpvec.x * tmpvec.x + tmpvec.y * tmpvec.y);
			//Debug.Log("Move " + len +" " + (GM.unit/30) + " " + this.Position.x + " " + this.Position.y + " " +targetMove.x +" " + targetMove.y);
			if (len > GM.unit / 3)
				this.Position += moveVec;
			else if (destroyToTarget)
				this.Destroy ();
				
		}
		if (Type >= 2) {
			if (!isMove) {
				int tapCount = 0;
				while (tapCount < Input.touches.Length) {
					Touch touch = Input.GetTouch (tapCount);
					tapCount++;
					Vector2 positionToWorldPoint = new Vector2 (Camera.main.ScreenToWorldPoint (touch.position).x, Camera.main.ScreenToWorldPoint (touch.position).y);
					if (touch.phase == TouchPhase.Began && Pos.Contains (this.Position, this.Size, positionToWorldPoint)) {
						isMove = true;
						this.auBG.Play ();
						this.MoveAndDestroy (new Vector3 (GM.unit * 2.5f, GM.height / 2 - GM.unit * 1.1f, 0), 50);
					}
					
				}
			}
			if ((int)(Time.timeSinceLevelLoad * 1000) - timePerform > 2500) {
				Color c = image.GetComponent<SpriteRenderer> ().color;
				c.a -= c.a > 0.02f ?  0.02f : 0 ;
				image.GetComponent<SpriteRenderer> ().color = c;
			}
			if ((int)(Time.timeSinceLevelLoad * 1000) - timePerform > 3500) {
				this.Destroy ();
			}

		}
		if (isDie)
			return;
		int timeIndex = (((int)(Time.timeSinceLevelLoad * 1000) - effectTime) / 20) % listSprite.Length;
		image.GetComponent<SpriteRenderer> ().sprite = listSprite [timeIndex];

	}
	public void Destroy()
	{
		//if type == 1
		GameObject.Destroy(image);
		image = null;
		isDie = true;
		
	}


}
