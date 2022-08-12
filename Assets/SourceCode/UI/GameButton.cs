using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton {

	public static int TYPE_CLICK_SCALE = 1;
    public static int TYPE_LIGHT = 4;

    public GameObject Object;
	private Vector3 position;
	private Vector3 normalScale;
	private Vector3 clickScale;
	private Sprite sprite;
	private Sprite spriteClick;
	private Sprite spriteLock;
	private string spritePath;
	private Vector3 spriteSize;
	private int type;
	public bool _lock = false;
	private Event buttonTapEvent;
	private Event buttonHoldEvent;
	private Event buttonDisableEvent;
	int buttonHoldTime;
	bool beginTap = false;
	int eventValue;
	bool enable = true;

	public static AudioSource auClick;
	public static GameObject auObj;


	public GameButton(string name, string spritePath, Vector3 pos, Vector3 scale, int type = 1)
	{
		Object = new GameObject (name);
		SpriteRenderer spriteRen = Object.AddComponent<SpriteRenderer> ();
		if (type == 1)
			sprite = spriteRen.sprite = Resources.Load<Sprite> (spritePath);
		if (type == 2) {
			sprite = spriteRen.sprite = Resources.Load<Sprite> (spritePath + "_normal");
			this.spriteClick = Resources.Load<Sprite> (spritePath + "_click");
			this.spriteLock = Resources.Load<Sprite> (spritePath + "_lock");

		}
		if (type == 10) {
			Sprite[] sprites = Resources.LoadAll<Sprite> (spritePath);
			sprite = spriteRen.sprite = sprites [0];
			spriteClick = sprites [1];
			type = 2;
		}
		Init (pos, scale, type);
		
			auClick = Object.AddComponent<AudioSource> ();
			auClick.loop = false;
			auClick.volume = 3f;
			auClick.clip = (AudioClip)Resources.Load ("Sound/CapClick");
         
	}
	public GameButton(string name, Sprite sprite, Sprite spriteClik, Vector3 pos, Vector3 scale, int type = 2)
	{
		Object = new GameObject (name);
		SpriteRenderer spriteRen =  Object.AddComponent<SpriteRenderer> ();
		spriteRen.sprite = this.sprite = sprite;
		this.spriteClick = spriteClik;

		Init (pos, scale, type);

        auClick = Object.AddComponent<AudioSource>();
        auClick.loop = false;
        auClick.volume = 3f;
        auClick.clip = (AudioClip)Resources.Load("Sound/CapClick");
    }
	void Init(Vector3 pos, Vector3 scale, int type)
	{
		Object.transform.position = pos;
		Object.transform.localScale = scale;

		this.position = pos;
		this.normalScale = scale;
		this.spriteSize = this.sprite.bounds.size;
		this.clickScale = this.normalScale * 0.2f; //new Vector3 (0.2f, 0.2f, 0.2f);
		this.spritePath = spritePath;
		this.type = type;
	}

    public Transform Parent
    {
        get { return Object.transform.parent; }
        set { Object.transform.parent = value; }
    }
    public bool Lock
	{
		get { return _lock; }
		set {
			this._lock = value;
			if (this._lock)
				// && type == 2)
				Object.GetComponent<SpriteRenderer> ().sprite = this.spriteLock;
			else
				Object.GetComponent<SpriteRenderer> ().sprite = this.sprite;
			
		}
	}
	public void setLockSprite(Sprite lockSprite)
	{
		this.spriteLock = lockSprite;
	}
	public Vector3 Position
	{
		get { return Object.transform.position; }
		set {
			this.position = value;
			this.Object.transform.position = value;
		}
	}
	public Vector3 Size
	{
		get { return Object.GetComponent<SpriteRenderer> ().bounds.size; }

	}

	public Vector3 Scale
	{
		get { return this.normalScale; }
		set
		{
			this.normalScale = value;
			this.clickScale = this.normalScale + new Vector3 (0.2f, 0.2f, 0.2f);
			this.Object.transform.localScale = this.normalScale;
		}
	}

    public void ChangeSprite(Sprite spr)
    {
        this.sprite = spr;
        Object.GetComponent<SpriteRenderer>().sprite = spr;
    }

    public Sprite Sprite
	{
		get { return this.sprite; }
		set {
			this.sprite = value;
		}
	}
	public Sprite SpriteClick
	{
		get { return this.spriteClick; }
		set {
			this.spriteClick = value;
		}
	}
	public Event ButtonTapEvent {
		get { return this.buttonTapEvent; }
		set{ this.buttonTapEvent = value; }
	}
	public Event ButtonHoldEvent {
		set { this.buttonHoldEvent = value; }
	}
	public Event ButtonDisableEvent {
		set { this.buttonDisableEvent = value; }
	}
	public int EventValue {
		get { return eventValue; }
		set { eventValue = value; }
	}

	public void changeGreenColor()
	{
		Color c = Object.GetComponent<SpriteRenderer> ().color;
		c.b = 72 / 255;
		Object.GetComponent<SpriteRenderer> ().color = c;
	}
	public void Shadow()
	{
		Color c = Object.GetComponent<SpriteRenderer> ().color;
		c.b = 75 / 255f;
		c.g = 75 / 255f;
		c.r = 75 / 255f;
		Object.GetComponent<SpriteRenderer> ().color = c;
	}
	public void Bright()
	{
		Color c = Object.GetComponent<SpriteRenderer> ().color;
		c.b = 255 / 255f;
		c.g = 255 / 255f;
		c.r = 255 / 255f;
		Object.GetComponent<SpriteRenderer> ().color = c;
	}
	public void setSprite(Sprite normalSprite, Sprite clickSprite)
	{
		Object.GetComponent<SpriteRenderer> ().sprite = Sprite = normalSprite;
		SpriteClick = clickSprite;
	}
    public void swapSprite()
    {
        Object.GetComponent<SpriteRenderer>().sprite = this.spriteClick;
        SpriteClick = sprite;
        sprite = Object.GetComponent<SpriteRenderer>().sprite;

    }
    public void Disable()
	{
		//this.Object.transform.localScale = new Vector3 (0, 0, 0);
		enable = false;
	}
	public void Enable()
	{
		this.Object.transform.localScale = this.normalScale;
		enable = true;
	}
    public float Alpha
    {
        set
        {
            Color c = Object.GetComponent<SpriteRenderer>().color;
            c.a = value;
            Object.GetComponent<SpriteRenderer>().color = c;
        }
        get { return Object.GetComponent<SpriteRenderer>().color.a; }
    }
    public Color Color
    {
        set
        {
            Color c = Object.GetComponent<SpriteRenderer>().color;
            Object.GetComponent<SpriteRenderer>().color = value;
        }
        get
        {
            return Object.GetComponent<SpriteRenderer>().color;
        }
    }
    public void ColorToWhite(int step)
    {
        Color c = Object.GetComponent<SpriteRenderer>().color;
        if (c.r < 255)
            c.r = c.r + step > 255 ? 255 : c.r + step;
        if (c.g < 255)
            c.g = c.g + step > 255 ? 255 : c.g + step;
        if (c.b < 255)
            c.b = c.b + step > 255 ? 255 : c.b + step;
        Object.GetComponent<SpriteRenderer>().color = c;

    }


    public void Update()
	{
		int tapCount = 0;
		if (Input.touches.Length == 0 && this.buttonHoldEvent != null)
			this.buttonHoldEvent.isHanddle = false;
		if (!enable)
			return;

		#if UNITY_EDITOR
		Vector2 posToWorldPoint = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		if (Input.GetMouseButtonDown(0) && Pos.Contains (this.Position, Object.GetComponent<SpriteRenderer> ().bounds.size, posToWorldPoint)) {

			if (type == 1)
				Object.transform.localScale = normalScale;
			if (type == 2 && !this.Lock)
				Object.GetComponent<SpriteRenderer> ().sprite = this.spriteClick;
            buttonHoldTime = (int)(Time.time * 1000);
            if (type == TYPE_LIGHT)
            {
                Bright();
            }

            if (this.buttonTapEvent != null && !this.Lock) {
				this.buttonTapEvent.isHanddle = true;
				this.buttonTapEvent.type = this.EventValue;
			}

			if (this.buttonHoldEvent != null)
				this.buttonHoldEvent.isHanddle = false;
			if (this.buttonDisableEvent != null)
				this.buttonDisableEvent.isHanddle = false;
            if (auClick != null)
                auClick.Play();
		}
        if ((int)(Time.time * 1000) - buttonHoldTime > 500)
            Object.GetComponent<SpriteRenderer>().sprite = sprite;

        #endif

        while (tapCount < Input.touches.Length) {
			Touch touch = Input.GetTouch (tapCount);
			tapCount++;

			Vector2 positionToWorldPoint = new Vector2 (Camera.main.ScreenToWorldPoint (touch.position).x, Camera.main.ScreenToWorldPoint (touch.position).y);


			if (Pos.Contains (this.Position, Object.GetComponent<SpriteRenderer> ().bounds.size, positionToWorldPoint)) {
				if (touch.phase == TouchPhase.Began) {
					if (type == 1)
						Object.transform.localScale = clickScale;
					if (type == 2 && !this.Lock)
						Object.GetComponent<SpriteRenderer> ().sprite = this.spriteClick;
			

					if (this.buttonDisableEvent != null)
						this.buttonDisableEvent.isHanddle = false;
					this.buttonHoldTime = (int)(Time.time * 1000);
					if (this.buttonHoldEvent != null)
						this.buttonHoldEvent.isHanddle = false;
					//if (this.buttonTapEvent != null)
					//	this.buttonTapEvent.isHanddle = true;



				} else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled
                    || (Object.GetComponent<SpriteRenderer>().sprite == spriteClick && (int)(Time.time * 1000) - buttonHoldTime > 500)) {

					if (type == 1)
						Object.transform.localScale = normalScale;
					if (type == 2 && !this.Lock)
						Object.GetComponent<SpriteRenderer> ().sprite = this.sprite;
                    if (type == TYPE_LIGHT)
                    {
                        Bright();
                    }

					if (this.buttonTapEvent != null && !this.Lock) {
						this.buttonTapEvent.isHanddle = true;
						this.buttonTapEvent.type = this.EventValue;
					}
					
					if (this.buttonHoldEvent != null)
						this.buttonHoldEvent.isHanddle = false;
					if (this.buttonDisableEvent != null)
						this.buttonDisableEvent.isHanddle = false;
					auClick.Play ();
					//this.buttonHoldTime = 0;
					//if (GM.debugText)
					//	GM.debugText.text = Event.STAGE_JUMP_BUTTON_TAP_EVENT.isHanddle + " end";

				} else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
					if (this.buttonHoldEvent != null && !this.Lock) {
						this.buttonHoldEvent.type = this.EventValue;
						//if (!this.buttonDisableEvent.isHanddle)
						this.buttonHoldEvent.isHanddle = true;
					}
				} else {
					if (this.buttonHoldEvent != null)
						this.buttonHoldEvent.isHanddle = false;
				}


			} else {
				if (type == 1)
					Object.transform.localScale = normalScale;
				if (type == 2 && !this.Lock)
					Object.GetComponent<SpriteRenderer> ().sprite = this.sprite;
				if (this.buttonHoldEvent != null)
					this.buttonHoldEvent.isHanddle = false;
			}
		}

		if (Object.transform.localScale.x != normalScale.x)
			Object.transform.localScale = normalScale;
	}


	public void ClickOn()
	{
		
	}

	public void Destroy()
	{
		GameObject.Destroy (this.Object);
		this.Object = null;
		sprite = null;
		buttonTapEvent = null;
		buttonHoldEvent = null;
		buttonDisableEvent = null;
	}

}
