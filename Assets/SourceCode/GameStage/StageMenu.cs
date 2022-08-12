using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMenu {

    public static Event OPTION_MENU = new Event();
    public static Event QUIT_MENU = new Event();
    public static Event BUTTON_RAISE = new Event();
    public static Event BUTTON_PRESS = new Event();
    public static Event ICE_TIME = new Event();
    public static Event ETHER_TIME = new Event();
    public static Event BOMB_DES_TIME = new Event();
    public static Event RESET_BAG = new Event();
    public static Event CLICK_BAG = new Event();
    public static Event MOUTH_TALK = new Event();
    public static Event LEVEL_BAR_RESTORE = new Event();

    public static AudioSource audioBackground;

    Score score;
    Score level;
    Score best;
    Image coat;
    Image head;
    Image mouth;
    Image levelProgress;
    Image levelProgressFlip;
    Image machinescreen;
    Image atomicMachine;
    Image scorename;
    Image levelname;
    Image bestname;
    GameButton atomicButton;
    Image atomicCap;
    Image atomicMeter;
    Image atomicMonitor;
    Image bombMeterBar;
    ProgressBar bombMeter;
    ProgressBar bombMeterMirror;
    GameButton optionButton;
    GameButton quitButton;
    List<Image> listIce;
    Image bagBG;
    Image[] itemBagImg;
    GameButton suitcase;
    Image menuBG;


    Sprite[] headlist;
    Sprite[] mouthlist;
    float scaleRatio;
    int tmpScore;
	int timeBefore = 0;
    int bestscore = 0;
    int mouthstep = 0;

	public StageMenu () {

        //GM.Init();
        scaleRatio = GM.ScaleSizeBG();

        if (GM.Mode == 3)
        {
            menuBG = new Image("game_items/line_cell_black", new Vector3(-GM.width / 2.7f, 0, -3), new Vector3(1, 2.8f, 1) * GM.ScaleSizeBG() * 0.35f);
            menuBG.Alpha = 0.87f;

            Sprite[] spritetext = Resources.LoadAll<Sprite>("UI/line_scorename");
            scorename = new Image(spritetext[0], menuBG.Position + new Vector3(0, menuBG.Size.y / 6f, -1.5f), Vector3.one * scaleRatio * 0.1f);
            score = new Score(GM.lineScore, scorename.Position - new Vector3(0, scorename.Size.y * 1.8f, 0), scorename.Scale, 2);

            bestscore = PlayerPrefs.GetInt("bestscore", 0);
            bestname = new Image(spritetext[1], menuBG.Position + new Vector3(0, menuBG.Size.y / 2.5f, -1.5f), Vector3.one * scaleRatio * 0.1f);
            best = new Score(bestscore, bestname.Position - new Vector3(0, bestname.Size.y * 1.8f, 0), bestname.Scale, 2);

            levelname = new Image(spritetext[4], menuBG.Position + new Vector3(0, -menuBG.Size.y / 50f, -1.5f), Vector3.one * scaleRatio * 0.1f);
            level = new Score(GM.lineScore, levelname.Position - new Vector3(0, levelname.Size.y * 1.8f, 0), levelname.Scale, 2);

            quitButton = new GameButton("quit", spritetext[3], spritetext[3], menuBG.Position - new Vector3(0, menuBG.Size.y / 2.5f, 1.5f), Vector3.one * scaleRatio * 0.1f, 1);
            quitButton.ButtonTapEvent = QUIT_MENU;
            
            return;
        }

        machinescreen = new Image("UI/AtomicMachine_Score", GM.BoardPos - new Vector3(GM.BoardSize.x / 1.4f, -GM.BoardSize.y / 3f, 3.5f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
        scorename = new Image("UI/levelandscore", machinescreen.Position + new Vector3(-machinescreen.Size.x / 4.5f, machinescreen.Size.y / 3f, -1.5f), new Vector3(1.2f, 1.6f, 1) * scaleRatio * 0.21f);
        score = new Score(GM.Mode == 1 ? GM.strategyScore : GM.actionScore, scorename.Position - new Vector3(0, scorename.Size.y * 2, 0), scorename.Scale / 4);
        levelname = new Image("UI/level", machinescreen.Position + new Vector3(machinescreen.Size.x / 2.9f, machinescreen.Size.y / 2.5f, -1.5f), new Vector3(1.2f, 1.2f, 1) * scaleRatio * 0.15f);
        level = new Score(GM.Mode == 1 ? GM.strategyLevel : GM.actionLevel, levelname.Position - new Vector3(0, levelname.Size.y / 1.5f, 0),levelname.Scale / 4);
        level.Rotation = new Vector3(0, 0, -5);
        level.changeColor(new Color(1, 1, 1, 0.85f));

        atomicMeter = new Image("UI/AtomicLevelMeter", GM.BoardPos - new Vector3(0, -GM.BoardSize.y / 1.9f, 3), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
        levelProgress = new Image("UI/levelbar75", atomicMeter.Position + new Vector3(-atomicMeter.Size.x / 3.2f, atomicMeter.Size.x / 120f, -0.1f), Vector3.zero);//atomicMeter.Scale * new Vector3(1 / 20f, 1, 1));
        levelProgressFlip = new Image("UI/levelbar75", atomicMeter.Position + new Vector3(atomicMeter.Size.x / 2.7f, atomicMeter.Size.x / 120f, -0.1f), Vector3.zero);//atomicMeter.Scale * new Vector3(1 / 20f, 1, 1));
        

        bombMeterBar = new Image("Item/AtomicMachineBomber", GM.BoardPos - new Vector3(GM.BoardSize.x / 6.5f, GM.BoardSize.y / 1.87f, 4.1f), atomicMeter.Scale * Vector3.one);
        bombMeter = new ProgressBar(0, bombMeterBar.Position - new Vector3(bombMeterBar.Size.x / 15.6f, -bombMeterBar.Size.y / 10, 0.1f), 35);
        bombMeter.Scale = bombMeterBar.Scale * Vector3.one;
        bombMeterMirror = new ProgressBar(1, bombMeterBar.Position + new Vector3(bombMeterBar.Size.x / 3.49f, bombMeterBar.Size.y / 10, 0.1f), 35);
        bombMeterMirror.Scale = bombMeterBar.Scale * Vector3.one;

        atomicButton = new GameButton("bombbutton", "Item/ButtonSeq", bombMeterBar.Position + new Vector3(bombMeterBar.Size.x / 9.2f, bombMeterBar.Size.y / 7, -1.1f), bombMeterBar.Scale * Vector3.one);
        atomicButton.ButtonTapEvent = Event.BOMB_HIT_EVENT;
        atomicCap = new Image("Item/AtomicMachineBomberCap", atomicButton.Position + new Vector3(0, atomicButton.Size.y / 3.1f, -0.1f), atomicButton.Scale * 0.9f);
        atomicCap.Alpha = 0.85f;
        if (GM.bombMeter > 5)
        {
            BUTTON_RAISE.isHanddle = true;
            BUTTON_RAISE.type = (int)(Time.time * 1000);
        }

        atomicMonitor = new Image("UI/AtomicMonitor", GM.BoardPos - new Vector3(GM.BoardSize.x / 1.3f, GM.BoardSize.y / 3f, 5), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);

        //coat = new Image("UI/coat", atomicMonitor.Position + new Vector3(0, 0, -0.1f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.21f);
        headlist = Resources.LoadAll<Sprite>("UI/AtomicusLeftNod");
        mouthlist = Resources.LoadAll<Sprite>("UI/AtomicMouthLeft");
        head = new Image(headlist[0], atomicMonitor.Position + new Vector3(0, atomicMonitor.Size.y / 15, -0.1f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.13f);
        mouth = new Image(mouthlist[0], head.Position - new Vector3(head.Size.x / 8, head.Size.y / 3, 0.05f), new Vector3(1.1f, 1, 1) * scaleRatio * 0.13f);
        suitcase = new GameButton("suitcase", "Item/suitcase", atomicMonitor.Position + new Vector3(-atomicMonitor.Size.x / 30, -atomicMonitor.Size.y / 5, -0.2f), new Vector3(1, 1, 1) * scaleRatio * 0.045f);
        suitcase.ButtonTapEvent = CLICK_BAG;
        suitcase.EventValue = 0;


        itemBagImg = new Image[3];
        Debug.Log("Shop " + GM.bagItem.Count);
        

        Sprite[] spritesbutton = Resources.LoadAll<Sprite>("UI/SidebarButtons");
        optionButton = new GameButton("option", spritesbutton[2], spritesbutton[3], atomicMonitor.Position + new Vector3(-atomicMonitor.Size.x / 22.2f, atomicMonitor.Size.y / 2.45f, -1), Vector3.one * scaleRatio * 0.21f, 2);
        optionButton.ButtonTapEvent = OPTION_MENU;

        quitButton = new GameButton("quit", spritesbutton[4], spritesbutton[5], atomicMonitor.Position - new Vector3(atomicMonitor.Size.x / 22.2f, atomicMonitor.Size.y / 2.25f, 1), Vector3.one * scaleRatio * 0.21f, 2);
        quitButton.ButtonTapEvent = QUIT_MENU;

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
	
	public void Update () {

		if (Input.GetKeyDown(KeyCode.M))
			Debug.Log("Score " + GM.strategyScore);



        

        if (GM.Mode == 3)
        {
            if (score.ScoreTotal < GM.lineScore)
                score.Plus(GM.lineScore - score.ScoreTotal);
            
            score.Update();
            if (GM.lineScore > bestscore)
            {
                best.Plus(GM.lineScore - bestscore);
                bestscore = GM.lineScore;
                PlayerPrefs.SetInt("bestscore", bestscore);
                best.Update();
            }
            if (Event.SCORE_CHANGE_EVENT.isHanddle)
            {
                Event.SCORE_CHANGE_EVENT.isHanddle = false;
            }
            if (QUIT_MENU.isHanddle)
            {
                if (!AtomStage.LEVEL_SUCCESS.isHanddle && !AtomStage.GAME_OVER.isHanddle && !ActionStage.GAME_OVER.isHanddle)
                    Event.QUIT_PAUSE.isHanddle = true;

                QUIT_MENU.isHanddle = false;
            }

            quitButton.Update();
            if (level.ScoreTotal < GM.lineStep)
                level.Plus(GM.lineStep - level.ScoreTotal);
            level.Update();
            return;
        }

        if (GM.Mode == 1)
        {
            
            if (GM.Mode == 1 && score.ScoreTotal < GM.strategyScore)
                score.Plus(GM.strategyScore - score.ScoreTotal);
            if (GM.Mode == 2 && score.ScoreValue < GM.actionScore)
                score.Plus(GM.actionScore - score.ScoreValue);
            score.Update();

            if (Event.SCORE_CHANGE_EVENT.isHanddle)
            {
                //2.7 scale full bar
                //Debug.Log("meter " + GM.strategymeter + "   full: " + LevelManager.fullScore() +"   " + GM.strategyLevel +"   value:" + GM.strategymeter / (1f * LevelManager.fullScore()));
                levelProgress.ExtraScale = new Vector3(GM.strategymeter * 1.16f / (1f * LevelManager.fullScore()), atomicMeter.ExtraScale.y, atomicMeter.ExtraScale.z);
                levelProgress.Position = atomicMeter.Position + new Vector3(-atomicMeter.Size.x / 3.25f + levelProgress.Size.x / 2f, atomicMeter.Size.x / 120f, -0.1f);
                levelProgressFlip.ExtraScale = new Vector3(GM.strategymeter * 1.22f/ (1f * LevelManager.fullScore()), atomicMeter.ExtraScale.y, atomicMeter.ExtraScale.z);
                levelProgressFlip.Position = atomicMeter.Position + new Vector3(atomicMeter.Size.x / 7.5f + levelProgressFlip.Size.x / 2f, atomicMeter.Size.x / 120f, -0.1f);
                levelProgressFlip.Position = levelProgressFlip.Position + new Vector3(atomicMeter.Size.x / 4.3f - levelProgressFlip.Size.x, 0, 0);
                Event.SCORE_CHANGE_EVENT.isHanddle = false;
            }
            if (LEVEL_BAR_RESTORE.isHanddle)
            {
                levelProgress.ExtraScale = new Vector3(GM.strategymeter / (1f * LevelManager.fullScore()), atomicMeter.ExtraScale.y, atomicMeter.ExtraScale.z);
                levelProgress.Position = atomicMeter.Position + new Vector3(-atomicMeter.Size.x / 3.2f + levelProgress.Size.x / 2f, atomicMeter.Size.x / 120f, -0.1f);
                levelProgressFlip.ExtraScale = new Vector3(GM.strategymeter / (1f * LevelManager.fullScore()), atomicMeter.ExtraScale.y, atomicMeter.ExtraScale.z);
                levelProgressFlip.Position = atomicMeter.Position + new Vector3(atomicMeter.Size.x / 7.2f + levelProgressFlip.Size.x / 2f, atomicMeter.Size.x / 120f, -0.1f);
                GM.strategymeter--;
                if (GM.strategymeter <= 0)
                {
                    GM.strategymeter = 0;
                    LEVEL_BAR_RESTORE.isHanddle = false;
                }
            }
        }
        else if (GM.Mode == 2)
        {
            //2.7 scale full bar
            levelProgress.ExtraScale = new Vector3(GM.actionmeter / (1f * LevelManager.fullScore()), atomicMeter.ExtraScale.y, atomicMeter.ExtraScale.z);
            levelProgress.Position = atomicMeter.Position + new Vector3(-atomicMeter.Size.x / 3.2f + levelProgress.Size.x / 2f, atomicMeter.Size.x / 120f, -0.1f);
            levelProgressFlip.ExtraScale = new Vector3(GM.actionmeter / (1f * LevelManager.fullScore()), atomicMeter.ExtraScale.y, atomicMeter.ExtraScale.z);
            levelProgressFlip.Position = atomicMeter.Position + new Vector3(atomicMeter.Size.x / 7.2f + levelProgressFlip.Size.x / 2f, atomicMeter.Size.x / 120f, -0.1f);
            GM.actionmeter++;
        }

        if (!BOMB_DES_TIME.isHanddle)
        {
            bombMeter.Update(GM.bombMeter, bombMeterBar.Position - new Vector3(bombMeterBar.Size.x / 15.6f, -bombMeterBar.Size.y / 10, 0.1f));
            bombMeterMirror.Update(GM.bombMeter, bombMeterBar.Position + new Vector3(bombMeterBar.Size.x / 3.49f, bombMeterBar.Size.y / 10, 0.1f));
        }
        else
        {
            if (BOMB_DES_TIME.type / 10000000 > 0)
            {
                if ((int)(Time.time * 1000) - BOMB_DES_TIME.type % 10000000 > 100)
                {
                    StageMenu.BOMB_DES_TIME.type = (BOMB_DES_TIME.type / 10000000 - 1) * 10000000 + (int)(Time.time * 1000);
                }
            }
            else
            {
                BOMB_DES_TIME.isHanddle = false;
                BOMB_DES_TIME.type = 0;
            }
            bombMeter.Update(BOMB_DES_TIME.type / 10000000, bombMeterBar.Position - new Vector3(bombMeterBar.Size.x / 15.6f, -bombMeterBar.Size.y / 10, 0.1f));
            bombMeterMirror.Update(BOMB_DES_TIME.type / 10000000, bombMeterBar.Position + new Vector3(bombMeterBar.Size.x / 3.49f, bombMeterBar.Size.y / 10, 0.1f));

        }
        if (BUTTON_RAISE.isHanddle)
        {
            RaiseButton();
        }
        if (BUTTON_PRESS.isHanddle)
            PressButton();
        if (Event.BOMB_HIT_EVENT.isHanddle && !BUTTON_PRESS.isHanddle)
        {
            if (Event.BOMB_HIT_EVENT.type <= 0)
                Event.BOMB_HIT_EVENT.type = 1;
            if (GM.bombMeter > 5)
            {
                BUTTON_PRESS.isHanddle = true;
                BUTTON_PRESS.type = (int)(Time.time * 1000);
            }
            //Event.BOMB_HIT_EVENT.isHanddle = false;

        }
        if (MOUTH_TALK.isHanddle)
        {
            HeadVoice();
        }

        if (OPTION_MENU.isHanddle)
        {
            Event.OPTION_PAUSE.isHanddle = true;
            //Event.DEBUG_ADDBALL.isHanddle = true;

            OPTION_MENU.isHanddle = false;
        }

        if (QUIT_MENU.isHanddle)
        {
            Debug.Log("Menu Quit - succ:" + AtomStage.LEVEL_SUCCESS.isHanddle + " and over:" + !AtomStage.GAME_OVER.isHanddle);
            
            if (!AtomStage.LEVEL_SUCCESS.isHanddle && !AtomStage.GAME_OVER.isHanddle && !ActionStage.GAME_OVER.isHanddle)
                Event.QUIT_PAUSE.isHanddle = true;
            //Event.DEBUG_ADDBALL.isHanddle = true;
            QUIT_MENU.isHanddle = false;
        }
        if (CLICK_BAG.isHanddle)
        {
            if (CLICK_BAG.type == 0)
            {
                OpenBag();
            }
            else
            {
                CloseBag();
            }
            suitcase.EventValue = 1 - CLICK_BAG.type;
            CLICK_BAG.isHanddle = false;
        }



        if (atomicButton != null)
            atomicButton.Update();
        if (optionButton != null)
            optionButton.Update();
        if (quitButton != null)
            quitButton.Update();
        if (suitcase != null)
            suitcase.Update();


        if (GM.Mode == 1 && AtomStage.CHOOSE_ITEM.isHanddle && itemBagImg[AtomStage.CHOOSE_ITEM.type] != null)
        {
            itemBagImg[AtomStage.CHOOSE_ITEM.type].Rotation += new Vector3(0, 0, 20);
        }

        //USE ITEM 
        int tapCount = 0;
        if (Input.GetMouseButtonDown(0) && !AtomStage.CHOOSE_ITEM.isHanddle && !ActionStage.CHOOSE_ITEM.isHanddle)
        //while (tapCount < Input.touches.Length && !AtomStage.CHOOSE_ITEM.isHanddle && !ActionStage.CHOOSE_ITEM.isHanddle)
        {
            //Touch touch = Input.GetTouch(tapCount);

            for (int i = 0; i < itemBagImg.Length; i++)
            {
                
                if (itemBagImg[i] != null && !itemBagImg[i].isDie)
                {
                    //Vector2 posToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
                    Vector2 posToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

                    if (Pos.Contains(itemBagImg[i].Position, itemBagImg[i].Size, posToWorldPoint))
                    {
                        Debug.Log("Click item " + i);
                        if (GM.Mode == 1)
                        {
                            AtomStage.CHOOSE_ITEM.isHanddle = true;
                            AtomStage.CHOOSE_ITEM.type = i;
                        }
                        if (GM.Mode == 2)
                        {
                            ActionStage.CHOOSE_ITEM.isHanddle = true;
                            ActionStage.CHOOSE_ITEM.type = i;
                        }
                    }
                }
            }
        }
		


        if (ICE_TIME.isHanddle)
        {
            if (ICE_TIME.type / 100000000 == 1)
            {
                if (listIce == null)
                    listIce = new List<Image>();
                if (listIce.Count <= 0)
                {
                    Sprite[] ices = Resources.LoadAll<Sprite>("Effect/freeze");
                    listIce.Add(new Image(ices[0], machinescreen.Position + new Vector3(-machinescreen.Size.x / 2.6f, machinescreen.Size.y / 40f, -0.1f), machinescreen.Scale * Vector3.one));
                    listIce.Add(new Image(ices[1], machinescreen.Position + new Vector3(-machinescreen.Size.x / 5f, -machinescreen.Size.y / 3f, -0.1f), machinescreen.Scale * Vector3.one));
                    listIce.Add(new Image(ices[2], machinescreen.Position + new Vector3(machinescreen.Size.x / 5.2f, -machinescreen.Size.y / 20f, -0.1f), machinescreen.Scale * Vector3.one));
                    listIce.Add(new Image(ices[3], machinescreen.Position + new Vector3(machinescreen.Size.x / 2.4f, machinescreen.Size.y / 3.3f, -0.1f), machinescreen.Scale * Vector3.one));

                    listIce.Add(new Image(ices[4], atomicMeter.Position + new Vector3(-atomicMeter.Size.x / 3.2f, 0, -0.1f), machinescreen.Scale * Vector3.one));
                    listIce.Add(new Image(ices[5], atomicMeter.Position + new Vector3(atomicMeter.Size.x / 15f, 0, -0.1f), machinescreen.Scale * Vector3.one));
                    listIce.Add(new Image(ices[6], atomicMeter.Position + new Vector3(atomicMeter.Size.x / 3.2f, 0, -0.1f), machinescreen.Scale * Vector3.one));

                    listIce.Add(new Image(ices[7], atomicMonitor.Position + new Vector3(-atomicMonitor.Size.x / 20f, atomicMonitor.Size.y / 20f, -0.1f), machinescreen.Scale * new Vector3(1.1f, 1, 1)));
                    listIce.Add(new Image(ices[8], bombMeterBar.Position + new Vector3(-bombMeterBar.Size.x / 4f, 0, -0.1f), machinescreen.Scale * Vector3.one));
                    listIce.Add(new Image(ices[9], bombMeterBar.Position + new Vector3(bombMeter.Size.x / 4f, 0, -0.1f), machinescreen.Scale * Vector3.one));


                    foreach (Image ice in listIce)
                        ice.Alpha = 0.5f;
                }
                ICE_TIME.type = 0;
                ICE_TIME.isHanddle = false;
            }
            else if (ICE_TIME.type / 100000000 == 2)
            {
                foreach (Image ice in listIce)
                    ice.Alpha = ice.Alpha - 0.007f;
                if ((int)(Time.time * 1000) - (ICE_TIME.type % 100000000) > 1500)
                {
                    ICE_TIME.isHanddle = false;
                    ICE_TIME.type = 0;
                    foreach (Image ice in listIce)
                        ice.Destroy();
                    listIce.Clear();
                }
            }
            
        }
        if (ETHER_TIME.isHanddle)
        {
            //Begin Ether Time
            if (ETHER_TIME.type / 100000000 == 1)
            {
                machinescreen.Color = new Color(92f / 255f, 219f / 255f, 20f / 255f);
                atomicMeter.Color = new Color(92f / 255f, 219f / 255f, 20f / 255f);
                bombMeterBar.Color = new Color(92f / 255f, 219f / 255f, 20f / 255f);
                atomicButton.Color = new Color(92f / 255f, 219f / 255f, 20f / 255f);
                optionButton.Color = new Color(92f / 255f, 219f / 255f, 20f / 255f);
                atomicMonitor.Color = new Color(92f / 255f, 219f / 255f, 20f / 255f);
                head.Color = new Color(92f / 255f, 219f / 255f, 20f / 255f);
                quitButton.Color = new Color(92f / 255f, 219f / 255f, 20f / 255f);

                ETHER_TIME.type = 0;
                ETHER_TIME.isHanddle = false;
            }
            //End Ether Time
            else if (ETHER_TIME.type / 100000000 == 2)
            {
                machinescreen.ColorToWhite(1);
                atomicMeter.ColorToWhite(1);
                bombMeterBar.ColorToWhite(1);
                atomicButton.ColorToWhite(1);
                optionButton.ColorToWhite(1);
                atomicMonitor.ColorToWhite(1);
                head.ColorToWhite(1);
                quitButton.ColorToWhite(1);

                if ((int)(Time.time * 1000) - (ETHER_TIME.type % 100000000) > 1000)
                {
                    ETHER_TIME.isHanddle = false;
                    ETHER_TIME.type = 0;
                    //listIce.Clear();
                }
            }

        }

        if ((GM.Mode == 1 && level.ScoreTotal < GM.strategyLevel) || (GM.Mode == 2 && level.ScoreTotal < GM.actionLevel))
            ChangeLevel();
        if (RESET_BAG.isHanddle)
        {
            Debug.Log("Reset bag " + GM.bagItem.Count);
            ReSetBag();
            RESET_BAG.isHanddle = false;
        }

    }
    

	public void Reset()
	{
		
	}
    public void RaiseButton()
    {
        int index = ((int)(Time.time * 1000) - BUTTON_RAISE.type) / 60;
        int indexCap = ((int)(Time.time * 1000) - BUTTON_RAISE.type) / 25;
        if (index < 11)
        {
            //atomicButton.Sprite = Resources.LoadAll<Sprite>("Item/ButtonSeq")[index];
            atomicButton.ChangeSprite(Resources.LoadAll<Sprite>("Item/ButtonSeq")[index]);
            if (indexCap < 24)
                atomicCap.changeSprite(Resources.LoadAll<Sprite>("Item/AtomicMachineBomberCap")[indexCap]);
            else if (indexCap >= 24)
                atomicCap.Alpha = 0;
        }
        else
            BUTTON_RAISE.isHanddle = false;

    }
    public void PressButton()
    {
        int index = 10 - ((int)(Time.time * 1000) - BUTTON_PRESS.type) / 40;
        if (index >= 0)
        {
            atomicButton.ChangeSprite(Resources.LoadAll<Sprite>("Item/ButtonSeq")[index]);
        }
        else if (index < 0 && -index < 11)
        {
            atomicButton.ChangeSprite(Resources.LoadAll<Sprite>("Item/ButtonSeq")[-index]);
        }
        else
        {
            BUTTON_PRESS.isHanddle = false;
            atomicButton.ChangeSprite(Resources.LoadAll<Sprite>("Item/ButtonSeq")[0]);
        }
    }

    public void HeadVoice()
    {
        if (mouthstep < 0)
            mouthstep = (MOUTH_TALK.type / 100 ) * 5;
        if (mouthstep / 5 < MOUTH_TALK.type % 100)
        {
            mouth.changeSprite(mouthlist[mouthstep / 5]);
            mouthstep++;
        }
        else
        {
            mouthstep = -1;
            MOUTH_TALK.isHanddle = false;
            MOUTH_TALK.type = -1;
            mouth.changeSprite(mouthlist[0]);
        }
    }

    public void ChangeLevel()
    {
        level.Plus(1);
        level.Update();
            //= new Score(GM.Mode == 1 ? GM.strategyLevel : GM.actionLevel, levelname.Position - new Vector3(0, levelname.Size.y / 1.5f, 0), levelname.Scale / 4);

    }
    public static void SetAudioVolume(float volume)
    {
        if (audioBackground != null && audioBackground.gameObject != null)
            audioBackground.volume = volume;

    }
    public static float GetAudioVolume()
    {
        if (audioBackground != null && audioBackground.gameObject != null)
            return audioBackground.volume;
        return 1;
    }
    void ReSetBag()
    {
        if (GM.bagItem == null || GM.bagItem.Count == 0)
        {
            if (itemBagImg[0] != null)
                itemBagImg[0].Destroy();
            itemBagImg[0] = null;
            return;
        }
        for (int i = 0; i < 3; i++)
        {
            if (i < GM.bagItem.Count)
            {
                int typeitem = GM.bagItem[i];
                if (typeitem >= 112 && typeitem <= 116)
                {
                    if (itemBagImg[i] != null)
                        itemBagImg[i].Destroy();
                    itemBagImg[i] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[36 + (typeitem - 112) * 9], bagBG.Position + new Vector3(0, -bagBG.Size.y / 1.55f + (i + 1) * bagBG.Size.x / 1.11f, -1.5f), new Vector3(1, 1, 1) * scaleRatio * 0.2f);
                }
            }
            else if (itemBagImg[i] != null)
            {
                itemBagImg[i].Destroy();
                itemBagImg[i] = null;
            }
        }

    }

    public void OpenBag()
    {
        bagBG = new Image("UI/bagItem", head.Position + new Vector3(head.Size.x / 1.4f, head.Size.y / 3.4f, -1.5f), new Vector3(1f, 1f, 1) * scaleRatio * 0.15f);
        if (GM.bagItem != null && GM.bagItem.Count != 0)
        {
            for (int i = 0; i < GM.bagItem.Count; i++)
            {
                int typeitem = GM.bagItem[i];
                if (typeitem >= 112 && typeitem <= 116)
                {
                    itemBagImg[i] = new Image(Resources.LoadAll<Sprite>("game_items/Atoms")[36 + (typeitem - 112) * 9], bagBG.Position + new Vector3(0, -bagBG.Size.y / 1.55f + (i + 1) * bagBG.Size.x / 1.11f, -1.5f), new Vector3(1, 1, 1) * scaleRatio * 0.2f);
                }
            }
        }
    }
    public void CloseBag()
    {
        bagBG.Destroy();
        bagBG = null;
        if (GM.bagItem != null && GM.bagItem.Count != 0)
        {
            for (int i = 0; i < GM.bagItem.Count; i++)
            {
                itemBagImg[i].Destroy();
            }
        }
        if (itemBagImg != null && itemBagImg[0] != null)
            itemBagImg[0].Destroy();
    }

}
