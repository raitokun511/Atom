using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Image
{
    public static int elmLevel = 1;
    public static int BallMovingTime = 0;
    public static int BallGravityTime = 0;
    public Image preatom;
    public static Sprite[] listSprite;
    public static Sprite[] hazardSprite;
    public static Sprite[] hazardcdSprite;
    public static Sprite[] explodeSprite;
    public static Sprite[] explodeFireSprite;
    public static Sprite[] elemenSprite;
    public GameObject hazardImg;
    public GameObject hazardCd;
    public List<Effect> listexplode;

    public int type;
    public int index;
    public bool isScored = false;
    public bool isDelRotate = false;
    public int superType = -1;
    public int stateAtom = 0;
    public short hazard = -1;
    public short gravitydrop = 0;

    public Vector3 rootpos;

    protected bool isAnimation = false;
    public bool isGrow = false;
    public int signAnim = 1;
    float angle = 1;

    public Ball() : base("", Vector3.zero, Vector3.zero)
    {
    }

    //100 101 102 103 ... Ball Bự
    //0 1 2 3 4... Aom
    //120 Chromium 20: Atom chrom
    public Ball(int type, int xindex, int yindex, bool grow)
    {
        this.type = type;
        isGrow = grow;
        index = xindex * 100 + yindex;

        image = new GameObject("ball_" + Random.Range(1000, 9999));
        if (type < 12)
            image.AddComponent<SpriteRenderer>().sprite = listSprite[type % 100 * 3];
        else if (type < 20)
            image.AddComponent<SpriteRenderer>().sprite = elemenSprite[(type - 12) % 100 * 16];
        else
            image.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("game_items/Chromium");
        if (GM.Mode < 3)
        {
            image.transform.position = GM.BoardPos - new Vector3(GM.BoardSize.x / 2, GM.BoardSize.y / 2, 0) +
                new Vector3(xindex * GM.BoardSize.x / 9, yindex * GM.BoardSize.y / 8, -3) + new Vector3(GM.BoardSize.x / 18, GM.BoardSize.y / 16, 0);
            image.transform.localScale = Vector3.one * GM.ScaleSizeBG() * 0.205f;

            this.rootScale = Vector3.one * GM.ScaleSizeBG() * 0.205f;
            rootpos = image.transform.position;
            stateAtom = 10;
            if (type < 100)
            {
                preatom = new Image("game_items/PreAtom", this.Position + new Vector3(0, 0, 0.1f), this.Scale * Vector3.one * 0.5f);
                preatom.Color = GetColorBall(type);
                image.transform.localScale = Vector3.zero;
                image.transform.position += new Vector3(0, 0, 2);
                stateAtom = 1;
            }

        }
        else if (GM.Mode == 3)
        {
            image.transform.position = GM.BoardPos - new Vector3(GM.BoardSize.y / 2, GM.BoardSize.y / 2, 0) +
                new Vector3(xindex * GM.BoardSize.y / 7.7f, yindex * GM.BoardSize.y / 7.7f, -3);// + new Vector3(GM.BoardSize.x / 18, GM.BoardSize.y / 18, 0);
            //image.transform.position = GM.BoardPos - new Vector3(GM.BoardSize.x / 2, GM.BoardSize.y / 2, 0) +
            //  new Vector3(xindex * GM.BoardSize.x / 9, yindex * GM.BoardSize.y / 8, -3) + new Vector3(GM.BoardSize.x / 18, GM.BoardSize.y / 16, 0);

            image.transform.localScale = Vector3.one * GM.ScaleSizeBG() * 0.13f;
            stateAtom = 1;
            this.rootScale = Vector3.one * GM.ScaleSizeBG() * 0.13f;
            rootpos = image.transform.position;
            image.transform.localScale = Vector3.one * GM.ScaleSizeBG() * 0.03f;
            image.transform.position += new Vector3(0, 0, 2);
        }
        
    }
    public Ball(int type, int index, Vector3 pos, Vector3 scale)
    {
        this.type = type;
        Sprite[] listSprite = null;
        if ((type % 100) / 10 == 0)
            listSprite = Resources.LoadAll<Sprite>("game_items/ball");
        else if ((type % 100) / 10 == 1)
            listSprite = Resources.LoadAll<Sprite>("game_items/super_ball");
        else if ((type % 100) / 10 == 2)
            listSprite = Resources.LoadAll<Sprite>("game_items/ultra_ball");
       
        image = new GameObject("ball");

        //Debug.Log ("type " + type);
        if ((type % 100) / 10 == 1)
        {
            superType = Random.Range(0, 5);
            normalSprite = listSprite[superType];
        }
        else
            normalSprite = listSprite[(type % 100) % 10];
        image.AddComponent<SpriteRenderer>().sprite = normalSprite;
        image.transform.position = pos;
        image.transform.localScale = scale;
        this.rootScale = scale;

    }
    public static Vector2 toIndex(int xindex, int yindex)
    {
        if (GM.Mode == 3)
            return GM.BoardPos - new Vector3(GM.BoardSize.y / 2, GM.BoardSize.y / 2, 0) +
         new Vector3(xindex * GM.BoardSize.y / 7.7f, yindex * GM.BoardSize.y / 7.7f, -3);

        return GM.BoardPos - new Vector3(GM.BoardSize.x / 2, GM.BoardSize.y / 2, 0) +
         new Vector3(xindex * GM.BoardSize.x / 9, yindex * GM.BoardSize.y / 8, -3) + new Vector3(GM.BoardSize.x / 18, GM.BoardSize.y / 16, 0);
        
    }
    public static Vector2 toXY(Vector3 position)
    {
        if (GM.Mode == 3)
        return new Vector3(Mathf.RoundToInt((position.x - GM.BoardPos.x + GM.BoardSize.y / 2) / (GM.BoardSize.y / 7.7f )),
            Mathf.RoundToInt((position.y - GM.BoardPos.y + GM.BoardSize.y / 2) / (GM.BoardSize.y / 7.7f)), 0);

        return new Vector3(Mathf.RoundToInt((position.x - GM.BoardSize.x / 18 - GM.BoardPos.x + GM.BoardSize.x / 2) / (GM.BoardSize.x / 9)),
            Mathf.RoundToInt((position.y - GM.BoardPos.y + GM.BoardSize.y / 2 - GM.BoardSize.y / 16) / (GM.BoardSize.y / 8)), 0);

    }
    public bool checkHazard
    {
        get { return hazardCd != null; }
    }
    public void GrowHalf()
    {
        if (GM.Mode < 3 && stateAtom == 1)
        {
            if (preatom.Scale < this.RootScale)
                preatom.Scale += GM.unit / 10;
            else
            {
                this.Scale = RootScale / 10;
                stateAtom = 2;
            }
        }
    }
    public void Grow(bool firstgrow = false)
    {
        //Debug.Log("BALL GROW " + (index / 100) + " ; " + (index % 100) + "  ");
        if (GM.Mode < 3)
        {
            if (stateAtom == 1)
            {
                if (type >= 12 && type < 20)
                    preatom.Active = false;
                if (preatom.Scale < this.RootScale)
                    preatom.Scale += GM.Mode == 1 || firstgrow ? RootScale / 10f : RootScale / 200f;//GM.unit / 10 : GM.unit / 80;
                else
                {
                    this.Scale = RootScale / 10;
                    stateAtom = 2;
                }
            }
            if (stateAtom == 2)
            {
                //Debug.Log(index + " State 2 " + preatom.Scale);
                if (this.Scale < this.RootScale)
                {
                    if (this.Scale + GM.unit / 10 < this.RootScale)
                        this.Scale += GM.unit / 8;
                    else this.Scale = this.RootScale;
                    preatom.Scale -= GM.unit / 16;
                    preatom.Position = this.Position + new Vector3(0, 0, 0.2f);
                    //Debug.Log("remove " + preatom.Scale);
                }
                else
                    stateAtom = 3;
            }
            if (stateAtom == 3)
            {
                if (this.type > 11)
                {
                    if (Ball.elmLevel == 2)
                        this.type += 200;
                    else if (Ball.elmLevel == 3)
                        this.type += 300;
                    else this.type += 100;
                    Ball.elmLevel = 1;
                }
                else
                    this.type += 100;
                preatom.Destroy();
                preatom = null;
                this.Scale = rootScale.x;
                image.transform.position -= new Vector3(0, 0, 2);
                stateAtom = (int)(Time.time * 1000);
                if (hazard > 0 && hazardImg != null)
                {
                    hazardImg.transform.localScale = image.transform.localScale;
                    hazardCd.transform.localScale = image.transform.localScale;
                    hazardImg.transform.position = image.transform.position + new Vector3(0, 0, -0.1f);
                    hazardCd.transform.position = image.transform.position + new Vector3(0, 0, -0.2f);
                    if (image.transform.childCount <= 0)
                    {
                        Object pPrefab = Resources.Load("Effect/Dust"); // note: not .prefab!
                        GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, this.Position + new Vector3(0, 0, -2.1f), Quaternion.identity);
                        pNewObject.transform.parent = image.transform;
                        pNewObject.transform.localScale = GM.scaleRatio * Vector3.one / 10;
                    }
                }
            }
        }
        else if (GM.Mode == 3)
        {
            if (stateAtom == 1)
            {
                stateAtom = 2;
            }
            if (stateAtom == 2)
            {
                if (this.Scale < this.RootScale)
                {
                    if (this.Scale + GM.unit / 10 < this.RootScale)
                        this.Scale += GM.unit / 8;
                    else this.Scale = this.RootScale;
                }
                else
                    stateAtom = 3;
            }
            if (stateAtom == 3)
            {
                this.type += 100;
                this.Scale = rootScale.x;
                image.transform.position -= new Vector3(0, 0, 2);
                stateAtom = (int)(Time.time * 1000);
            }
        }
    }
    public void RePos()
    {
        rootpos = image.transform.position;
    }
    public short Hazard
    {
        set
        {
            hazard = value;
            if (hazardImg == null)
            {
                hazardImg = new GameObject("ballhz");
                hazardCd = new GameObject("ballhhaz");
            }
            if (value > 0)
            {
                if (hazardImg.GetComponent<SpriteRenderer>() == null)
                {
                    hazardImg.AddComponent<SpriteRenderer>().sprite = hazardSprite[hazard - 1];
                    hazardCd.AddComponent<SpriteRenderer>().sprite = hazardcdSprite[hazard - 1];
                }
                else
                {
                    hazardImg.GetComponent<SpriteRenderer>().sprite = hazardSprite[hazard - 1];
                    hazardCd.GetComponent<SpriteRenderer>().sprite = hazardcdSprite[hazard - 1];
                }
                if (this.type < 100)
                {
                    hazardImg.transform.localScale = Vector3.zero;
                    hazardCd.transform.localScale = Vector3.zero;
                }
            }
            
        }
        get { return hazard; }
    }
    public void Move(Vector3 position)
    {
        this.Position = position;
        if (hazardImg != null)
        {
            hazardImg.transform.position = image.transform.position + new Vector3(0, 0, -0.1f);
            hazardCd.transform.position = image.transform.position + new Vector3(0, 0, -0.2f);
        }
    }
    public static void ResetBallSprite()
    {
        if (GM.Mode <= 2)
        {
            listSprite = Resources.LoadAll<Sprite>("game_items/Atoms");
            hazardSprite = Resources.LoadAll<Sprite>("game_items/biohazard");
            hazardcdSprite = Resources.LoadAll<Sprite>("game_items/biocountdown");
            explodeSprite = Resources.LoadAll<Sprite>("Effect/atomicexplosion");
            explodeFireSprite = Resources.LoadAll<Sprite>("Effect/atomicexplosion3");
            elemenSprite = Resources.LoadAll<Sprite>("game_items/elemental");
        }
        else
        {
            listSprite = Resources.LoadAll<Sprite>("game_items/lineballs");
        }
    }
    public bool IsAnimation
    {
        set
        {
            if (value && !this.image.GetComponent<Rigidbody2D>())
            {
                Rigidbody2D rb = this.image.AddComponent<Rigidbody2D>();
                image.AddComponent<CircleCollider2D>().sharedMaterial = Resources.Load<PhysicsMaterial2D>("Effect/bounce");
                rb.gravityScale = 1;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                //hazard làm nền
                hazardImg = new GameObject("ground");
                hazardImg.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UI/music_progress_but");
                hazardImg.transform.localScale = new Vector3(this.Scale * 4, this.Scale / 3, 1);
                hazardImg.transform.position = new Vector3(this.Position.x, this.Position.y - this.Size.y / 1.1f, this.Position.z);
                Rigidbody2D rbgr = hazardImg.AddComponent<Rigidbody2D>();
                hazardImg.AddComponent<BoxCollider2D>();
                hazardImg.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                rbgr.constraints = RigidbodyConstraints2D.FreezeAll;
                this.Position += new Vector3(0, this.Size.y / 3.4f, 0);
            }
            else if (hazardImg != null)
            {
                GameObject.Destroy(image.GetComponent<Rigidbody2D>());
                GameObject.Destroy(image.GetComponent<CircleCollider2D>());
                GameObject.Destroy(hazardImg);
                hazardImg = null;
                Position = rootpos;
            }
            isAnimation = value;

        }
        get { return isAnimation; }
    }
    public float RootScale
    {
        get { return rootScale.x; }
    }
    public bool isDie
    {
        get { return image == null; }
    }
    public Vector3 BSize
    {
        get { return image.GetComponent<SpriteRenderer>().bounds.size * Scale; }
    }
    public void chooseSprite()
    {
        if (type >= 100 && type < 112)
            image.GetComponent<SpriteRenderer>().sprite = listSprite[type % 100 * 3 + 2];
        
    }
    public void unChooseSprite()
    {
        if (type >= 100 && type < 112)
            image.GetComponent<SpriteRenderer>().sprite = listSprite[type % 100 * 3];
        
    }
    public bool isExplode
    {
        set
        {
            isScored = true;
        }
        get { return isScored && signAnim > 0; }
    }
    public bool isBonusExplode
    {
        set
        {
            isScored = true;
            isAnimation = true;
        }
        get { return isScored && signAnim > 0 && isAnimation; }
    }
    public int timeExplode
    {
        set { signAnim = value; }
    }
    public int Explode()
    {
        if (((int)(Time.time * 1000) < signAnim))
            return 0;

        if (!isAnimation)//Not Explode Fire Ball
            if (listexplode != null && listexplode.Count > 0)
            {
                foreach (Effect e in listexplode)
                    if (e != null && e.isLive)
                        e.Update();
                listexplode.RemoveAll(e => !e.isLive);
            }

        index = ((int)(Time.time * 1000) - signAnim) / 70;
        if (index < 16)
        {
            image.GetComponent<SpriteRenderer>().sprite = isAnimation ? explodeFireSprite[index] : explodeSprite[index];
            if (listexplode == null)
                listexplode = new List<Effect>();
            if (!isAnimation)//Not Fire Explode
                if (index < 12 && listexplode.Count < index / 2)
                    listexplode.Add(new Effect("Effect/atomicexplosion", this.Position + new Vector3(Random.Range(-Size.x, Size.x), Random.Range(-Size.y, Size.y), 0), this.Scale * Vector3.one, false));
            if (!isAnimation && index >= 1)
            {
                if (image.transform.childCount == 0)
                {
                    Object pPrefab = Resources.Load("Effect/NukeFlasLight");// BombLight2D");
                    GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, new Vector3(0, 0, -5), Quaternion.identity);
                    //GameObject pNewObject = new GameObject("flash");
                    //pNewObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Effect/NukeFlash");
                    pNewObject.transform.position = this.Position + new Vector3(0, 0, 0.1f);
                    pNewObject.transform.localScale = Vector3.one * GM.width / 20 / 2.5f; //this.Scale * Vector3.one / 5;
                    Debug.Log("Scale " + (this.Scale / 5) + "  vs  " + (GM.width / 20 / 2.5f));
                    pNewObject.transform.parent = image.transform;
                    return 1;
                }
                else
                    //image.transform.GetChild(0).localScale += this.Scale * Vector3.one / 10;
                    if (image.transform.GetChild(0).localScale.x < RootScale * 2)
                    image.transform.GetChild(0).localScale *= 1.08f;
            }
        }
        else if (state <= 1)
            DestroyAfter(100);
        else
        {
            //Destroy after
            if (!isDie)
            {
                if ((int)(Time.time * 1000) > state)
                {
                    if (image.transform.childCount > 0)
                        GameObject.Destroy(image.transform.GetChild(0).gameObject);
                    Destroy();
                }
            }
        }
        return 0;
    }
    public void Update()
    {
        if (isDelRotate)
        {
            image.transform.RotateAround(GM.HoleCenter, Vector3.forward, 400 * Time.deltaTime);
            image.transform.position = new Vector3((this.Position.x - GM.HoleCenter.x) *0.98f, Position.y, Position.z);
            image.transform.localScale *= 0.98f;
            this.Alpha = 0.5f;
            Vector2 distance = Position - GM.HoleCenter;
            if (hazardCd != null)
            {
                GameObject.Destroy(hazardCd);
                GameObject.Destroy(hazardImg);
                hazardCd = null;
                hazardImg = null;
            }
            if (image.transform.childCount > 0)
                GameObject.Destroy(image.transform.GetChild(0).gameObject);
            if (distance.magnitude < GM.BoardSize.x / 10)
            {
                Destroy();
                return;
            }
        }
        //hazard
        if (hazard > 0 && hazardImg != null)
        {
            hazardImg.transform.position = image.transform.position + new Vector3(0, 0, -0.1f);
            hazardCd.transform.position = image.transform.position + new Vector3(0, 0, -0.2f);
           
            Color c = hazardCd.GetComponent<SpriteRenderer>().color;
            if (c.a < 0.2f)
                signAnim = 1;
            else if (c.a > 0.95f)
                signAnim = -1;
            c.a = c.a + signAnim * 0.02f;
            hazardCd.GetComponent<SpriteRenderer>().color = c;
            Color c2 = hazardImg.GetComponent<SpriteRenderer>().color;
            c2.a = 1.15f - c.a / 2 - 0.4f;
            hazardImg.GetComponent<SpriteRenderer>().color = c2;
            //https://www.youtube.com/watch?v=tPtRCpwSgBg
            //Glow
            //https://www.youtube.com/watch?v=WiDVoj5VQ4c
            //2D light
            //https://www.youtube.com/watch?v=nkgGyO9VG54
            
        }
        if (GM.Mode == 3 && isAnimation)
        {
            //Alpha = Alpha + 0.01f >= 1 ? Alpha - 1 : Alpha + 0.01f;
            //this.Position += new Vector3(0, 0, 0);
            //Debug.Log("Update");
            //image.GetComponent<Rigidbody2D>().velocity = Vector2.up * 6;

        }

        if (type >= 112 && type < 120)
        {
            int timeIndex = ((type % 100 - 12) * 16) + (((int)(Time.time * 1000) - stateAtom) / 100) % 16;//% listSprite.Length;
            image.GetComponent<SpriteRenderer>().sprite = elemenSprite[timeIndex];
            //image.GetComponent<SpriteRenderer>().sprite = elemenSprite[((type % 100 - 12) * 16) + ((int)(Time.time * 1000) / 30) / 16 % 16];
        }

        int tapCount = 0;
        while (tapCount < Input.touches.Length)
        {
            Touch touch = Input.GetTouch(tapCount);
            tapCount++;
            Vector2 positionToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
            if (touch.phase == TouchPhase.Began && Pos.Contains(this.Position, this.Size, positionToWorldPoint))
            {
                //isMove = true;
                //this.auBG.Play();

            }

        }
    }



    public static Color GetColorBall(int type)
    {
        if (type == 0)
            return new Color(226f / 255f, 16f / 255f, 16f / 255f);//233 140 140
        if (type == 1)
            return new Color(75f / 255f, 210f / 255f, 57f / 255f);
        if (type == 2)
            return new Color(217f / 255f, 217f / 255f, 65f / 255f);
        if (type == 3)
            return new Color(22f / 255f, 121f / 255f, 222f / 255f);
        if (type == 4)
            return new Color(202f / 255f, 22f / 255f, 221f / 255f);
        if (type == 5)
            return new Color(221f / 255f, 138f / 255f, 22f / 255f);
        if (type == 6)
            return new Color(219f / 255f, 183f / 255f, 183f / 255f);

        return new Color(1, 1, 1);
    }

    public void DeleteAnimation(Vector3 force)
    {
        if (this.Scale > rootScale.x / 2)
        {
            this.Scale *= 0.9f;
        }
    }
    public void DeleteAnimation()
    {
        if (isDelRotate)
            return;

        image.transform.position = rootpos + Random.insideUnitSphere * this.Size.x / 8;
        if (type == 120)
            image.GetComponent<SpriteRenderer>().sprite = listSprite[35];
        else
            image.GetComponent<SpriteRenderer>().sprite = listSprite[type % 100 * 3 + 2];

        if (image.transform.childCount == 0)
        {
            Object pPrefab = Resources.Load("Effect/ScoreLight");// BombLight2D");
            GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, new Vector3(0, 0, -5), Quaternion.identity);
            pNewObject.transform.position = this.Position + new Vector3(0, 0, 0.1f);
            pNewObject.transform.localScale = this.Scale * Vector3.one;
            pNewObject.transform.parent = image.transform;
        }

    }
    public void OverAnimation()
    {
        image.transform.position = rootpos + Random.insideUnitSphere * this.Size.x / 8;

    }
    public void AllDelete()
    {
        angle -= 0.0025f;

        image.transform.Rotate(Vector3.up, angle * Time.deltaTime);
        image.transform.Translate(Vector3.forward * 20 * Time.deltaTime);

    }

    public void Destroy()
    {
        base.Destroy();
        if (preatom != null)
            preatom.Destroy();
        GameObject.Destroy(hazardCd);
        hazardCd = null;
        GameObject.Destroy(hazardImg);
        hazardImg = null;
        preatom = null;
        if (listexplode != null)
        {
            foreach (Effect e in listexplode)
                e.Destroy();
            listexplode.Clear();
        }
        listexplode = null;

    }
    public void DestroyAfter(int time)
    {
        state = (int)(Time.time * 1000) + time;
    }

}
