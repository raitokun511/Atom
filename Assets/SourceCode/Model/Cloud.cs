using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud
{
    GameObject cld;
    Object pPrefab;
    int time;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Cloud(Ball ball, Vector3 pos)
    {
        Init(pos, ball.Scale * Vector3.one / 10f);
    }
    public void Init(Vector3 pos, Vector3 scale)
    {
        cld = new GameObject("cloud");
        //listSprite = 
        cld.AddComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Effect/cloud_1")[Random.Range(0, 6)];
        cld.transform.localScale = scale;
        cld.transform.position = pos;

        time = (int)(Time.time * 1000);
    }
    // Update is called once per frame
    public void Update()
    {
        Color c = cld.GetComponent<SpriteRenderer>().color;
        c.a -= 0.05f;
        cld.GetComponent<SpriteRenderer>().color = c;
        if ((int)(Time.time * 1000) - time > 2000)
            Destroy();
    }
    public bool isDie
    {
        get { return cld == null; }
    }
    public void Destroy()
    {
        if (pPrefab != null)
            Object.Destroy(pPrefab);
        pPrefab = null;
        if (cld != null)
            GameObject.Destroy(cld);
        cld = null;
    }
}
