using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	protected GameObject item;
	public int Type;
	protected Vector3 position;
	protected Vector3 scale;
	//protected Sprite[] itemSprite;

	public Item(string name,int type, Vector3 pos, float itemscale)
	{
		this.scale = new Vector3(itemscale, itemscale, 1);
		this.position = pos;
		this.Type = type;
		Sprite[] itemSprite = Resources.LoadAll<Sprite> ("Item/");// + ResourcePath.listItemPath [type]);
		item = new GameObject (name);
		item.AddComponent<SpriteRenderer> ().sprite = itemSprite [0];
		item.transform.position = pos;
		item.transform.localScale = this.scale;
	}
    public Item(string name, Vector3 pos, float itemscale)
    {
        item = new GameObject(name);
        item.transform.position = pos;
        item.transform.localScale = this.scale;
    }
    public bool isDie
    {
        get { return item == null; }
        
    }

    public Vector3 Position
	{
		get { return item.transform.position; }
		set {
			this.position = value;
			item.transform.position = this.position;
		}
	}
	public Vector3 ItemSize
	{
		get { return item.GetComponent<SpriteRenderer> ().bounds.size; }

	}
	

	public virtual void Update () {

	}

	public void ChangeItemType(int type)
	{
		if (this.Type != type) {
			this.Type = type;
			Sprite[] itemSprite = Resources.LoadAll<Sprite> ("Item/");// + ResourcePath.listItemPath [type]);
			item.GetComponent<SpriteRenderer> ().sprite = itemSprite [0];
		}

	}

}
