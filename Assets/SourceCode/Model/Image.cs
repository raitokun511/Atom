using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image {

	protected GameObject image;
	protected Sprite normalSprite;
	protected Sprite nextSprite;
	bool enable = true;
	protected Vector3 rootScale;

	public int state = 1;

	public Image()
	{
	}
	public Image (string spritePath, Vector3 pos, Vector3 scale) {

		image = new GameObject ("image_" + spritePath);
		normalSprite =  Resources.Load<Sprite> (spritePath);
		image.AddComponent<SpriteRenderer> ().sprite = normalSprite;
		image.transform.position = pos;
		image.transform.localScale = scale;
		this.rootScale = scale;
	}
	public Image (Sprite sprite, Vector3 pos, Vector3 scale) {

		image = new GameObject ("image");
		image.AddComponent<SpriteRenderer> ().sprite = sprite;
		image.transform.position = pos;
		image.transform.localScale = scale;
		this.rootScale = scale;
	}
    public Image(Sprite sprite, Vector3 pos, Vector3 scale, Color color)
    {
        image = new GameObject("image");
        image.AddComponent<SpriteRenderer>().sprite = sprite;
        image.transform.position = pos;
        image.transform.localScale = scale;
        this.rootScale = scale;
        Color c = image.GetComponent<SpriteRenderer>().color;
        image.GetComponent<SpriteRenderer>().color = color;
    }

    public Image (Sprite normal,Sprite next, Vector3 pos, Vector3 scale):		this (normal, pos, scale){
		nextSprite = next;
	}
	public Image (string spritePath,string nextSpritePath, Vector3 pos, Vector3 scale):		this (spritePath, pos, scale){
		nextSprite = Resources.Load<Sprite> (nextSpritePath);

	}

    public Transform Parent
    {
        get { return image.transform.parent; }
        set { image.transform.parent = value; }
    }

	public float Scale {
		get { return image.transform.localScale.x; }
		set{
			image.transform.localScale = new Vector3 (value, value, 1);
		
		}
	}
	public Vector3 ExtraScale {
		get { return image.transform.localScale; }
		set{
			image.transform.localScale = value;

		}
	}
	public Vector3 Position
	{
		get { return image.transform.position; }
		set {
			this.image.transform.position = value;
		}
	}
	public Vector3 Rotation
	{
		get { return image.transform.localRotation.eulerAngles; }
		set {
			this.image.transform.localRotation = Quaternion.Euler (value);
		}
	}
	public Vector3 Size
	{
		get { return image.GetComponent<SpriteRenderer> ().bounds.size; }

	}
	public void Disable()
	{
		this.image.transform.localScale = new Vector3 (0, 0, 0);
		enable = false;
	}
	public void Enable()
	{
		this.image.transform.localScale = this.rootScale;
		enable = true;
	}
    public bool Active
    {
        set { this.image.SetActive(value); }
    }
    public void changeSprite(Sprite sprite)
	{
		this.image.GetComponent<SpriteRenderer> ().sprite = sprite;
	}
	public void blur(float alpha)
	{
		Color c = image.GetComponent<SpriteRenderer> ().color;
		c.a = alpha;
		image.GetComponent<SpriteRenderer> ().color = c;
	}
    public float Alpha
    {
        set
        {
            Color c = image.GetComponent<SpriteRenderer>().color;
            c.a = value;
            image.GetComponent<SpriteRenderer>().color = c;
        }
        get { return image.GetComponent<SpriteRenderer>().color.a; }
    }
    public Color Color
    {
        set
        {
            Color c = image.GetComponent<SpriteRenderer>().color;
            image.GetComponent<SpriteRenderer>().color = value;
        }
        get
        {
            return image.GetComponent<SpriteRenderer>().color;
        }
    }
    public void ColorToWhite(int step)
    {
        Color c = image.GetComponent<SpriteRenderer>().color;
        if (c.r < 255)
            c.r = c.r + step > 255 ? 255 : c.r + step;
        if (c.g < 255)
            c.g = c.g + step > 255 ? 255 : c.g + step;
        if (c.b < 255)
            c.b = c.b + step > 255 ? 255 : c.b + step;
        image.GetComponent<SpriteRenderer>().color = c;

    }
    public void AddAudio(string path)
    {
        AudioSource audioBackground = image.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load(path);
    }
    public void PlaySound()
    {
        image.GetComponent<AudioSource>().Play();
    }
    public bool isDie
    {
        get { return image == null; }
    }

    // Update is called once per frame
    public virtual void Update () {
		
	}

	public int BagState {
		get { return state; }
		set {
			state = value;
			if (state == 2)
				this.image.GetComponent<SpriteRenderer> ().sprite = nextSprite;//Resources.LoadAll<Sprite> ("holderBag") [1];
			else if (state == 1)
				this.image.GetComponent<SpriteRenderer> ().sprite = normalSprite;
		}
	}
	public int BGState {
		get { return state; }
		set {
			state = value;
			if (state == 1)
				this.image.GetComponent<SpriteRenderer> ().sprite = normalSprite;
			else
				this.image.GetComponent<SpriteRenderer> ().sprite = nextSprite;
		}
	}

	public void ChangeRootScale(Vector3 scale)
	{
		this.Scale = scale.x;
		this.rootScale = scale;
	}

	public void Destroy()
	{
        if (image!= null)
		GameObject.Destroy(image);
        image = null;
	}
}
