using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineStage
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
    List<Image> tilesBG;
    List<Image> listleveltext;
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
    int moveValue = 1;
    int[,] pathMove;
    int typeReward;
    Sprite[] graphics;
    Sprite[] anous;

    int timeBeginDelete;

    List<int> listNewBall = new List<int>();
    List<int> listBallGrow = new List<int>();

    int numberHorizontal = 1;
    int numberVertical = 1;
    int numberDelta1 = 1;
    int numberDelta2 = 1;
    float cameraShake = 0;
    int extraNumberBall = -1;
    float scaleRatio;
    int timeTutBegin = -1;
    int strategState = 0;
    int timeClickBall = -1;
    bool allballgrow = false;
    bool isOver = false;
    int bonuseffectttype = 0;
    int bonusupgradetime = 0;
    bool initDone = false;

    public LineStage()
    {
        //GM.strategyLevel = 52;
        //PlayerPrefs.SetInt("atomicbomb", -1);
        //PlayerPrefs.SetInt("firstcombo", -1);
        GM.gameBeginTime = -1;

        GM.numberRow = 9;
        GM.numberColumn = 9;
        scaleRatio = GM.ScaleSizeBG();
        Ball.ResetBallSprite();
        Image overlay = new Image("UI/overlayBue", Vector3.zero, new Vector3(1.1f, 1, 1) * scaleRatio * 5f);
        if (GM.Mode <= 2)
        {
            AtomRim = new Image("UI/AtomicRim", new Vector3(GM.width / 9, -GM.unit / 4, -2), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
            if (GM.strategyLevel == 28)
                boardBG = new Image("UI/BoardBG8x9_pt", AtomRim.Position + new Vector3(0, AtomRim.Size.y / 20, 1), Vector3.one * scaleRatio * 0.205f);
            else
                boardBG = new Image("UI/BoardBG8x9", AtomRim.Position + new Vector3(0, AtomRim.Size.y / 20, 1), Vector3.one * scaleRatio * 0.205f);
            blackborder = new Image("UI/blackborder", new Vector3(0, 0, -8), new Vector3(scaleRatio * 1.05f, scaleRatio, 1));

        }
        else//Mode == 3
        {
            boardBG = new Image("UI/BoardBG8x9", new Vector3(GM.width / 24, -GM.unit / 4, -2), Vector3.one * scaleRatio * 0.205f);
            boardBG.Alpha = 0;
            blackborder = new Image("BG/planet", new Vector3(0, 0, -1), new Vector3(scaleRatio * 0.35f, scaleRatio * 0.35f, 1));

        }
        GM.BoardSize = boardBG.Size;
        GM.BoardPos = boardBG.Position;
        rootBoardPos = GM.BoardPos - GM.BoardSize / 2;
        boardBG.Alpha = 0;
        tilesBG = new List<Image>();

        elist = new List<Electron>();
        floatlist = new List<Effect>();
        listleveltext = new List<Image>();

        anous = Resources.LoadAll<Sprite>("UI/announcebold");
        gameSlogan = new Image(Resources.LoadAll<Sprite>("UI/bigwords")[2], GM.BoardPos + new Vector3(0, 0, -6f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
        gameSlogan.state = 1001;
        listleveltext = LevelManager.LevelText(gameSlogan, anous, scaleRatio);



        GM.soundlevel = PlayerPrefs.GetFloat("soundlevel", 1);
        Debug.Log("SoundLevel " + GM.soundlevel);

        GM.gameBeginTime = (int)(Time.time * 1000);
        Debug.Log("Time End Contruc " + (int)(Time.time * 1000));
        //InitGame();

    }
    public void InitGame(bool newgame = false)
    {
        GM.strategyScore = 0;
        GM.strategymeter = 0;
        GM.combo = 0;

        if (tilesBG.Count <= 0)
        {
            Debug.Log("cell count " + GM.numberColumn + "  " + GM.numberRow);
            for (int i = 0; i < GM.numberRow; i++)
                for (int j = 0; j < GM.numberColumn; j++)
                {
                    Image img = new Image("game_items/line_cell_black", Vector3.zero, Vector3.one * GM.ScaleSizeBG() * 0.11f);//0.09632
                    img.Position = GM.BoardPos - new Vector3(GM.BoardSize.y / 2, GM.BoardSize.y / 2, 0) +
                new Vector3(i * GM.BoardSize.y / 7.7f, j * GM.BoardSize.y / 7.7f, -3);
                    img.Alpha = 0.4f;
                    tilesBG.Add(img);
                }
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
        Debug.Log("level " + GM.strategyLevel + " SaveType " + GM.SaveType + "  " + GM.boardstratype);
        List<Ball> liststart = new List<Ball>();

        if (GM.SaveType == 1 && GM.Mode == 1 && GM.boardstratype)
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

        glow = new Image("Effect/StarBurst", new Vector3(GM.width * 2, 0, 0), boardBG.Scale * Vector3.one);
        glow.Alpha = 0.2f;

        TUT_TIME.isHanddle = true;
        if (TUT_TIME.isHanddle)
        {
            TUT_TIME.type = 1;
            timeTutBegin = (int)(Time.time * 1000);
        }
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
            //Debug.Log("first " + PlayerPrefs.GetInt("firstcombo", -1) +"  " + PlayerPrefs.GetInt("atomicbomb", -1));
            Debug.Log("Level:" + GM.strategyLevel + "  actionlv:" + GM.actionLevel);
            Debug.Log("gameover:" + GAME_OVER.isHanddle + "  game success:" + LEVEL_SUCCESS.isHanddle + "  netxlv:" + NEXT_LEVEL_EVENT.isHanddle +
                "option:" + Event.OPTION_PAUSE.isHanddle + "  quit:" + Event.QUIT_PAUSE.isHanddle + "  finishads:" + Event.FINISH_ADS_EVENT.isHanddle);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Mode:" + GM.Mode + "  " + GM.combo);
            GM.strategymeter++;

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Break();
        }
        if ((int)(Time.time * 1000) - GM.gameBeginTime > 1200 && (int)(Time.time * 1000) - GM.gameBeginTime < 1400 && !Sound.GetComponent<Sound>().GoPlaying())
        {
            Sound.GetComponent<Sound>().ChangeVolume();
            Sound.GetComponent<Sound>().Go();
        }
        if ((int)(Time.time * 1000) - GM.gameBeginTime < 500 && !Sound.GetComponent<Sound>().GetReadyPlaying())
        {
            Sound.GetComponent<Sound>().GetReady();
        }
        //Debug.Log("gametime " + GM.gameBeginTime +"  " + initDone);
        if ((int)(Time.time * 1000) - GM.gameBeginTime > 400 && !initDone)
            InitGame();

        if (gameSlogan != null && gameSlogan.state >= 100)
        {
            if (gameSlogan.state == 100)
            {
                gameSlogan.Alpha += 0.03f;
                foreach (Image lvtext in listleveltext)
                    if (lvtext != null && !lvtext.isDie)
                        lvtext.Alpha += 0.03f;
            }
            if (gameSlogan.state >= 120)
            {
                gameSlogan.Alpha -= 0.03f;
                foreach (Image lvtext in listleveltext)
                    if (lvtext != null && !lvtext.isDie)
                        lvtext.Alpha -= 0.03f;
            }
            if (gameSlogan.Alpha >= 1 && gameSlogan.state < 120)
                gameSlogan.state++;
            //            listleveltext
        }
        if ((int)(Time.time * 1000) - GM.gameBeginTime > 200 && GM.Mode < 3)
            boardBG.Alpha += 0.01f;

        if ((int)(Time.time * 1000) - GM.gameBeginTime < 1100 || !initDone)
            return;

        if ((int)(Time.time * 1000) - GM.gameBeginTime > 2000 && (int)(Time.time * 1000) - GM.gameBeginTime < 4000 &&
            gameSlogan != null && !gameSlogan.isDie && gameSlogan.Alpha <= 0)
        {
            gameSlogan.Destroy();
            gameSlogan = null;
            foreach (Image lvtext in listleveltext)
                if (lvtext != null && !lvtext.isDie)
                    lvtext.Destroy();
            listleveltext.Clear();
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
            Event.QUIT_PAUSE.isHanddle = false;
            SceneManager.LoadScene("MainMenu");
            return;
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
        if (Event.FINISH_ADS_EVENT.isHanddle && GAME_OVER.isHanddle)
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
            {
                nextlevelmenu = new PauseMenu(3, Event.RETURN_MAIN_EVENT, RETURN_GAME_EVENT, Event.RETURN_MAIN_NOTSAVE_EVENT);
                //AquaData.SaveData(board, true);
            }
            nextlevelmenu.Update();
            if (RETURN_GAME_EVENT.isHanddle)
            {
                //Debug.Log("return game");
                nextlevelmenu.Destroy();
                nextlevelmenu = null;
                Event.OPTION_PAUSE.isHanddle = false;
                RETURN_GAME_EVENT.isHanddle = false;
            }
            if (Event.RETURN_MAIN_EVENT.isHanddle)
            {


            }
            if (Event.RETURN_MAIN_NOTSAVE_EVENT.isHanddle)
            {
                Debug.Log("back main Not Save");
                SceneManager.LoadScene("MainMenu");

            }
            return;
        }

        if (NEXT_LEVEL_EVENT.isHanddle)
        {
            Debug.Log("Next Level");
            nextlevelmenu.Destroy();
            nextlevelmenu = null;
            if (gameSlogan == null)
            {
                timeTutBegin = (int)(Time.time * 1000);
                gameSlogan = new Image(Resources.LoadAll<Sprite>("UI/bigwords")[2], GM.BoardPos + new Vector3(0, 0, -6f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
                gameSlogan.Alpha = 1;
                gameSlogan.state = 100;
                listleveltext.Clear();
                listleveltext = LevelManager.LevelText(gameSlogan, anous, scaleRatio);
            }

            NEXT_LEVEL_EVENT.isHanddle = false;
            LEVEL_SUCCESS.isHanddle = false;
            if (GM.Mode == 1)
                GM.boardstratype = false;
            if (GM.Mode == 2)
                GM.boardacttype = false;
            AquaData.Save();
            GM.strategyLevel++;
            Event.ReSetStageEvent();
            GM.gameBeginTime = (int)(Time.time * 1000);
            AtomStage.ResetEvent();
            strategState = 0;
            initDone = false;
            //InitGame();

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
                        if (GM.Mode == 2)
                        {
                            GM.actionLevel = 1;
                            GM.actionScore = 0;
                            GM.bombMeter = 0;
                            GM.actionmeter = 0;
                        }
                        nextlevelmenu.Destroy();
                        if (GM.Mode == 1)
                            GM.boardstratype = false;
                        if (GM.Mode == 2)
                            GM.boardacttype = false;

                        Event.ReSetStageEvent();
                        GM.gameBeginTime = (int)(Time.time * 1000);
                        AtomStage.ResetEvent();
                        initDone = false;
                        strategState = 0;
                        Debug.Log("Restart Success");
                    }
                    if (Event.SHOP_GOING.isHanddle)
                    {

                    }
                }
            }

        }

        if (TUT_TIME.isHanddle && Event.delay < (int)(Time.time * 1000))
        {
            TutTime();
            return;
        }





        foreach (Electron e in elist)
            e.Update();


        for (int i = 0; i < GM.numberColumn; i++)
            for (int j = 0; j < GM.numberRow; j++)
            {
                if (board[i, j] != null && !board[i, j].isDie)
                    board[i, j].Update();
                if (board[i, j] != null && board[i, j].isDie)
                    board[i, j] = null;
            }


        if (BONUS_DEL_ANIM_TIME.isHanddle)
        {
            BallBonus();
            return;
        }

        if (GET_SCORE_AGAIN_EVENT.isHanddle)
        {
            int tmptypeReward = -1;
            int num = GM.strategyLevel == 8 || GM.strategyLevel == 17 || GM.strategyLevel == 24 || GM.strategyLevel == 29 || GM.strategyLevel == 33
                ? GM.numberColumn * GM.numberRow : listBallGrow.Count;
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

                //typeReward = Estimate.EstimateRound(board, x, y);
                numberHorizontal = 1;
                numberVertical = 1;
                numberDelta1 = 1;
                numberDelta2 = 1;
                Estimate.EstimateNumberLine(board, x, y, board[x, y].type, board[x, y].superType, ref numberHorizontal, ref numberVertical, ref numberDelta1, ref numberDelta2);
                Estimate.Mark(board, x, y, board[x, y].type, board[x, y].superType, numberHorizontal > 4, numberVertical > 4, numberDelta1 > 4, numberDelta2 > 4);
                typeReward = (numberHorizontal > 4 ? numberHorizontal : 0) + (numberVertical > 4 ? numberVertical : 0) +
                        (numberDelta1 > 4 ? numberDelta1 : 0) + (numberDelta2 > 4 ? numberDelta2 : 0);
                //Debug.Log("typere " + typeReward);
                if (typeReward >= 5)
                {
                    tmptypeReward = typeReward;
                    GM.lineScore += typeReward + (typeReward - 5) * 2;
                    //floatlist.AddRange(LevelManager.FloatScore(GM.combo * 80, board[x, y]));
                    Sound.GetComponent<Sound>().Whoosh();
                }


            }


            typeReward = tmptypeReward;
            if (typeReward < 5)
            {
                //get Score lần nữa ko cần check - Bio
                //CheckBonus(true);
            }
            else
            {
                Event.SCORE_CHANGE_EVENT.isHanddle = true;
                bonusupgradetime--;
            }


            listBallGrow.Clear();
            GET_SCORE_AGAIN_EVENT.isHanddle = false;
            BALL_DELETE_ANIM_EVENT.isHanddle = true;
            BALL_DELETE_ANIM_EVENT.type = 2;
            timeBeginDelete = (int)(Time.time * 1000);
            Debug.Log("begin set timedelee " + timeBeginDelete + " (" + (int)(Time.time * 1000) + ")");

        }

        if (CREATE_NEW_BALL_EVENT.isHanddle)
        {
            //Debug.Log("CreateNewBall " + CREATE_NEW_BALL_EVENT.type);
            //Tạo Ball mới
            if (CREATE_NEW_BALL_EVENT.type <= 1)
            {
                List<int> listEmpty = new List<int>();
                int numberK = 0;
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] == null || board[i, j].isDie)
                        {
                            listEmpty.Add(i * 100 + j);
                        }
                
                Debug.Log("new ball " + listEmpty.Count);
                for (int k = 0; k < 3; k++)
                {
                    if (listEmpty.Count > 0)
                    {
                        numberK++;
                        int type = LevelManager.RandomBall();
                        int position = Random.Range(0, listEmpty.Count);
                        int value = listEmpty[position];
                        listEmpty.RemoveAt(position);

                        int i = value / 100;
                        int j = value % 100;
                        //Debug.Log("new Ball " + i + " " + j);
                        board[i, j] = new Ball(type, i, j, false);
                    }
                    else
                    {

                    }

                }
                listEmpty.Clear();
                if (numberK < 2 && isOver)
                {
                    for (int i = 0; i < GM.numberColumn; i++)
                        for (int j = 0; j < GM.numberRow; j++)
                        {
                            if (board[i, j] == null || board[i, j].isDie)
                            {
                                board[i, j] = new Ball(LevelManager.RandomBall(), i, j, true);
                                //Debug.Log("new " + i + "  " + j);
                            }
                            if (board[i, j].type < 100)
                            {
                                board[i, j].isGrow = true;
                                //Debug.Log("new " + i + "  " + j);
                            }
                        }
                    CREATE_NEW_BALL_EVENT.type = 3;
                    isOver = false;
                }
                else
                    CREATE_NEW_BALL_EVENT.type = 2;
            }
            //During Grow Ball mới
            else if (CREATE_NEW_BALL_EVENT.type == 2 || CREATE_NEW_BALL_EVENT.type == 3)
            {
                int count = 0;
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                    {
                        if (board[i, j] != null && !board[i, j].isDie)
                        {
                            if (CREATE_NEW_BALL_EVENT.type == 2 && board[i, j].stateAtom < 2)
                            {
                                board[i, j].Grow();
                                count++;
                            }
                            else if (CREATE_NEW_BALL_EVENT.type == 3 && board[i, j].stateAtom < 3)
                            {
                                board[i, j].Grow();
                                count++;
                            }
                        }
                    }
               
                if (count <= 0)
                {
                    CREATE_NEW_BALL_EVENT.type = 1;
                    CREATE_NEW_BALL_EVENT.isHanddle = false;
                    GET_SCORE_AGAIN_EVENT.isHanddle = true;
                    strategState = 1;
                }
            }
        }
        if (BALL_GROW_EVENT.isHanddle)
        {
            int count = 0;
            Debug.Log("extra begin " + extraNumberBall);
            if (extraNumberBall >= 0)
            {
                Debug.Log("Extra > 0 with " + (board[extraNumberBall / 10000, extraNumberBall / 1000 % 10] != null) + " and " + (!board[extraNumberBall / 10000, extraNumberBall / 1000 % 10].isDie));
                int pos = Random.Range(0, 81);
                int i = pos / 9;
                int j = pos % 9;
                int cot = 0;
                while (board[i, j] != null && cot++ < 81)
                {
                    pos++;
                    i = pos / 9;
                    j = pos % 9;
                    if (i >= GM.numberRow)
                        i = 0;
                    if (j >= GM.numberColumn)
                        j = 0;
                }
                if (board[i, j] == null)
                    board[i, j] = new Ball(Random.Range(0, 6), i, j, true);
                Debug.Log("extra rand " + i + " , " + j);

                extraNumberBall = -1;
            }
            if (!(BONUSBALL_EFFECT_TIME.isHanddle && bonuseffectttype % 100 == 3))
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].type < 100)
                        {
                            board[i, j].Grow();
                            bool exist = false;
                            for (int k = 0; k < listBallGrow.Count; k++)
                                if (i * 100 + j == listBallGrow[k])
                                    exist = true;
                            if (!exist)
                            {
                                listBallGrow.Add(i * 100 + j);
                            }
                            count++;
                        }

            if (count <= 0)
            {
                BALL_GROW_EVENT.isHanddle = false;
                CREATE_NEW_BALL_EVENT.isHanddle = true;
                CREATE_NEW_BALL_EVENT.type = 1;
            }
            return;
        }

        if (BALL_DELETE_ANIM_EVENT.isHanddle)
        {
            bool isWin = false;
            bool isClear = LevelManager.checkWin(GM.strategymeter, board, true);
            if (typeReward < 5 || (int)(Time.time * 1000) - timeBeginDelete > 0)
            {
                for (int i = 0; i < GM.numberColumn; i++)
                {
                    for (int j = 0; j < GM.numberRow; j++)
                    {
                        if (board[i, j] != null && board[i, j].isScored)
                        {
                            //board[i, j].isDelRotate = true;
                            for (int x = 0; x < 7; x++)
                                for (int y = 0; y < 7; y++)
                                {
                                    GameObject go = new GameObject("despie_" + board[i,j].type);
                                    go.AddComponent<SpriteRenderer>().sprite = Ball.listSprite[(board[i, j].type % 100) * 3];
                                    go.transform.localScale = Vector3.one * board[i, j].Scale / 10;
                                    go.transform.position = board[i, j].Position - new Vector3(board[i, j].Size.x / 4f, board[i, j].Size.y / 4f, 0.1f) + new Vector3(x * board[i, j].Size.x / 14f, y * board[i, j].Size.y / 14f, 0);
                                    //Debug.Log("force " + (go.transform.position - board[i, j].Position).x +"  " +(go.transform.position - board[i, j].Position).y);
                                    Vector2 force = go.transform.position - board[i, j].Position;
                                    force *= 10 * Random.Range(1, 50);
                                    go.AddComponent<Rigidbody2D>().AddForce(force);
                                    go.GetComponent<Rigidbody2D>().gravityScale = 0;
                                    GameObject.Destroy(go, 0.5f);
                                    //Debug.Log("Destroy Effect");
                                }
                            board[i, j].Destroy();
                            
                        }
                    }
                }
                
                Debug.Log("extra regain " + extraNumberBall);
                if (extraNumberBall > 100)
                {
                    int x = extraNumberBall / 10000;
                    int y = extraNumberBall % 10000 / 1000;
                    if (board[x, y] == null)
                        board[x, y] = new Ball(extraNumberBall % 100, x, y, false);
                }
                if (LevelManager.checkFail(GM.strategyScore, board))
                {
                    Debug.Log("Check Fail True");
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
                        //Debug.Log("event " + BALL_DELETE_ANIM_EVENT.type +"  typereward " + typeReward);
                        //type == 1: Ăn ngay sau khi move => Tạo Ball mới
                        //type == 2: Ăn lần 2 khi GrowBall => Chờ Choose ball
                        if (typeReward < 5 && BALL_DELETE_ANIM_EVENT.type == 1)
                        {
                            BALL_GROW_EVENT.isHanddle = true;
                            Sound.GetComponent<Sound>().AppearBall();
                        }
                        
                    }

                }
            }
            else
            {
            }

            if (isWin)
            {
                if (gameSlogan == null || gameSlogan.isDie)
                {
                    timeTutBegin = (int)(Time.time * 1000);

                    if (GM.strategyLevel % 5 == 0)
                    {
                        if (!LevelManager.checkWin(GM.strategyScore, board, true) && (int)(Time.time * 1000) - timeBeginDelete < 500)
                        {
                            gameSlogan = new Image(Resources.LoadAll<Sprite>("UI/bigwords")[2], GM.BoardPos + new Vector3(0, 0, -6f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
                            gameSlogan.state = 1001;
                        }
                        else
                        {
                            gameSlogan = new Image(Resources.LoadAll<Sprite>("UI/bigwords")[0], GM.BoardPos + new Vector3(0, 0, -6f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
                            gameSlogan.state = 1;
                        }
                    }
                    else
                    {
                        gameSlogan = new Image(Resources.LoadAll<Sprite>("UI/bigwords")[0], GM.BoardPos + new Vector3(0, 0, -6f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
                        gameSlogan.state = 1;
                    }
                    gameSlogan.Alpha = 0;
                    Debug.Log("Level Up Logan");
                }

                if (gameSlogan != null)
                {
                    if (gameSlogan.state % 1000 < 50)
                        gameSlogan.Alpha += (!isClear ? 0.05f : 0.04f);
                    if (gameSlogan.state % 1000 >= 50)
                        gameSlogan.Alpha -= (!isClear ? 0.04f : 0.03f);

                    gameSlogan.state++;
                    //Debug.Log("loganAlpha: " + gameSlogan.Alpha + "  " + gameSlogan.state);
                    if (gameSlogan.state / 1000 > 0)
                    {
                        if (gameSlogan.Alpha <= 0 && gameSlogan.state % 1000 >= 50)
                        {
                            gameSlogan.Destroy();
                            gameSlogan = null;
                        }
                    }
                }
                if (!LEVEL_SUCCESS.isHanddle && (int)(Time.time * 1000) - timeTutBegin > 2000)
                {
                    LEVEL_SUCCESS.isHanddle = true;
                    LEVEL_SUCCESS.type = (int)(Time.time * 1000);
                    Event.WAITING_VIDEO_ADS_EVENT.type = 0;
                    for (int i = 0; i < GM.numberColumn; i++)
                        for (int j = 0; j < GM.numberRow; j++)
                            if (board[i, j] != null && !board[i, j].isDie)
                            {
                                if (board[i, j].type < 100)
                                {
                                    board[i, j].stateAtom = 3; ;
                                    board[i, j].Grow();
                                }
                                board[i, j].isDelRotate = true;
                            }
                }


                if ((int)(Time.time * 1000) - timeTutBegin > 3000 + (isClear ? 1500 : 0))
                {
                    Debug.Log("timetut " + timeTutBegin + "  " + (int)(Time.time * 1000));
                    isWin = false;
                    gameSlogan.Destroy();
                    gameSlogan = null;
                    BALL_DELETE_ANIM_EVENT.isHanddle = false;
                }

            }
            if (LEVEL_SUCCESS.isHanddle)
                return;
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
                extraNumberBall = (int)indexTargetPos.x * 10000 + (int)indexTargetPos.y * 1000 + board[(int)indexTargetPos.x, (int)indexTargetPos.y].type;
                board[(int)indexTargetPos.x, (int)indexTargetPos.y].Destroy();
                board[(int)indexTargetPos.x, (int)indexTargetPos.y] = null;
                Debug.Log("moving done set extra " + extraNumberBall + " + Destroy: " + ((int)indexTargetPos.x) + ";" + ((int)indexTargetPos.y));
                //Debug.Log("Replace with " + (int)indexTargetBall.x + " ; " + (int)indexTargetBall.y+" = " + board[(int)indexTargetBall.x, (int)indexTargetBall.y].type);
                
            }
            if (GM.Mode == 3)
                GM.lineStep++;
            board[(int)indexTargetPos.x, (int)indexTargetPos.y] = board[(int)indexTargetBall.x, (int)indexTargetBall.y];
            board[(int)indexTargetPos.x, (int)indexTargetPos.y].RePos();
            board[(int)indexTargetPos.x, (int)indexTargetPos.y].unChooseSprite();
            board[(int)indexTargetBall.x, (int)indexTargetBall.y] = null;
            BALL_MOVING_DONE_EVENT.isHanddle = false;

            GET_SCORE_ESTIMATE_EVENT.isHanddle = true;

            return;
        }
        if (BALL_MOVING_EVENT.isHanddle)
        {
            BallMove();
            return;
        }
        if (BALL_START_MOVE_EVENT.isHanddle)
        {
            //Debug.Log ("IndexBall " + indexTargetBall.x + "  " + indexTargetBall.y + " =  " + board[(int)indexTargetBall.x, (int)indexTargetBall.y].type);
            //Debug.Log ("IndexPos " + indexTargetPos.x + "  " + indexTargetPos.y );
            //Debug.Log ("-------------------------------------------------------");
            pathMove = BFS.doBFS(board, indexTargetPos, indexTargetBall, false);
            Debug.Log("From " + indexTargetPos.x + "," + indexTargetPos.y + "  To  " + indexTargetBall.x + "," + indexTargetBall.y);
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
                            board[val / 100, val % 100].Hazard = 5;
                            //new Cloud(board[i, j], board[val / 100, val % 100]);
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
    

    void GetScoreEstimate(int x, int y)
    {

        //typeReward = Estimate.EstimateRound(board, x, y);
        numberHorizontal = 1;
        numberVertical = 1;
        numberDelta1 = 1;
        numberDelta2 = 1;
        Estimate.EstimateNumberLine(board, x, y, board[x, y].type, board[x, y].superType, ref numberHorizontal, ref numberVertical, ref numberDelta1, ref numberDelta2);
        Estimate.Mark(board, x, y, board[x, y].type, board[x, y].superType, numberHorizontal > 4, numberVertical > 4, numberDelta1 > 4, numberDelta2 > 4);
        typeReward = (numberHorizontal > 4 ? numberHorizontal : 0) + (numberVertical > 4 ? numberVertical : 0) +
                        (numberDelta1 > 4 ? numberDelta1 : 0) + (numberDelta2 > 4 ? numberDelta2 : 0);
        //Debug.Log("typere " + typeReward + "  " + numberHorizontal + "  " + numberVertical + "  " + numberDelta1 + "   " + numberDelta2);

        if (typeReward >= 5)
        {
                GM.lineScore += typeReward + (typeReward - 5) * 2;
                //floatlist.AddRange(LevelManager.FloatScore(GM.combo * 80, board[x, y]));
                Sound.GetComponent<Sound>().Whoosh();
        }
        

        if (typeReward < 5)
        {
            //CheckBonus(false);
            //extraNumberBall = -1;
        }
        else
        {
            if (GM.combo == 2)
                Sound.GetComponent<Sound>().Combo();
            //extraNumberBall = -1;
            Event.SCORE_CHANGE_EVENT.isHanddle = true;
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
        //Debug.Log("irun:" + indexRunBall.x + " ; " + indexRunBall.y + "  target:" + indexTargetPos.x + " ; " + indexTargetPos.y);

        //if (indexRunBall.x != Ball.toXY(targetBall.Position).x || indexRunBall.y != Ball.toXY(targetBall.Position).y)
        if (posRunBall.x != targetBall.Position.x || posRunBall.y != targetBall.Position.y)
        {
            targetBall.Position = Vector3.MoveTowards(targetBall.Position, posRunBall, targetBall.Size.x * Mathf.Sqrt(moveValue) / 4);
            //Debug.Log("target Ball Pos:" + targetBall.Position.x + "," + targetBall.Position.y + "  To " + posRunBall.x + "," + posRunBall.y + " size " + (targetBall.Size.x * Mathf.Sqrt(moveValue) / 4) + "  " + moveValue + "   " + targetBall.Size.x);
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
            //Debug.Log("Path[" + x + "," + y + "] = " + pathMove[x, y]);
            for (int i = x - 1; i <= x + 1 && !found; i++)
                for (int j = y - 1; j <= y + 1 && !found; j++)
                    if ((i != x || j != y) && i >= 0 && j >= 0 && i < GM.numberColumn && j < GM.numberRow)
                    {
                        //Debug.Log("....pathround " + i + "," + j + "  " + pathMove[i, j]);
                    }

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
            float unit = GM.BoardSize.x / 9;
            int x = -1;
            int y = -1;
            foreach (Image cell in tilesBG)
                if (Pos.Contains(cell.Position, cell.Size, positionToWorldPoint))
                {
                    x = (int)Ball.toXY(cell.Position).x;
                    y = (int)Ball.toXY(cell.Position).y;
                }

            if (x >= 0 && x < GM.numberColumn && y >= 0 && y < GM.numberRow)
            {
                
                Debug.Log("Click " + x + "  " + y + "  ");
                if (board[x, y] != null && !board[x, y].isDie && board[x, y].type >= 100 && (targetBall == null || targetBall.isDie))
                {
                    Debug.Log("click new target ball " + board[x, y].type);
                    targetBall = board[x, y];
                    foreach (Electron e in elist)
                        e.ReParent(targetBall);
                    board[x, y].IsAnimation = true;
                    board[x, y].chooseSprite();
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
                    targetBall.IsAnimation = false;
                    if (board[x, y] != null && board[x, y].type < 100)
                        isOver = true;
                    Sound.GetComponent<Sound>().MoveBall();

                }
                else if (board[x, y] != null && !board[x, y].isDie && board[x, y].type >= 100 && targetBall != null && !targetBall.isDie)
                {
                    Debug.Log("Change target ball " + targetBall.type + " to " + board[x, y].type);
                    if (targetBall == board[x, y])
                    {
                        targetBall.unChooseSprite();
                        foreach (Electron e in elist)
                            e.Disable();
                        light.transform.position = new Vector3(GM.BoardSize.x * 5, 0, 0);
                        glow.Position = new Vector3(GM.BoardSize.x * 5, 0, 0);
                        targetBall = null;
                    }
                    else
                    {
                        Sound.GetComponent<Sound>().ClickBall();
                        targetBall.IsAnimation = false;
                        targetBall.unChooseSprite();
                        targetBall = board[x, y];
                        targetBall.chooseSprite();
                        targetBall.IsAnimation = true;
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
        
    }
  
    



    void TutTime()
    {
        Event.delay = -1;

        if (TUT_TIME.type == 1)
        {
            if (!allballgrow)
            {
                GrowBall();
            }
            else
            {
                TUT_TIME.isHanddle = false;
                TUT_TIME.type = 2;
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
