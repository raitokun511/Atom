using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event {

	//Main Menu
	public static Event MAIN_FB_EVENT = new Event();
	public static Event RETURN_MAIN_EVENT = new Event();
    public static Event RETURN_MAIN_NOTSAVE_EVENT = new Event();
    public static Event MAIN_STAT_EVENT = new Event();
	public static Event MAIN_SHOP_EVENT = new Event();

	//ADS
	public static Event WAITING_VIDEO_ADS_EVENT = new Event();
	public static Event LEVEL_OVER_INFO_EVENT = new Event();
    public static Event LEVEL_END_INFO_EVENT = new Event();
    public static Event VIEW_VIDEO_ADS_EVENT = new Event();
    public static Event FINISH_ADS_EVENT = new Event();

    public static Event CONTINUE_WITH_ADS = new Event();
    public static Event RESTART_GAME = new Event();
    public static Event SHOP_GOING = new Event();
    public static Event START_WITH_CONTINUE = new Event();
    public static Event DAILYREWARD_CLICK = new Event();
    public static Event RATING_CLICK = new Event();
    public static Event RATING_TIME = new Event();

    public static Event SCORE_CHANGE_EVENT = new Event();
	public static Event BOMB_HIT_EVENT = new Event();
    public static Event ACTION_LEVEL_BOMB_EVENT = new Event();
    //Stage Game
    public static Event STAGE_CLEAR = new Event();
	public static Event STAGE_BACK_HOME = new Event();
	public static Event STAGE_PAUSE = new Event();
    public static Event QUIT_PAUSE = new Event();
    public static Event OPTION_PAUSE = new Event();
    public static Event RESET_GAME = new Event();
    public static Event SOUND_CHANGE = new Event();
    public static Event DEBUG_ADDBALL = new Event();

    //Enemy



    public static int delay;
	public bool issHanddle = false;
	public int type;
    public bool isHanddle
    {
        get { return issHanddle; }
        set
        {
            issHanddle = value;
        }
    }

    public static void ReSetStageEvent()
    {
        AtomStage.TUT_TIME.isHanddle = false;
        AtomStage.BALL_START_MOVE_EVENT.isHanddle = false;
        AtomStage.BALL_MOVING_EVENT.isHanddle = false;
        AtomStage.BALL_MOVING_DONE_EVENT.isHanddle = false;
        AtomStage.GET_SCORE_ESTIMATE_EVENT.isHanddle = false;
        AtomStage.BALL_DELETE_ANIM_EVENT.isHanddle = false;
        AtomStage.BALL_GROW_EVENT.isHanddle = false;
        AtomStage.CREATE_NEW_BALL_EVENT.isHanddle = false;
        AtomStage.GET_SCORE_AGAIN_EVENT.isHanddle = false;
        AtomStage.GRAVITY_EFFECT_EVENT.isHanddle = false;
        AtomStage.LEVEL_SUCCESS.isHanddle = false;
        AtomStage.WAITING_PLAYER_MOVE.isHanddle = false;
        AtomStage.GAME_OVER.isHanddle = false;
    }

}
