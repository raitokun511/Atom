using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu {
	
	Image BG;
    Image contentBG;
	Image overlayBG;
    GameButton OKButon;
    GameButton CancelButton;
    GameButton donsaveButton;
    GameButton shopButton;
    int Type;
    List<Image> infocontent;
    Image soundScroll;
    Image musicScroll;

    public PauseMenu (int type, Event OKEvent, Event cancelEvent, Event dontEvent = null) {

        Type = type;
        if (type == 1)//Next Level
        {
            Debug.Log("Game Info: " + GM.atomCollect + "   " + GM.moculeMade + "   " + GM.bonusMocule + "   " + GM.bonusUpgrade +
                        "    " + GM.biggestCombo);
            BG = new Image("UI/DialogMonitor", new Vector3(GM.BoardPos.x, GM.BoardPos.y, -7), Vector3.one * GM.scaleRatio * 0.23f);
            contentBG = new Image("UI/next_info", BG.Position - new Vector3(BG.Size.x / 32f, BG.Size.y / 32f, 0.01f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f);
            //Image cnt = new Image("UI/next_info", BG.Position + new Vector3(BG.Size.x / 2, BG.Size.y / 16f, -0.1f), Vector3.one * scaleRatio / 6 / 1.25f);
            OKButon = new GameButton("OKBtn", "UI/click_next_level", BG.Position - new Vector3(BG.Size.x / 50, BG.Size.y / 3.1f, 0.01f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f, 1);
            OKButon.ButtonTapEvent = OKEvent;

            BG.Position += new Vector3(0, GM.BoardSize.y, 0);
            contentBG.Position += new Vector3(0, GM.BoardSize.y, 0);
            OKButon.Position += new Vector3(0, GM.BoardSize.y, 0);
            Sprite[] listSprite = Resources.LoadAll<Sprite>("UI/monitorfont");
            infocontent = new List<Image>();
            Color textcolor = new Color(138f / 255f, 255f / 255f, 138f / 255f);

            Vector3 spos = contentBG.Position + new Vector3(-contentBG.Size.x / 8.0f, contentBG.Size.y / 4.1f, -0.1f);
            //leveltime
            int minute = ((int)(Time.time * 1000) - GM.gameBeginTime) / 1000 / 60;
            int second = ((int)(Time.time * 1000) - GM.gameBeginTime) / 1000 % 60;
            Debug.Log("Time: " + GM.gameBeginTime+" - " + (int)(Time.time * 1000) + "  " + minute+"  " + second);//: = 89
            if (minute > 10)
            {
                infocontent.Add(new Image(listSprite[minute % 100 / 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));
                spos += new Vector3(contentBG.Size.x / 32, 0, 0);
            }
            infocontent.Add(new Image(listSprite[minute % 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));
            spos += new Vector3(contentBG.Size.x / 46, 0, 0);
            infocontent.Add(new Image(listSprite[89], spos, contentBG.Scale * Vector3.one, textcolor));
            spos += new Vector3(contentBG.Size.x / 46, 0, 0);
            infocontent.Add(new Image(listSprite[second % 100 / 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));
            spos += new Vector3(contentBG.Size.x / 32, 0, 0);
            infocontent.Add(new Image(listSprite[second % 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));

            //atom
            spos = contentBG.Position + new Vector3(-contentBG.Size.x / 14, contentBG.Size.y / 5.7f, -0.1f);
            infocontent.Add(new Image(listSprite[38], spos, contentBG.Scale * Vector3.one, textcolor));
            infocontent.Add(new Image(listSprite[41], spos + new Vector3(contentBG.Size.x / 32, 0, 0), contentBG.Scale * Vector3.one, textcolor));

            //138 255 138

            //mocule made
            spos = contentBG.Position + new Vector3(-contentBG.Size.x / 14, contentBG.Size.y / 9.7f, -0.1f);
            if (GM.moculeMade > 10)
            {
                infocontent.Add(new Image(listSprite[GM.moculeMade % 100 / 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));
                spos += new Vector3(contentBG.Size.x / 32, 0, 0);
            }
            infocontent.Add(new Image(listSprite[GM.moculeMade % 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));

            //bigest combo
            spos = contentBG.Position + new Vector3(contentBG.Size.x / 2.4f, contentBG.Size.y / 4.05f, -0.1f);
            if (GM.biggestCombo > 10)
            {
                infocontent.Add(new Image(listSprite[GM.biggestCombo % 100 / 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));
                spos += new Vector3(contentBG.Size.x / 32, 0, 0);
            }
            infocontent.Add(new Image(listSprite[GM.biggestCombo % 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));
            spos += new Vector3(contentBG.Size.x / 32, 0, 0);
            infocontent.Add(new Image(listSprite[83], spos, contentBG.Scale * Vector3.one, textcolor));

            //Bonus mocule
            spos = contentBG.Position + new Vector3(contentBG.Size.x / 2.3f, contentBG.Size.y / 5.8f, -0.1f);
            if (GM.bonusMocule > 10)
            {
                infocontent.Add(new Image(listSprite[GM.bonusMocule % 100 / 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));
                spos += new Vector3(contentBG.Size.x / 32, 0, 0);
            }
            infocontent.Add(new Image(listSprite[GM.bonusMocule % 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));

            //bonus upgrade
            spos = contentBG.Position + new Vector3(contentBG.Size.x / 2.25f, contentBG.Size.y / 10.0f, -0.1f);
            if (GM.bonusUpgrade > 10)
            {
                infocontent.Add(new Image(listSprite[GM.bonusUpgrade % 100 / 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));
                spos += new Vector3(contentBG.Size.x / 32, 0, 0);
            }
            infocontent.Add(new Image(listSprite[GM.bonusUpgrade % 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));

            //next rank
            int nextrank = LevelManager.NextRank(GM.strategyScore);
            Debug.Log("Next rank " + nextrank);
            spos = contentBG.Position + new Vector3(contentBG.Size.x / 3.8f, -contentBG.Size.y / 2.3f, -0.1f);
            while (nextrank > 0 && minute++ < 30)
            {
                infocontent.Add(new Image(listSprite[nextrank % 10 + 35], spos, contentBG.Scale * Vector3.one, textcolor));
                nextrank = nextrank / 10;
                spos += new Vector3(-contentBG.Size.x / 32, 0, 0);
            }

            //rankstrip
            infocontent.Add(new Image(Resources.LoadAll<Sprite>("Item/RankStrip")[LevelManager.RankStripID(GM.strategyScore)], contentBG.Position - new Vector3(contentBG.Size.x / 4, contentBG.Size.y / 5, 0.1f), contentBG.Scale * Vector3.one));

        }
        else if (type == 2)//Quit Pause
        {
            BG = new Image("UI/DialogMonitor", new Vector3(GM.BoardPos.x, GM.BoardPos.y, -7), Vector3.one * GM.scaleRatio * 0.23f);
            contentBG = new Image("UI/T_quit_confirm", BG.Position - new Vector3(BG.Size.x / 32f, - BG.Size.y / 23f, 0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f);

            OKButon = new GameButton("OKBtn", "UI/savenquit_button", BG.Position - new Vector3(BG.Size.x / 50, BG.Size.y / 6.5f, 0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f, 1);
            OKButon.ButtonTapEvent = OKEvent;
            donsaveButton = new GameButton("DonBtn", "UI/quitdontsave_button", BG.Position - new Vector3(BG.Size.x / 50, BG.Size.y / 4.5f, 0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f, 1);
            donsaveButton.ButtonTapEvent = dontEvent;
            CancelButton = new GameButton("CanBtn", "UI/return_button", BG.Position - new Vector3(BG.Size.x / 50, BG.Size.y / 3.1f, 0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f, 1);
            CancelButton.ButtonTapEvent = cancelEvent;

        }
        else if (type == 3)//Option Pause
        {
            BG = new Image("UI/DialogMonitor", new Vector3(GM.BoardPos.x, GM.BoardPos.y, -7), Vector3.one * GM.scaleRatio * 0.23f);
            contentBG = new Image("UI/fx_music_3", BG.Position - new Vector3(BG.Size.x / 3.3f, -BG.Size.y / 23f, 0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f);

            infocontent = new List<Image>();
            infocontent.Add(new Image("UI/music_progress_bar", BG.Position + new Vector3(BG.Size.x / 14f, BG.Size.y / 15f, -0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f));
            infocontent.Add(new Image("UI/music_progress_bar", BG.Position + new Vector3(BG.Size.x / 14f, BG.Size.y / 60f, -0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f));

            soundScroll = new Image("UI/music_progress_but", infocontent[0].Position + new Vector3((GM.soundlevel - 0.5f) * infocontent[0].Size.x, 0, -0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f);
            musicScroll = new Image("UI/music_progress_but", infocontent[1].Position + new Vector3((StageMenu.GetAudioVolume() - 0.5f) * infocontent[1].Size.x, 0, -0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f);

            CancelButton = new GameButton("CanBtn", "UI/done_button", BG.Position - new Vector3(BG.Size.x / 50, BG.Size.y / 3.1f, 0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f, 1);
            CancelButton.ButtonTapEvent = cancelEvent;

        }
        else if (type == 4)//Game Over
        {
            BG = new Image("UI/DialogMonitor", new Vector3(GM.BoardPos.x, GM.BoardPos.y, -7), Vector3.one * GM.scaleRatio * 0.23f);
            contentBG = new Image("UI/GameOverLogo", BG.Position - new Vector3(0, -BG.Size.y / 15f, 0.1f), Vector3.one * GM.scaleRatio * 0.17f / 1.25f);

            //infocontent = new List<Image>();
            //infocontent.Add(new Image("UI/music_progress_bar", BG.Position + new Vector3(BG.Size.x / 14f, BG.Size.y / 15f, -0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f));
            //infocontent.Add(new Image("UI/music_progress_bar", BG.Position + new Vector3(BG.Size.x / 14f, BG.Size.y / 60f, -0.1f), Vector3.one * GM.scaleRatio * 0.23f / 1.25f));


            //Continue
            OKButon = new GameButton("OKBtn", "UI/continuebutton", BG.Position - new Vector3(BG.Size.x / 100, BG.Size.y / 15.0f, 0.1f), Vector3.one * GM.scaleRatio * 0.2f / 1.25f, 1);
            OKButon.ButtonTapEvent = OKEvent;
            //retstart
            CancelButton = new GameButton("CanBtn", "UI/RestartButton", BG.Position - new Vector3(BG.Size.x / 100, BG.Size.y / 5.0f, 0.1f), Vector3.one * GM.scaleRatio * 0.2f / 1.25f, 1);
            CancelButton.ButtonTapEvent = cancelEvent;

            //shop
            //shopButton = new GameButton("OKBtn", "UI/Shop_1", BG.Position - new Vector3(BG.Size.x / 100, BG.Size.y / 3.2f, 0.1f), Vector3.one * GM.scaleRatio * 0.2f / 1.25f, 1);
            //shopButton.ButtonTapEvent = dontEvent;

            BG.Position += new Vector3(0, GM.BoardSize.y, 0);
            contentBG.Position += new Vector3(0, GM.BoardSize.y, 0);
            OKButon.Position += new Vector3(0, GM.BoardSize.y, 0);
            CancelButton.Position += new Vector3(0, GM.BoardSize.y, 0);
            //shopButton.Position += new Vector3(0, GM.BoardSize.y, 0);

        }
        else if (type == 5)//Rating pause
        {
            BG = new Image("UI/rate_board", new Vector3(GM.BoardPos.x, GM.BoardPos.y, -8), Vector3.one * GM.scaleRatio * 0.23f);
            overlayBG = new Image("overlayscreen", new Vector3(0, 0, -7.01f), Vector3.one * 5);
            overlayBG.Alpha = 0.65f;

            //Continue
            OKButon = new GameButton("OKBtn", "UI/rate_button", BG.Position - new Vector3(BG.Size.x / 100, BG.Size.y / 15.0f, 0.1f), Vector3.one * GM.scaleRatio * 0.2f / 1.25f, 1);
            OKButon.ButtonTapEvent = OKEvent;
            OKButon.EventValue = 1;
            //retstart
            CancelButton = new GameButton("CanBtn", "UI/nothanks_button", BG.Position - new Vector3(BG.Size.x / 100, BG.Size.y / 5.0f, 0.1f), Vector3.one * GM.scaleRatio * 0.2f / 1.25f, 1);
            CancelButton.ButtonTapEvent = cancelEvent;
            CancelButton.EventValue = 0;

            BG.Position += new Vector3(0, GM.BoardSize.y, 0);
            OKButon.Position += new Vector3(0, GM.BoardSize.y, 0);
            CancelButton.Position += new Vector3(0, GM.BoardSize.y, 0);

        }

    }

    public void Update()
    {

        if (Type == 1 && BG.Position.y > GM.BoardPos.y + GM.BoardSize.y / 20f)
        {
            BG.Position -= new Vector3(0, GM.BoardSize.y, 0) / 20f;
            contentBG.Position -= new Vector3(0, GM.BoardSize.y, 0) / 20f;
            OKButon.Position -= new Vector3(0, GM.BoardSize.y, 0) / 20f;
            if (infocontent != null)
                for (int i = 0; i < infocontent.Count; i++)
                    infocontent[i].Position -= new Vector3(0, GM.BoardSize.y, 0) / 20f;
            /*
            if (!Event.WAITING_VIDEO_ADS_EVENT.isHanddle && Event.WAITING_VIDEO_ADS_EVENT.type == 0)
            {
                Event.WAITING_VIDEO_ADS_EVENT.type = 1;
                Event.WAITING_VIDEO_ADS_EVENT.isHanddle = true;
            }
            */
        }
        if ((Type == 4 || Type == 5) && BG.Position.y > GM.BoardPos.y + GM.BoardSize.y / 20f)
        {
            BG.Position -= new Vector3(0, GM.BoardSize.y, 0) / 20f;
            if (contentBG != null)
                contentBG.Position -= new Vector3(0, GM.BoardSize.y, 0) / 20f;
            OKButon.Position -= new Vector3(0, GM.BoardSize.y, 0) / 20f;
            if (shopButton != null)
                shopButton.Position -= new Vector3(0, GM.BoardSize.y, 0) / 20f;
            CancelButton.Position -= new Vector3(0, GM.BoardSize.y, 0) / 20f;
        }

        if (OKButon != null)
            OKButon.Update();
        if (CancelButton != null)
            CancelButton.Update();
        if (donsaveButton != null)
            donsaveButton.Update();
        if (shopButton != null)
            shopButton.Update();

#if UNITY_EDITOR
        if (Type == 3 && Input.GetMouseButtonDown(0))
        {
            Vector2 positionToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Vector3 rect = new Vector3(infocontent[0].Size.x * 0.9f, infocontent[0].Size.y);
            if (Pos.Contains(infocontent[0].Position, rect, positionToWorldPoint))
            {
                soundScroll.Position = new Vector3(positionToWorldPoint.x, soundScroll.Position.y, soundScroll.Position.z);
                GM.soundlevel = (soundScroll.Position.x - infocontent[0].Position.x + infocontent[0].Size.x * 0.5f) / infocontent[0].Size.x;
                if (GM.Mode == 1)
                    Event.SOUND_CHANGE.isHanddle = true;
                //min 0                   max 1
                //Posx - Sizex / 2      Posx + Sizex / 2
                //0.7// (PosScr  - Posx  + Sizex * 0.5) / Sizex) = 0.7 = val
            }
            rect = new Vector3(infocontent[1].Size.x * 0.9f, infocontent[1].Size.y);
            if (Pos.Contains(infocontent[1].Position, rect, positionToWorldPoint))
            {
                musicScroll.Position = new Vector3(positionToWorldPoint.x, musicScroll.Position.y, musicScroll.Position.z);
                StageMenu.SetAudioVolume((musicScroll.Position.x - infocontent[1].Position.x + infocontent[1].Size.x * 0.5f) / infocontent[1].Size.x);

            }
        }
#endif
        int tapCount = 0;
        if (Type == 3)
        {
            while (tapCount < Input.touches.Length)
            {
                Touch touch = Input.GetTouch(tapCount);
                tapCount++;

                Vector2 positionToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);

                Vector3 rect = new Vector3(infocontent[0].Size.x * 0.9f, infocontent[0].Size.y);

                if (Pos.Contains(infocontent[0].Position, rect, positionToWorldPoint))
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        soundScroll.Position = new Vector3(positionToWorldPoint.x, soundScroll.Position.y, soundScroll.Position.z);
                        GM.soundlevel = (soundScroll.Position.x - infocontent[0].Position.x + infocontent[0].Size.x * 0.5f) / infocontent[0].Size.x;
                        if (GM.Mode == 1)
                            Event.SOUND_CHANGE.isHanddle = true;
                    }
                    else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                    {

                    }
                    else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        soundScroll.Position = new Vector3(positionToWorldPoint.x, soundScroll.Position.y, soundScroll.Position.z);
                        GM.soundlevel = (soundScroll.Position.x - infocontent[0].Position.x + infocontent[0].Size.x * 0.5f) / infocontent[0].Size.x;
                        if (GM.Mode == 1)
                            Event.SOUND_CHANGE.isHanddle = true;
                    }
                    else
                    {

                    }


                }
                else if (Pos.Contains(infocontent[1].Position, rect, positionToWorldPoint))
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        musicScroll.Position = new Vector3(positionToWorldPoint.x, musicScroll.Position.y, musicScroll.Position.z);
                        float level = (musicScroll.Position.x - infocontent[1].Position.x + infocontent[1].Size.x * 0.5f) / infocontent[1].Size.x;
                        StageMenu.SetAudioVolume(level);
                        PlayerPrefs.SetFloat("musiclevel", level);
                    }
                    else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                    {

                    }
                    else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        musicScroll.Position = new Vector3(positionToWorldPoint.x, musicScroll.Position.y, musicScroll.Position.z);
                        float level = (musicScroll.Position.x - infocontent[1].Position.x + infocontent[1].Size.x * 0.5f) / infocontent[1].Size.x;
                        StageMenu.SetAudioVolume(level);
                        PlayerPrefs.SetFloat("musiclevel", level);
                    }
                    else
                    {

                    }


                }
            }
    }


    }

    public bool isDie
    {
        get { return BG == null; }
    }

	public void Destroy()
	{
        if (BG != null)
            BG.Destroy();
        BG = null;
        if (overlayBG != null)
            overlayBG.Destroy();
		overlayBG = null;
        if (OKButon != null)
            OKButon.Destroy();
        OKButon = null;
        if (CancelButton != null)
            CancelButton.Destroy();
        CancelButton = null;
        if (shopButton != null)
            shopButton.Destroy();
        shopButton = null;
        if (contentBG != null)
            contentBG.Destroy();
        contentBG = null;
        if (infocontent != null)
        {
            for (int i = 0; i < infocontent.Count; i++)
                infocontent[i].Destroy();
            infocontent.Clear();
        }
        infocontent = null;
        if (donsaveButton != null)
            donsaveButton.Destroy();
        if (musicScroll != null)
            musicScroll.Destroy();
        musicScroll = null;
        if (soundScroll != null)
            soundScroll.Destroy();
        donsaveButton = null;
    }

}
