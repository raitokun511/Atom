using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect {

    protected GameObject effect;
	public int Type;

    protected Vector3 position;
    protected Sprite[] listSprite;
    protected static Sprite[] listFloat;
    protected int effectTime;
	public int timeIndex = -1;
    protected int timeBeDestroy = -1;
    protected int timeBeginDestroy = -1;
    protected bool isDestroy = false;
    protected bool isLoop;
    public int effectRender = 20;
	protected int index;

    public Effect()
    {

    }

    public Effect (int type, Vector3 pos, Vector3 scale, bool isloop = true) {

		this.Type = type;
        effectRender = 60;
        this.position = pos;
		effect = new GameObject ("effect" + type);
        if (listFloat == null || listFloat.Length <= 0)
            listFloat = Resources.LoadAll<Sprite>("UI/floatyfont");
        if (type >= 100)
        {
            if (type / 1000 == 10)
                effect.AddComponent<SpriteRenderer>().sprite = listFloat[0];
            else
                effect.AddComponent<SpriteRenderer>().sprite = listFloat[(type / 1000) % 10 + 1];
        }
		effect.transform.localScale = scale;
		effect.transform.position = this.position;
		if (type % 1000 >= 100) {
            SetColor(type % 1000);	
		}
		effectTime = (int)(Time.time * 1000);
		isDestroy = false;
		this.isLoop = isloop;
	}

	public Effect (string path, Vector3 pos, Vector3 scale, bool isloop = true) {

		Init (path, pos, scale, isloop);
		index = listSprite.Length;
	}
	public Effect (string path, Vector3 pos, int indexStart, int indexEnd, int render, bool isloop = true, int scaleType = 2) {

		Type = scaleType;//for Big Missile = 7, SmallMisslie = 2
		Init (path, pos,Vector3.one, isloop);
		index = indexStart * 1000 + indexEnd;
		effectRender = render;

    }


    public void Init(string path, Vector3 pos, Vector3 scale, bool isloop = true)
	{
		this.position = pos - new Vector3 (0, 0, 0.1f);
		effect = new GameObject ("effect" + path);
		listSprite = Resources.LoadAll<Sprite> (path);
		effect.AddComponent<SpriteRenderer> ().sprite = listSprite [0];
		effect.transform.localScale = scale;
		effect.transform.position = this.position;

		effectTime = (int)(Time.time * 1000);
		isDestroy = false;
		this.isLoop = isloop;
	}

	public string AudioPath
	{
		set {
			AudioSource au = effect.GetComponent<AudioSource> () != null ? effect.GetComponent<AudioSource> () : effect.AddComponent<AudioSource> ();
			au.clip = (AudioClip)Resources.Load (value);
			effect.GetComponent<AudioSource> ().Play ();
		}
	}
	public Vector3 Scale 
	{
		set {
			effect.transform.localScale = value;
		}
	}
	public int numberSprite {
		get { return listSprite.Length; }
	}

	public string Name
	{
		get { return effect.name; }
	}
    public void SetColor(int type)
    {
        Color color = effect.GetComponent<SpriteRenderer>().color;
        if (type == 100)
            color = Color.red;
        if (type == 101)
            color = Color.green;
        if (type == 102)
            color = Color.yellow;
        if (type == 103)
            color = Color.blue;
        if (type == 104)
            color = new Color(128f / 255f, 0, 128f / 255f);
        if (type == 105)
            color = new Color(1, 165f / 255f, 0);
        if (type == 106)
            color = new Color(251f / 255f, 226f / 255f, 227f / 255f);
        if (type == 107)
            color = new Color(207f / 255f, 206f / 255f, 156f / 255f);
        if (type == 108)
            color = Color.black;
        if (type == 109)
            color = new Color(170f / 255f, 152f / 255f, 229f / 255f);
        if (type == 110)
            color = new Color(135f / 255f, 212f / 255f, 190f / 255f);
        if (type == 111)
            color = new Color(170f / 255f, 152f / 255f, 229f / 255f);
        if (type == 120)
            color = Color.white;

        if (type % 100 == 12)
            color = new Color(255f / 255f, 165f / 255f, 38f / 255f);
        if (type % 100 == 13)
            color = new Color(37f / 255f, 139f / 255f, 255f / 255f);
        if (type % 100 == 14)
            color = new Color(170f / 255f, 105f / 255f, 255f / 255f);
        if (type % 100 == 15)
            color = new Color(122f / 255f, 110f / 255f, 137f / 255f);
        if (type % 100 == 16)
            color = new Color(115f / 255f, 219f / 255f, 184f / 255f);
        if (type == 120)
            color = Color.white;
        effect.GetComponent<SpriteRenderer>().color = color;
    }

	public virtual void Update () {
		
		
		if (Type >= 100) {
            Color color = effect.GetComponent<SpriteRenderer>().color;
            color.a -= 0.01f;
            effect.GetComponent<SpriteRenderer>().color = color;
            this.effect.transform.position += new Vector3(0, GM.BoardSize.x / 200f, 0);
            //if (effect.GetComponent<SpriteRenderer>().color.a <= 0)
            //    Destroy();
        }
		else{
			timeIndex = index / 1000 + (((int)(Time.time * 1000) - effectTime) / effectRender) % (index % 1000);//% listSprite.Length;
			effect.GetComponent<SpriteRenderer> ().sprite = listSprite[timeIndex];				
			if (!isLoop && timeIndex == (index % 1000) - 1)
				this.Destroy ();

		}
		if ( timeBeginDestroy > 0 && (int)(Time.time * 1000) - timeBeginDestroy > timeBeDestroy)
			this.Destroy ();

	}

	public Vector3 Position
	{
		get { return this.position; }
		set{
			this.position = value;
			effect.transform.position = value;
		}
	}
	public Vector3 Size
	{
		get { return effect.GetComponent<SpriteRenderer> ().bounds.size; }

	}

	public void Destroy()
	{
		listSprite = null;
		GameObject.Destroy (effect);
		isDestroy = true;
        
	}

	public void DestroyAfter(int time)
	{
		timeBeginDestroy = (int)(Time.time * 1000);
		timeBeDestroy = time;
	}
	public bool isLive
	{
		get { return effect != null; }
	}

}
