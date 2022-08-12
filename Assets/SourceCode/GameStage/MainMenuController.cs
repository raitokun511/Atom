using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;


public class MainMenuController : MonoBehaviour {

    public static Event PLAY_EVENT = new Event();
    public static Event BG_ANIMATION = new Event();
    public static Event QUIT_EVENT = new Event();
    public static Event PLAY_TYPE_EVENT = new Event();
    public static Event DEL_DATA_EVENT = new Event();
    public static Event GO_SHOP_EVENT = new Event();
    public static Event TEST_MODE_EVENT = new Event();


    public Image gameBG;
    public Image logo;
    public Image leftdoor;
    public Image rightdoor;
    public GameButton overlayScreen;
    

    public GameButton strategyButton;
    public GameButton actionButton;
    public GameButton linenormalButton;
    public GameButton adventureButton;
    public GameButton quitButton;
    public PiecesTexture savedStrategyButton;
    public PiecesTexture newStrategyButton;
    public GameButton expertStrategyButton;
    public PiecesTexture savedActionButton;
    public PiecesTexture newActionButton;
    public GameButton expertActionButton;
    public GameButton shopButton;
    public Image shopcart;

    public GameButton scene1;
    public GameButton scene2;
    public GameButton scene3;
    public GameButton scene4;

    public GameButton deleteDataBtn;

    Texture2D text;
    public PiecesTexture greenoverStr;
    public PiecesTexture rollStr;
    public PiecesTexture greenoverAct;
    public PiecesTexture rollAct;
    public PiecesTexture greenoverLine;

    public Image strategyLogo;
    public Image actionLogo;
    public Image lineName;
    public Image lineDes;


    public static AudioSource auIntro;

    AudioSource audioBackground;
    AudioSource doorslam;
    AudioSource dooropen;

    int timeAnim = -1;
    int timeBegin = -1;
    int timeButton = 0;
    bool havesavedStra = false;
    bool havesavedAct = false;



    Event BACK_MAIN_EVENT = new Event();

    public Text debugText;
    public Button loginBtn;


    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    void Start()
    {
        GM.debugText = this.debugText;
        GM.Init();
        //UserData.Delete();
        UserData.Load();


        Vector3 camPos = Camera.main.transform.position;
        float scaleRatio = GM.ScaleSizeBG();

        gameBG = new Image("UI/MenuPanel", new Vector3(camPos.x, camPos.y + GM.unit * 20, -1), new Vector3(1.15f, 1, 1) * GM.unit * 1.2f * scaleRatio);//new Vector3(GM.unit * 2.7f, GM.unit * 2.7f, 1f));
        leftdoor = new Image(Resources.LoadAll<Sprite>("UI/MenuDoors")[0], new Vector3(camPos.x - GM.width / 2, camPos.y, -0.9f), new Vector3(1.15f, 1, 1) * GM.unit * 1.4f * scaleRatio);//new Vector3(GM.unit * 2.7f, GM.unit * 2.7f, 1f));
        rightdoor = new Image(Resources.LoadAll<Sprite>("UI/MenuDoors")[1], new Vector3(camPos.x + GM.width / 2, camPos.y, -0.9f), new Vector3(1.15f, 1, 1) * GM.unit * 1.4f * scaleRatio);//new Vector3(GM.unit * 2.7f, GM.unit * 2.7f, 1f));
        Image overlayTreasure = new Image("OverlayScreen", gameBG.Position + new Vector3(0, 0, 1f), scaleRatio * Vector3.one * 5);

        logo = new Image("UI/menulogo", new Vector3(camPos.x, camPos.y + gameBG.Size.y / 2.8f, -3), new Vector3(1.15f, 1, 1) * GM.unit * 1.7f * scaleRatio);

        Sprite[] mainbuttons = Resources.LoadAll<Sprite>("UI/main_type");
        Sprite[] mainlogos = Resources.LoadAll<Sprite>("UI/GametypeImages");
        text = Resources.Load<Texture2D>("UI/greenover_xborder");

        strategyButton = new GameButton("strategy", mainbuttons[0], mainbuttons[0], new Vector3(gameBG.Position.x , gameBG.Position.y + gameBG.Size.y / 3.45f, -2), gameBG.ExtraScale * 0.82f, 10);//new Vector3(GM.unit * 2.5f, GM.unit * 2.5f, 1), 10);
        strategyButton.ButtonTapEvent = PLAY_EVENT;
        strategyButton.EventValue = 1;
        strategyLogo = new Image(mainlogos[0], strategyButton.Position - new Vector3(strategyButton.Size.x / 2.6f, 0, 0.1f), strategyButton.Scale * 1.3f);
        strategyLogo.Color = new Color(56f / 255f, 1, 0);

        actionButton = new GameButton("action", mainbuttons[1], mainbuttons[1], new Vector3(gameBG.Position.x , gameBG.Position.y + gameBG.Size.y / 10, -2), gameBG.ExtraScale * 0.82f, 10);
        actionButton.ButtonTapEvent = PLAY_EVENT;
        actionButton.EventValue = 2;
        actionLogo = new Image(mainlogos[1], actionButton.Position - new Vector3(actionButton.Size.x / 2.6f, 0, 0.1f), actionButton.Scale * 1.3f);
        actionLogo.Color = new Color(56f / 255f, 1, 0);

        linenormalButton = new GameButton("action", mainbuttons[1], mainbuttons[1], new Vector3(gameBG.Position.x, gameBG.Position.y - gameBG.Size.y / 10, -2), gameBG.ExtraScale * 0.82f, 10);
        linenormalButton.ButtonTapEvent = PLAY_EVENT;
        linenormalButton.EventValue = 3;
        greenoverLine = new PiecesTexture(text, linenormalButton.Position + new Vector3(0, linenormalButton.Size.y / 2.1f, -0.5f), new Vector3(gameBG.ExtraScale.x * 1.4f, gameBG.ExtraScale.y * 0.75f, 1), new Rect(0, 0, text.width, text.height), new Vector2(0.5f, 1f));
        lineName = new Image(Resources.LoadAll<Sprite>("UI/LineMain")[0], linenormalButton.Position - new Vector3(linenormalButton.Size.x / 6.6f, - linenormalButton.Size.y / 4, 0.6f), actionButton.Scale * 1.0f);
        lineDes = new Image(Resources.LoadAll<Sprite>("UI/LineMain")[1], linenormalButton.Position - new Vector3(linenormalButton.Size.x / 11f, linenormalButton.Size.y / 10, 0.6f), actionButton.Scale * 1.0f);

        
        //shopButton = new GameButton("UI/Shop_2", "UI/Shop_2", new Vector3(gameBG.Position.x - gameBG.Size.x / 6, gameBG.Position.y - gameBG.Size.y / 3, -2.1f), gameBG.ExtraScale * 0.7f);
        //shopButton.ButtonTapEvent = GO_SHOP_EVENT;
        //shopcart = new Image("UI/Shop_Cart", new Vector3(gameBG.Position.x - gameBG.Size.x / 3, gameBG.Position.y - gameBG.Size.y / 3, -2.2f), gameBG.ExtraScale * 0.7f);
        

        //actionLogo = new Image(mainlogos[1], actionButton.Position - new Vector3(actionButton.Size.x / 2.6f, 0, 0.1f), actionButton.Scale * 1.3f);
        //actionLogo.Color = new Color(56f / 255f, 1, 0);

        //deleteDataBtn = new GameButton("delete", "UI/AtomicBombSymbol", new Vector3(gameBG.Position.x - gameBG.Size.x / 2.5f, 0 - gameBG.Size.y / 2.45f, -3), gameBG.ExtraScale * 0.3f, 1);
        //deleteDataBtn.ButtonTapEvent = DEL_DATA_EVENT;
        //quitButton.EventValue = 2;
        BG_ANIMATION.isHanddle = true;
        havesavedAct = AquaData.CheckSavedAction();
        havesavedStra = AquaData.CheckSavedStrategy();
        loadAudio();

        /*
        scene1 = new GameButton("UI/Shop_2", "UI/Shop_2", new Vector3(gameBG.Position.x , - gameBG.Size.y / 3, -2.1f), gameBG.ExtraScale * 0.3f);
        scene1.ButtonTapEvent = TEST_MODE_EVENT;
        scene1.EventValue = 1;
        scene2 = new GameButton("UI/Shop_2", "UI/Shop_2", new Vector3(gameBG.Position.x + gameBG.Size.x / 8,  - gameBG.Size.y / 3, -4.1f), gameBG.ExtraScale * 0.3f);
        scene2.ButtonTapEvent = TEST_MODE_EVENT;
        scene2.EventValue = 2;
        scene3 = new GameButton("UI/Shop_2", "UI/Shop_2", new Vector3(gameBG.Position.x + gameBG.Size.x / 5, - gameBG.Size.y / 3, -4.1f), gameBG.ExtraScale * 0.3f);
        scene3.ButtonTapEvent = TEST_MODE_EVENT;
        scene3.EventValue = 3;
        scene4 = new GameButton("UI/Shop_2", "UI/Shop_2", new Vector3(gameBG.Position.x + gameBG.Size.x / 2.3f, - gameBG.Size.y / 3, -4.1f), gameBG.ExtraScale * 0.3f);
        scene4.ButtonTapEvent = TEST_MODE_EVENT;
        scene4.EventValue = 4;
        */
    }

    // Update is called once per frame
    void Update()
    {
        //scene1.Update();
        //scene2.Update();
        //scene3.Update();
        //scene4.Update();
        if (TEST_MODE_EVENT.isHanddle)
        {
            if (TEST_MODE_EVENT.type == 1)
                GM.TestMode = 30;
            if (TEST_MODE_EVENT.type == 2)
                GM.TestMode = 40;
            if (TEST_MODE_EVENT.type == 3)
                GM.strategyLevel = 19;
            if (TEST_MODE_EVENT.type == 4)
                GM.strategyLevel = 8;
            GM.Mode = 1;
            SceneManager.LoadScene("GameMain");
            TEST_MODE_EVENT.isHanddle = false;
        }

        if (BG_ANIMATION.isHanddle)
        {
            if (leftdoor.Position.x < -leftdoor.Size.x / 2)
                leftdoor.Position += new Vector3(GM.unit / 4, 0, 0);
            if (rightdoor.Position.x > rightdoor.Size.x / 2)
                rightdoor.Position -= new Vector3(GM.unit / 4, 0, 0);
            //else
            if (!(leftdoor.Position.x < -leftdoor.Size.x / 2 && rightdoor.Position.x > rightdoor.Size.x / 2))
            {
                if (timeAnim <= 0)
                {
                    timeAnim = (int)(Time.time * 1000);
                    doorslam.Play();
                }

            }
            if (timeAnim > 0 && (int)(Time.time * 1000) - timeAnim > 500)
            {
                if (gameBG.Position.y > 0)
                {
                    gameBG.Position -= new Vector3(0, GM.unit, 0);
                    strategyButton.Position -= new Vector3(0, GM.unit, 0);
                    actionButton.Position -= new Vector3(0, GM.unit, 0);
                    strategyLogo.Position -= new Vector3(0, GM.unit, 0);
                    actionLogo.Position -= new Vector3(0, GM.unit, 0);
                    linenormalButton.Position -= new Vector3(0, GM.unit, 0);
                    if (shopButton != null)
                        shopButton.Position -= new Vector3(0, GM.unit, 0);
                    if (shopcart != null)
                        shopcart.Position -= new Vector3(0, GM.unit, 0);
                    greenoverLine.Position -= new Vector3(0, GM.unit, 0);
                    lineName.Position -= new Vector3(0, GM.unit, 0);
                    lineDes.Position -= new Vector3(0, GM.unit, 0);
                }
                else
                {
                    gameBG.Position -= new Vector3(0, gameBG.Position.y, 0);
                    BG_ANIMATION.isHanddle = false;
                }
            }
            
            
        }




        if ((int)(Time.time * 1000) - timeBegin < 1000)
        {
            return;
        }

        if (PLAY_TYPE_EVENT.isHanddle)
        {
            PLAY_EVENT.isHanddle = false;

            if ((int)(Time.time * 1000) - PLAY_TYPE_EVENT.type % 100000000 < 200)
            {
                if (GM.Mode == 1 && PLAY_TYPE_EVENT.type / 100000000 == 1)
                {
                    if ((int)(Time.time * 1000) - PLAY_TYPE_EVENT.type % 100000000 < 100 && havesavedStra)
                        savedStrategyButton.Color = Color.yellow;
                    else
                        savedStrategyButton.Color = new Color(74f / 255f, 188f / 255f, 47f / 255f);
                    return;
                }
                else if (GM.Mode == 1 && PLAY_TYPE_EVENT.type / 100000000 == 2)
                {
                    if ((int)(Time.time * 1000) - PLAY_TYPE_EVENT.type % 100000000 < 100)
                        newStrategyButton.Color = Color.yellow;
                    else
                        newStrategyButton.Color = new Color(74f / 255f, 188f / 255f, 47f / 255f);
                    return;
                }
                if (GM.Mode == 2 && PLAY_TYPE_EVENT.type / 100000000 == 1)
                {
                    if ((int)(Time.time * 1000) - PLAY_TYPE_EVENT.type % 100000000 < 100 && havesavedAct)
                        savedActionButton.Color = Color.yellow;
                    else
                        savedActionButton.Color = new Color(74f / 255f, 188f / 255f, 47f / 255f);
                    return;
                }
                else if (GM.Mode == 2 && PLAY_TYPE_EVENT.type / 100000000 == 2)
                {
                    if ((int)(Time.time * 1000) - PLAY_TYPE_EVENT.type % 100000000 < 100)
                        newActionButton.Color = Color.yellow;
                    else
                        newActionButton.Color = new Color(74f / 255f, 188f / 255f, 47f / 255f);
                    return;
                }
            }
            if (PLAY_TYPE_EVENT.type / 100000000 == 1)
            {
                AquaData.Load();
                GM.SaveType = 1;
                MainMenuController.PLAY_EVENT.isHanddle = false;
                MainMenuController.PLAY_TYPE_EVENT.isHanddle = false;
                AtomStage.ResetEvent();
                Debug.Log("Load Save Game " + PLAY_TYPE_EVENT.type);
                AtomStage.CHOOSE_ITEM.isHanddle = false;
                SceneManager.LoadScene("GameMain");

            }
            else if (PLAY_TYPE_EVENT.type / 100000000 == 2)
            {
                if (GM.Mode == 1)
                    GM.ReSetStrategy();
                if (GM.Mode == 2)
                    GM.ReSetAction();
                GM.SaveType = 2;
                MainMenuController.PLAY_EVENT.isHanddle = false;
                MainMenuController.PLAY_TYPE_EVENT.isHanddle = false;
                AtomStage.ResetEvent();
                Debug.Log("Load New Game " + PLAY_TYPE_EVENT.type);
                ActionStage.CHOOSE_ITEM.isHanddle = false;
                SceneManager.LoadScene("GameMain");

            }
        }


        if (PLAY_EVENT.isHanddle)
        {
            if (timeButton <= 0)
            {
                timeButton = (int)(Time.time * 1000);
                if (PLAY_EVENT.type == 1)
                {
                    strategyButton.Scale *= 0.9f;
                    strategyLogo.Scale *= 0.9f;
                }
                if (PLAY_EVENT.type == 2)
                {
                    actionButton.Scale *= 0.9f;
                    actionLogo.Scale *= 0.9f;
                }
                if (PLAY_EVENT.type == 3)
                {
                    linenormalButton.Scale *= 0.9f;
                    lineName.Scale *= 0.9f;
                    lineDes.Scale *= 0.9f;
                }
                dooropen.Play();
                if (savedStrategyButton == null)
                {
                    //savedStrategyButton = new GameButton("savedStra", "UI/ctn_saved_game", strategyButton.Position - new Vector3(strategyButton.Size.x / 4, 0, 1), strategyButton.Scale.y * Vector3.one);
                    //newStrategyButton = new GameButton("newStra", "UI/play_a_new", strategyButton.Position - new Vector3(strategyButton.Size.x / 4, 0, 1), strategyButton.Scale.y * Vector3.one);
                    //savedStrategyButton.Scale = new Vector3(savedStrategyButton.Scale.x, 0, savedStrategyButton.Scale.z);
                    //newStrategyButton.Scale = new Vector3(newStrategyButton.Scale.x, 0, newStrategyButton.Scale.z);
                    Texture2D textsaved = Resources.Load<Texture2D>("UI/ctn_saved_game_white");
                    Texture2D textnew = Resources.Load<Texture2D>("UI/play_a_new_white");
                    Texture2D textroll = Resources.Load<Texture2D>("UI/separte_roll");
                    greenoverStr = new PiecesTexture(text, strategyButton.Position + new Vector3(0, strategyButton.Size.y / 2, -0.5f), new Vector3(gameBG.ExtraScale.x * 1.4f, gameBG.ExtraScale.y * 0.75f, 1), new Rect(0, 0, text.width, text.height), new Vector2(0.5f, 1f));
                    rollStr = new PiecesTexture(textroll, strategyButton.Position + new Vector3(0, strategyButton.Size.y / 1.8f, -0.6f), new Vector3(gameBG.ExtraScale.x * 0.75f, gameBG.ExtraScale.x * 0.75f, 1), new Rect(0, 0, textroll.width, textroll.height), new Vector2(0.5f, 1f));
                    savedStrategyButton = new PiecesTexture(textsaved, strategyButton.Position + new Vector3(-strategyButton.Size.x / 8, strategyButton.Size.y / 2.3f, -1), strategyButton.Scale.x * Vector3.one, new Rect(0, 0, textsaved.width, 0), new Vector2(0.5f, 1f));
                    newStrategyButton = new PiecesTexture(textnew, strategyButton.Position + new Vector3(strategyButton.Size.x / 5, strategyButton.Size.y / 2.3f, -1), strategyButton.Scale.x * Vector3.one, new Rect(0, 0, textnew.width, 0), new Vector2(0.5f, 1f));
                    savedStrategyButton.Color = new Color(74f / 255f, 188f / 255f, 47f / 255f);
                    newStrategyButton.Color = new Color(74f / 255f, 188f / 255f, 47f / 255f);
                    savedStrategyButton.Margin = new Vector3(0, -savedStrategyButton.Size.y / 2, 0);
                    newStrategyButton.Margin = new Vector3(0, -newStrategyButton.Size.y / 2, 0);
                    //}
                    //else if (PLAY_EVENT.type == 2 && savedActionButton == null)
                    //{
                    //Texture2D text = Resources.Load<Texture2D>("UI/greenover_xborder");
                    //Texture2D textsaved = Resources.Load<Texture2D>("UI/ctn_saved_game");
                    //Texture2D textnew = Resources.Load<Texture2D>("UI/play_a_new");
                    greenoverAct = new PiecesTexture(text, actionButton.Position + new Vector3(0, actionButton.Size.y / 2, -0.5f), new Vector3(gameBG.ExtraScale.x * 1.4f, gameBG.ExtraScale.y * 0.75f, 1), new Rect(0, 0, text.width, text.height), new Vector2(0.5f, 1f));
                    rollAct = new PiecesTexture(textroll, actionButton.Position + new Vector3(0, actionButton.Size.y / 2, -0.6f), new Vector3(gameBG.ExtraScale.x * 0.75f, gameBG.ExtraScale.x * 0.75f, 1), new Rect(0, 0, textroll.width, textroll.height), new Vector2(0.5f, 1f));
                    savedActionButton = new PiecesTexture(textsaved, actionButton.Position + new Vector3(-actionButton.Size.x / 8, actionButton.Size.y / 2.5f, -1), actionButton.Scale.x * Vector3.one, new Rect(0, 0, textsaved.width, 0), new Vector2(0.5f, 1f));
                    newActionButton = new PiecesTexture(textnew, actionButton.Position + new Vector3(actionButton.Size.x / 5, actionButton.Size.y / 2.5f, -1), actionButton.Scale.x * Vector3.one, new Rect(0, 0, textnew.width, 0), new Vector2(0.5f, 1f));
                    savedActionButton.Color = new Color(74f / 255f, 188f / 255f, 47f / 255f);
                    newActionButton.Color = new Color(74f / 255f, 188f / 255f, 47f / 255f);
                    savedActionButton.Margin = new Vector3(0, -savedStrategyButton.Size.y / 2, 0);
                    newActionButton.Margin = new Vector3(0, -newStrategyButton.Size.y / 2, 0);
                }
            }
            if ((int)(Time.time * 1000) - timeButton < 200)
                return;
            //AquaData.LoadData();
            if (PLAY_EVENT.type == 1)
            {
                strategyButton.Disable();
                actionButton.Enable();
                if (strategyButton.Scale.x  < gameBG.ExtraScale.x * 0.82f)
                {
                    strategyButton.Scale *= 1.01f;
                    strategyLogo.Scale *= 1.01f;
                }
                //if (savedStrategyButton.Scale.y < savedStrategyButton.Scale.x)
                //    savedStrategyButton.Scale += new Vector3(0, savedStrategyButton.Scale.x / 30f, 0);

                //Debug.Log("srect " + savedStrategyButton.Rect.width);
                savedStrategyButton.ReRect(new Rect(0, 0, savedStrategyButton.Rect.width, savedStrategyButton.Rect.height + 4 <= 39 ? savedStrategyButton.Rect.height + 4 : 39));
                newStrategyButton.ReRect(new Rect(0, 0, newStrategyButton.Rect.width, newStrategyButton.Rect.height + 4 <= 39 ? newStrategyButton.Rect.height + 4 : 39));
                greenoverStr.ReRect(new Rect(0, 0, greenoverStr.Rect.width, greenoverStr.Rect.height + 8 <= 75 ? greenoverStr.Rect.height + 8: 75));
                rollStr.ReRect(new Rect(0, 0, rollStr.Rect.width, rollStr.Rect.height + 8 <= 75 ? rollStr.Rect.height + 8 : 75));

                if (savedActionButton != null)
                {
                    savedActionButton.ReRect(new Rect(0, 0, savedActionButton.Rect.width, savedActionButton.Rect.height - 8 >= 0 ? savedActionButton.Rect.height - 8 : 0));
                    newActionButton.ReRect(new Rect(0, 0, newActionButton.Rect.width, newActionButton.Rect.height - 8 >= 0 ? newActionButton.Rect.height - 8 : 0));
                    greenoverAct.ReRect(new Rect(0, 0, greenoverAct.Rect.width, greenoverAct.Rect.height - 8 >= 0 ? greenoverAct.Rect.height - 8 : 0));
                    rollAct.ReRect(new Rect(0, 0, rollAct.Rect.width, rollAct.Rect.height - 8 >= 0 ? rollAct.Rect.height - 8 : 0));

                }
                if (havesavedStra)
                {
                    savedStrategyButton.ButtonTapEvent = PLAY_TYPE_EVENT;
                }
                else
                {
                    savedStrategyButton.Color = Color.grey;
                    savedStrategyButton.Enable = false;
                }
                savedStrategyButton.EventValue = 100000000 + (int)(Time.time * 1000);
                newStrategyButton.ButtonTapEvent = PLAY_TYPE_EVENT;
                newStrategyButton.EventValue = 200000000 + (int)(Time.time * 1000);

            }
            if (PLAY_EVENT.type == 2)
            {
                actionButton.Disable();
                strategyButton.Enable();
                if (actionButton.Scale.x < gameBG.ExtraScale.x * 0.82f)
                {
                    actionButton.Scale *= 1.01f;
                    actionLogo.Scale *= 1.01f;
                }

                savedActionButton.ReRect(new Rect(0, 0, savedActionButton.Rect.width, savedActionButton.Rect.height + 4 <= 39 ? savedActionButton.Rect.height + 4 : 39));
                newActionButton.ReRect(new Rect(0, 0, newActionButton.Rect.width, newActionButton.Rect.height + 4 <= 39 ? newActionButton.Rect.height + 4 : 39));
                greenoverAct.ReRect(new Rect(0, 0, greenoverAct.Rect.width, greenoverAct.Rect.height + 8 <= 75 ? greenoverAct.Rect.height + 8 : 75));
                rollAct.ReRect(new Rect(0, 0, rollAct.Rect.width, rollAct.Rect.height + 8 <= 75 ? rollAct.Rect.height + 8 : 75));

                if (savedStrategyButton != null)
                {
                    savedStrategyButton.ReRect(new Rect(0, 0, savedStrategyButton.Rect.width, savedStrategyButton.Rect.height - 8 >= 0 ? savedStrategyButton.Rect.height - 8 : 0));
                    newStrategyButton.ReRect(new Rect(0, 0, newStrategyButton.Rect.width, newStrategyButton.Rect.height - 8 >= 0 ? newStrategyButton.Rect.height - 8 : 0));
                    greenoverStr.ReRect(new Rect(0, 0, greenoverStr.Rect.width, greenoverStr.Rect.height - 8 >= 0 ? greenoverStr.Rect.height - 8 : 0));
                    rollStr.ReRect(new Rect(0, 0, rollStr.Rect.width, rollStr.Rect.height - 8 >= 0 ? rollStr.Rect.height - 8 : 0));

                }
                if (havesavedAct)
                {
                    savedActionButton.ButtonTapEvent = PLAY_TYPE_EVENT;
                }
                else
                {
                    savedActionButton.Enable = false;
                    savedActionButton.Color = Color.grey;
                }
                savedActionButton.EventValue = 100000000 + (int)(Time.time * 1000);
                newActionButton.ButtonTapEvent = PLAY_TYPE_EVENT;
                newActionButton.EventValue = 200000000 + (int)(Time.time * 1000);
            }
            if (PLAY_EVENT.type == 3)
            {
                if (linenormalButton.Scale.x < gameBG.ExtraScale.x * 0.82f)
                {
                    linenormalButton.Scale *= 1.01f;
                    linenormalButton.Scale *= 1.01f;
                    lineName.Scale *= 1.01f;
                    lineDes.Scale *= 1.01f;
                }
                GM.Mode = 3;
                GM.SaveType = 2;
                MainMenuController.PLAY_EVENT.isHanddle = false;
                MainMenuController.PLAY_TYPE_EVENT.isHanddle = false;
                AtomStage.ResetEvent();
                SceneManager.LoadScene("LineMain");
                return;
            }
            GM.Mode = PLAY_EVENT.type;
            if (GM.Mode == 1)
            {

            }
            else if (GM.Mode == 2)
            {

            }
            //if (GM.Mode < 3)
            //    SceneManager.LoadScene("GameMain");
            //PLAY_EVENT.isHanddle = false;

        }

        if (GO_SHOP_EVENT.isHanddle)
        {
            if (GO_SHOP_EVENT.type >= 100)
            {
                shopButton.Scale *= 1.01f;
                shopcart.Scale *= 1.01f;
            }
            if (GO_SHOP_EVENT.type <= 0)
            {
                GO_SHOP_EVENT.type = (int)(Time.time * 1000);
                shopButton.Scale *= 0.9f;
                shopcart.Scale *= 0.9f;
            }
            if ((int)(Time.time * 1000) - GO_SHOP_EVENT.type > 200)
            {
                ShopStage.parentSceneCode = 1;
                SceneManager.LoadScene("ShopItem");
                GO_SHOP_EVENT.isHanddle = false;
                GO_SHOP_EVENT.type = -1;
            }
            return;
        }


        if (DEL_DATA_EVENT.isHanddle)
        {
            //Application.Quit();
            AquaData.Delete();
            DEL_DATA_EVENT.isHanddle = false;
        }

        /*if (Event.UPDATE_NOW_EVENT.isHanddle)
        {
            Application.OpenURL("market://details?id=com.mono.mummy");
            Event.UPDATE_NOW_EVENT.isHanddle = false;
        }
        */


        actionButton.Update();
        strategyButton.Update();
        linenormalButton.Update();
        if (savedStrategyButton != null)
            savedStrategyButton.Update();
        if (newStrategyButton != null)
            newStrategyButton.Update();
        if (savedActionButton != null)
            savedActionButton.Update();
        if (newActionButton != null)
            newActionButton.Update();
        if (shopButton != null)
            shopButton.Update();

        //if (deleteDataBtn != null)
        //    deleteDataBtn.Update();

    }



    IEnumerator GetVersion()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://khuyenmaianuong.com/game/aquarium_version.php");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            //Debug.Log("version:" + +"  " + );



            if (GM.APP_VERSION < int.Parse(www.downloadHandler.text))
            {

                //CheckUpdate();
            }


        }
    }


    public void loadAudio()
    {
        GameObject BGAudioObject = GameObject.Find("BGaudio");
        if (BGAudioObject == null)
        {
            BGAudioObject = new GameObject("BGaudio");
            DontDestroyOnLoad(BGAudioObject);
            audioBackground = BGAudioObject.AddComponent<AudioSource>();
            audioBackground.loop = true;
            audioBackground.clip = (AudioClip)Resources.Load("Music/MainMenu");
            audioBackground.Play();
        }
        else
            BGAudioObject.GetComponent<AudioSource>().Play();

        GameObject go = new GameObject("doorslam");
        doorslam = go.AddComponent<AudioSource>();
        doorslam.loop = false;
        doorslam.clip = (AudioClip)Resources.Load("Sound/doorslam");

        go = new GameObject("dooropen");
        dooropen = go.AddComponent<AudioSource>();
        dooropen.loop = false;
        dooropen.clip = (AudioClip)Resources.Load("Sound/dooropen");

    }

}
