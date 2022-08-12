using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar {

	GameObject barBG;
	GameObject barValue;
	Texture2D barTexture;
	float Total;
	float Current;
	int Type;

	public ProgressBar (int type, Vector3 pos, float TotalValue, float currentValue = -1) {

		this.Type = type;
        float scale = GM.ScaleSizeBG();
        string[] nametype = { "Item/BomberLeft", "Item/BomberRight" };

        barBG = new GameObject ("BGBar");
		barBG.AddComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (nametype[type]);
		barBG.transform.position = pos - new Vector3 (0, 0, 0.1f);
		barBG.transform.localScale = scale * Vector3.one / 3;
        Color c = barBG.GetComponent<SpriteRenderer>().color;
        c.a = 0.0f;
        barBG.GetComponent<SpriteRenderer>().color = c;

        barValue = new GameObject ("BGValue");
		barTexture = Resources.Load (nametype[type]) as Texture2D;
		barValue.AddComponent<SpriteRenderer> ().sprite = Sprite.Create (barTexture, new Rect (0, 0, barTexture.width, barTexture.height), Vector2.zero);
		barValue.transform.position = pos - new Vector3(barTexture.width/2, barTexture.height/2, 0) - new Vector3 (0, 0, 0.2f);
		barValue.transform.localScale = scale * Vector3.one / 3;
        this.Total = TotalValue;
		if (currentValue == -1)
			this.Current = this.Total;
		else
			this.Current = currentValue;
			
	
	}
	public Vector3 Position
	{
		get { return this.barBG.transform.position; }
		set {
			barBG.transform.position = value  - new Vector3 (0, 0, 0.1f);
			barValue.transform.position = value  - new Vector3 (0, 0, 0.2f);
		}
	}
	public Vector3 Size
	{
		get { return barBG.GetComponent<SpriteRenderer> ().bounds.size; }

	}
    public Vector3 Scale
    {
        set
        {
            barBG.transform.localScale = value;
            barValue.transform.localScale = value;
        }
    }

	
	public void Update (float curValue, Vector3 pos) {
		this.Position = pos;
		this.Current = curValue;
        
        int intValue = Current > Total ? barTexture.width : (int)(this.Current * barTexture.width / this.Total);
        int desValue = Current > Total || Type == 0 ? 0 : (int)((Total - Current) * barTexture.width / this.Total);
        
        Sprite valueSprite = Sprite.Create(barTexture, new Rect(desValue, 0, intValue, barTexture.height), Vector2.zero);
        ///Sprite valueSprite =  Sprite.Create (barTexture, new Rect (0, 0, intValue, barTexture.height), Vector2.zero);
        Sprite fullSprite =  Sprite.Create (barTexture, new Rect (0, 0, barTexture.width, barTexture.height), Vector2.zero);

		Vector3 valueBound = fullSprite.bounds.size * barValue.transform.localScale.x;

		barValue.GetComponent<SpriteRenderer> ().sprite = valueSprite;
        //type == 0 normal, type == 1 mirror
        if (Type == 0)
            barValue.transform.position = barBG.transform.position - new Vector3(valueBound.x / 2, valueBound.y / 2, 0) + new Vector3(0, valueBound.y / 30, 0) - new Vector3(0, 0, 0.1f);
        else if (Type == 1)
            barValue.transform.position = barBG.transform.position + new Vector3(valueBound.x / 2 - (Current / Total > 1 ? 1 : Current / Total) * valueBound.x, -valueBound.y / 2, 0) + new Vector3(0, valueBound.y / 30, 0) - new Vector3(0, 0, 0.1f);
    }
}
