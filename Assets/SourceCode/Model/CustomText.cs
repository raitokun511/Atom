using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomText {

	public static int  CENTER = 0;
	public static int LEFT = -1;
	public static int RIGHT = 1;
	public static Sprite[] Alphabe;
    public string value;

	public Sprite[] listSprite;

	public GameObject[] listGameObject;
	public float scale;
	public float Zposition;
	public int Align;
	public int numberLine = 0;
	public Vector3 Position;

	private float previousSizeChar;
	private Vector3 previousPostion;

	public Vector3 spriteTextSize;
	int type;
	Color color = new Color (1, 1, 1);

    //4  = character
	public CustomText (string text, float scaleValue = 1f, float Zpos = -1f, int align = 0, bool isUpper = false, int type = 1) {
	
		if (Alphabe == null) {
			Alphabe = Resources.LoadAll<Sprite> ("UI/number");
			//AlphabeRed = Resources.LoadAll<Sprite> ("UI/number2");
            //Alphabe3 = Resources.LoadAll<Sprite>("UI/number3");
            //Alpha = Resources.LoadAll<Sprite>("UI/font1");
        }
        //Debug.Log ("Num Alpha" + Alphabe.Length);
        this.type = type;
		if (isUpper)
			this.value = text.ToUpper ();
		else
			this.value = text;
        if (this.type == 1)
            this.listSprite = Alphabe;
       

		this.scale = scaleValue;
		this.Zposition = Zpos;
		this.Align = align;
		this.Update (text);
		this.spriteTextSize = listSprite [1].bounds.size * scale;

	}

	public Color setColor
	{
		set { color = value;}
	}

	public bool isDisable()
	{
		if (value == null || value.Length == 0)
			return true;
		return false;
	}
		
	public void Update (string text) {

		if (listGameObject != null)
			for (int i = 0; i < listGameObject.Length; i++)
				GameObject.Destroy (listGameObject [i]);
		
		this.value = text;
		if (this.value.Length == 0)
			return;

		char[] stringArray = value.ToCharArray ();
		float allSizeText = 0;
		float firstTextSize = 0;



		for (int i = 0; i < value.Length; i++) {
			int asciiChar = (int)stringArray [i];

			if (asciiChar > 47 && asciiChar < 58)
				asciiChar -= 48;
			else
				asciiChar = 11;

			if (i == 0)
				firstTextSize = this.listSprite [asciiChar].bounds.size.x;

			allSizeText += this.listSprite [asciiChar].bounds.size.x;
		}

		previousSizeChar = 0;
		previousPostion = new Vector3 (Camera.main.transform.position.x - allSizeText / 2.0f + firstTextSize / 2.0f, Camera.main.transform.position.y + GM.height / 4.0f, -1);
		listGameObject = new GameObject[this.value.Length];

		for (int i = 0; i < value.Length; i++) {
			int asciiChar = (int)stringArray [i];
			if (asciiChar > 47 && asciiChar < 58)
				asciiChar -= 48;
			else
				asciiChar = 11;

			GameObject textObject = new GameObject (stringArray [i] + "_" + "Alphabe_" + asciiChar);
			SpriteRenderer textSprite = textObject.AddComponent<SpriteRenderer> ();
			textSprite.color = color;
			textSprite.sprite = this.listSprite [asciiChar];
			if (i > 0)
				previousSizeChar += textSprite.bounds.size.x / 2.0f;
		
			textObject.transform.position = new Vector3 (previousPostion.x + previousSizeChar, previousPostion.y, Zposition);
			textObject.transform.localScale = new Vector3 (scale, scale, 1f);
			previousPostion = textObject.transform.position;
			previousSizeChar = textObject.GetComponent<SpriteRenderer> ().bounds.size.x / 2.0f;
			listGameObject [i] = textObject;
		}
	}


	public void Update (string text, Vector3 position, float Zpos = 100, float rightMargin = 0) {


		if (position.z != 1000)
			this.Position = position;
		NumberUpdate (text, this.Position, Zpos, rightMargin);


	}

	void NumberUpdate(string text ,Vector3 position, float Zpos, float rightMargin)
	{
		if (Zpos != 100)
			Zposition = Zpos;
		if (listGameObject != null)
			for (int i = 0; i < listGameObject.Length; i++)
				GameObject.Destroy (listGameObject [i]);

        float currentScale = scale * (type == 4 && text.Length > 6 ? 0.8f : 1f);
        

		this.value = text.ToUpper ();
		if (this.value.Length == 0)
			return;

		char[] stringArray = value.ToCharArray ();
		float allSizeText = 0;
		float firstTextSize = 0;
		float lastTextSize = 0;
		//Debug.Log("first ascii: "+ (int) stringArray[0]);

		for (int i = 0; i < value.Length; i++) {
			int asciiChar = (int)stringArray [i];
            //if (asciiChar != 32 && (asciiChar < 48 || (asciiChar > 57 && asciiChar < 65) || asciiChar > 90))
            //	return;

            if (type == 4)
                asciiChar -= 39;
            else
            if (asciiChar > 47 && asciiChar < 58)
                asciiChar -= 48;
            else
                asciiChar = 11;

            
			if (i == 0)
				firstTextSize = this.listSprite [asciiChar].bounds.size.x * currentScale;
			if (i == value.Length - 1)
				lastTextSize = this.listSprite [asciiChar].bounds.size.x * currentScale;

            if (type == 3)
                allSizeText += this.listSprite[asciiChar].bounds.size.x * currentScale;
            else if (type == 4)
                allSizeText += this.listSprite[asciiChar < 0 ?/*32*/ 0 : asciiChar].bounds.size.x * currentScale * 0.75f;
            else
                allSizeText += spriteTextSize.x * currentScale;
        }
		//Debug.Log ("AllSize: " + allSizeText + " Align:" + Align+" posX:" + position.x);

		previousSizeChar = -firstTextSize / 2 - rightMargin;
		if (Align == CustomText.CENTER)
			previousPostion = new Vector3 (position.x - allSizeText / 2.0f + firstTextSize / 2.0f, position.y, -1);
		else if (Align == CustomText.LEFT)
			previousPostion = new Vector3 (position.x, position.y, -1);
		else if (Align == CustomText.RIGHT)
			previousPostion = new Vector3 (position.x , position.y, -1);
		listGameObject = new GameObject[this.value.Length];
        

		for (int i = 0; i < value.Length; i++) {
			int asciiChar = 0;
			if (Align == CustomText.CENTER || Align == CustomText.LEFT)
				asciiChar = (int)stringArray [i];
			if (Align == CustomText.RIGHT)
				asciiChar = (int)stringArray [value.Length - i - 1];

            if (type == 4)
                asciiChar -= 39;
            else
            if (asciiChar > 47 && asciiChar < 58)
                asciiChar -= 48;
            else
                asciiChar = 11;

			
			GameObject textObject = new GameObject (stringArray [i] + "_" + "Alphabe_" + asciiChar);
			SpriteRenderer textSprite = textObject.AddComponent<SpriteRenderer> ();
			textSprite.color = color;
			if (asciiChar < 100) 
				textSprite.sprite = asciiChar < 0 ?/*32*/ null : this.listSprite [asciiChar];

			textObject.transform.localScale = new Vector3 (currentScale, currentScale, 1f);
            //if (asciiChar == 100)
            //	previousSizeChar += spriteTextSize.x / 2;
            //else
            if (type == 3)//number3
                previousSizeChar += textSprite.bounds.size.x / 2f;
            else if (type == 4)
                previousSizeChar += asciiChar < 0 ?/*32*/this.listSprite[0].bounds.size.x / 4f : textSprite.bounds.size.x / 4f;
            else
                previousSizeChar += textSprite.bounds.size.x / 1.5f;


			if (Align == CustomText.CENTER || Align == CustomText.LEFT)
				textObject.transform.position = new Vector3 (previousPostion.x + previousSizeChar, previousPostion.y, Zposition);
			if (Align == CustomText.RIGHT)
				textObject.transform.position = new Vector3 (previousPostion.x - previousSizeChar, previousPostion.y, Zposition);


			previousPostion = textObject.transform.position;
			//if (asciiChar == 100)
			//	previousSizeChar = spriteTextSize.x / 2;
			previousSizeChar = textObject.GetComponent<SpriteRenderer> ().bounds.size.x / 2;
			listGameObject [i] = textObject;
		}
	}

	void RedUpdate(string text, Vector3 position, float Zpos)
	{
		if (Zpos != 100)
			Zposition = Zpos;
		if (listGameObject != null)
			for (int i = 0; i < listGameObject.Length; i++)
				GameObject.Destroy (listGameObject [i]);
		
		this.value = text;
		if (this.value.Length == 0)
			return;

		char[] stringArray = value.ToCharArray ();
		float allSizeText = 0;
		float firstTextSize = 0;
		float lastTextSize = 0;
		//Debug.Log("first ascii: "+ (int) stringArray[0]);

		for (int i = 0; i < value.Length; i++) {
			int asciiChar = (int)stringArray [i];
		//	if (asciiChar != 32 && asciiChar != 43 && (asciiChar < 48 || (asciiChar > 57 && asciiChar < 65) || asciiChar > 90))
		//		Debug.Log ("ERROR ASCII CODE: " + stringArray [i]);
			if (asciiChar == 43)
				asciiChar = 64;
			else if (asciiChar == 32)
				asciiChar = 1000;
			else if (asciiChar == 37)
				asciiChar = 69;
			else if (asciiChar > 47 && asciiChar < 58)
				asciiChar += 4;
			else if (asciiChar > 64 && asciiChar < 91)
				asciiChar -= 65;
			else if (asciiChar > 96 && asciiChar < 123)
				asciiChar -= 71;
			
			//Debug.Log ("ascii " + asciiChar);

			if (i == 0)
				firstTextSize = this.listSprite [asciiChar].bounds.size.x * scale;
			if (i == value.Length - 1)
				lastTextSize = this.listSprite [asciiChar].bounds.size.x * scale;

			if (asciiChar < 1000)
				allSizeText += this.listSprite [asciiChar].bounds.size.x * scale;
			else 
				allSizeText += spriteTextSize.x * scale;
		}
		//Debug.Log ("AllSize: " + allSizeText);

		previousSizeChar = -firstTextSize / 2;
		if (Align == CustomText.CENTER)
			previousPostion = new Vector3 (position.x - allSizeText / 2.0f + firstTextSize / 2.0f, position.y, -1);
		else if (Align == CustomText.LEFT)
			previousPostion = new Vector3 (position.x, position.y, -1);
		else if (Align == CustomText.RIGHT)
			previousPostion = new Vector3 (position.x , position.y, -1);
		listGameObject = new GameObject[this.value.Length];


		for (int i = 0; i < value.Length; i++) {
			int asciiChar = 0;
			if (Align == CustomText.CENTER || Align == CustomText.LEFT)
				asciiChar = (int)stringArray [i];
			if (Align == CustomText.RIGHT)
				asciiChar = (int)stringArray [value.Length - i - 1];

			if (asciiChar == 43)
				asciiChar = 64;
			else if (asciiChar == 32)
				asciiChar = 1000;
			else if (asciiChar == 37)
				asciiChar = 69;
			else if (asciiChar > 47 && asciiChar < 58)
				asciiChar += 4;
			else if (asciiChar > 64 && asciiChar < 91)
				asciiChar -= 65;
			else if (asciiChar > 96 && asciiChar < 123)
				asciiChar -= 71;
			
			GameObject textObject = new GameObject (stringArray [i] + "_" + "Alphabe_" + asciiChar);
			SpriteRenderer textSprite = textObject.AddComponent<SpriteRenderer> ();
			textSprite.color = color;
			if (asciiChar < 1000) 
				textSprite.sprite = this.listSprite [asciiChar];

			textObject.transform.localScale = new Vector3 (scale, scale, 1f);
			if (asciiChar == 1000)
				previousSizeChar += spriteTextSize.x / 2;
			else
				previousSizeChar += textSprite.bounds.size.x / 2.0f;

			if (Align == CustomText.CENTER || Align == CustomText.LEFT)
				textObject.transform.position = new Vector3 (previousPostion.x + previousSizeChar, previousPostion.y, Zposition);
			if (Align == CustomText.RIGHT)
				textObject.transform.position = new Vector3 (previousPostion.x - previousSizeChar, previousPostion.y, Zposition);


			previousPostion = textObject.transform.position;
			if (asciiChar == 1000)
				previousSizeChar = spriteTextSize.x / 2;
			previousSizeChar = textObject.GetComponent<SpriteRenderer> ().bounds.size.x / 2;
			listGameObject [i] = textObject;
		}
	}


	public void MoveWithDistance(Vector3 position)
	{
		if (listGameObject != null) {
			for (int i = 0; i < listGameObject.Length; i++)
				if (listGameObject [i] != null)
					listGameObject [i].transform.position += position;
			this.Position += position;
		}
	}
	public void BlurText(float value)
	{
        if (listGameObject != null)
		for (int i = 0; i < listGameObject.Length; i++)
		{
			Color tmpColor = listGameObject[i].GetComponent<SpriteRenderer> ().color;
			tmpColor.a -= value;
			listGameObject[i].GetComponent<SpriteRenderer> ().color = tmpColor;

			//listGameObject [i].GetComponent<Color>
		}
	}
			
}
