using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron
{
    GameObject e;
    Ball parent;
    public int type;
    float angle;
    public bool mirror = false; 

    // Start is called before the first frame update
    public Electron(int typeparent,int direc, Ball mparent, float scale)
    {
        e = new GameObject("e");
        e.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Effect/Electron");
        parent = mparent;
        type = direc * 10000 + mparent.type;
        e.transform.position = parent.Position + new Vector3(0, 0, -2.5f);
        e.transform.localScale = Vector3.one * scale / 5;
        TrailRenderer trail = e.AddComponent<TrailRenderer>();
        trail.time = 0.3f;
        trail.startWidth = 0.04f;
        trail.endWidth = 0f;
        trail.minVertexDistance = 0;
        trail.material = Resources.Load("Effect/trailMat", typeof(Material)) as Material;
        setColor();
        angle = 0;
        if (direc >= 10)
            mirror = true;
    }
    public void ReParent(Ball newparent)
    {
        //đỏ: ngang, xanh lá:ngang, dọc     vàng: dọc
        //xanhdương: dọc, z     tím: ngang dọc z
        //chrominum: ngang dọc chéo
        mirror = !mirror;

        if ((type / 10000 == 0 || type / 10000 == 10) && newparent.type >= 100 &&
        (newparent.type % 100 == 0 || newparent.type % 100 == 1 || newparent.type % 100 == 4 || newparent.type == 120 ||
                (newparent.type % 100 >= 12 && newparent.type % 100 <= 16) || newparent.type % 100 == 6 || newparent.type % 100 == 9 ||
                newparent.type % 100 == 11))
        {
            if (mirror)
                Enable();
            else
                Disable();
        }
        else if ((type / 10000 == 1 || type / 10000 == 11) && newparent.type > 100 &&
            (newparent.type % 100 == 1 || newparent.type % 100 == 2 || newparent.type % 100 == 3 || newparent.type % 100 == 4 ||
                newparent.type == 120 || (newparent.type % 100 >= 12 && newparent.type % 100 <= 16 && newparent.type / 100 >= 2)
                || newparent.type % 100 == 7 || newparent.type % 100 == 9 || newparent.type % 100 == 10 || newparent.type % 100 == 11))
        {
            if (mirror)
                Enable();
            else
                Disable();
        }
        else if ((type / 10000 == 2 || type / 10000 == 12) && newparent.type > 100 &&
        (newparent.type % 100 == 3 || newparent.type % 100 == 4 || newparent.type == 120 || newparent.type % 100 == 8 ||
                newparent.type % 100 == 10))
        {
            if (!e.activeSelf)
                Enable();
            else
                Disable();
        }
        else if ((type / 10000 == 3 || type / 10000 == 13) && newparent.type > 100 &&
        (newparent.type % 100 == 5 || newparent.type % 100 == 6 || newparent.type % 100 == 7 || newparent.type % 100 == 8 ||
                newparent.type == 120 || newparent.type % 100 == 9 || newparent.type % 100 == 10 || newparent.type % 100 == 11 ||
                 (newparent.type % 100 >= 12 && newparent.type % 100 <= 16 && newparent.type / 100 == 3)))
        {
            if (mirror)
                Enable();
            else
                Disable();
        }
        else
            Disable();
        type = (type / 10000) * 10000 + newparent.type;
        parent = newparent;
        e.transform.position = parent.Position + new Vector3(0, 0, -2.5f);
        setColor();
    }
    void setColor()
    {
        Color col = Color.red;
        if (parent.type % 100 == 1)
            col = Color.green;
        else if (parent.type % 100 == 2)
            col = Color.yellow;
        else if (parent.type % 100 == 3)
            col = Color.blue;
        else if (parent.type % 100 == 4)
            col = new Color(128f / 255f, 0, 128f / 255f);
        else if (parent.type % 100 == 5)
            col = new Color(1, 165f / 255f, 0);
        else if (parent.type % 100 == 6)
            col = new Color(251f / 255f, 226f / 255f, 227f / 255f);
        else if (parent.type % 100 == 7)
            col = new Color(207f / 255f, 206f / 255f, 156f / 255f);
        else if (parent.type % 100 == 8)
            col = new Color(0, 0, 0);
        else if (parent.type % 100 == 9)
            col = new Color(170f / 255f, 152f / 255f, 229f / 255f);
        else if (parent.type % 100 == 10)
            col = new Color(135f / 255f, 212f / 255f, 190f / 255f);
        else if (parent.type % 100 == 11)
            col = new Color(170f / 255f, 152f / 255f, 229f / 255f);

        else if (parent.type % 100 == 20)
            col = new Color(1, 1, 1);
        else if (parent.type % 100 == 12)
            col = new Color(255f / 255f, 165f / 255f, 38f / 255f);
        else if (parent.type % 100 == 13)
            col = new Color(37f / 255f, 139f / 255f, 255f / 255f);
        else if (parent.type % 100 == 14)
            col = new Color(170f / 255f, 105f / 255f, 255f / 255f);
        else if (parent.type % 100 == 15)
            col = new Color(122f / 255f, 110f / 255f, 137f / 255f);
        else if (parent.type % 100 == 16)
            col = new Color(115f / 255f, 219f / 255f, 184f / 255f);

        e.GetComponent<SpriteRenderer>().color = col;
        TrailRenderer trail = e.GetComponent<TrailRenderer>();
        trail.startColor = col;
        trail.endColor = col;

    }
    public void Disable()
    {
        e.SetActive(false);
     
        //Debug.Log("Disable " + type);
    }
    public void MirrorDisable()
    {
        e.transform.position = new Vector3(GM.BoardSize.x * 5, GM.BoardSize.y * 5, 100);
    }
    public void Enable()
    {
        e.SetActive(true);
        //Debug.Log("Enable " + type);
    }
    // Update is called once per frame
    public void Update()
    {
        if (parent == null || parent.isDie)
            return;
        float velocity = 4;
        if (type % 10000 == 200)
            velocity = 6;
        angle += Mathf.PI / 180;

        if (type / 10000 == 0 || type / 10000 == 10)
            e.transform.position = new Vector3(parent.Position.x + Mathf.Sin(angle * velocity) * parent.Size.x / 2, parent.Position.y, parent.Position.z + Mathf.Cos(angle * velocity) * parent.Size.x / 2);
        else if (type / 10000 == 1 || type / 10000 == 11)
            e.transform.position = new Vector3(parent.Position.x, parent.Position.y + Mathf.Sin(Time.time * velocity) * parent.Size.y / 2, parent.Position.z + Mathf.Cos(Time.time * velocity) * parent.Size.y / 2);
        else if (type / 10000 == 2 || type / 10000 == 12)
            e.transform.position = new Vector3(parent.Position.x + Mathf.Sin(Time.time * velocity) * parent.Size.y / 2, parent.Position.y + Mathf.Cos(Time.time * velocity) * parent.Size.y / 2, e.transform.position.z);
        else if (type / 10000 == 3 || type / 10000 == 13)
            e.transform.position = new Vector3(parent.Position.x + Mathf.Sin(Time.time * velocity) * parent.Size.y / 2, parent.Position.y + Mathf.Cos(Time.time * velocity - Mathf.PI / 4f) * parent.Size.y / 2, parent.Position.z + Mathf.Cos(angle * velocity) * parent.Size.x / 2);
        else if (type / 10000 == 4 || type / 10000 == 14)
            e.transform.position = new Vector3(parent.Position.x + Mathf.Sin(Time.time * velocity) * parent.Size.y / 2, parent.Position.y + Mathf.Cos(Time.time * velocity) * parent.Size.y / 2, e.transform.position.z);
        
    }
    public void Destroy()
    {
        GameObject.Destroy(e);
        e = null;
    }
}
