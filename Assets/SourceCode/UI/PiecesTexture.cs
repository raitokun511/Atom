using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesTexture
{
    GameObject text;
    Texture2D texture;
    Vector2 pivot;
    Event buttonTapEvent;
    int eventValue;
    bool enable = true;
    Vector3 margintouch = Vector3.zero;
    Vector3 size;

    public PiecesTexture(Texture2D textureSprite, Vector3 pos, Vector3 scale, Rect insize, Vector2 p)
    {
        text = new GameObject("BGValue");
        texture = textureSprite;//Resources.Load(listTypeBarValue[type]) as Texture2D;
        text.AddComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), p);
        text.transform.localScale = scale;
        size = text.GetComponent<SpriteRenderer>().bounds.size;
        text.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(insize.x, insize.y, insize.width, insize.height), p);
        text.transform.position = pos;
        pivot = p;

    }
    public int EventValue
    {
        get { return eventValue; }
        set { eventValue = value; }
    }
    public Event ButtonTapEvent
    {
        get { return this.buttonTapEvent; }
        set { this.buttonTapEvent = value; }
    }
    public bool Enable
    {
        set { enable = value; }
        get { return enable; }
    }
    public void ReRect(Rect newrect)
    {
        text.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, newrect, pivot);
    }
    public Rect Rect
    {
        get { return text.GetComponent<SpriteRenderer>().sprite.rect; }
    }
    public Vector3 Position
    {
        get { return text.transform.position; }
        set { text.transform.position = value; }
    }
    public float Alpha
    {
        set
        {
            Color c = text.GetComponent<SpriteRenderer>().color;
            c.a = value;
            text.GetComponent<SpriteRenderer>().color = c;
        }
        get
        {
            return text.GetComponent<SpriteRenderer>().color.a;
        }
    }
    public Color Color
    {
        set
        {
            Color c = text.GetComponent<SpriteRenderer>().color = value;
        }
        get
        {
            return text.GetComponent<SpriteRenderer>().color;
        }
    }
    public Vector3 Margin
    {
        set { margintouch = value; }
        get { return margintouch; }
    }
    public Vector3 Size
    {
        get { return size; }
    }

    public void Update()
    {
        int tapCount = 0;
        if (!enable)
            return;

#if UNITY_EDITOR
        Vector2 posToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        if (Input.GetMouseButtonDown(0) && Pos.Contains(text.transform.position + margintouch, text.GetComponent<SpriteRenderer>().bounds.size, posToWorldPoint))
        {
            //Vector3 pos = new Vector3(posToWorldPoint.x, posToWorldPoint.y, -6);
            //Image newo = new Image("game_items/Atoms", pos, Vector3.one * 0.3f);
            //Debug.Log("Margin " + margintouch);
            text.GetComponent<SpriteRenderer>().color = Color.yellow;
            //buttonHoldTime = (int)(Time.time * 1000);

            if (this.buttonTapEvent != null)
            {
                this.buttonTapEvent.isHanddle = true;
                this.buttonTapEvent.type = this.EventValue;
            }

            //if (auClick != null)
            //    auClick.Play();
        }
        
#endif

        while (tapCount < Input.touches.Length)
        {
            Touch touch = Input.GetTouch(tapCount);
            tapCount++;

            Vector2 positionToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);


            if (Pos.Contains(text.transform.position + margintouch, text.GetComponent<SpriteRenderer>().bounds.size, positionToWorldPoint))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    //if (type == 1)
                    //    Object.transform.localScale = clickScale;
                    //if (type == 2 && !this.Lock)
                    //    Object.GetComponent<SpriteRenderer>().sprite = this.spriteClick;

                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                  //|| (text.GetComponent<SpriteRenderer>().sprite == spriteClick && (int)(Time.time * 1000) - buttonHoldTime > 500))
                {
                    //if (type == 1)
                    ///    Object.transform.localScale = normalScale;
                    //if (type == 2 && !this.Lock)
                    //    Object.GetComponent<SpriteRenderer>().sprite = this.sprite;
                    text.GetComponent<SpriteRenderer>().color = Color.yellow;

                    if (this.buttonTapEvent != null)
                    {
                        this.buttonTapEvent.isHanddle = true;
                        this.buttonTapEvent.type = this.EventValue;
                    }
                    //if (auClick != null)
                    //auClick.Play();
                    

                }
                else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                }
                else
                {
                 
                }


            }
            else
            {
                //if (type == 1)
                //    Object.transform.localScale = normalScale;
                //if (type == 2 && !this.Lock)
                //    Object.GetComponent<SpriteRenderer>().sprite = this.sprite;
                
            }
        }

    }

    public void Destroy()
    {
        GameObject.Destroy(text);

    }



}
