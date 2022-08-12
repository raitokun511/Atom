using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : Item
{

    public static Sprite[] itemSprite;
    public static Sprite[] itemnumSprite;
    public static Sprite[] diamondSprite;

    List<GameObject> numbers;
    Vector3 rootpos;
    int timeBegin;
    int count;
    int tmpPlus = 0;
    public int ScoreValue = 0;
    int align = 0;

    public Score(int score, Vector3 pos, float scale, int type = 1) : base("score3", pos, scale)
    {
        timeBegin = (int)(Time.time * 1000);
        int tmpScore = score;
        ScoreValue = score;
        Type = type;
        count = 0;
        while (tmpScore > 0)
        {
            tmpScore /= 10;
            count++;
        }
        numbers = new List<GameObject>();
        tmpScore = score;
        if (itemSprite == null || itemSprite.Length <= 0)
        {
            itemSprite = Resources.LoadAll<Sprite>("UI/LevelFont");
            itemnumSprite = Resources.LoadAll<Sprite>("UI/line_scores");
            diamondSprite = Resources.LoadAll<Sprite>("UI/coin_number");
        }
        rootpos = pos;
        float size = 0;

        if (score == 0)
        {
            numbers.Add(new GameObject("num_0_0"));
            numbers[0].AddComponent<SpriteRenderer>().sprite = type == 1 ? itemSprite[0] : type == 2 ? itemnumSprite[0] : diamondSprite[0];
            numbers[0].transform.localScale = Vector3.one * scale;
            size = numbers[0].GetComponent<SpriteRenderer>().bounds.size.x * 1.1f;
            numbers[0].transform.position = rootpos - new Vector3(size * (-count / 2f + 0.5f), 0, 0);
            if (Type == 2)
                numbers[0].transform.position -= new Vector3(size * 0.1f, 0, 0);
        }

        for (int i = 0; i < count; i++)
        {
            int num = tmpScore % 10;
            tmpScore /= 10;
            GameObject go = new GameObject("num" + score + "_" + num);
            go.AddComponent<SpriteRenderer>().sprite = type == 1 ? itemSprite[num] : type == 2 ? itemnumSprite[num] : diamondSprite[num];
            go.transform.position = rootpos - new Vector3(size * (i - count / 2f + 0.5f), 0, 0);
            go.transform.localScale = Vector3.one * scale;
            if (i == 0)
            {
                size = go.GetComponent<SpriteRenderer>().bounds.size.x * 1.1f;
                go.transform.position = rootpos - new Vector3(size * (-count / 2f + 0.5f), 0, 0);
                if (Type == 2)
                    go.transform.position -= new Vector3(size * 0.1f, 0, 0);
            }
            numbers.Add(go);
        }

    }

    public void Plus(int val)
    {
        tmpPlus += val;
    }
    public int ScoreTotal
    {
        get { return tmpPlus + ScoreValue; }
    }

    public Vector3 AddPosition
    {
        set
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i].transform.position += value;
            }
        }
    }
    public int Align
    {
        set { align = value; }
        get { return align; }
    }

    public void changeColor(Color color)
    {
        for (int i = 0; i < numbers.Count; i++)
        {

            Color c = numbers[i].GetComponent<SpriteRenderer>().color;
            c = color;
            numbers[i].GetComponent<SpriteRenderer>().color = c;
        }
    }
    public Vector3 Rotation
    {
        set
        {
            item.transform.rotation = Quaternion.Euler(value);
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i].transform.rotation = Quaternion.Euler(value);
            }
        }
    }

    public override void Update()
    {

        if (isDie)
            return;

        if (tmpPlus > 0)
        {
            if (tmpPlus >= 10)
            {
                ScoreValue += 10;
                tmpPlus -= 10;
            }
            else
            {
                ScoreValue += tmpPlus;
                tmpPlus = 0;
            }
            ChangeValue(ScoreValue);
        }

    }

    public void ChangeValue(int mvalue)
    {
        int tmpcount = 0;
        int tmpScore = mvalue;
        while (tmpScore > 0)
        {
            tmpScore /= 10;
            tmpcount++;
        }
        if (tmpcount > count)
        {
            for (int i = 0; i < tmpcount - count; i++)
            {
                GameObject go = new GameObject("num");
                go.AddComponent<SpriteRenderer>().sprite = Type == 1 ? itemSprite[0] : Type == 2 ? itemnumSprite[0] : diamondSprite[0];
                go.transform.position = Vector3.zero;// pos + new Vector3(size, 0, 0);
                go.transform.localScale = numbers[0].transform.localScale;
                numbers.Add(go);
            }

            count = tmpcount;
        }
        else if (tmpcount < count)
        {
            for (int i = 0; i < count - tmpcount; i++)
                GameObject.Destroy(numbers[i]);
            numbers.RemoveRange(0, count - tmpcount);
            count = tmpcount;
        }


        tmpScore = mvalue;
        float size = numbers[0].GetComponent<SpriteRenderer>().bounds.size.x * 0.9f;
        for (int i = 0; i < count; i++)
        {
            int num = tmpScore % 10;
            tmpScore /= 10;
            numbers[i].GetComponent<SpriteRenderer>().sprite = Type == 1 ? itemSprite[num] : Type == 2 ? itemnumSprite[num] : diamondSprite[num];
            //if (align == 0)
                numbers[i].transform.position = rootpos - new Vector3(size * (i - count / 2f + 0.5f), 0, 0);
            //else if (align == 1)
            //    numbers[i].transform.position = rootpos - new Vector3(size * (i - count / 2f + 0.5f), 0, 0);
            numbers[i].transform.localScale = numbers[0].transform.localScale;
            numbers[i].transform.rotation = Quaternion.Euler(item.transform.rotation.eulerAngles);
            if (i == 0)
            {
                size = numbers[i].GetComponent<SpriteRenderer>().bounds.size.x * 0.8f;
                numbers[i].transform.position = rootpos - new Vector3(size * (-count / 2f + 0.5f), 0, 0);
                if (Type == 2)
                    numbers[i].transform.position -= new Vector3(size * 0.1f, 0, 0);
            }
        }
        
        if (align == 1)//right
        {
            for (int i = count - 1; i >= 0; i--)
                numbers[i].transform.position = rootpos - new Vector3(size * (i + 0.5f), 0, 0);
        }
        

    }

    public void Destroy()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            GameObject.Destroy(numbers[i]);
            numbers[i] = null;
        }
        numbers = null;
        GameObject.Destroy(item);
        item = null;
    }

}
