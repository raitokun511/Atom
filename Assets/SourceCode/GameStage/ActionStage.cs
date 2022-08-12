using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionStage
{
    public static Event TUT_TIME = new Event();
    public static Event BALL_START_MOVE_EVENT = new Event();
    public static Event BALL_MOVING_EVENT = new Event();
    public static Event BALL_MOVING_DONE_EVENT = new Event();
    public static Event GET_SCORE_ESTIMATE_EVENT = new Event();
    public static Event BALL_DELETE_ANIM_EVENT = new Event();
    public static Event ADD_SPECIAL_BALL_ANIM_EVENT = new Event();
    public static Event BALL_GROW_EVENT = new Event();
    public static Event CREATE_NEW_BALL_EVENT = new Event();
    public static Event GET_SCORE_AGAIN_EVENT = new Event();
    public static Event GRAVITY_EFFECT_EVENT = new Event();
    public static Event LEVEL_SUCCESS = new Event();
    public static Event NEXT_LEVEL_EVENT = new Event();
    public static Event GAME_OVER = new Event();
    public static Event WAITING_PLAYER_MOVE = new Event();
    public static Event BONUS_PATTERN_TIME = new Event();
    public static Event BONUS_DEL_ANIM_TIME = new Event();
    public static Event CREATE_BIO_BALL_EVENT = new Event();
    public static Event RETURN_GAME_EVENT = new Event();
    public static Event BONUSBALL_EFFECT_TIME = new Event();

    public static Event CHOOSE_ITEM = new Event();


    GameStageController parent;
    Vector3 rootBoardPos;// = new Vector3(-GM.width / 2 + GM.unit, GM.height / 2 - GM.unit, 0);
    Image AtomRim;
    Image boardBG;
    Image blackborder;
    Image logchat;
    Image tipgr1;
    Image tipgr2;
    Image gameSlogan;
    PauseMenu nextlevelmenu;
    BonusFrame bonusFrame;
    public GameObject light;
    public Image glow;
    public GameObject Sound;

    List<Image> shadowholes;
    GameObject tornado;


    public Ball[,] board;
    int[] ballPath;
    List<Electron> elist;
    List<Effect> floatlist;


    Ball targetBall = null;
    Ball targetPos;
    Vector3 indexTargetBall;
    Vector3 indexTargetPos;
    Vector3 indexRunBall;
    Vector3 posRunBall;
    Vector3 targetTornado;
    int moveValue;
    int[,] pathMove;
    int typeReward;
    Sprite[] graphics;
    Image bonusword;

    int timeBeginDelete;

    //List<int> listNewBall = new List<int>();
    List<int> listBallGrow = new List<int>();
    List<int> listBallHazard = new List<int>();


    float cameraShake = 0;
    int extraNumberBall = 0;
    float scaleRatio;
    int timeTutBegin = -1;
    int strategState = 0;
    int timeClickBall = -1;
    bool allballgrow = false;
    bool firstallgrow = false;
    bool isOver = false;
    int bonuseffectttype = 0;
    int bonusupgradetime = 0;
    bool initDone = false;

    public ActionStage()
    {
        //GM.strategyLevel = 34;
        GM.actionLevel = 1;
        GM.Init();
        GM.numberRow = 8;
        GM.numberColumn = 9;
        scaleRatio = GM.ScaleSizeBG();
        Ball.ResetBallSprite();
        Image overlay = new Image("UI/overlayBue", Vector3.zero, new Vector3(1.1f, 1, 1) * scaleRatio * 5f);
        AtomRim = new Image("UI/AtomicRim", new Vector3(GM.width / 9, -GM.unit / 4, -2), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
        if (GM.strategyLevel == 28)
            boardBG = new Image("UI/BoardBG8x9_pt", AtomRim.Position + new Vector3(0, AtomRim.Size.y / 20, 1), Vector3.one * scaleRatio * 0.205f);
        else
            boardBG = new Image("UI/BoardBG8x9", AtomRim.Position + new Vector3(0, AtomRim.Size.y / 20, 1), Vector3.one * scaleRatio * 0.205f);
        GM.BoardSize = boardBG.Size;
        GM.BoardPos = boardBG.Position;
        rootBoardPos = GM.BoardPos - GM.BoardSize / 2;
        blackborder = new Image("UI/blackborder", new Vector3(0, 0, -8), new Vector3(scaleRatio * 1.05f, scaleRatio, 1));
        shadowholes = new List<Image>();

        elist = new List<Electron>();
        floatlist = new List<Effect>();

        InitGame();
        CREATE_NEW_BALL_EVENT.type = 2;


    }
    public void InitGame()
    {
        GM.actionScore = 0;
        GM.actionmeter = 0;
        GM.combo = 0;
        if (GM.Mode == 1 && (GM.strategyLevel == 28 || GM.strategyLevel == 29))
        {
            boardBG.Destroy();
            if (GM.strategyLevel == 28)
                boardBG = new Image("UI/BoardBG8x9_pt", AtomRim.Position + new Vector3(0, AtomRim.Size.y / 20, 1), Vector3.one * scaleRatio * 0.205f);
            else
                boardBG = new Image("UI/BoardBG8x9", AtomRim.Position + new Vector3(0, AtomRim.Size.y / 20, 1), Vector3.one * scaleRatio * 0.205f);
        }
        if (board != null)
        {
            foreach (Ball ball in board)
            {
                if (ball != null && !ball.isDie)
                    ball.Destroy();
                //ball = null;
            }
            board = null;
        }
        board = new Ball[GM.numberColumn, GM.numberRow];
        Debug.Log("SaveType " + GM.SaveType +"  " + GM.boardacttype);
        List<Ball> liststart = new List<Ball>();

        if (GM.SaveType == 1 && GM.Mode == 1 && GM.boardstratype)
            liststart = LevelManager.LoadList(AquaData.Load());
        else if (GM.SaveType == 1 && GM.Mode == 2 && GM.boardacttype)
            liststart = LevelManager.LoadList(AquaData.Load());
        else
        {
            liststart = LevelManager.StartList();
        }
        for (int i = 0; i < liststart.Count; i++)
        {
            int x = liststart[i].index / 100;
            int y = liststart[i].index % 100;
            board[x, y] = liststart[i];
        }

        if (elist != null)
        {
            elist.RemoveAll(e => e != null);
            elist.Clear();
        }
        elist.Add(new Electron(liststart[0].type, 0, liststart[0], scaleRatio));
        elist.Add(new Electron(liststart[0].type, 1, liststart[0], scaleRatio));
        elist.Add(new Electron(liststart[0].type, 2, liststart[0], scaleRatio));

        elist.Add(new Electron(liststart[0].type, 3, liststart[0], scaleRatio));
        elist.Add(new Electron(liststart[0].type, 4, liststart[0], scaleRatio));
        elist.Add(new Electron(liststart[0].type, 5, liststart[0], scaleRatio));



        elist.Add(new Electron(liststart[0].type, 10, liststart[0], scaleRatio));
        elist.Add(new Electron(liststart[0].type, 11, liststart[0], scaleRatio));
        elist.Add(new Electron(liststart[0].type, 12, liststart[0], scaleRatio));

        elist.Add(new Electron(liststart[0].type, 13, liststart[0], scaleRatio));
        elist.Add(new Electron(liststart[0].type, 14, liststart[0], scaleRatio));
        elist.Add(new Electron(liststart[0].type, 15, liststart[0], scaleRatio));

        foreach (Electron e in elist)
            e.Disable();

        glow = new Image("Effect/StarBurst", new Vector3(0, 0, 0), boardBG.Scale * Vector3.one);
        glow.Alpha = 0.2f;

        GM.gameBeginTime = (int)(Time.time * 1000);
        GM.atomCollect = 0;
        GM.moculeMade = 0;
        GM.biggestCombo = 0;
        GM.bonusMocule = 0;
        GM.bonusUpgrade = 0;
        allballgrow = false;
        initDone = true;

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(TUT_TIME.isHanddle + " - " + TUT_TIME.type + " " +
            BALL_START_MOVE_EVENT.isHanddle + " " + BALL_MOVING_EVENT.isHanddle + " " + BALL_MOVING_DONE_EVENT.isHanddle + "  " +
            LEVEL_SUCCESS.isHanddle + "  bonus " + BONUS_DEL_ANIM_TIME.isHanddle + "  grav:" + GRAVITY_EFFECT_EVENT.isHanddle + " " + GRAVITY_EFFECT_EVENT.type);
            Debug.Log("first " + PlayerPrefs.GetInt("firstcombo", -1) + "  " + PlayerPrefs.GetInt("atomicbomb", -1));

        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //BFS.Print(board);
            Debug.Log("Mode:" + GM.Mode + "  " + GM.combo);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Break();
        }

        if ((int)(Time.time * 1000) - GM.gameBeginTime > 1200 && (int)(Time.time * 1000) - GM.gameBeginTime < 1400 && !Sound.GetComponent<Sound>().GoPlaying())
        {
            Sound.GetComponent<Sound>().Go();
        }
        if ((int)(Time.time * 1000) - GM.gameBeginTime < 500 && !Sound.GetComponent<Sound>().GetReadyPlaying())
        {
            Sound.GetComponent<Sound>().GetReady();
        }
        if ((int)(Time.time * 1000) - GM.gameBeginTime > 400 && !initDone)
            InitGame();


        if (gameSlogan != null && gameSlogan.state >= 100)
        {
            if (gameSlogan.state == 100)
            {
                gameSlogan.Alpha += 0.03f;
            }
            if (gameSlogan.state >= 120)
            {
                gameSlogan.Alpha -= 0.03f;
            }
            if (gameSlogan.Alpha >= 1 && gameSlogan.state < 120)
                gameSlogan.state++;
            //            listleveltext
        }

        if ((int)(Time.time * 1000) - GM.gameBeginTime > 200)
            boardBG.Alpha += 0.01f;

        if ((int)(Time.time * 1000) - GM.gameBeginTime < 1100 || !initDone)
            return;


        if ((int)(Time.time * 1000) - GM.gameBeginTime > 2000 && (int)(Time.time * 1000) - GM.gameBeginTime < 4000 &&
            gameSlogan != null && !gameSlogan.isDie && gameSlogan.Alpha <= 0)
        {
            gameSlogan.Destroy();
            gameSlogan = null;
        }

        foreach (Effect ef in floatlist)
            if (ef != null && ef.isLive)
                ef.Update();
        floatlist.RemoveAll(ef => ef == null || !ef.isLive);


        if (Event.SOUND_CHANGE.isHanddle)
        {
            Sound.GetComponent<Sound>().ChangeVolume();
            PlayerPrefs.SetFloat("soundlevel", GM.soundlevel);

            Event.SOUND_CHANGE.isHanddle = false;
        }


        if (Event.QUIT_PAUSE.isHanddle)
        {
            if (nextlevelmenu == null)
            {
                nextlevelmenu = new PauseMenu(2, Event.RETURN_MAIN_EVENT, RETURN_GAME_EVENT, Event.RETURN_MAIN_NOTSAVE_EVENT);
            }
            nextlevelmenu.Update();
            if (RETURN_GAME_EVENT.isHanddle)
            {
                nextlevelmenu.Destroy();
                nextlevelmenu = null;
                RETURN_GAME_EVENT.isHanddle = false;
                Event.QUIT_PAUSE.isHanddle = false;
            }
            if (Event.RETURN_MAIN_EVENT.isHanddle)
            {
                Debug.Log("Back Main and Save");
                Event.RETURN_MAIN_EVENT.isHanddle = false;
                Event.QUIT_PAUSE.isHanddle = false;
                if (GM.Mode == 1)
                    GM.boardstratype = true;
                if (GM.Mode == 2)
                    GM.boardacttype = true;
                AquaData.Save(board);
                SceneManager.LoadScene("MainMenu");
            }
            if (Event.RETURN_MAIN_NOTSAVE_EVENT.isHanddle)
            {
                Debug.Log("back main Not Save");
                Event.RETURN_MAIN_NOTSAVE_EVENT.isHanddle = false;
                Event.QUIT_PAUSE.isHanddle = false;
                SceneManager.LoadScene("MainMenu");

            }
            return;
        }
        if (Event.FINISH_ADS_EVENT.isHanddle)
        {
            //Reset game with not resset level
            if (GM.Mode == 1)
                GM.boardstratype = false;
            if (GM.Mode == 2)
                GM.boardacttype = false;
            //GM.strategyLevel++;
            Event.ReSetStageEvent();
            GM.gameBeginTime = (int)(Time.time * 1000);
            AtomStage.ResetEvent();
            strategState = 0;
            initDone = false;
            if (nextlevelmenu != null)
                nextlevelmenu.Destroy();
            nextlevelmenu = null;
            Event.FINISH_ADS_EVENT.isHanddle = false;
        }

        if (Event.OPTION_PAUSE.isHanddle)
        {
            if (nextlevelmenu == null)
                nextlevelmenu = new PauseMenu(2, Event.RETURN_MAIN_EVENT, RETURN_GAME_EVENT, Event.RETURN_MAIN_EVENT);
            nextlevelmenu.Update();
            if (RETURN_GAME_EVENT.isHanddle)
            {
                nextlevelmenu.Destroy();
                nextlevelmenu = null;
                Event.OPTION_PAUSE.isHanddle = false;
                RETURN_GAME_EVENT.isHanddle = false;
            }
            if (Event.RETURN_MAIN_EVENT.isHanddle)
            {
                //Load MainScene
            }
            if (Event.RETURN_MAIN_NOTSAVE_EVENT.isHanddle)
            {
                Debug.Log("back main Not Save");
                SceneManager.LoadScene("MainMenu");

            }
            return;
        }



        if (!(BONUSBALL_EFFECT_TIME.isHanddle && bonuseffectttype % 100 == 5))
        {
            if (shadowholes.Count <= 0 || shadowholes[shadowholes.Count - 1].Scale < scaleRatio * 0.2f)
            {
                if (shadowholes.Count > 0 && shadowholes[0].Scale < scaleRatio * 0.05f)
                {
                    shadowholes[0].Destroy();
                    shadowholes.RemoveAt(0);
                }
                Image shadowhole = new Image("Effect/poly", new Vector3(0, 0, -2), new Vector3(scaleRatio * 0.3f, scaleRatio * 0.3f, 1));
                shadowhole.Rotation = new Vector3(0, 0, Random.Range(0, 360));
                shadowhole.Alpha = 0.2f;
                shadowholes.Add(shadowhole);
            }
            if (shadowholes.Count > 0)
            {
                foreach (Image shh in shadowholes)
                {
                    shh.Scale -= 0.002f;
                    //shh.Alpha -= 0.001f;
                    //if (shh.Scale > scaleRatio * 0.2f && shh.Alpha < 0.1f)
                    //    shh.Alpha += 0.01f;
                }
            }
        }


        if (NEXT_LEVEL_EVENT.isHanddle)
        {
            Debug.Log("Next Level");
            nextlevelmenu.Destroy();
            nextlevelmenu = null;
            if (gameSlogan == null)
            {
                timeTutBegin = (int)(Time.time * 1000);
                gameSlogan = new Image(Resources.LoadAll<Sprite>("UI/bigwords")[2], GM.BoardPos + new Vector3(0, 0, -1f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
                gameSlogan.Alpha = 1;
                gameSlogan.state = 100;
            }

            NEXT_LEVEL_EVENT.isHanddle = false;
            LEVEL_SUCCESS.isHanddle = false;
            //AquaData.SaveData();
            //GM.strategyLevel++;
            //Event.ReSetStageEvent();
            //InitGame();

        }
        if (LEVEL_SUCCESS.isHanddle)
        {
            GM.actionmeter = 0;
            GM.actionLevel++;
            LEVEL_SUCCESS.isHanddle = false;
            Event.ACTION_LEVEL_BOMB_EVENT.isHanddle = true;
            Event.ACTION_LEVEL_BOMB_EVENT.type = 1;
        }

        if (GAME_OVER.isHanddle)
        {
            //Debug.Log("GAME Over " + GAME_OVER.type);
            if (GAME_OVER.type / 10000000 == 1)
            {
                for (int i = 0; i < GM.numberColumn; i++)
                {
                    for (int j = 0; j < GM.numberRow; j++)
                    {
                        if (board[i, j] != null && !board[i, j].isDie)
                        {
                            if ((int)(Time.time * 1000) - GAME_OVER.type % 10000000 < 1000)
                                board[i, j].OverAnimation();
                            else
                                board[i, j].isDelRotate = true;
                        }
                    }
                }
                Debug.Log("TimeOver " + GAME_OVER.type + "  Now:" + (int)(Time.time * 1000));
                if ((int)(Time.time * 1000) - GAME_OVER.type % 10000000 > 2000)
                {
                    GAME_OVER.type = 20000000 + (int)(Time.time * 1000);
                    gameSlogan = new Image(Resources.LoadAll<Sprite>("UI/bigwords")[1], GM.BoardPos + new Vector3(0, 0, -6f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
                    gameSlogan.state = 100;
                    gameSlogan.Alpha = 0.0f;
                    gameSlogan.AddAudio("Voice/gameover");
                    gameSlogan.PlaySound();
                }
            }
            else if (GAME_OVER.type / 10000000 == 2)
            {
                if ((int)(Time.time * 1000) - GAME_OVER.type % 10000000 > 2500)
                {
                    if (nextlevelmenu == null || nextlevelmenu.isDie)
                    {
                        nextlevelmenu = new PauseMenu(4, Event.CONTINUE_WITH_ADS, Event.RESTART_GAME, Event.SHOP_GOING);
                    }
                    if (nextlevelmenu != null && !nextlevelmenu.isDie)
                        nextlevelmenu.Update();
                    if (Event.CONTINUE_WITH_ADS.isHanddle)
                    {
                        Debug.Log("continue ads");
                        //Event.LEVEL_OVER_INFO_EVENT.isHanddle = true;
                        Event.WAITING_VIDEO_ADS_EVENT.isHanddle = true;
                        Event.CONTINUE_WITH_ADS.isHanddle = false;
                    }
                    if (Event.RESTART_GAME.isHanddle)
                    {
                        if (GM.Mode == 1)
                        {
                            GM.strategyLevel = 1;
                            GM.strategyScore = 0;
                            GM.bombMeter = 0;
                            GM.strategymeter = 0;
                        }
                        if (GM.Mode == 2)
                        {
                            GM.actionLevel = 1;
                            GM.actionScore = 0;
                            GM.bombMeter = 0;
                            GM.actionmeter = 0;
                        }
                        nextlevelmenu.Destroy();
                        nextlevelmenu = null;
                        if (GM.Mode == 1)
                            GM.boardstratype = false;
                        if (GM.Mode == 2)
                            GM.boardacttype = false;

                        Event.ReSetStageEvent();
                        GM.gameBeginTime = (int)(Time.time * 1000);
                        ActionStage.ResetEvent();
                        initDone = false;
                        strategState = 0;
                        Debug.Log("Restart Success");
                    }
                    if (Event.SHOP_GOING.isHanddle)
                    {

                    }
                }
            }
            //only for Action Stage
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                {
                    if (board[i, j] != null && !board[i, j].isDie)
                        board[i, j].Update();
                    if (board[i, j] != null && board[i, j].isDie)
                        board[i, j] = null;
                }
            return;
        }




        if (!firstallgrow)
        {
            firstallgrow = true;
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (board[i, j] != null && !board[i, j].isDie && board[i, j].isGrow)
                    {
                        board[i, j].Grow(true);
                        if (board[i, j].stateAtom < 3)
                            firstallgrow = false;
                    }
            if (firstallgrow)
            {
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && !board[i, j].isDie && !board[i, j].isGrow && board[i, j].type < 100)
                            board[i, j].isGrow = true;
                
            }
            return;
        }
        if (GM.actionmeter > 1000 && !LEVEL_SUCCESS.isHanddle)
            LEVEL_SUCCESS.isHanddle = true;

        foreach (Electron e in elist)
            e.Update();


        if (BONUSBALL_EFFECT_TIME.isHanddle)
        {
            //Fire
            if (bonuseffectttype % 100 == 2)
            {
                bool exist = false;
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && !board[i, j].isDie && board[i,j].type >= 100 && board[i, j].isExplode)
                        {
                            board[i, j].Explode();
                            exist = true;
                        }
                if (!exist)
                {
                    bonusword.Destroy();
                    BONUSBALL_EFFECT_TIME.isHanddle = false;
                    BONUSBALL_EFFECT_TIME.type = 0;
                }
                Debug.Log("do " + BONUSBALL_EFFECT_TIME.type + "  " + (int)(Time.time * 1000));
                if (((int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type) > 500 && bonusword != null && !bonusword.isDie)
                {
                    bonusword.Alpha -= 0.01f;
                }

                return;
            }
            //Ice 103, 203 ...
            else if (bonuseffectttype % 100 == 3)
            {
                if ((bonuseffectttype / 100 == 1 && (int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type > 10000) ||
                    (bonuseffectttype / 100 == 2 && (int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type > 18000) ||
                    (bonuseffectttype / 100 == 3 && (int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type > 22000))
                {
                    BONUSBALL_EFFECT_TIME.isHanddle = false;
                    BONUSBALL_EFFECT_TIME.type = 0;
                    bonusword.Destroy();
                    boardBG.changeSprite(Resources.Load<Sprite>("UI/BoardBG8x9"));
                    StageMenu.ICE_TIME.isHanddle = true;
                    StageMenu.ICE_TIME.type = 200000000 + (int)(Time.time * 1000);
                }
                if (((int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type) > 500 && bonusword != null && !bonusword.isDie)
                {
                    bonusword.Alpha -= 0.01f;
                }
            }
            else if (bonuseffectttype % 100 == 4)
            {
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && !board[i, j].isDie && tornado != null && Pos.Contains(board[i, j].Position, board[i, j].Size, tornado.transform.position))
                        {
                            board[i, j].isDelRotate = true;
                        }
                //R = boardsize
                //vector pháp tuyến x1-x2, y1-y2, trung điểm x1+x2/2  y1+y2/2
                //xpt(xR-xI) + ypt(yR-yI) = 0
                //(xR-xI)^2 + (yR-yI)^2 = R^2
                tornado.transform.position = Vector3.MoveTowards(tornado.transform.position, targetTornado, boardBG.Size.x / 100f);
                if (tornado.transform.position.x == targetTornado.x && tornado.transform.position.y == targetTornado.y)
                {
                    targetTornado = new Vector3(boardBG.Position.x + Random.Range(-boardBG.Size.x / 2f, boardBG.Size.x / 2f),
                                    boardBG.Position.y + Random.Range(-boardBG.Size.y / 2f, boardBG.Size.y / 2f), 0);
                }
                if ((bonuseffectttype / 100 == 1 && (int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type > 10000) ||
                    (bonuseffectttype / 100 == 2 && (int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type > 20000))
                {
                    BONUSBALL_EFFECT_TIME.isHanddle = false;
                    BONUSBALL_EFFECT_TIME.type = 0;
                    bonusword.Destroy();
                }
                if (((int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type) > 500 && bonusword != null && !bonusword.isDie)
                {
                    bonusword.Alpha -= 0.01f;
                }
            }
            else if (bonuseffectttype % 100 == 5)
            {
                if ((bonuseffectttype / 100 == 1 && (int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type > 10000) ||
                    (bonuseffectttype / 100 == 2 && (int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type > 18000) ||
                    (bonuseffectttype / 100 == 3 && (int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type > 22000))
                {
                    BONUSBALL_EFFECT_TIME.isHanddle = false;
                    BONUSBALL_EFFECT_TIME.type = 0;
                    bonusword.Destroy();
                    boardBG.Color = new Color(1, 1, 1);
                    //188 224 115 board
                    //92 219 20
                    foreach (Image shh in shadowholes)
                        shh.Destroy();
                    shadowholes.Clear();
                    StageMenu.ETHER_TIME.isHanddle = true;
                    StageMenu.ETHER_TIME.type = 200000000 + (int)(Time.time * 1000);
                }
                if (((int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type) > 500 && bonusword != null && !bonusword.isDie)
                {
                    bonusword.Alpha -= 0.01f;
                }
                if (shadowholes.Count > 0)
                {
                    foreach (Image shh in shadowholes)
                    {
                        if (shh.Position.x > 0)
                        {
                            shh.Position -= new Vector3(Random.Range(boardBG.Size.x / 100, boardBG.Size.x / 30), 0, 0);
                            if (shh.Position.x < GM.width / 4f)
                                shh.Alpha -= 0.005f;
                            if (shh.Position.x <= 0)
                            {
                                shh.Position = new Vector3(Random.Range(GM.width / 2f, GM.width / 1.8f), Random.Range(-GM.height / 2f, GM.height / 2f), -2);
                                shh.Alpha = 0.2f;
                            }
                        }
                        else if (shh.Position.x < 0)
                        {
                            shh.Position += new Vector3(Random.Range(boardBG.Size.x / 100, boardBG.Size.x / 30), 0, 0);
                            if (shh.Position.x > -GM.width / 4f)
                                shh.Alpha -= 0.005f;
                            if (shh.Position.x >= 0)
                            {
                                shh.Position = new Vector3(-Random.Range(GM.width / 2f, GM.width / 1.8f), Random.Range(-GM.height / 2f, GM.height / 2f), -2);
                                shh.Alpha = 0.2f;
                            }
                        }
                    }
                }
            }
            else if (bonuseffectttype % 100 == 6)
            {
                if ((int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type > 1000)
                {
                    BONUSBALL_EFFECT_TIME.isHanddle = false;
                    BONUSBALL_EFFECT_TIME.type = 0;
                    bonusword.Destroy();
                }
                if (((int)(Time.time * 1000) - BONUSBALL_EFFECT_TIME.type) > 500 && bonusword != null && !bonusword.isDie)
                {
                    bonusword.Alpha -= 0.01f;
                }
            }
        }

        for (int i = 0; i < GM.numberColumn; i++)
            for (int j = 0; j < GM.numberRow; j++)
            {
                if (board[i, j] != null && !board[i, j].isDie)
                    board[i, j].Update();
                if (board[i, j] != null && board[i, j].isDie)
                    board[i, j] = null;
            }


        if (CREATE_BIO_BALL_EVENT.isHanddle)
        {
            BioCreate();
            return;
        }
        if (Event.ACTION_LEVEL_BOMB_EVENT.isHanddle)
        {
            if (Event.ACTION_LEVEL_BOMB_EVENT.type == 1)
            {
                List<int> listNoEmpty = new List<int>();
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && !board[i, j].isDie)
                        {
                            listNoEmpty.Add(i * 100 + j);
                        }

                int maxExplode = 3;
                for (int i = 0; i < maxExplode; i++)
                {
                    int rand = Random.Range(0, listNoEmpty.Count);
                    int index = listNoEmpty[rand];
                    board[index / 100, index % 100].isExplode = true;
                    board[index / 100, index % 100].timeExplode = (int)(Time.time * 1000) + 100 * i;
                }
                Event.ACTION_LEVEL_BOMB_EVENT.type = 2;
            }
            else if (Event.ACTION_LEVEL_BOMB_EVENT.type == 2)

            {
                bool exist = false;
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && !board[i, j].isDie && board[i,j].type >= 100 && board[i, j].isExplode)
                        {
                            int res = board[i, j].Explode();
                            if (res == 1)
                                Sound.GetComponent<Sound>().Nuke();
                            exist = true;
                        }
                if (!exist)
                {
                    Event.ACTION_LEVEL_BOMB_EVENT.isHanddle = false;
                    Event.ACTION_LEVEL_BOMB_EVENT.type = 0;
                }
            }
        }
        if (Event.BOMB_HIT_EVENT.isHanddle)
        {
            if (Event.BOMB_HIT_EVENT.type <= 0)
                Event.BOMB_HIT_EVENT.type = 1000000 + (int)(Time.time * 1000);
            if ((int)(Time.time * 1000) - Event.BOMB_HIT_EVENT.type % 1000000 < 500 && !Sound.GetComponent<Sound>().AtomicBombPlaying())
                Sound.GetComponent<Sound>().AtomicBomb();
            if ((int)(Time.time * 1000) - Event.BOMB_HIT_EVENT.type % 1000000 < 800)
                return;
            if (cameraShake > 0)
            {
                Vector3 shakevec = Random.insideUnitSphere * boardBG.Size.x / 30;
                Camera.main.transform.localPosition = new Vector3(shakevec.x, shakevec.y, Camera.main.transform.localPosition.z);
                cameraShake -= Time.deltaTime * 1.0f;

            }
            else
            {
                cameraShake = 0.0f;
                Camera.main.transform.localPosition = new Vector3(0, 0, Camera.main.transform.localPosition.z);
            }
            if (Event.BOMB_HIT_EVENT.type / 1000000 == 1)
            {
                List<int> listNoEmpty = new List<int>();
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && !board[i, j].isDie && board[i,j].type >= 100)
                        {
                            listNoEmpty.Add(i * 100 + j);
                        }

                int maxExplode = listNoEmpty.Count > GM.bombMeter ? GM.bombMeter : listNoEmpty.Count;
                for (int i = 0; i < maxExplode; i++)
                {
                    int rand = Random.Range(0, listNoEmpty.Count);
                    int index = listNoEmpty[rand];
                    board[index / 100, index % 100].isExplode = true;
                    board[index / 100, index % 100].timeExplode = (int)(Time.time * 1000) + 100 * i;
                }
                Event.BOMB_HIT_EVENT.type = 2000000;
                cameraShake = 1.5f;
            }
            else if (Event.BOMB_HIT_EVENT.type / 1000000 == 2)
            {
                bool exist = false;
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isExplode)
                        {
                            int res = board[i, j].Explode();
                            if (res == 1)
                                Sound.GetComponent<Sound>().Nuke();
                            exist = true;
                        }
                if (!exist)
                {
                    Event.BOMB_HIT_EVENT.isHanddle = false;
                    Event.BOMB_HIT_EVENT.type = 0;
                }
            }
            return;
        }

        if (!BONUS_PATTERN_TIME.isHanddle && !BONUS_DEL_ANIM_TIME.isHanddle && bonusupgradetime <= 0)
        {
            if (GM.Mode == 2 && GM.actionmeter > 2 && Random.Range(0, 100) > 110 - GM.actionmeter * 10)
            {
                int typebonus = BonusFrame.levelRandomBonus(GM.actionLevel, false);
                bonusFrame = new BonusFrame(typebonus / 1000000, (typebonus % 1000000) / 100000, (typebonus % 100000) / 10000);
                bonusFrame.DelayPosition(-new Vector3(GM.BoardSize.x / 4f, 0, 0));
                BONUS_PATTERN_TIME.isHanddle = true;
                BONUS_PATTERN_TIME.type = typebonus;//1120000
                Sound.GetComponent<Sound>().BonusMoleculeReady();
            }
        }
        if (!BONUS_PATTERN_TIME.isHanddle && bonusFrame != null)
        {
            bonusFrame.DelTime = true;
            if (bonusFrame.isDie)
                bonusFrame = null;
        }
        if (bonusFrame != null && !bonusFrame.isDie)
            bonusFrame.Update();

        /*
        if (GRAVITY_EFFECT_EVENT.isHanddle && (GM.strategyLevel == 8 || GM.strategyLevel == 17 || GM.strategyLevel == 24
            || GM.strategyLevel == 29 || GM.strategyLevel == 33))
        {

            Gravity();
            return;

        }
        */

        if (BONUS_DEL_ANIM_TIME.isHanddle)
        {
            BallBonus();
            //return;
        }
        
        if (GET_SCORE_AGAIN_EVENT.isHanddle)
        {
            int tmptypeReward = -1;
            listBallGrow.AddRange(listBallHazard);
            int num = listBallGrow.Count;//listNewBall.Count;
                //GM.strategyLevel == 8 || GM.strategyLevel == 17 || GM.strategyLevel == 24 || GM.strategyLevel == 29 || GM.strategyLevel == 33
                //? GM.numberColumn * GM.numberRow : listBallGrow.Count;
            for (int k = 0; k < num; k++)
            {
                int x, y = 0;
                if (GM.strategyLevel == 8 || GM.strategyLevel == 17 || GM.strategyLevel == 24 || GM.strategyLevel == 29 || GM.strategyLevel == 33)
                {
                    x = k / GM.numberColumn;
                    y = k % GM.numberRow;
                }
                else
                {
                    x = listBallGrow[k] / 100;
                    y = listBallGrow[k] % 100;
                }

                typeReward = Estimate.EstimateRound(board, x, y);
                Debug.Log("GetAgain " + x + "," + y + " = " + typeReward);
                if (typeReward == 4)
                {
                    tmptypeReward = typeReward;
                    if (GM.Mode == 2)
                    {
                        GM.combo++;
                        GM.actionScore += GM.combo * 80;
                        GM.actionmeter -= 50;
                        GM.EstimateBombMeter(Sound.GetComponent<Sound>().AtomicReady());
                        GM.atomCollect += 4;
                        if (GM.combo > GM.biggestCombo)
                            GM.biggestCombo = GM.combo;
                        GM.moculeMade++;

                        floatlist.AddRange(LevelManager.FloatScore(GM.combo * 80, board[x, y]));
                        Sound.GetComponent<Sound>().Whoosh();

                    }
                }
                if (typeReward == 6)
                {
                    tmptypeReward = typeReward;
                    if (GM.Mode == 2)
                    {
                        GM.combo++;
                        GM.actionScore += GM.combo * 80;
                        GM.actionmeter -= 100;
                        GM.EstimateBombMeter(Sound.GetComponent<Sound>().AtomicReady());
                        GM.atomCollect += 6;
                        if (GM.combo > GM.biggestCombo)
                            GM.biggestCombo = GM.combo;
                        GM.moculeMade++;

                        floatlist.AddRange(LevelManager.FloatScore(GM.combo * 80, board[x, y]));
                        Sound.GetComponent<Sound>().Whoosh();

                    }

                }

            }
            typeReward = tmptypeReward;
            if (typeReward < 0)
            {
                CheckBonus();
            }
            else
            {
                if (GM.combo == 2)
                    Sound.GetComponent<Sound>().Combo();
                else if (GM.combo == 3)
                    Sound.GetComponent<Sound>().SuperCombo();
                else if (GM.combo == 4)
                    Sound.GetComponent<Sound>().MegaCombo();
                else if (GM.combo == 5)
                    Sound.GetComponent<Sound>().UltraCombo();
                else if (GM.combo == 6)
                    Sound.GetComponent<Sound>().HyperCombo();
                else if (GM.combo > 6)
                    Sound.GetComponent<Sound>().MaxCombo();
                Event.SCORE_CHANGE_EVENT.isHanddle = true;
                bonusupgradetime--;
            }

            listBallGrow.Clear();
            listBallHazard.Clear();
            GET_SCORE_AGAIN_EVENT.isHanddle = false;
            BALL_DELETE_ANIM_EVENT.isHanddle = true;
            BALL_DELETE_ANIM_EVENT.type = 2;
            timeBeginDelete = (int)(Time.time * 1000);
            Debug.Log("begin set timedelee " + timeBeginDelete + " (" + (int)(Time.time * 1000) + ")");

        }

        //Tạo Ball mới
        if (CREATE_NEW_BALL_EVENT.type <= 1)
        {
            Debug.Log("CreateNewBall " + CREATE_NEW_BALL_EVENT.type);

            List<int> listEmpty = new List<int>();
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (board[i, j] == null || board[i, j].isDie)
                    {
                        listEmpty.Add(i * 100 + j);
                    }
            //Tạo 6 Ball vòng 1
            extraNumberBall = GM.Mode == 1 && GM.strategyLevel == 1 && strategState == 0 ? 3 : 0;
            Debug.Log("new ball " + listEmpty.Count);
            for (int k = 0; k < 3 + extraNumberBall; k++)
            {
                if (listEmpty.Count > 0)
                {
                    int type = LevelManager.RandomBall();
                    int position = Random.Range(0, listEmpty.Count);
                    int value = listEmpty[position];
                    listEmpty.RemoveAt(position);

                    int i = value / 100;
                    int j = value % 100;
                    Debug.Log("new Ball " + i + " " + j);
                    board[i, j] = new Ball(type, i, j, false);
                    if (GM.Mode == 1)
                    {
                        if (GM.strategyLevel == 7 && Random.Range(0, 100) < 20)
                            board[i, j].Hazard = 5;
                        else if ((GM.strategyLevel == 26 || GM.strategyLevel == 22) && k == 2 && board[i, j].type != 20 && board[i, j].type != 120)
                            board[i, j].Hazard = 5;
                        else if ((GM.strategyLevel == 34) && board[i, j].type != 20 && board[i, j].type != 120)
                        {
                            if (k == 2 && Random.Range(0, 100) < 85)
                                board[i, j].Hazard = 5;
                            if (k == 0 && Random.Range(0, 100) < 20)
                                board[i, j].Hazard = 5;
                        }
                    }
                    //listNewBall.Add(value);
                }
                else
                {
                    //if (k == 0)
                    //    GAME_OVER.isHanddle = true;
                }

            }

            listEmpty.Clear();

            CREATE_NEW_BALL_EVENT.type = 2;

        }
        //During Grow Ball mới
        else if (CREATE_NEW_BALL_EVENT.type == 2)
        {
            int count = 0;
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (board[i, j] != null && !board[i, j].isDie && board[i, j].stateAtom < 3)
                    {
                        board[i, j].Grow();
                        count++;
                    }

            if (count <= 0)
            {
                CREATE_NEW_BALL_EVENT.type = 1;
                CREATE_NEW_BALL_EVENT.isHanddle = false;
                GET_SCORE_AGAIN_EVENT.isHanddle = true;
                strategState = 1;
            }
        }
        
        

        if (BALL_DELETE_ANIM_EVENT.isHanddle)
        {
            bool isWin = LevelManager.checkWin(GM.strategymeter, board);
            bool isClear = LevelManager.checkWin(GM.strategymeter, board, true);
            if (typeReward < 0 || (int)(Time.time * 1000) - timeBeginDelete > 1000)
            {
                //Debug.Log("timedelee " + timeBeginDelete + " (" + (int)(Time.time * 1000) + ")");
                for (int i = 0; i < GM.numberColumn; i++)
                {
                    for (int j = 0; j < GM.numberRow; j++)
                    {
                        if (board[i, j] != null && board[i, j].isScored)
                        {
                            //countBall(board[i, j]);
                            board[i, j].Destroy();
                            board[i, j] = null;
                        }
                    }
                }
                if (LevelManager.checkFail(GM.strategyScore, board))
                {
                    GAME_OVER.isHanddle = true;
                    GAME_OVER.type = 10000000 + (int)(Time.time * 1000);
                    BALL_DELETE_ANIM_EVENT.isHanddle = false;
                }
                else if (!isWin)
                {
                    BALL_DELETE_ANIM_EVENT.isHanddle = false;
                    if (GM.strategyLevel != 5 && GM.strategyLevel != 10 && GM.strategyLevel != 15 && GM.strategyLevel != 20 &&
                        GM.strategyLevel != 25 && GM.strategyLevel != 30)
                    {
                        Debug.Log("event " + BALL_DELETE_ANIM_EVENT.type + "  typereward " + typeReward);
                        //type == 1: Ăn ngay sau khi move => Tạo Ball mới
                        //type == 2: Ăn lần 2 khi GrowBall => Chờ Choose ball
                        if (typeReward <= 0 && BALL_DELETE_ANIM_EVENT.type == 1)
                        {
                            BALL_GROW_EVENT.isHanddle = true;
                            Sound.GetComponent<Sound>().AppearBall();
                        }
                        else if (typeReward > 0 && BALL_DELETE_ANIM_EVENT.type == 1)
                        {
                            if (GM.strategyLevel == 8 || GM.strategyLevel == 17 || GM.strategyLevel == 24 || GM.strategyLevel == 29 || GM.strategyLevel == 33)
                            {
                                GRAVITY_EFFECT_EVENT.isHanddle = true;
                                GRAVITY_EFFECT_EVENT.type = 300;
                                Debug.Log("GRAV go");
                            }
                        }
                    }

                }
            }
            else
            {
                if (typeReward > 0 && (int)(Time.time * 1000) - timeBeginDelete > 300 && TUT_TIME.type == 2 && GM.Mode == 1 && GM.strategyLevel == 1)
                {
                    TUT_TIME.isHanddle = true;
                    timeTutBegin = (int)(Time.time * 1000);
                }
                LogChatX();

                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].state < 100)
                        {
                            board[i, j].state = 100;
                            for (int x = -1; x < 2; x++)
                                for (int y = -1; y < 2; y++)
                                    if ((x != 0 || y != 0) && (x == 0 || y == 0) && i + x >= 0 && i + x < GM.numberColumn && j + y >= 0 && j + y < GM.numberRow)
                                        if (board[i + x, j + y] != null && !board[i + x, j + y].isDie && board[i + x, j + y].isScored)
                                        {
                                            Object pPrefab = Resources.Load("LightningBolt/Bolt"); // note: not .prefab!
                                            GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, new Vector3(0, 0, -5), Quaternion.identity);
                                            pNewObject.transform.GetChild(0).transform.position = board[i, j].Position;
                                            pNewObject.transform.GetChild(1).transform.position = board[i + x, j + y].Position;
                                            GameObject.Destroy(pNewObject, 0.9f);
                                            board[i + x, j + y].state = 100;
                                            Sound.GetComponent<Sound>().Electric();
                                        }
                        }

                for (int i = 0; i < GM.numberColumn; i++)
                {
                    for (int j = 0; j < GM.numberRow; j++)
                    {
                        if (board[i, j] != null && board[i, j].isScored)
                        {
                            board[i, j].DeleteAnimation();
                        }
                    }
                }
            }

        }

        if (GET_SCORE_ESTIMATE_EVENT.isHanddle)
        {
            //from targetPos... or targetBall
            //printPath();

            int x = (int)indexTargetPos.x;
            int y = (int)indexTargetPos.y;
            Debug.Log("GetScoreEst");
            GetScoreEstimate(x, y);

            //Check Level mission success

        }
        if (BALL_MOVING_DONE_EVENT.isHanddle)
        {
            //Debug.Log ("DONE MOVE with " + (board [(int)indexTargetPos.x, (int)indexTargetPos.y] != null ? "ball " : "null") + " , " + (board [(int)indexTargetBall.x, (int)indexTargetBall.y] != null ? "ball2 ": "null"));

            //Destroy if Ball Small Override
            if (board[(int)indexTargetPos.x, (int)indexTargetPos.y] != null)
            {
                int valueBall = ((int)indexTargetPos.x) * GM.numberColumn + (int)indexTargetPos.y;

                board[(int)indexTargetPos.x, (int)indexTargetPos.y].Destroy();
            }

            board[(int)indexTargetPos.x, (int)indexTargetPos.y] = board[(int)indexTargetBall.x, (int)indexTargetBall.y];
            board[(int)indexTargetPos.x, (int)indexTargetPos.y].RePos();
            board[(int)indexTargetBall.x, (int)indexTargetBall.y] = null;
            BALL_MOVING_DONE_EVENT.isHanddle = false;
            if (GM.strategyLevel == 8 || GM.strategyLevel == 17 || GM.strategyLevel == 24 || GM.strategyLevel == 29 || GM.strategyLevel == 33)
            {
                GRAVITY_EFFECT_EVENT.isHanddle = true;
                GRAVITY_EFFECT_EVENT.type = 100;
                Debug.Log("grav " + GRAVITY_EFFECT_EVENT.type);
            }
            else
                GET_SCORE_ESTIMATE_EVENT.isHanddle = true;
            //Debug.Log ("after " + (board [(int)indexTargetPos.x, (int)indexTargetPos.y] != null ? "ball " : "null") + " , " + (board [(int)indexTargetBall.x, (int)indexTargetBall.y] != null ? "ball2 ": "null"));
            return;
        }
        if (BALL_MOVING_EVENT.isHanddle)
        {
            foreach (Electron e in elist)
                e.Disable();
            BallMove();
            return;
        }
        if (BALL_START_MOVE_EVENT.isHanddle)
        {
            //Debug.Log ("IndexBall " + indexTargetBall.x + "  " + indexTargetBall.y + " =  " + board[(int)indexTargetBall.x, (int)indexTargetBall.y].type);
            //Debug.Log ("IndexPos " + indexTargetPos.x + "  " + indexTargetPos.y );
            //Debug.Log ("-------------------------------------------------------");
            pathMove = BFS.doBFS(board, indexTargetPos, indexTargetBall);

            Debug.Log("Finish Pos Value is: " + pathMove[(int)indexTargetBall.x, (int)indexTargetBall.y]);

            if (pathMove[(int)indexTargetBall.x, (int)indexTargetBall.y] > 0)
            {
                pathMove[(int)indexTargetPos.x, (int)indexTargetPos.y] = 0;
                indexRunBall = new Vector3(indexTargetBall.x, indexTargetBall.y, 0);
                Ball.BallMovingTime = (int)(Time.time * 1000);
                BALL_MOVING_EVENT.isHanddle = true;
                posRunBall = Ball.toIndex((int)indexRunBall.x, (int)indexRunBall.y);
            }
            else
            {
                light.transform.position = new Vector3(GM.BoardSize.x * 5, 0, 0);
                glow.Position = new Vector3(GM.BoardSize.x * 5, 0, 0);
            }
            BALL_START_MOVE_EVENT.isHanddle = false;
            return;
        }

        ChooseBall();

    }

    public void BioCreate()
    {
        if (CREATE_BIO_BALL_EVENT.type == 0)
        {
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (board[i, j] != null && board[i, j].Hazard <= 0 && board[i, j].checkHazard)
                    {
                        board[i, j].Hazard = 5;
                        List<int> listemp = new List<int>();
                        for (int x = -1; x < 2; x++)
                            for (int y = -1; y < 2; y++)
                                if (x != 0 || y != 0)
                                    if (i + x >= 0 && i + x < GM.numberColumn && j + y >= 0 && j + y < GM.numberRow && board[i + x, j + y] == null)
                                        listemp.Add((i + x) * 100 + (j + y));
                        if (listemp.Count > 0)
                        {
                            int val = listemp[Random.Range(0, listemp.Count)];
                            board[val / 100, val % 100] = new Ball(LevelManager.RandomBall(true), val / 100, val % 100, true);
                            //board[val / 100, val % 100] = new Ball(1, val / 100, val % 100, true);
                            board[val / 100, val % 100].Hazard = 5;
                            listBallHazard.Add(val);
                            Object pPrefab = Resources.Load("LightningBolt/Bolt"); // note: not .prefab!
                            GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, new Vector3(0, 0, -5), Quaternion.identity);
                            pNewObject.transform.GetChild(0).transform.position = board[i, j].Position;
                            pNewObject.transform.GetChild(1).transform.position = board[val / 100, val % 100].Position;
                            GameObject.Destroy(pNewObject, 1.3f);
                            Sound.GetComponent<Sound>().Electric();

                        }
                    }
            CREATE_BIO_BALL_EVENT.type = 1;
        }
        else if (CREATE_BIO_BALL_EVENT.type == 1)
        {
            bool exist = false;
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (board[i, j] != null && board[i, j].Hazard > 0 && board[i, j].type < 100)
                    {
                        board[i, j].Grow();
                        exist = true;
                    }
            if (!exist)
            {
                CREATE_BIO_BALL_EVENT.isHanddle = false;
                CREATE_BIO_BALL_EVENT.type = 0;
            }
        }

    }
    public void Gravity()
    {
        if (GRAVITY_EFFECT_EVENT.type % 100 == 0)
        {
            Debug.Log("grav count");
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                {
                    int isym = GM.numberColumn - i - 1;
                    int jsym = GM.numberRow - j - 1;
                    int idec = GM.numberColumn - i;
                    if (GM.strategyLevel == 8 && board[i, j] != null && board[i, j].type >= 100)
                    {
                        int k = j;
                        while (k > 0 && board[i, --k] == null)
                            board[i, j].gravitydrop++;
                        if (k > 0 && board[i, k] != null)
                            board[i, j].gravitydrop += board[i, k].gravitydrop;

                    }
                    if (GM.strategyLevel == 17 && board[isym, j] != null && board[isym, j].type >= 100)
                    {
                        int k = isym;
                        while (k + 1 < GM.numberColumn && board[++k, j] == null)
                            board[isym, j].gravitydrop++;
                        if (k + 1 < GM.numberColumn && board[k, j] != null)
                            board[isym, j].gravitydrop += board[k, j].gravitydrop;

                    }
                    if (GM.strategyLevel == 24 && board[i, jsym] != null && board[i, jsym].type >= 100)
                    {
                        int k = jsym;
                        while (k + 1 < GM.numberRow && board[i, ++k] == null)
                            board[i, jsym].gravitydrop++;
                        if (k + 1 < GM.numberRow && board[i, k] != null)
                            board[i, jsym].gravitydrop += board[i, k].gravitydrop;

                    }
                    if ((GM.strategyLevel == 29 || GM.strategyLevel == 33) && board[i, j] != null && board[i, j].type >= 100)
                    {
                        int k = i;
                        while (k > 0 && board[--k, j] == null)
                            board[i, j].gravitydrop++;
                        if (k > 0 && board[k, j] != null)
                            board[i, j].gravitydrop += board[k, j].gravitydrop;

                    }
                }

            GRAVITY_EFFECT_EVENT.type = 1 + (GRAVITY_EFFECT_EVENT.type / 100) * 100;
        }
        else if (GRAVITY_EFFECT_EVENT.type % 100 == 1 && (int)(Time.time * 1000) - Ball.BallMovingTime > 0)
        {
            Debug.Log("grav anim");
            bool moving = false;
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                {
                    int isym = GM.numberColumn - i - 1;
                    int jsym = GM.numberRow - j - 1;
                    if (GM.strategyLevel == 8 && board[i, j] != null && board[i, j].gravitydrop > 0)
                        if (board[i, j].Position.y != Ball.toIndex(i, j - board[i, j].gravitydrop).y)
                        {
                            Vector3 vectarget = Ball.toIndex(i, j - board[i, j].gravitydrop);
                            vectarget.z = board[i, j].Position.z;
                            board[i, j].Position = Vector3.MoveTowards(board[i, j].Position, vectarget, GM.BoardSize.y / 32);
                            Ball.BallMovingTime = (int)(Time.time * 1000);
                            moving = true;
                        }
                    if (GM.strategyLevel == 17 && board[isym, j] != null && board[isym, j].gravitydrop > 0)
                        if (board[isym, j].Position.x != Ball.toIndex(isym + board[isym, j].gravitydrop, j).x)
                        {
                            Vector3 vectarget = Ball.toIndex(isym + board[isym, j].gravitydrop, j);
                            vectarget.z = board[isym, j].Position.z;
                            board[isym, j].Position = Vector3.MoveTowards(board[isym, j].Position, vectarget, GM.BoardSize.x / 32);
                            Ball.BallMovingTime = (int)(Time.time * 1000);
                            moving = true;
                        }
                    if (GM.strategyLevel == 24 && board[i, jsym] != null && board[i, jsym].gravitydrop > 0)
                        if (board[i, jsym].Position.y != Ball.toIndex(i, jsym + board[i, jsym].gravitydrop).y)
                        {
                            Vector3 vectarget = Ball.toIndex(i, jsym + board[i, jsym].gravitydrop);
                            vectarget.z = board[i, jsym].Position.z;
                            board[i, jsym].Position = Vector3.MoveTowards(board[i, jsym].Position, vectarget, GM.BoardSize.y / 32);
                            Ball.BallMovingTime = (int)(Time.time * 1000);
                            moving = true;
                        }
                    if ((GM.strategyLevel == 29 || GM.strategyLevel == 33) && board[i, j] != null && board[i, j].gravitydrop > 0)
                        if (board[i, j].Position.x != Ball.toIndex(i - board[i, j].gravitydrop, j).x)
                        {
                            Vector3 vectarget = Ball.toIndex(i - board[i, j].gravitydrop, j);
                            vectarget.z = board[i, j].Position.z;
                            board[i, j].Position = Vector3.MoveTowards(board[i, j].Position, vectarget, GM.BoardSize.x / 32);
                            Ball.BallMovingTime = (int)(Time.time * 1000);
                            moving = true;
                        }
                }

            if (!moving)
            {
                Debug.Log("GRAVITY type " + GRAVITY_EFFECT_EVENT.type);
                //BallGrow after
                if (GRAVITY_EFFECT_EVENT.type / 100 == 2)
                    GET_SCORE_AGAIN_EVENT.isHanddle = true;
                else if (GRAVITY_EFFECT_EVENT.type / 100 == 3)
                {
                    BALL_GROW_EVENT.isHanddle = true;
                    Sound.GetComponent<Sound>().AppearBall();
                }
                else//if type / 100 <= 1, BallMove done after
                    GET_SCORE_ESTIMATE_EVENT.isHanddle = true;
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                    {
                        int isym = GM.numberColumn - i - 1;
                        int jsym = GM.numberRow - j - 1;
                        if (GM.strategyLevel == 8 && board[i, j] != null && board[i, j].gravitydrop > 0)
                        {
                            int y = j - board[i, j].gravitydrop;
                            board[i, j - board[i, j].gravitydrop] = board[i, j];
                            board[i, j].gravitydrop = 0;
                            board[i, j] = null;
                            board[i, y].RePos();

                        }
                        if (GM.strategyLevel == 17 && board[isym, j] != null && board[isym, j].gravitydrop > 0)
                        {
                            int x = isym + board[isym, j].gravitydrop;
                            board[isym + board[isym, j].gravitydrop, j] = board[isym, j];
                            board[isym, j].gravitydrop = 0;
                            board[isym, j] = null;
                            board[x, j].RePos();
                        }
                        if (GM.strategyLevel == 24 && board[i, jsym] != null && board[i, jsym].gravitydrop > 0)
                        {
                            int y = jsym + board[i, jsym].gravitydrop;
                            board[i, jsym + board[i, jsym].gravitydrop] = board[i, jsym];
                            board[i, jsym].gravitydrop = 0;
                            board[i, jsym] = null;
                            board[i, y].RePos();
                        }
                        if ((GM.strategyLevel == 29 || GM.strategyLevel == 33) && board[i, j] != null && board[i, j].gravitydrop > 0)
                        {
                            int x = i - board[i, j].gravitydrop;
                            board[i - board[i, j].gravitydrop, j] = board[i, j];
                            board[i, j].gravitydrop = 0;
                            board[i, j] = null;
                            board[x, j].RePos();
                        }
                    }
                GRAVITY_EFFECT_EVENT.isHanddle = false;
                GRAVITY_EFFECT_EVENT.type = 0;
            }
        }

    }

    void GetScoreEstimate(int x, int y)
    {

        typeReward = Estimate.EstimateRound(board, x, y);
        if (typeReward == 4)
        {
            if (GM.Mode == 2)
            {
                GM.combo++;
                GM.actionScore += GM.combo * 80;
                GM.actionmeter -= 50;
                GM.EstimateBombMeter(Sound.GetComponent<Sound>().AtomicReady());
                GM.atomCollect += 4;
                if (GM.combo > GM.biggestCombo)
                    GM.biggestCombo = GM.combo;
                GM.moculeMade++;

                floatlist.AddRange(LevelManager.FloatScore(GM.combo * 80, board[x, y]));
                Sound.GetComponent<Sound>().Whoosh();
            }
        }
        if (typeReward == 6)
        {
            if (GM.Mode == 2)
            {
                GM.combo += 2;
                GM.actionScore += GM.combo * 80;
                GM.actionmeter -= 80;
                GM.EstimateBombMeter(Sound.GetComponent<Sound>().AtomicReady());
                GM.atomCollect += 6;
                if (GM.combo > GM.biggestCombo)
                    GM.biggestCombo = GM.combo;
                GM.moculeMade++;

                floatlist.AddRange(LevelManager.FloatScore(GM.combo * 80, board[x, y]));
                Sound.GetComponent<Sound>().Whoosh();
            }
        }
        if (typeReward < 0)
        {
            CheckBonus();
        }
        else
        {
            if (GM.combo == 2)
                Sound.GetComponent<Sound>().Combo();
            else if (GM.combo == 3)
                Sound.GetComponent<Sound>().SuperCombo();
            else if (GM.combo == 4)
                Sound.GetComponent<Sound>().MegaCombo();
            else if (GM.combo == 5)
                Sound.GetComponent<Sound>().UltraCombo();
            else if (GM.combo == 6)
                Sound.GetComponent<Sound>().HyperCombo();
            else if (GM.combo > 6)
                Sound.GetComponent<Sound>().MaxCombo();
            Event.SCORE_CHANGE_EVENT.isHanddle = true;
            bonusupgradetime--;
        }

        GET_SCORE_ESTIMATE_EVENT.isHanddle = false;
        BALL_DELETE_ANIM_EVENT.isHanddle = BONUS_DEL_ANIM_TIME.isHanddle ? false : true;
        BALL_DELETE_ANIM_EVENT.type = 1;
        targetBall = null;
        targetPos = null;
        timeBeginDelete = (int)(Time.time * 1000);

    }
    void BallMove()
    {
        //if ((int)(Time.time * 1000) - Ball.BallMovingTime < 100)
        //    return;
        //Debug.Log("irun:" + posRunBall.x + " ; " + posRunBall.y + "  target:" + targetBall.Position.x + " ; " + targetBall.Position.y);

        //if (indexRunBall.x != Ball.toXY(targetBall.Position).x || indexRunBall.y != Ball.toXY(targetBall.Position).y)
        if (posRunBall.x != targetBall.Position.x || posRunBall.y != targetBall.Position.y)
        {
            if (GM.Mode == 1)
                targetBall.Position = Vector3.MoveTowards(targetBall.Position, posRunBall, targetBall.Size.x * Mathf.Sqrt(moveValue) / 4);
            else if (GM.Mode == 2)
                targetBall.Position = Vector3.MoveTowards(targetBall.Position, posRunBall, targetBall.Size.x * 2);
            targetBall.Update();
            light.transform.position = targetBall != null && !targetBall.isDie ? targetBall.Position : Vector3.one * 1000;
            glow.Position = targetBall != null && !targetBall.isDie ? targetBall.Position : Vector3.one * 1000;
            glow.Color = targetBall != null && !targetBall.isDie ? Ball.GetColorBall(targetBall.type % 100) : Color.white;
            glow.Alpha = 0.2f;
            return;
        }

        int x = (int)indexRunBall.x;
        int y = (int)indexRunBall.y;
        if (indexRunBall.x != indexTargetPos.x || indexRunBall.y != indexTargetPos.y)
        {
            bool found = false;
            for (int i = x - 1; i <= x + 1 && !found; i++)
                for (int j = y - 1; j <= y + 1 && !found; j++)
                    if ((i != x || j != y) && i >= 0 && j >= 0 && i < GM.numberColumn && j < GM.numberRow && (Mathf.Abs(x - i) + Mathf.Abs(y - j) == 1) && pathMove[i, j] == pathMove[x, y] - 1)
                    {
                        indexRunBall = new Vector3(i, j);
                        found = true;
                        moveValue = pathMove[x, y] - 1 > 0 ? pathMove[x, y] - 1 : 1;
                    }
            if (found)
            {
                posRunBall = Ball.toIndex((int)indexRunBall.x, (int)indexRunBall.y);
                posRunBall.z = targetBall.Position.z;
            }
            else
                Debug.Log("NotFound " + targetBall.Position.x + " vs " + indexTargetPos.x + "  " + targetBall.Position.y + " vs " + indexTargetPos.y);
        }
        else
        {
            light.transform.position = new Vector3(GM.BoardSize.x * 5, 0, 0);
            glow.Position = new Vector3(GM.BoardSize.x * 5, 0, 0);
            BALL_MOVING_EVENT.isHanddle = false;
            BALL_MOVING_DONE_EVENT.isHanddle = true;
        }
    }

    void ChooseBall()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 positionToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            if (Pos.Contains(GM.BoardPos, GM.BoardSize, positionToWorldPoint))
            {
                float unit = GM.BoardSize.x / 9;
                int x = (int)((positionToWorldPoint.x - rootBoardPos.x) / unit);
                unit = GM.BoardSize.y / 8;
                int y = (int)((positionToWorldPoint.y - rootBoardPos.y) / unit);
                //Debug.Log("Click " + x + "  " + y + "  " + board[x, y].type);
                if (board[x, y] != null && !board[x, y].isDie && board[x, y].type >= 100 && (targetBall == null || targetBall.isDie))
                {
                    Debug.Log("click new target ball " + board[x, y].type);
                    targetBall = board[x, y];
                    foreach (Electron e in elist)
                        e.ReParent(targetBall);
                    //board[x, y].IsAnimation = true;
                    light.transform.position = board[x, y].Position;
                    glow.Position = board[x, y].Position;
                    glow.Color = Ball.GetColorBall(board[x, y].type % 100);
                    glow.Alpha = 0.2f;
                    indexTargetBall = new Vector3(x, y, 0);
                    timeClickBall = (int)(Time.time * 1000);
                    Sound.GetComponent<Sound>().ClickBall();

                }
                else if ((board[x, y] == null || board[x, y].isDie || board[x, y].type < 100) && targetBall != null && !targetBall.isDie)
                {
                    Debug.Log("target ball move " + targetBall.type + " from ");
                    indexTargetPos = new Vector3(x, y, 0);
                    BALL_START_MOVE_EVENT.isHanddle = true;
                    if (board[x, y] != null && board[x, y].type < 100)
                        isOver = true;
                    if (targetBall.Hazard > 0)
                        Sound.GetComponent<Sound>().MoveBioBall();
                    else
                        Sound.GetComponent<Sound>().MoveBall();
                }
                else if (board[x, y] != null && !board[x, y].isDie && board[x, y].type >= 100 && targetBall != null && !targetBall.isDie)
                {
                    Debug.Log("Change target ball " + targetBall.type + " to " + board[x, y].type);
                    if (targetBall == board[x, y])
                    {
                        if (board[x, y].type > 111 && board[x, y].type % 100 < 20 && (int)(Time.time * 1000) - timeClickBall < 500)
                        {
                            BONUSBALL_EFFECT_TIME.isHanddle = true;
                            BONUSBALL_EFFECT_TIME.type = (int)(Time.time * 1000);
                            bonusword = new Image(Resources.LoadAll<Sprite>("Item/bonusword")[board[x, y].type % 100 - 12], board[x, y].Position + new Vector3(0, 0, -0.1f), board[x, y].Scale * Vector3.one);
                            //Fire
                            if (board[x, y].type % 100 == 12)
                            {
                                bonusword.Color = new Color(231f / 255f, 228f / 255f, 112f / 255f, 1);
                                board[x, y].isBonusExplode = true;
                                board[x, y].timeExplode = (int)(Time.time * 1000) + 100;
                                int count = 2;
                                for (int i = x - 1; i < x + board[x, y].type / 100 + 1; i++)
                                    for (int j = y - 1; j < y + board[x, y].type / 100 + 1; j++)
                                        if ((x != i || y != j) && i >= 0 && j >= 0 && i < GM.numberColumn && j < GM.numberRow &&
                                            board[i, j] != null && board[i, j] != null)
                                        {
                                            board[i, j].isBonusExplode = true;
                                            board[i, j].timeExplode = (int)(Time.time * 1000) + 200 * count++;
                                        }
                                bonuseffectttype = (board[x, y].type / 100) * 100 + 2;
                                bonusword.AddAudio("Voice/fire");
                                bonusword.PlaySound();
                            }
                            //Ice
                            else if (board[x, y].type % 100 == 13)
                            {
                                bonuseffectttype = (board[x, y].type / 100) * 100 + 3;
                                board[x, y].isDelRotate = true;
                                //Tạo hiệu ứng Ice
                                boardBG.changeSprite(Resources.Load<Sprite>("UI/BoardBG8x9_ice"));
                                bonusword.Color = new Color(10f / 255f, 245f / 255f, 217f / 255f);
                                StageMenu.ICE_TIME.isHanddle = true;
                                StageMenu.ICE_TIME.type = 100000000 + (int)(Time.time * 1000);
                                board[x, y].isScored = true;
                                bonusword.AddAudio("Voice/ice");
                                bonusword.PlaySound();
                            }
                            //Wind
                            else if (board[x, y].type % 100 == 14)
                            {
                                bonuseffectttype = (board[x, y].type / 100) * 100 + 4;
                                board[x, y].isDelRotate = true;
                                Object pPrefab = Resources.Load("Effect/Tornado/CartoonFX/CFX_Tornado");
                                tornado = (GameObject)GameObject.Instantiate(pPrefab, board[x, y].Position + new Vector3(0, 0, -1), Quaternion.identity);
                                tornado.transform.rotation = Quaternion.Euler(-74, 5, 30);
                                tornado.transform.localScale = GM.scaleRatio * Vector3.one / 15;
                                if (board[x, y].type / 100 == 1)
                                    GameObject.Destroy(tornado, 10.0f);
                                else if (board[x, y].type / 100 == 2)
                                    GameObject.Destroy(tornado, 20.0f);
                                targetTornado = new Vector3(boardBG.Position.x + Random.Range(-boardBG.Size.x / 2f, boardBG.Size.x / 2f),
                                    boardBG.Position.y + Random.Range(-boardBG.Size.y / 2f, boardBG.Size.y / 2f), 0);
                                bonusword.AddAudio("Voice/wind");
                                bonusword.PlaySound();
                            }
                            //Ether
                            else if (board[x, y].type % 100 == 15)
                            {
                                bonuseffectttype = (board[x, y].type / 100) * 100 + 5;
                                board[x, y].isDelRotate = true;
                                //Tạo hiệu ứng Ice
                                //bonusword.Color = new Color(10f / 255f, 245f / 255f, 217f / 255f);
                                StageMenu.ETHER_TIME.isHanddle = true;
                                StageMenu.ETHER_TIME.type = 100000000 + (int)(Time.time * 1000);
                                board[x, y].isScored = true;
                                boardBG.Color = new Color(188f / 255f, 224f / 255f, 115f / 255f);

                                foreach (Image shh in shadowholes)
                                    shh.Destroy();
                                shadowholes.Clear();
                                for (int i = 0; i < 20; i++)
                                {
                                    Image shadowhole = new Image(Resources.LoadAll<Sprite>("Effect/Clouds")[Random.Range(0, 6)], new Vector3(Random.Range(GM.width / 2f, GM.width / 1.8f), Random.Range(-GM.height / 2f, GM.height / 2f), -2), new Vector3(scaleRatio * 0.3f, scaleRatio * 0.3f, 1));
                                    shadowhole.Alpha = 0.2f;
                                    shadowholes.Add(shadowhole);
                                    if (i > 9)
                                        shadowhole.Position -= new Vector3(GM.width, 0, 0);
                                }
                                bonusword.AddAudio("Voice/ether");
                                bonusword.PlaySound();
                            }
                            //Light
                            else if (board[x, y].type % 100 == 16)
                            {
                                bonuseffectttype = (board[x, y].type / 100) * 100 + 6;
                                board[x, y].isDelRotate = true;

                                //Tạo hiệu ứng prefab sét
                                for (int i = 0; i < board[x, y].type / 100; i++)
                                {
                                    Vector2 choose = BFS.ChooseRandomBall(board, x, y);
                                    Object pPrefab = Resources.Load("LightningBolt/Bolt");
                                    GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, new Vector3(0, 0, -5), Quaternion.identity);
                                    pNewObject.transform.GetChild(0).transform.position = board[x, y].Position;
                                    pNewObject.transform.GetChild(1).transform.position = board[(int)choose.x, (int)choose.y].Position;
                                    GameObject.Destroy(pNewObject, 2.9f);
                                    board[(int)choose.x, (int)choose.y].state = 100;
                                    //1,0 -> 3,3
                                    //an : 1,1 = - 1;  2,1 = 0.5;   2,2= -0.5;   3,2 = 1
                                    //1,2 = -2; 1,3 = -3; 2,3 = -4.5; 2,0 = 1.5; 3,0 = 3
                                    //y= ax + b
                                    //(y2-y1)(x-x1) - (y-y1)(x2-x1) > 0
                                    int xmin = (int)choose.x < x ? (int)choose.x : x;
                                    int ymin = (int)choose.y < y ? (int)choose.y : y;
                                    int xmax = (int)choose.x >= x ? (int)choose.x : x;
                                    int ymax = (int)choose.y >= y ? (int)choose.y : y;

                                    for (int xx = xmin; xx < xmax + 1; xx++)
                                        for (int yy = ymin; yy < ymax + 1; yy++)
                                        {
                                            float val = ((int)choose.y - y) * (xx - x) - ((int)choose.x - x) * (yy - y);
                                            if (Mathf.Abs(val) <= 2 && board[xx, yy] != null && !board[xx, yy].isDie)
                                            {
                                                board[xx, yy].isDelRotate = true;
                                                Debug.Log("(" + xx + "," + yy + ") = val " + val);
                                            }
                                        }
                                }
                                bonusword.AddAudio("Voice/lightning");
                                bonusword.PlaySound();
                            }
                        }

                        foreach (Electron e in elist)
                            e.Disable();
                        light.transform.position = new Vector3(GM.BoardSize.x * 5, 0, 0);
                        glow.Position = new Vector3(GM.BoardSize.x * 5, 0, 0);
                        targetBall = null;
                    }
                    else
                    {
                        Sound.GetComponent<Sound>().ClickBall();
                        //targetBall.IsAnimation = false;
                        targetBall = board[x, y];
                        //targetBall.IsAnimation = true;
                        light.transform.position = targetBall.Position;
                        glow.Position = targetBall.Position;
                        glow.Color = Ball.GetColorBall(targetBall.type % 100);
                        glow.Alpha = 0.2f;
                        foreach (Electron e in elist)
                            e.ReParent(targetBall);
                        indexTargetBall = new Vector3(x, y, 0);
                        timeClickBall = (int)(Time.time * 1000);
                    }
                }
                else
                {
                    Debug.Log("target " + (targetBall == null) + "  (" + x + " , " + y + ")=  " + (board[x, y] == null ? "null" : board[x, y] + ""));
                }//== null == null ; do not all

            }
            //}
        }


    }

    public void BallBonus()
    {
        //Debug.Log("Bonus time " + timeBeginDelete +"  " + (int)(Time.time * 1000));
        if ((int)(Time.time * 1000) - timeBeginDelete > 1000)
        {
            if (BONUS_DEL_ANIM_TIME.type <= 1)
            {
                Debug.Log("delete");
                for (int i = 0; i < GM.numberColumn; i++)
                {
                    for (int j = 0; j < GM.numberRow; j++)
                    {
                        if (board[i, j] != null && board[i, j].isScored)
                        {
                            board[i, j].Destroy();
                            board[i, j] = null;
                        }
                    }
                }
                Debug.Log("type " + BONUS_PATTERN_TIME.type);
                int type = BONUS_PATTERN_TIME.type / 1000000;
                BONUS_PATTERN_TIME.type = BONUS_PATTERN_TIME.type % 1000000;
                board[BONUS_PATTERN_TIME.type / 100, BONUS_PATTERN_TIME.type % 100] = LevelManager.BallWithBonus(type, BONUS_PATTERN_TIME.type / 100, BONUS_PATTERN_TIME.type % 100);
                GM.bonusMocule++;
                GM.bonusUpgrade++;
                BONUS_DEL_ANIM_TIME.type = 2;
            }
            if (BONUS_DEL_ANIM_TIME.type == 2)
            {
                bool growing = false;
                int index = -1;
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && board[i, j].type < 100 && board[i, j].type >= 12)
                        {
                            board[i, j].Grow();
                            growing = true;
                            index = i * 100 + j;
                        }
                Debug.Log("Grow " + growing + "  " + index);
                if (!growing)
                {
                    BONUS_DEL_ANIM_TIME.isHanddle = false;
                    BONUS_DEL_ANIM_TIME.type = 1;
                    ADD_SPECIAL_BALL_ANIM_EVENT.isHanddle = true;
                }
            }
        }
        else
        {
            //LogChatX();

            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].state < 100)
                    {
                        board[i, j].state = 100;
                        for (int x = -1; x < 2; x++)
                            for (int y = -1; y < 2; y++)
                                if ((x != 0 || y != 0) && (x == 0 || y == 0) && i + x >= 0 && i + x < GM.numberColumn && j + y >= 0 && j + y < GM.numberRow)
                                    if (board[i + x, j + y] != null && !board[i + x, j + y].isDie && board[i + x, j + y].isScored)
                                    {
                                        Object pPrefab = Resources.Load("LightningBolt/Bolt"); // note: not .prefab!
                                        GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, new Vector3(0, 0, -5), Quaternion.identity);
                                        pNewObject.transform.GetChild(0).transform.position = board[i, j].Position;
                                        pNewObject.transform.GetChild(1).transform.position = board[i + x, j + y].Position;
                                        GameObject.Destroy(pNewObject, 0.9f);
                                        board[i + x, j + y].state = 100;
                                    }
                    }

            for (int i = 0; i < GM.numberColumn; i++)
            {
                for (int j = 0; j < GM.numberRow; j++)
                {
                    if (board[i, j] != null && board[i, j].isScored)
                    {
                        board[i, j].DeleteAnimation();
                    }
                }
            }
        }

    }
    void printPath()
    {

        for (int ii = 0; ii < GM.numberColumn; ii++)
        {
            string s = "";
            for (int jj = 0; jj < GM.numberRow; jj++)
            {
                if (board[ii, jj] != null)
                    s += board[ii, jj].type + 1 + "  ";
                else
                    s += 0 + "  ";
            }
            Debug.Log("... " + s);
        }
    }
    void Explode(int typePos, int x, int y)
    {
        if (typePos == 1)
            for (int i = 0; i < GM.numberColumn; i++)
                if (board[i, y] != null)
                {
                    countBall(board[i, y]);
                    board[i, y].Destroy();
                    board[i, y] = null;
                }
        if (typePos == 2)
            for (int i = 0; i < GM.numberRow; i++)
                if (board[x, i] != null)
                {
                    countBall(board[x, i]);
                    board[x, i].Destroy();
                    board[x, i] = null;
                }


        if (typePos == 3)
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (i - j == x - y && board[i, j] != null)
                    {
                        countBall(board[i, j]);
                        board[i, j].Destroy();
                        board[i, j] = null;
                    }
        //0 -8 , 1 - 7

        if (typePos == 4)
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (i + j == x + y && board[i, j] != null)
                        if (board[x, i] != null)
                        {
                            countBall(board[i, j]);
                            board[i, j].Destroy();
                            board[i, j] = null;
                        }
    }

    void countBall(Ball ball)
    {


    }


    void TutTime()
    {
        //Bomb
        Event.delay = -1;
        if (TUT_TIME.type / 1000 >= 1)
        {
            if (graphics == null)
                graphics = Resources.LoadAll<Sprite>("UI/tipgraphics");
            if (logchat == null)
            {
                string tippath = TUT_TIME.type / 1000 == 1 ? "tipX1" : "tipX2";
                logchat = new Image("LogChat/" + tippath, boardBG.Position - new Vector3(0, 0, 5), scaleRatio * Vector3.one * GM.unit);
                tipgr1 = new Image(graphics[TUT_TIME.type / 1000 == 1 ? 2 : 0], LevelManager.tutTipPos(boardBG.Size, boardBG.Position), Vector3.one * scaleRatio * GM.unit * 1.4f, Color.red);
            }
            else if ((int)(Time.time * 1000) - timeTutBegin > 200 && Input.GetMouseButtonDown(0))
            {
                DestroyTip(TUT_TIME.type % 1000 + 1);
                timeBeginDelete = (int)(Time.time * 1000) - 400;
            }
        }
        else if (GM.strategyLevel == 1 || GM.strategyLevel == 3 || (GM.strategyLevel >= 4 && GM.strategyLevel <= 6) || GM.strategyLevel == 8
            || GM.strategyLevel == 12 || GM.strategyLevel == 14 || GM.strategyLevel == 19)
        {
            if (TUT_TIME.type == 1)
            {
                if (!allballgrow)//((int)(Time.time * 1000) - timeTutBegin < 1000)
                {
                    GrowBall();
                    if (graphics == null)
                        graphics = Resources.LoadAll<Sprite>("UI/tipgraphics");
                }
                else if (logchat == null)
                {
                    int[] tiplvl = { 0, 0, 0, 3, 4, 5, 6, 0, 6, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1 };
                    logchat = new Image("LogChat/tip" + tiplvl[GM.strategyLevel], boardBG.Position - new Vector3(boardBG.Size.x / 2, -boardBG.Size.y / 4, 5), scaleRatio * Vector3.one * GM.unit);
                    if (GM.strategyLevel == 1)
                        tipgr2 = new Image(graphics[1], boardBG.Position - new Vector3(0, boardBG.Size.y / 16, 5), Vector3.one * 2 * GM.unit * 1, Color.green);
                    tipgr1 = new Image(graphics[0], LevelManager.tutTipPos(boardBG.Size, boardBG.Position), Vector3.one * 2 * GM.unit * 1, Color.red);
                    if (GM.strategyLevel == 5 || GM.strategyLevel == 19)
                        tipgr1.Disable();
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        DestroyTip(2);
                        if (GM.strategyLevel == 8)
                        {
                            GRAVITY_EFFECT_EVENT.isHanddle = true;
                            GRAVITY_EFFECT_EVENT.type = 200;
                        }
                    }
                }
            }
            else if (TUT_TIME.type == 2 || TUT_TIME.type == 3)
            {
                if (logchat == null)
                {
                    string tippath = TUT_TIME.type == 2 ? "tip1" : "tip2";
                    logchat = new Image("LogChat/" + tippath, boardBG.Position - new Vector3(0, 0, 5), scaleRatio * Vector3.one * GM.unit);
                    tipgr1 = new Image(graphics[TUT_TIME.type == 2 ? 0 : 0], boardBG.Position - new Vector3(boardBG.Size.x / 2.7f, -boardBG.Size.y / 2.3f, 5), Vector3.one * scaleRatio * GM.unit * 1.4f, Color.red);
                }
                else if ((int)(Time.time * 1000) - timeTutBegin > 200 && Input.GetMouseButtonDown(0))
                {
                    DestroyTip(TUT_TIME.type + 1);
                    timeBeginDelete = (int)(Time.time * 1000) - 400;
                    if (GM.strategyLevel == 1)
                        CREATE_NEW_BALL_EVENT.isHanddle = true;
                }
            }
        }
        else if (GM.strategyLevel == 2)
        {
            if (TUT_TIME.type == 1)
            {
                if ((int)(Time.time * 1000) - timeTutBegin < 1000)
                {
                    GrowBall();
                    if (graphics == null)
                        graphics = Resources.LoadAll<Sprite>("UI/tipgraphics");
                }
                else if (logchat == null)
                {
                    logchat = new Image("LogChat/tip2", boardBG.Position + new Vector3(0, 0, -5), scaleRatio * Vector3.one * GM.unit);
                    tipgr1 = new Image(graphics[0], LevelManager.tutTipPos(boardBG.Size, boardBG.Position), Vector3.one * 2 * GM.unit * 1, Color.red);
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        DestroyTip(2);
                    }
                }
            }
        }
        else if (GM.strategyLevel == 7 || (GM.strategyLevel >= 9 && GM.strategyLevel <= 11) || (GM.strategyLevel >= 16 && GM.strategyLevel <= 18) || GM.strategyLevel == 13
            || (GM.strategyLevel >= 20 && GM.strategyLevel <= 34))
        {
            if (TUT_TIME.type == 1)
            {
                if (!allballgrow)
                {
                    GrowBall();
                    if (graphics == null)
                        graphics = Resources.LoadAll<Sprite>("UI/tipgraphics");
                }
                else
                {
                    DestroyTip(2);
                    if (GM.strategyLevel == 17 || GM.strategyLevel == 24 || GM.strategyLevel == 29 || GM.strategyLevel == 33)
                    {
                        GRAVITY_EFFECT_EVENT.isHanddle = true;
                        GRAVITY_EFFECT_EVENT.type = 200;
                    }
                }

            }
        }
    }
    void GrowBall()
    {
        allballgrow = true;
        for (int i = 0; i < GM.numberColumn; i++)
            for (int j = 0; j < GM.numberRow; j++)
                if (board[i, j] != null && !board[i, j].isDie && board[i, j].isGrow)
                {
                    board[i, j].Grow();
                    if (board[i, j].stateAtom < 3)
                        allballgrow = false;
                }
                else if (board[i, j] != null && !board[i, j].isDie && !board[i, j].isGrow)
                {
                    board[i, j].GrowHalf();
                }
    }
    void DestroyTip(int nexttiptype = -1)
    {
        if (logchat != null)
            logchat.Destroy();
        logchat = null;
        if (tipgr1 != null)
            tipgr1.Destroy();
        tipgr1 = null;
        if (tipgr2 != null)
            tipgr2.Destroy();
        tipgr2 = null;
        TUT_TIME.isHanddle = false;
        TUT_TIME.type = nexttiptype > 0 ? nexttiptype : TUT_TIME.type;
        Debug.Log("Destroy tip " + nexttiptype);
    }
    void LogChatX()
    {
        if (GM.Mode == 1 && GM.bombMeter > 5 && PlayerPrefs.GetInt("atomicbomb", -1) < 0)
        {
            PlayerPrefs.SetInt("atomicbomb", 1);
            TUT_TIME.isHanddle = true;
            TUT_TIME.type = 1000 + TUT_TIME.type;
            timeTutBegin = (int)(Time.time * 1000);

        }
        if (GM.Mode == 1 && GM.combo > 1 && PlayerPrefs.GetInt("firstcombo", -1) < 0)
        {
            PlayerPrefs.SetInt("firstcombo", 1);
            TUT_TIME.isHanddle = true;
            TUT_TIME.type = 2000 + TUT_TIME.type;
            timeTutBegin = (int)(Time.time * 1000);
            Event.delay = (int)(Time.time * 1000) + 1000;
        }
    }
    public void CheckBonus()
    {

        GM.combo = 0;
        for (int i = 0; i < GM.numberColumn; i++)
        {
            for (int j = 0; j < GM.numberRow; j++)
            {
                if (board[i, j] != null && !board[i, j].isDie && board[i, j].type >= 100 && board[i, j].hazard > 0)
                {
                    board[i, j].Hazard--;
                    if (board[i, j].Hazard == 0)
                    {
                        CREATE_BIO_BALL_EVENT.isHanddle = true;
                    }
                }
            }
        }

        //Check xem có đúng Bonus Patern không
        if (BONUS_PATTERN_TIME.isHanddle)
        {
            BONUS_PATTERN_TIME.type = (BONUS_PATTERN_TIME.type / 10000) * 10000 + ((BONUS_PATTERN_TIME.type % 10000) + 1) % 10000;
            int typebonus = BONUS_PATTERN_TIME.type;
            Debug.Log("BONUS " + typebonus + "  " + ((typebonus % 1000000) / 100000) + "  " + (typebonus % 100000) / 10000 + "  " + (typebonus % 10000) / 1000);
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (BONUS_PATTERN_TIME.isHanddle)
                    {
                        if (typebonus / 1000000 == 5 || board[i, j] != null && !board[i, j].isDie)
                            if (BonusFrame.checkBonus(typebonus / 1000000, board, i, j, (typebonus % 1000000) / 100000, (typebonus % 100000) / 10000, (typebonus % 10000) / 1000) > 0)
                            {
                                BONUS_PATTERN_TIME.isHanddle = false;
                                BONUS_PATTERN_TIME.type = (BONUS_PATTERN_TIME.type / 1000000) * 1000000 + i * 100 + j;
                                bonusupgradetime = Random.Range(5, 10);
                                Sound.GetComponent<Sound>().BonusMolecule();
                            }
                    }
            //Phát hiện trúng bonus
            if (!BONUS_PATTERN_TIME.isHanddle)
            {
                BONUS_DEL_ANIM_TIME.isHanddle = true;
            }
        }

    }
    public static void ResetEvent()
    {
        TUT_TIME.isHanddle = false;
        BALL_START_MOVE_EVENT.isHanddle = false;
        BALL_MOVING_EVENT.isHanddle = false;
        BALL_MOVING_DONE_EVENT.isHanddle = false;
        GET_SCORE_ESTIMATE_EVENT.isHanddle = false;
        BALL_DELETE_ANIM_EVENT.isHanddle = false;
        ADD_SPECIAL_BALL_ANIM_EVENT.isHanddle = false;
        BALL_GROW_EVENT.isHanddle = false;
        CREATE_NEW_BALL_EVENT.isHanddle = false;
        GET_SCORE_AGAIN_EVENT.isHanddle = false;
        GRAVITY_EFFECT_EVENT.isHanddle = false;
        LEVEL_SUCCESS.isHanddle = false;
        NEXT_LEVEL_EVENT.isHanddle = false;
        GAME_OVER.isHanddle = false;
        WAITING_PLAYER_MOVE.isHanddle = false;
        BONUS_PATTERN_TIME.isHanddle = false;
        BONUS_DEL_ANIM_TIME.isHanddle = false;
        CREATE_BIO_BALL_EVENT.isHanddle = false;
        RETURN_GAME_EVENT.isHanddle = false;
        BONUSBALL_EFFECT_TIME.isHanddle = false;
        Event.CONTINUE_WITH_ADS.isHanddle = false;
        Event.RESTART_GAME.isHanddle = false;
        Event.SHOP_GOING.isHanddle = false;
        Event.SOUND_CHANGE.isHanddle = false;
    }
}
