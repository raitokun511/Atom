using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon {

	GameObject effect;
	public int Type;
	Vector3 position;
	Sprite[] listSprite;
	public int effectTime;
	int iStart;
	int iEnd;
    int endAtFrame = - 1;
    public int timeIndex = -1;
	int timeBeDestroy = -1;
	int timeBeginDestroy = -1;
	bool isDestroy = false;
	bool isLoop;
	public int effectRender = 70;

	public Icon (string path, int indexStart, int indexEnd, Vector3 pos, bool isloop = true) {

		this.position = pos - new Vector3 (0, 0, 0.1f);
		effect = new GameObject ("icon");
		listSprite = Resources.LoadAll<Sprite> (path);
		effect.AddComponent<SpriteRenderer> ().sprite = listSprite [indexStart];

		effect.transform.localScale = new Vector3 (GM.unit * 3, GM.unit * 3, 1);
		effect.transform.position = this.position;
		iStart = indexStart;
		iEnd = indexEnd;

		effectTime = (int)(Time.time * 1000);
		isDestroy = false;
		this.isLoop = isloop;
		//Debug.Log ("Egg Info " + iStart +" . " + iEnd);
	}
	public Vector3 Scale 
	{
		set {
			effect.transform.localScale = value;
		}
	}
	public int numberSprite {
		get {
            return listSprite.Length;
        }
	}

	public void ChangeSprite(string path, int indexStart, int indexEnd, int endAt = -1)
	{
		if (path != null && path.Length > 0)
			listSprite = Resources.LoadAll<Sprite>(path);
        
		effect.GetComponent<SpriteRenderer> ().sprite = listSprite [iEnd > iStart ? indexStart : iEnd];
		iStart = indexStart;
		iEnd = indexEnd;
        endAtFrame = endAt;

    }
    public int Rotation
	{
		set {
			effect.transform.localRotation = Quaternion.Euler(new Vector3(0, value < 0 ? 0 : 180, 0));
		}
	}

    public Color Color
    {
        set
        {
            effect.GetComponent<SpriteRenderer>().color = value;
        }
    }

	public int Index
	{
		get {  return iStart + (((int)(Time.time * 1000) - effectTime) / effectRender) % (iEnd - iStart + 1); }
	}
    public void Reset()
    {
        effectTime = (int)(Time.time * 1000);
    }

    public void Update () {
		if (isDestroy)
			return;
        //Debug.Log ("start " + iStart + "  end " + iEnd);
        if (effectTime >= 0)
        {
            if (iStart <= iEnd)
                timeIndex = iStart + (((int)(Time.time * 1000) - effectTime) / effectRender) % (iEnd - iStart + 1);
            else
            {
                timeIndex = iStart - (((int)(Time.time * 1000) - effectTime) / effectRender) % (iStart - iEnd + 1);
                Debug.Log("index " + timeIndex);
            }
        }

        if (endAtFrame >= 0 && ((timeIndex == iEnd - 1 && iEnd >= iStart) || (timeIndex == iEnd && iEnd < iStart)))
        {
            effect.GetComponent<SpriteRenderer>().sprite = listSprite[endAtFrame];
            effectTime = -1;
        }
        else
            effect.GetComponent<SpriteRenderer>().sprite = listSprite[timeIndex];				
        
        
        if (!isLoop && timeIndex == iEnd - 1 && endAtFrame < 0)
			this.Destroy ();


		if (timeBeginDestroy > 0 && (int)(Time.time * 1000) - timeBeginDestroy > timeBeDestroy)
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
		get { return !isDestroy; }
	}

}
