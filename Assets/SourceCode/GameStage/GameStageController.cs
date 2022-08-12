using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStageController : MonoBehaviour
{

    public static GameStageController Instance;
    public int x;
    public int y;
    public int x1;
    public int y1;
    public GameObject light;
    public GameObject audio;

    public BoardGame board;
    public StageMenu menu;
    public AtomStage atomstage;
    public StageMenu atommenu;
    public ActionStage actionstage;
    public LineStage linestage;


    PauseMenu pauseMenu;
    public Text debugText;
    public Text debugShow;
    GameObject overlayBG;
    Sprite[] listSpriteLevel;
    Image gameLevelText;

    bool isTut = false;
    bool isLevelSpin = false;
    int GameState = 0;

    Event LEVEL_PAUSE = new Event();

    bool doneAd = false;

    //BackGround background;
    public static AudioSource auBG;


    private void RequestRewardBasedVideo()
    {

    }

    void Start()
    {
        Instance = this;

        this.Init();
        this.RequestRewardBasedVideo();

        loadAudio();

        auBG.Play();

        listSpriteLevel = Resources.LoadAll<Sprite>("UI/stage1");

    }

    void Init()
    {
        GM.Init();
        GM.debugText = this.debugText;
        GM.debugShow = this.debugShow;
#if UNITY_EDITOR
        if (GM.Mode == 1)
        {
            atomstage = new AtomStage();
            atomstage.light = light;
            atomstage.Sound = audio;
        }
        if (GM.Mode == 2)
        {
            actionstage = new ActionStage();
            actionstage.light = light;
            actionstage.Sound = audio;
            //board = new BoardGame(this);
        }
        if (GM.Mode == 3)
        {
            linestage = new LineStage();
            linestage.light = light;
            linestage.Sound = audio;
            //board = new BoardGame(this);
        }
#else
        try
        {
            if (GM.Mode == 1)
            {
                atomstage = new AtomStage();
                atomstage.light = light;
                atomstage.Sound = audio;
            }
            if (GM.Mode == 2)
            {
                actionstage = new ActionStage();
                actionstage.light = light;
                actionstage.Sound = audio;
                //board = new BoardGame(this);
            }
            if (GM.Mode == 3)
            {
                linestage = new LineStage();
                linestage.light = light;
                linestage.Sound = audio;
                //board = new BoardGame(this);
            }
        } catch (Exception e)
        {
            debugText.text = e.ToString();
        }
#endif

        if (menu == null)
            menu = new StageMenu();
        else
            menu.Reset();


    }
    int timeNext = -1;

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Event.STAGE_PAUSE.isHanddle = true;
            Event.STAGE_PAUSE.type = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Event.STAGE_CLEAR.isHanddle = true;
            if (auBG.isPlaying)
                auBG.Stop();
            
        }

        if (pauseMenu != null && !pauseMenu.isDie)
        {
            pauseMenu.Update();
            return;
        }
        if (pauseMenu != null && pauseMenu.isDie)
            pauseMenu = null;


        //Back Home button pressed
        if (Event.STAGE_BACK_HOME.isHanddle)
        {

            Event.STAGE_BACK_HOME.isHanddle = false;
            restartAllData();
            SceneManager.LoadScene("MainMenu");
            return;
        }

        //Pause game Button pressed
        if (Event.STAGE_PAUSE.isHanddle)
        {
            if (pauseMenu == null)
                pauseMenu = new PauseMenu(100, null, null);

            Event.STAGE_PAUSE.isHanddle = false;
        }


        //Game Work------------------------------------------------------------------------------------------------------------------------------------
#if UNITY_EDITOR

        if (atomstage != null && GM.Mode == 1)
            atomstage.Update();
        if (actionstage != null && GM.Mode == 2)
            actionstage.Update();
        if (linestage != null && GM.Mode == 3)
            linestage.Update();
        //board.Update();
        if (menu != null)
            menu.Update();


        if (pauseMenu != null)
            pauseMenu.Update();

#else
        try
        {
            if (atomstage != null && GM.Mode == 1)
                atomstage.Update();
            if (actionstage != null && GM.Mode == 2)
                actionstage.Update();
            if (linestage != null && GM.Mode == 3)
                linestage.Update();
            //board.Update();
            if (menu != null)
                menu.Update();


            if (pauseMenu != null)
                pauseMenu.Update();
        }
        catch (Exception e)
        {
            //debugText.text = e.ToString();
        }
#endif


    }



    void restartAllData()
    {
        Event.STAGE_PAUSE.isHanddle = false;
        doneAd = false;
        //SceneManager.LoadScene("Stage_1_1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void loadAudio()
    {
        GameObject auBGObj = new GameObject("auBG");
        auBG = auBGObj.AddComponent<AudioSource>();
        auBG.loop = true;
        auBG.volume = 0.3f;
        
    }

    private void GameOver()
    {

    }
}
