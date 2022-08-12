using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopStage : MonoBehaviour
{
    public static Event OPTION_MENU = new Event();
    public static Event QUIT_MENU = new Event();
    public static Event BUY_ITEM_CLICK = new Event();
    public static Event PURCHASE_CLICK = new Event();
    public static Event PURCHASE_CHOOSE_CLICK = new Event();
    public static Event PURCHASE_COMPLETE = new Event();
    public static Event DAILY_REWARD_CLICK = new Event();
    public static Event DAILY_OK_CLICK = new Event();

    public static int parentSceneCode = 0;
    float scaleRatio;
    Image shopBG;
    Image shopOver;
    GameObject shopPanel;
    GameObject purchasePanel;
    Image coinName;
    Score coin;
    Image diamondName;
    Score diamond;
    GameButton quitButton;
    GameButton purchaseButton;
    GameButton dailyGift;
    Image[] ItemsBG;
    Image[] ItemsImg;
    GameButton[] ItemsBuy;
    Image[] ItemsDes;
    Image bagBG;
    Image[] itemBagImg;
    GameButton[] gemBuy;
    Image dailyDialog;
    GameButton dailyOKBtn;
    Image overlayGift;
    List<Image> listgemAnim;

    float leftPos;
    float rightPos;
    float touchpos;
    int giftscale = 0;
    float xI;
    float[] scaleline = { 4.4f, 4.3f, 4.2f, 4.1f, 4.0f, 4.0f, 4.0f, 4.0f, 4.0f, 4.0f, 4.0f, 4.0f, 4.0f, 4.0f, 3.9f, 3.8f, 3.7f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.6f, 3.7f, 3.8f, 3.9f, 4.0f, 4.1f, 4.2f, 4.3f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, 4.4f, };


    GameObject iap;
    public static AudioSource audioBackground;
    public UnityEngine.UI.Text debugText;


    // Start is called before the first frame update
    void Start()
    {
        GM.Init();
        //GM.Diamond = 30;
        GM.debugShop = debugText;
        GM.bagItem = new List<int>();
        listgemAnim = new List<Image>();
        UserData.Load();

        scaleRatio = GM.ScaleSizeBG();
        shopOver = new Image("UI/Shop_Over", new Vector3(0f, 0f, -7.0f), new Vector3(1, 1, 1) * scaleRatio * 1f);

        shopBG = new Image("UI/Shop_BG", new Vector3(0f, 0f, -1f), new Vector3(1, 1, 1) * scaleRatio * 1f);
        coinName = new Image("UI/levelandscore", shopBG.Position + new Vector3(-shopBG.Size.x / 4.5f, shopBG.Size.y / 3f, -1.5f), new Vector3(1.2f, 1.6f, 1) * scaleRatio * 0.2f);
        coin = new Score(GM.Mode == 1 ? GM.strategyScore : GM.actionScore, coinName.Position - new Vector3(0, coinName.Size.y * 2, 0), coinName.Scale / 4);

        Image diamondRound = new Image("UI/GemBox", shopBG.Position + new Vector3(shopBG.Size.x / 3.6f, -shopBG.Size.y / 2.4f, -0.5f), new Vector3(1f, 1f, 1) * scaleRatio * 1.1f);
        diamondName = new Image("UI/gemblueS", shopBG.Position + new Vector3(shopBG.Size.x / 2.5f, -shopBG.Size.y / 2.4f, -1.5f), new Vector3(1f, 1f, 1) * scaleRatio * 0.7f);
        diamond = new Score(GM.Diamond, shopBG.Position + new Vector3(shopBG.Size.x / 2.75f, -shopBG.Size.y / 2.4f, -1.5f), diamondName.Scale * 1.4f, 3);
        diamond.Align = 1;
        diamond.ChangeValue(GM.Diamond);
        purchaseButton = new GameButton("Purchase", "UI/AddGemButton", diamondRound.Position - new Vector3(diamondRound.Size.x / 2.5f, 0, 0.2f), Vector3.one * scaleRatio * 0.85f, 1);
        purchaseButton.ButtonTapEvent = PURCHASE_CLICK;

        shopPanel = new GameObject("Panel");

        //levelProgress = new Image("UI/levelbar75", atomicMeter.Position + new Vector3(-atomicMeter.Size.x / 3.2f, atomicMeter.Size.x / 120f, -0.1f), Vector3.zero);//atomicMeter.Scale * new Vector3(1 / 20f, 1, 1));
        //levelProgressFlip = new Image("UI/levelbar75", atomicMeter.Position + new Vector3(atomicMeter.Size.x / 2.7f, atomicMeter.Size.x / 120f, -0.1f), Vector3.zero);//atomicMeter.Scale * new Vector3(1 / 20f, 1, 1));
        ItemsBG = new Image[5];
        ItemsImg = new Image[5];
        ItemsBuy = new GameButton[5];
        ItemsDes = new Image[5];

        Sprite[] spriteitem = Resources.LoadAll<Sprite>("UI/SidebarButtons");
        Sprite[] spriteDes = Resources.LoadAll<Sprite>("UI/ItemDes");
        Sprite[] spriteBtn = Resources.LoadAll<Sprite>("UI/ItemBuyBtn");

        //Item 1
        ItemsBG[0] = new Image("UI/Shop_Item", shopBG.Position - new Vector3(shopBG.Size.x / 3f, shopBG.Size.y / 250f, 1.5f), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        ItemsImg[0] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[36], ItemsBG[0].Position + new Vector3(0, ItemsBG[0].Size.y / 3.5f, -1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 1f);
        ItemsBuy[0] = new GameButton("buy1", spriteBtn[1], spriteitem[1], ItemsBG[0].Position - new Vector3(0, ItemsBG[0].Size.y / 2.8f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        ItemsBuy[0].ButtonTapEvent = BUY_ITEM_CLICK;
        ItemsBuy[0].EventValue = 1;
        ItemsDes[0] = new Image(spriteDes[0], ItemsBG[0].Position - new Vector3(0, ItemsBG[0].Size.y / 225f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);
        leftPos = ItemsBG[0].Position.x;

        //Item2
        ItemsBG[1] = new Image("UI/Shop_Item", ItemsBG[0].Position + new Vector3(ItemsBG[0].Size.x * 1.1f, 0, 0), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        ItemsImg[1] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[45], ItemsBG[1].Position + new Vector3(0, ItemsBG[1].Size.y / 3.5f, -1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 1f);
        ItemsBuy[1] = new GameButton("quit", spriteBtn[1], spriteBtn[1], ItemsBG[1].Position - new Vector3(0, ItemsBG[1].Size.y / 2.8f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        ItemsBuy[1].ButtonTapEvent = BUY_ITEM_CLICK;
        ItemsBuy[1].EventValue = 2;
        ItemsDes[1] = new Image(spriteDes[1], ItemsBG[1].Position - new Vector3(0, ItemsBG[1].Size.y / 225f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);

        //Item 3
        ItemsBG[2] = new Image("UI/Shop_Item", ItemsBG[1].Position + new Vector3(ItemsBG[1].Size.x * 1.1f, 0, 0), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        ItemsImg[2] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[54], ItemsBG[2].Position + new Vector3(0, ItemsBG[2].Size.y / 3.5f, -1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 1f);
        ItemsBuy[2] = new GameButton("quit", spriteBtn[1], spriteBtn[1], ItemsBG[2].Position - new Vector3(0, ItemsBG[2].Size.y / 2.8f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        ItemsBuy[2].ButtonTapEvent = BUY_ITEM_CLICK;
        ItemsBuy[2].EventValue = 3;
        ItemsDes[2] = new Image(spriteDes[2], ItemsBG[2].Position - new Vector3(0, ItemsBG[2].Size.y / 225f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);
        rightPos = ItemsBG[2].Position.x;

        //Item 4
        ItemsBG[3] = new Image("UI/Shop_Item", ItemsBG[2].Position + new Vector3(ItemsBG[2].Size.x * 1.1f, 0, 0), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        ItemsImg[3] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[63], ItemsBG[3].Position + new Vector3(0, ItemsBG[3].Size.y / 3.5f, -1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 1f);
        ItemsBuy[3] = new GameButton("quit", spriteBtn[1], spriteBtn[1], ItemsBG[3].Position - new Vector3(0, ItemsBG[3].Size.y / 2.8f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        ItemsBuy[3].ButtonTapEvent = BUY_ITEM_CLICK;
        ItemsBuy[3].EventValue = 4;
        ItemsDes[3] = new Image(spriteDes[3], ItemsBG[3].Position - new Vector3(0, ItemsBG[3].Size.y / 225f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);

        //Item 5
        ItemsBG[4] = new Image("UI/Shop_Item", ItemsBG[3].Position + new Vector3(ItemsBG[3].Size.x * 1.1f, 0, 0), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        ItemsImg[4] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[72], ItemsBG[4].Position + new Vector3(0, ItemsBG[4].Size.y / 3.5f, -1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 1f);
        ItemsBuy[4] = new GameButton("quit", spriteBtn[1], spriteBtn[1], ItemsBG[4].Position - new Vector3(0, ItemsBG[4].Size.y / 2.8f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        ItemsBuy[4].ButtonTapEvent = BUY_ITEM_CLICK;
        ItemsBuy[4].EventValue = 5;
        ItemsDes[4] = new Image(spriteDes[4], ItemsBG[4].Position - new Vector3(0, ItemsBG[4].Size.y / 225f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);


        //Item 6
        /*
        ItemsBG[5] = new Image("UI/Shop_Item", ItemsBG[4].Position + new Vector3(ItemsBG[4].Size.x * 1.1f, 0, 0), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        ItemsImg[5] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[1], ItemsBG[5].Position + new Vector3(0, ItemsBG[5].Size.y / 3.5f, -1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 1);
        ItemsBuy[5] = new GameButton("quit", spriteBtn[1], spriteBtn[1], ItemsBG[5].Position - new Vector3(0, ItemsBG[5].Size.y / 2.8f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        ItemsBuy[5].ButtonTapEvent = BUY_ITEM_CLICK;
        ItemsBuy[5].EventValue = 6;
        ItemsDes[5] = new Image(spriteDes[4], ItemsBG[5].Position - new Vector3(0, ItemsBG[5].Size.y / 225f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);
        */
        //Item 7
        /*
        ItemsBG[5] = new Image("UI/Shop_Item", ItemsBG[4].Position + new Vector3(ItemsBG[4].Size.x * 1.1f, 0, 0), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        ItemsImg[5] = new Image("UI/level", shopBG.Position + new Vector3(shopBG.Size.x / 2.9f, shopBG.Size.y / 2.5f, 1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.15f);
        ItemsBuy[5] = new GameButton("quit", spriteitem[4], spriteitem[5], ItemsBG[5].Position - new Vector3(0, ItemsBG[5].Size.y / 225f, 0.5f), Vector3.one * scaleRatio * 0.21f, 2);
        ItemsBuy[5].ButtonTapEvent = BUY_ITEM_CLICK;
        ItemsBuy[5].EventValue = 1;
        ItemsDes[5] = new Image("UI/level", shopBG.Position + new Vector3(shopBG.Size.x / 2.9f, shopBG.Size.y / 2.5f, -1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.15f);
        */

        for (int i = 0; i < 5; i++)
        {
            ItemsBG[i].Parent = shopPanel.transform;
            ItemsImg[i].Parent = shopPanel.transform;
            ItemsBuy[i].Parent = shopPanel.transform;
            ItemsDes[i].Parent = shopPanel.transform;
        }


        bagBG = new Image("UI/bagItem", shopBG.Position + new Vector3(-shopBG.Size.x / 3.4f, -shopBG.Size.y / 2.4f, -1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.45f);
        bagBG.Rotation = new Vector3(0, 0, 90);
        itemBagImg = new Image[3];


        Sprite[] spritesbutton = Resources.LoadAll<Sprite>("UI/SidebarButtons");


        quitButton = new GameButton("quit", "UI/Shop_close", shopBG.Position + new Vector3(shopBG.Size.x / 2.05f, shopBG.Size.y / 2.05f, -6.2f), Vector3.one * scaleRatio * 1.5f, 1);
        quitButton.ButtonTapEvent = QUIT_MENU;


        if (GM.bagItem != null && GM.bagItem.Count != 0)
        {
            for (int i = 0; i < GM.bagItem.Count; i++)
            {
                int typeitem = GM.bagItem[i];
                if (typeitem >= 112 && typeitem <= 115)
                {
                    itemBagImg[i] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[36 + (typeitem - 112) * 9], bagBG.Position + new Vector3(-bagBG.Size.x / 1.55f + (i + 1) * bagBG.Size.x / 3.1f, 0, -1.5f), new Vector3(1, 1, 1) * scaleRatio * 0.7f);
                }
            }
        }

        purchasePanel = new GameObject("PurchasePanel");
        purchasePanel.transform.position = new Vector3(0, 0, -7.5f);
        Image overlayPur = new Image("OverlayScreen", purchasePanel.transform.position + new Vector3(0, 0, 0), scaleRatio * Vector3.one * 5);
        overlayPur.Parent = purchasePanel.transform;
        SpriteRenderer spr = purchasePanel.AddComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>("OverlayScreen");
        purchasePanel.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);

        Image[] gemBG = new Image[4];
        gemBuy = new GameButton[4];
        Image[] gemDes = new Image[4];
        Image[] gemImg = new Image[4];
        Sprite[] spriteDesPlus = Resources.LoadAll<Sprite>("UI/ItemDesPlus");


        gemBG[0] = new Image("UI/Shop_Gem_Item", purchasePanel.transform.position - new Vector3(shopBG.Size.x / 5f, -shopBG.Size.y / 4f, 0.5f), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        gemImg[0] = new Image(Resources.LoadAll<Sprite>("UI/gembluelist")[0], gemBG[0].Position + new Vector3(0, gemBG[0].Size.y / 5.2f, -1.5f), new Vector3(0.35f, 0.35f, 1) * scaleRatio * 1f);
        gemBuy[0] = new GameButton("quit", spriteBtn[14], spriteBtn[14], gemBG[0].Position - new Vector3(0, gemBG[0].Size.y / 2.2f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        gemBuy[0].ButtonTapEvent = PURCHASE_CHOOSE_CLICK;
        gemBuy[0].EventValue = 1;
        gemDes[0] = new Image(spriteDesPlus[5], gemBG[0].Position - new Vector3(0, gemBG[0].Size.y / 6f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);


        gemBG[1] = new Image("UI/Shop_Gem_Item", purchasePanel.transform.position + new Vector3(shopBG.Size.x / 5f, shopBG.Size.y / 4f, -0.5f), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        gemImg[1] = new Image(Resources.LoadAll<Sprite>("UI/gembluelist")[1], gemBG[1].Position + new Vector3(0, gemBG[1].Size.y / 5.2f, -1.5f), new Vector3(0.35f, 0.35f, 1) * scaleRatio * 1f);
        gemBuy[1] = new GameButton("quit", spriteBtn[15], spriteBtn[15], gemBG[1].Position - new Vector3(0, gemBG[1].Size.y / 2.2f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        gemBuy[1].ButtonTapEvent = PURCHASE_CHOOSE_CLICK;
        gemBuy[1].EventValue = 2;
        gemDes[1] = new Image(spriteDesPlus[6], gemBG[1].Position - new Vector3(0, gemBG[1].Size.y / 6f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);

        gemBG[2] = new Image("UI/Shop_Gem_Item", purchasePanel.transform.position + new Vector3(-shopBG.Size.x / 5f, -shopBG.Size.y / 4f, -0.5f), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        gemImg[2] = new Image(Resources.LoadAll<Sprite>("UI/gembluelist")[2], gemBG[2].Position + new Vector3(0, gemBG[2].Size.y / 5.2f, -1.5f), new Vector3(0.35f, 0.35f, 1) * scaleRatio * 1f);
        gemBuy[2] = new GameButton("quit", spriteBtn[16], spriteBtn[16], gemBG[2].Position - new Vector3(0, gemBG[2].Size.y / 2.2f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        gemBuy[2].ButtonTapEvent = PURCHASE_CHOOSE_CLICK;
        gemBuy[2].EventValue = 3;
        gemDes[2] = new Image(spriteDesPlus[7], gemBG[2].Position - new Vector3(0, gemBG[2].Size.y / 6f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);


        gemBG[3] = new Image("UI/Shop_Gem_Item", purchasePanel.transform.position - new Vector3(-shopBG.Size.x / 5f, shopBG.Size.y / 4f, 0.5f), new Vector3(1f, 1f, 1) * scaleRatio * 1);
        gemImg[3] = new Image(Resources.LoadAll<Sprite>("UI/gembluelist")[3], gemBG[3].Position + new Vector3(0, gemBG[3].Size.y / 5.2f, -1.5f), new Vector3(0.35f, 0.35f, 1) * scaleRatio * 1f);
        gemBuy[3] = new GameButton("quit", spriteBtn[17], spriteBtn[17], gemBG[3].Position - new Vector3(0, gemBG[3].Size.y / 2.2f, 0.5f), Vector3.one * scaleRatio * 0.8f, 1);
        gemBuy[3].ButtonTapEvent = PURCHASE_CHOOSE_CLICK;
        gemBuy[3].EventValue = 4;
        gemDes[3] = new Image(spriteDesPlus[8], gemBG[3].Position - new Vector3(0, gemBG[3].Size.y / 6.0f, 0.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.8f);

        for (int i = 0; i < 4; i++)
        {
            gemBG[i].Parent = purchasePanel.transform;
            gemBuy[i].Parent = purchasePanel.transform;
            gemDes[i].Parent = purchasePanel.transform;
            gemImg[i].Parent = purchasePanel.transform;
        }
        purchasePanel.SetActive(false);

        iap = new GameObject("MyIAP");
        iap.AddComponent<Purchaser>();


        //Daily Reward
        int time = -1;// PlayerPrefs.GetInt("lasttimereward", -1);
        int nowtime = System.DateTime.Now.Day * 1000000 + System.DateTime.Now.Month * 10000 + System.DateTime.Now.Year;
        if (time < 0 || time != nowtime)
        {
            //PlayerPrefs.SetInt("lasttimereward", nowtime);
            //Reward
            dailyGift = new GameButton("gift","UI/GiftBoxClose", shopBG.Position - new Vector3(shopBG.Size.x / 28f, shopBG.Size.y / 2.4f, 2.5f), Vector3.one * scaleRatio / 4.4f, 1);
            dailyGift.ButtonTapEvent = DAILY_REWARD_CLICK;
            /*
            Rigidbody2D rb = dailyGift.Object.AddComponent<Rigidbody2D>();
            dailyGift.Object.AddComponent<CircleCollider2D>().sharedMaterial = Resources.Load<PhysicsMaterial2D>("Effect/giftbounce");
            rb.gravityScale = 1;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            GameObject ground = new GameObject("ground");
            ground.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UI/music_progress_but");
            ground.transform.localScale = new Vector3(dailyGift.Scale.x * 4, dailyGift.Scale.y / 3, 1);
            ground.transform.position = new Vector3(dailyGift.Position.x, dailyGift.Position.y - dailyGift.Size.y / 1.8f, dailyGift.Position.z);
            Rigidbody2D rbgr = ground.AddComponent<Rigidbody2D>();
            ground.AddComponent<BoxCollider2D>();
            ground.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            rbgr.constraints = RigidbodyConstraints2D.FreezeAll;
            dailyGift.Position += new Vector3(0, dailyGift.Size.y / 3.4f, 0);
            */
        }

        audioBackground = (new GameObject("BGaudio")).AddComponent<AudioSource>();
        audioBackground.loop = true;
        if (GM.Mode == 1)
            audioBackground.clip = (AudioClip)Resources.Load("Sound/atomica_strategymode");
        else if (GM.Mode == 2)
            audioBackground.clip = (AudioClip)Resources.Load("Sound/atomica_action");
        audioBackground.Play();

        float musiclevel = PlayerPrefs.GetFloat("musiclevel", 1);
        StageMenu.SetAudioVolume(musiclevel);
    }

    // Update is called once per frame
    void Update()
    {
        int tapCount = 0;
        if (diamond.ScoreValue != GM.Diamond)
        {
            diamond.ChangeValue(GM.Diamond);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Press B " + ItemsBG[ItemsBG.Length - 1].Position.x + " vs " + rightPos + " : " + ItemsBG[0].Position.x + " vs " + leftPos);
            if (ItemsBG[ItemsBG.Length - 1].Position.x >= rightPos)
            {
                Debug.Log("Move left");
                shopPanel.transform.position += new Vector3(-GM.unit / 5, 0, 0);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (ItemsBG[0].Position.x <= leftPos)
            {
                shopPanel.transform.position += new Vector3(GM.unit / 5, 0, 0);
            }
            GM.Diamond *= 10;
            GM.Diamond += Random.Range(0, 9);
            if (GM.Diamond > 10000)
                GM.Diamond = 1;
            Debug.Log("Diamond " + GM.Diamond);
        }


        if (!DAILY_REWARD_CLICK.isHanddle)
        {
            if (dailyGift != null)
            {
                giftscale = (int)(Time.time * 1000);
                dailyGift.Scale = Vector3.one * scaleRatio / scaleline[giftscale / 20 % scaleline.Length];
            }
        }
        if (DAILY_REWARD_CLICK.isHanddle)
        {
            if (DAILY_REWARD_CLICK.type <= 0)
            {
                DAILY_REWARD_CLICK.type = (int)(Time.time * 1000);
                giftscale = (int)(Time.time * 1000);
                dailyDialog = new Image("UI/daily_free_dialog", new Vector3(0, 0, -8), Vector3.one * scaleRatio * 0.2f);
                dailyOKBtn = new GameButton("dailyOK", "UI/ClaimButton", dailyDialog.Position - new Vector3(0, dailyDialog.Size.y / 2f, 0.1f), Vector3.one * scaleRatio * 0.2f);
                dailyOKBtn.ButtonTapEvent = DAILY_OK_CLICK;
            }
            if ((int)(Time.time * 1000) - DAILY_REWARD_CLICK.type < 1500)
            {
                Debug.Log("Gift " + ((int)(Time.time * 1000) - giftscale)+"  TIME " + (int)(Time.time * 1000) );
                dailyGift.ChangeSprite(Resources.LoadAll<Sprite>("UI/GiftBoxOpen")[((int)(Time.time * 1000) - giftscale) / 100 % 5]);
            }
            else
            {
                //Trước khi click Nhận gem
                if (listgemAnim.Count <= 0)
                {
                    if (overlayGift == null)
                    {
                        overlayGift = new Image("OverlayScreen", new Vector3(0, 0, -6f), scaleRatio * Vector3.one * 5);
                        overlayGift.Alpha = 0.7f;
                    }
                    if (dailyDialog.Scale < scaleRatio * 0.8f)
                    {
                        dailyDialog.Scale += 0.03f;
                        dailyOKBtn.Scale += Vector3.one * 0.03f;
                        dailyOKBtn.Position -= new Vector3(0, dailyDialog.Size.x / 150, 0);
                    }
                }
                if (DAILY_OK_CLICK.isHanddle)
                {
                    if (listgemAnim.Count == 0)
                    {
                        listgemAnim.Add(new Image("UI/gemblueS", dailyDialog.Position + new Vector3(dailyDialog.Size.x / 25f, -dailyDialog.Size.y / 100, -0.5f), new Vector3(1f, 1f, 1) * scaleRatio * 1.0f));
                        listgemAnim.Add(new Image("UI/gemblueS", dailyDialog.Position + new Vector3(dailyDialog.Size.x / 25f, -dailyDialog.Size.y / 100f, -0.5f), new Vector3(1f, 1f, 1) * scaleRatio * 1.0f));
                        DAILY_OK_CLICK.type = (int)(Time.time * 1000);
                        xI = listgemAnim[0].Position.x + (diamond.Position.x - listgemAnim[0].Position.x) / 2f;
                        //listgemAnim[1].Position += new Vector3((diamond.Position.x - listgemAnim[0].Position.x) / 2f, dailyDialog.Size.x / 4, 0);
                        listgemAnim[0].state = 0;
                        listgemAnim[1].state = 200;

                        //đỉnh xI
                        //y = (xI - x) / a * x^2 => qua xI, y đổi chiều / di chuyển tốc độ x^2 / hệ số a = tốc độ di chuyển = tỷ lệ x/y thêm điều chỉnh

                    }
                    else
                    {
                        if (listgemAnim[0] != null && !listgemAnim[0].isDie)
                        {
                            //Move list gems Anim
                            float x = listgemAnim[0].Position.x + listgemAnim[0].Size.x / 10f;
                            float xi = listgemAnim[0].Size.x / 10f;
                            float y = listgemAnim[0].Position.y + xi * xi * (xI - x) / (listgemAnim[0].Size.x / 15);
                            listgemAnim[0].Position = new Vector3(x, y, listgemAnim[0].Position.z);
                            if (listgemAnim[0].Position.y < diamond.Position.y)
                            {
                                listgemAnim[0].Destroy();
                                GM.Diamond++;
                            }
                        }
                        if (listgemAnim[1] != null && !listgemAnim[1].isDie)
                        {
                            listgemAnim[1].state -= (int)(Time.deltaTime * 1000);
                            if (listgemAnim[1].state <= 0)
                            {
                                float x = listgemAnim[1].Position.x + listgemAnim[1].Size.x / 10f;
                                float xi = listgemAnim[1].Size.x / 10f;
                                float y = listgemAnim[1].Position.y + xi * xi * (xI - x) / (listgemAnim[1].Size.x / 15);
                                listgemAnim[1].Position = new Vector3(x, y, listgemAnim[1].Position.z);
                                if (listgemAnim[1].Position.y < diamond.Position.y)
                                {
                                    listgemAnim[1].Destroy();
                                    GM.Diamond++;
                                }
                            }
                        }
                    }
                    if (dailyDialog != null)
                    {
                        dailyDialog.Alpha -= 0.05f;
                        dailyOKBtn.Alpha -= 0.05f;
                        overlayGift.Alpha -= 0.05f;
                    }
                    if ((int)(Time.time * 1000) - DAILY_OK_CLICK.type > 1200 || dailyDialog.Alpha <= 0)
                    {
                        dailyDialog.Destroy();
                        dailyDialog = null;
                        dailyOKBtn.Destroy();
                        dailyOKBtn = null;
                        overlayGift.Destroy();
                        overlayGift = null;

                        int nowtime = System.DateTime.Now.Day * 1000000 + System.DateTime.Now.Month * 10000 + System.DateTime.Now.Year;
                        PlayerPrefs.SetInt("lasttimereward", nowtime);

                        DAILY_OK_CLICK.type = -1;
                        DAILY_OK_CLICK.isHanddle = false;
                        DAILY_REWARD_CLICK.isHanddle = false;
                        DAILY_REWARD_CLICK.type = -1;
                    }
                }
                if (dailyOKBtn != null)
                    dailyOKBtn.Update();
            }
            return;
        }

        if (!purchasePanel.activeSelf)//PURCHASE_CLICK.isHanddle)
        {
            if (PURCHASE_CLICK.isHanddle)
            {
                PURCHASE_CLICK.isHanddle = false;
                purchasePanel.SetActive(true);
            }
        }
        else
        {
            if (PURCHASE_CHOOSE_CLICK.isHanddle && PURCHASE_CHOOSE_CLICK.type > 0)
            {
                iap.GetComponent<Purchaser>().BuyConsumable(PURCHASE_CHOOSE_CLICK.type - 1);
                PURCHASE_CHOOSE_CLICK.isHanddle = false;
            }
            
            while (tapCount < Input.touches.Length)
            {
                Touch touch = Input.GetTouch(tapCount);
                tapCount++;

                Vector2 positionToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
                bool buttonClick = false;
                if (touch.phase == TouchPhase.Ended)
                {
                    for (int i = 0; i < 4; i++)
                        if (Pos.Contains(gemBuy[i].Position, gemBuy[i].Size, positionToWorldPoint))
                        {
                            buttonClick = true;
                        }
                }
                //if (!buttonClick || PURCHASE_COMPLETE.isHanddle)
                //    purchasePanel.SetActive(false);
                //Rect rectClick = new Rect(x:gemBuy[0].Position.x,y:gemBuy[1].Position.,width:,height:)
                if (Pos.Contains(Vector3.zero, new Vector3(gemBuy[1].Position.x - gemBuy[0].Position.x + gemBuy[0].Size.x * 2, gemBuy[0].Position.y - gemBuy[2].Position.y + shopBG.Size.y / 2, 0), positionToWorldPoint))
                {

                }
                else
                    purchasePanel.SetActive(false);
            }
            
            for (int i = 0; i < 4; i++)
                if (gemBuy[i] != null)
                    gemBuy[i].Update();

                return;
        }
        if (PURCHASE_COMPLETE.isHanddle)
        {

        }
        if (ItemsBG[ItemsBG.Length - 1].Position.x < rightPos)
            shopPanel.transform.position += new Vector3(rightPos - ItemsBG[ItemsBG.Length - 1].Position.x, 0, 0);
        if (ItemsBG[0].Position.x > leftPos)
            shopPanel.transform.position -= new Vector3(ItemsBG[0].Position.x - leftPos, 0, 0);
        while (tapCount < Input.touches.Length)
        {
            Touch touch = Input.GetTouch(tapCount);
            tapCount++;

            Vector2 positionToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);


            if (Pos.Contains(Vector3.zero, new Vector3(shopBG.Size.x, shopBG.Size.y / 1.4f, 0), positionToWorldPoint))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    touchpos = positionToWorldPoint.x;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {


                }
                else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    if (ItemsBG[ItemsBG.Length - 1].Position.x >= rightPos - (shopBG.Size.x / 5) && ItemsBG[0].Position.x <= leftPos + shopBG.Size.x / 7f)
                    {
                        shopPanel.transform.position += new Vector3(positionToWorldPoint.x - touchpos, 0, 0);
                        
                    }
                    
                    touchpos = positionToWorldPoint.x;
                }
                else
                {

                }


            }

        }
       
        //Click Buy Item
        if (BUY_ITEM_CLICK.isHanddle)
        {
            if (BUY_ITEM_CLICK.type >= 1 && BUY_ITEM_CLICK.type < 6)
            {
                if (GM.Diamond > 1 && (GM.bagItem != null && GM.bagItem.Count < 3))
                {
                    GM.Diamond -= 2;
                    Debug.Log("Item " + BUY_ITEM_CLICK.type);
                    if (BUY_ITEM_CLICK.type == 1)
                        GM.bagItem.Add(112);
                    if (BUY_ITEM_CLICK.type == 2)
                        GM.bagItem.Add(113);
                    if (BUY_ITEM_CLICK.type == 3)
                        GM.bagItem.Add(114);
                    if (BUY_ITEM_CLICK.type == 4)
                        GM.bagItem.Add(115);
                    if (BUY_ITEM_CLICK.type == 5)
                        GM.bagItem.Add(116);
                    ReSetBag();
                }
                //if (BUY_ITEM_CLICK.type == 5)
                //    iap.GetComponent<Purchaser>().BuyConsumable(0);

                UserData.Save();
            }
            BUY_ITEM_CLICK.isHanddle = false;
        }

        if (QUIT_MENU.isHanddle)
        {
            if (parentSceneCode == 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
            QUIT_MENU.isHanddle = false;
            //QUIT_MENU.type = 0;
            return;
        }

        //Update Component
        for (int i = 0; i < 5; i++)
            ItemsBuy[i].Update();

        if (quitButton != null)
            quitButton.Update();
        if (purchaseButton != null)
            purchaseButton.Update();
        if (dailyGift != null)
            dailyGift.Update();


    }

    void ReSetBag()
    {
        if (GM.bagItem == null || GM.bagItem.Count == 0)
            return;
        int typeitem = GM.bagItem[GM.bagItem.Count - 1];
        if (typeitem >= 112 && typeitem <= 116)
        {
            itemBagImg[GM.bagItem.Count - 1] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[36 + (typeitem - 112) * 9], bagBG.Position + new Vector3(-bagBG.Size.x / 1.55f + GM.bagItem.Count * bagBG.Size.x / 3.1f, 0, -1.5f), new Vector3(1, 1, 1) * scaleRatio * 0.7f);
        }
    }



}
