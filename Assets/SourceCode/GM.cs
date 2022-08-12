using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM {

	public static int MIN_SCORE = 4;
	public static int MIN_EXPLODE = 5;
	public static int CREATE_BALL3_SCORE = 6;
	public static int CREATE_BALL5_SCORE = 7;


	public static float width;
	public static float height;
	public static float unit;
	public static Vector3 rect;
    public static float scaleRatio;

	public static int Mode = 1;
    public static int TestMode = 1;
    public static int SaveType = 1;
    public static bool boardacttype = false;
    public static bool boardstratype = false;
    public static int gameBeginTime = -1;
    public static float soundlevel = 1;

    public static int numberRow;
	public static int numberColumn;

	public static int GameState = 0;

    public static int strategyLevel;
    public static int actionLevel;
    public static int actionmeter;
    public static int gamePlayed;
    public static int strategyScore;
    public static int strategymeter;
    public static int actionScore;
    public static int lineScore;
    public static int lineStep;
    public static int tutLevel = 0;
    public static int totalCoin;
    public static short combo;
    public static int bombMeter;
    public static int Diamond;
    public static List<int> bagItem;
    public static float currentLevelScale;

	public static Text debugText;
    public static Text debugShow;
    public static Text debugShop;
    public static int APP_VERSION = 1;

    public static short adsCount = 0;
    public static Vector3 BoardSize;
    public static Vector3 BoardPos;
    public static Vector3 BGSize;
    public static Vector3 HoleCenter;

    public static short atomCollect = 0;
    public static short moculeMade = 0;
    public static short bonusMocule = 0;
    public static short bonusUpgrade = 0;
    public static short biggestCombo = 0;
    public static List<short> listsavehazard;

    public static void Init()
	{
		GM.width = (float)(Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height);
		GM.height = (float)Camera.main.orthographicSize * 2f;
		GM.unit = GM.height / 10f;
		GM.rect = new Vector3 (GM.width, GM.height, 0);

        
		GM.numberRow = 8;
		GM.numberColumn = 9;

        GM.scaleRatio = GM.GetScaleRatio();
        Debug.Log("ScaleRatio:" + GM.scaleRatio);


        //GM.bombMeter = 0;
        GM.HoleCenter = new Vector3(0, 0, 0);
        if (GM.strategyLevel <= 0)
            GM.strategyLevel = 1;

	}


    public static float GetScaleRatio()
    {
        float W = GM.width > GM.height ? GM.width : GM.height;
        float H = GM.width < GM.height ? GM.width : GM.height;


        return W / H;
    }
    //(1.25  1.28)    1.333   (1.5   1.6        1.666)   (1.706    1.778)     2
    //                        (     2560/1600  800/480)
    public static float ScaleSizeBG()
    {
        float W = GM.width > GM.height ? GM.width : GM.height;
        float H = GM.width < GM.height ? GM.width : GM.height;

        if (W / H > 1 && W / H < 1.3f)
            return 2.3f;
        if (W / H >= 1.3f && W / H < 1.45f)
            return 1.8f;
        if (W / H >= 1.45f && W / H < 1.68f)
            return 1.9f;
        if (W / H >= 1.68f && W / H < 1.885f)
            return 1.9f;
        if (W / H >= 1.885 && W / H <= 2)
            return 1.8f;

        return W / H > 2 ? 1.9f : 2.6f;
    }
    public static float ScaleSizeMenu()
    {
        float W = GM.width > GM.height ? GM.width : GM.height;
        float H = GM.width < GM.height ? GM.width : GM.height;

        if (W / H > 1 && W / H < 1.3f)
            return 1.07f;
        if (W / H >= 1.3f && W / H < 1.45f)//1280/950
            return 1.06f;//
        if (W / H >= 1.45f && W / H < 1.68f)
            return 1.04f;//
        if (W / H >= 1.68f && W / H < 1.8f)
            return 1.06f;//
        if (W / H >= 1.8f && W / H < 1.885f)
            return 1f;
        if (W / H >= 1.885 && W / H <= 2)
            return 0.95f;//

        return W / H > 2 ? 0.85f : 1.07f;
    }
    public static float ScalePosMenu()
    {
        float W = GM.width > GM.height ? GM.width : GM.height;
        float H = GM.width < GM.height ? GM.width : GM.height;

        if (W / H > 1 && W / H < 1.3f)
            return 2.34f;
        if (W / H >= 1.3f && W / H < 1.45f)//1280/950
            return 2.34f;//
        if (W / H >= 1.45f && W / H < 1.68f)//2560/1600
            return 2.34f;//
        if (W / H >= 1.68f && W / H < 1.8f)//2560/1440
            return 2.34f;//
        if (W / H >= 1.8f && W / H < 1.885f)//
            return 2.34f;
        if (W / H >= 1.885 && W / H <= 2)//
            return 2.34f;//

        return 2.34f;
    }


    public static IEnumerator Wait(float numberSeconds)
	{
		yield return new WaitForSeconds(numberSeconds);
	}


	public static int randomBall()
	{
		return Random.Range (1, 6);
	}
    public static void EstimateBombMeter(AudioSource atomicVoice)
    {
        int bombold = GM.bombMeter;
        if (GM.combo == 2)
            GM.bombMeter++;
        else if (GM.combo == 3)
            GM.bombMeter += 3;
        else if (GM.combo == 4)
            GM.bombMeter += 5;
        else if (GM.combo == 5)
            GM.bombMeter += 8;
        else if (GM.combo > 5)
            GM.bombMeter += 10;
        if (bombold < 5 && GM.bombMeter >= 5)
        {
            atomicVoice.Play();
            StageMenu.BUTTON_RAISE.isHanddle = true;
            StageMenu.BUTTON_RAISE.type = (int)(Time.time * 1000);
        }
    }
    public static void ReSetStrategy()
    {
        GM.strategyLevel = 1;
        GM.bombMeter = 0;
        GM.strategymeter = 0;
        GM.strategyScore = 0;
    }
    public static void ReSetAction()
    {
        GM.actionLevel = 1;
        GM.bombMeter = 0;
        GM.actionLevel = 0;
        GM.actionScore = 0;
    }

}

