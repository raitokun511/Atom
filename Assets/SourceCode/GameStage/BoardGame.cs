using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGame : MonoBehaviour
{

	GameStageController parent;
	Vector3 rootBoardPos = new Vector3(-GM.width / 2 + GM.unit, GM.height / 2 - GM.unit, 0);

	public Ball[,] board;
	int[] ballPath;

	Vector3 ballSize;
	Ball targetBall = null;
	Ball targetPos;
	Vector3 indexTargetBall;
	Vector3 indexTargetPos;
	Vector3 indexRunBall;
	int[,] pathMove;
    int typeReward;

    int timeBeginDelete;

	int numberHorizontal = 1;
	int numberVertical = 1;
	int numberDelta1 = 1;
	int numberDelta2 = 1;
	int numBallOverride = 0;
	List<int> listBallOverride = new List<int>();
	List<int> listBallOverridePos = new List<int>();
	List<int> listNewBall = new List<int>();
	List<int> listBallGrow = new List<int>();
	List<Ball> listBallDeleteAfter = new List<Ball>();

	//GameStage Info
	public int numberGreenObtain = 0;
	public int numberRedObtain = 0;
	public int numberBlueObtain = 0;
	public int numberYellowObtain = 0;
	public int numberPurpleObtain = 0;
	public int numberSuperObtain = 0;
	public int numberUltraObtain = 0;
	public int numberExplodeObtain = 0;
	public int numberFreezeObtain = 0;
	public int numberAllcolorObtain = 0;



	public static Event BALL_START_MOVE_EVENT = new Event();
	public static Event BALL_MOVING_EVENT = new Event();
	public static Event BALL_MOVING_DONE_EVENT = new Event();
	public static Event GET_SCORE_ESTIMATE_EVENT = new Event();
	public static Event BALL_DELETE_ANIM_EVENT = new Event();
	public static Event ADD_SPECIAL_BALL_ANIM_EVENT = new Event();
	public static Event CREATE_NEW_BALL_EVENT = new Event();
	public static Event GET_SCORE_AGAIN_EVENT = new Event();
	public static Event BALL_DELETE_ANIM_AGAIN_EVENT = new Event();
	public static Event LEVEL_SUCCESS = new Event();



	public BoardGame(GameStageController prent)
	{

		parent = prent;

		int numberBall = 10;
		int numberBallSmall = 3;
		int[] randPos = new int[numberBall];
		for (int i = 0; i < numberBall; i++)
			randPos[i] = Random.Range(0, GM.numberRow * GM.numberColumn);

		board = new Ball[GM.numberRow, GM.numberColumn];
		for (int i = 0; i < GM.numberRow; i++)
			for (int j = 0; j < GM.numberColumn; j++)
			{
				//Image Board
				Image img = new Image("cell", new Vector3(rootBoardPos.x + j * GM.unit * 1.4f, rootBoardPos.y - i * GM.unit * 1.4f, -1), new Vector3(GM.unit, GM.unit, GM.unit));
				img.blur(0.2f);

				for (int k = 0; k < numberBall; k++)
					if (i * GM.numberRow + j == randPos[k] && board[i, j] == null)
					{
						int randType = GM.randomBall() + (numberBallSmall > 0 ? --numberBallSmall * 0 : 100);
						if (randType > 100)
							board[i, j] = new Ball(randType, i, new Vector3(rootBoardPos.x + j * GM.unit * 1.4f, rootBoardPos.y - i * GM.unit * 1.4f, -2), new Vector3(GM.unit * 1f, GM.unit * 1f, GM.unit * 1));
						else
							board[i, j] = new Ball(randType, i, new Vector3(rootBoardPos.x + j * GM.unit * 1.4f, rootBoardPos.y - i * GM.unit * 1.4f, -2), new Vector3(GM.unit / 4, GM.unit / 4, GM.unit / 4));
						ballSize = board[i, j].Size;
					}
			}

	}

	public void Update()
	{
		
		if (LEVEL_SUCCESS.isHanddle)
		{
			//TODO
			Event.STAGE_CLEAR.isHanddle = true;

			return;
		}

		if (Input.GetKeyDown(KeyCode.T))
		{
			//BFS.doBFS(board, new Vector3(GameStageController.Instance.x, GameStageController.Instance.y, 0), new Vector3(GameStageController.Instance.x1, GameStageController.Instance.y1, 0));

		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			BFS.Print(board);
		}



		if (BALL_DELETE_ANIM_AGAIN_EVENT.isHanddle)
		{

			for (int i = 0; i < GM.numberRow; i++)
			{
				for (int j = 0; j < GM.numberColumn; j++)
				{
					if (board[i, j] != null && board[i, j].isScored)
					{
						countBall(board[i, j]);
						board[i, j].Destroy();
						board[i, j] = null;
					}
				}
			}
			//Add Anim here
			//...

			listNewBall.Clear();
			listBallDeleteAfter.Clear();
			BALL_DELETE_ANIM_AGAIN_EVENT.isHanddle = false;
		}

		if (GET_SCORE_AGAIN_EVENT.isHanddle)
		{
			for (int k = 0; k < listBallGrow.Count; k++)
			{
				int x = listBallGrow[k] / GM.numberColumn;
				int y = listBallGrow[k] % GM.numberColumn;
				numberHorizontal = 1;
				numberVertical = 1;
				numberDelta1 = 1;
				numberDelta2 = 1;
				Debug.Log("listNewBalll: " + x + "  " + y + "  " + (board[x, y] != null ? board[x, y].type.ToString() : "null"));
				Estimate.EstimateNumberLine(board, x, y, board[x, y].type, board[x,y].superType, ref numberHorizontal, ref numberVertical, ref numberDelta1, ref numberDelta2);
				//Debug.Log ("Count H:" + numberHorizontal + " V:" + numberVertical + "  D1:" + numberDelta1 + "  D2:" + numberDelta2);
				Estimate.Mark(board, x, y, board[x, y].type, board[x,y].superType, numberHorizontal > 3, numberVertical > 3, numberDelta1 > 3, numberDelta2 > 3);
			}

			listBallGrow.Clear();
			GET_SCORE_AGAIN_EVENT.isHanddle = false;
			BALL_DELETE_ANIM_AGAIN_EVENT.isHanddle = true;

		}

		if (CREATE_NEW_BALL_EVENT.isHanddle)
		{

			List<int> listEmpty = new List<int>();
			for (int i = 0; i < GM.numberRow; i++)
				for (int j = 0; j < GM.numberColumn; j++)
					if (board[i, j] != null)
					{
						if (board[i, j].type < 100)
						{
							board[i, j].type += 100;
							board[i, j].ChangeRootScale(new Vector3(GM.unit, GM.unit, GM.unit));
							listBallGrow.Add(i * GM.numberColumn + j);
						}
					}
					else
						listEmpty.Add(i * GM.numberColumn + j);
			//Raise Ball Override
			for (int k = 0; k < numBallOverride; k++)
			{
				int position = Random.Range(0, listEmpty.Count);
				int value = listEmpty[position];
				listEmpty.RemoveAt(position);

				//int i = listBallOverride [k] / GM.numberColumn;
				//int j = listBallOverride [k] % GM.numberColumn;
				int inew = value / GM.numberColumn;
				int jnew = value % GM.numberColumn;
				board[inew, jnew] = new Ball(listBallOverride[k] < 100 ? listBallOverride[k] + 100 : listBallOverride[k], inew * GM.numberColumn + jnew, new Vector3(rootBoardPos.x + jnew * GM.unit * 1.4f, rootBoardPos.y - inew * GM.unit * 1.4f, -2), new Vector3(GM.unit, GM.unit, GM.unit));
				listNewBall.Add(value);
				//board [i, j].Destroy ();
			}

			for (int k = 0; k < 3; k++)
			{
				int type = GM.randomBall();
				int position = Random.Range(0, listEmpty.Count);
				int value = listEmpty[position];
				listEmpty.RemoveAt(position);

				int i = value / GM.numberColumn;
				int j = value % GM.numberColumn;
				board[i, j] = new Ball(type, i, new Vector3(rootBoardPos.x + j * GM.unit * 1.4f, rootBoardPos.y - i * GM.unit * 1.4f, -2), new Vector3(GM.unit / 4, GM.unit / 4, GM.unit / 4));
				listNewBall.Add(value);
			}

			numBallOverride = 0;
			listEmpty.Clear();
			listBallOverride.Clear();
			listBallOverridePos.Clear();
			listBallOverride = new List<int>();


			CREATE_NEW_BALL_EVENT.isHanddle = false;
			GET_SCORE_AGAIN_EVENT.isHanddle = true;

		}

		if (ADD_SPECIAL_BALL_ANIM_EVENT.isHanddle)
		{

			ADD_SPECIAL_BALL_ANIM_EVENT.isHanddle = false;
			if (numberHorizontal < GM.MIN_SCORE && numberVertical < GM.MIN_SCORE && numberDelta1 < GM.MIN_SCORE && numberDelta2 < GM.MIN_SCORE)
				CREATE_NEW_BALL_EVENT.isHanddle = true;
			else
			{

			}


		}

        if (BALL_DELETE_ANIM_EVENT.isHanddle)
        {
            if (typeReward < 0 || (int)(Time.time * 1000) - timeBeginDelete > 100)
            {
                for (int i = 0; i < GM.numberRow; i++)
                {
                    for (int j = 0; j < GM.numberColumn; j++)
                    {
                        if (board[i, j] != null && board[i, j].isScored)
                        {
                            countBall(board[i, j]);
                            board[i, j].Destroy();
                            board[i, j] = null;
                        }
                    }
                }
                for (int k = 0; k < numBallOverride; k++)
                {
                    int x = listBallOverridePos[k] / GM.numberColumn;
                    int y = listBallOverridePos[k] % GM.numberColumn;
                    if (board[x, y] == null)
                    {
                        board[x, y] = new Ball(listBallOverride[k], listBallOverridePos[k], new Vector3(rootBoardPos.x + y * GM.unit * 1.4f, rootBoardPos.y - x * GM.unit * 1.4f, -2), new Vector3(GM.unit / 4, GM.unit / 4, GM.unit / 4));
                        Debug.Log("New Ball Over at: " + x + "  " + y + "  " + listBallOverridePos[k]);
                    }
                }
                for (int i = 0; i < listBallDeleteAfter.Count; i++)
                {
                    listBallDeleteAfter[i].Destroy();
                }
                listBallDeleteAfter.Clear();
                //Add Anim here
                //...

                BALL_DELETE_ANIM_EVENT.isHanddle = false;
                ADD_SPECIAL_BALL_ANIM_EVENT.isHanddle = true;
            }
            else
            {
                for (int i = 0; i < GM.numberRow; i++)
                {
                    for (int j = 0; j < GM.numberColumn; j++)
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
			numberHorizontal = 1;
			numberVertical = 1;
			numberDelta1 = 1;
			numberDelta2 = 1;
			Estimate.EstimateNumberLine(board, x, y, targetBall.type, targetBall.superType, ref numberHorizontal, ref numberVertical, ref numberDelta1, ref numberDelta2);
			Debug.Log("Count H:" + numberHorizontal + " V:" + numberVertical + "  D1:" + numberDelta1 + "  D2:" + numberDelta2);
			Estimate.Mark(board, x, y, targetBall.type, targetBall.superType, numberHorizontal > GM.MIN_SCORE - 1, numberVertical > GM.MIN_SCORE - 1, numberDelta1 > GM.MIN_SCORE - 1, numberDelta2 > GM.MIN_SCORE - 1);


			typeReward = Estimate.EstimateBallReward(numberHorizontal, numberVertical, numberDelta1, numberDelta2);
			if (typeReward / 100 == 0 && typeReward > 0)
			{
				Debug.Log("Exlode " + x + "  " + y + "  " + typeReward);
				GM.lineScore += 5;
				Explode(typeReward % 100, x, y);
			}
			if (typeReward / 100 == 1)
			{
				Debug.Log("SUper Ball " + typeReward);
				if (board[x, y] != null)
					listBallDeleteAfter.Add(board[x, y]);
				GM.lineScore += 10;
				board[x, y] = new Ball(typeReward, 0, new Vector3(rootBoardPos.x + y * GM.unit * 1.4f, rootBoardPos.y - x * GM.unit * 1.4f, -2), new Vector3(GM.unit, GM.unit, GM.unit));
			}
			if (typeReward / 100 == 2)
			{
				Debug.Log("SUper Ball " + typeReward);

				if (board[x, y] != null)
					listBallDeleteAfter.Add(board[x, y]);
				GM.lineScore += 15;
				board[x, y] = new Ball(typeReward, 0, new Vector3(rootBoardPos.x + y * GM.unit * 1.4f, rootBoardPos.y - x * GM.unit * 1.4f, -2), new Vector3(GM.unit, GM.unit, GM.unit));
			}

			GET_SCORE_ESTIMATE_EVENT.isHanddle = false;
			targetBall = null;
			targetPos = null;
			BALL_DELETE_ANIM_EVENT.isHanddle = true;
            timeBeginDelete = (int)(Time.time * 1000);
			//Check Level mission success
			
		}
		if (BALL_MOVING_DONE_EVENT.isHanddle)
		{
			//Debug.Log ("DONE MOVE with " + (board [(int)indexTargetPos.x, (int)indexTargetPos.y] != null ? "ball " : "null") + " , " + (board [(int)indexTargetBall.x, (int)indexTargetBall.y] != null ? "ball2 ": "null"));

			//Destroy if Ball Small Override
			if (board[(int)indexTargetPos.x, (int)indexTargetPos.y] != null)
			{
				numBallOverride++;
				listBallOverride.Add(board[(int)indexTargetPos.x, (int)indexTargetPos.y].type);
				int valueBall = ((int)indexTargetPos.x) * GM.numberColumn + (int)indexTargetPos.y;
				listBallOverridePos.Add(valueBall);
				Debug.Log("Ball Over at: " + (int)indexTargetPos.x + "  " + (int)indexTargetPos.y + "  " + valueBall);
				board[(int)indexTargetPos.x, (int)indexTargetPos.y].Destroy();
			}

			board[(int)indexTargetPos.x, (int)indexTargetPos.y] = board[(int)indexTargetBall.x, (int)indexTargetBall.y];
			board[(int)indexTargetBall.x, (int)indexTargetBall.y] = null;
			BALL_MOVING_DONE_EVENT.isHanddle = false;
			GET_SCORE_ESTIMATE_EVENT.isHanddle = true;
			//Debug.Log ("after " + (board [(int)indexTargetPos.x, (int)indexTargetPos.y] != null ? "ball " : "null") + " , " + (board [(int)indexTargetBall.x, (int)indexTargetBall.y] != null ? "ball2 ": "null"));
			return;
		}
		if (BALL_MOVING_EVENT.isHanddle)
		{
			//parent.StartCoroutine (GM.Wait (1f));
			if ((int)(Time.time * 1000) - Ball.BallMovingTime < 20)
				return;

			int x = (int)indexRunBall.x;
			int y = (int)indexRunBall.y;
			if (indexRunBall.x != indexTargetPos.x || indexRunBall.y != indexTargetPos.y)
			{
				bool found = false;
				for (int i = x - 1; i <= x + 1 && !found; i++)
					for (int j = y - 1; j <= y + 1 && !found; j++)
						if ((i != x || j != y) && i >= 0 && j >= 0 && i < GM.numberRow && j < GM.numberColumn && (Mathf.Abs(x - i) + Mathf.Abs(y - j) == 1) && pathMove[i, j] == pathMove[x, y] - 1)
						{
							indexRunBall = new Vector3(i, j);
							found = true;

						}
				if (found)
				{
					//Debug.Log ("Found " + indexRunBall.x + "  " + indexRunBall.y);
					targetBall.Position = new Vector3(rootBoardPos.x + indexRunBall.y * GM.unit * 1.4f, rootBoardPos.y - indexRunBall.x * GM.unit * 1.4f, -2);
					Ball.BallMovingTime = (int)(Time.time * 1000);
				}
				else
					Debug.Log("NotFound ");
			}
			else
			{
				BALL_MOVING_EVENT.isHanddle = false;
				BALL_MOVING_DONE_EVENT.isHanddle = true;
			}
			return;
		}
		if (BALL_START_MOVE_EVENT.isHanddle)
		{
			//Debug.Log ("IndexBall " + indexTargetBall.x + "  " + indexTargetBall.y + " =  " + board[(int)indexTargetBall.x, (int)indexTargetBall.y].type);
			//Debug.Log ("IndexPos " + indexTargetPos.x + "  " + indexTargetPos.y );
			//Debug.Log ("-------------------------------------------------------");
			pathMove = BFS.doBFS(board, indexTargetPos, indexTargetBall);

			//Debug.Log ("Finish Pos Value is: " + pathMove [(int)indexTargetBall.x, (int)indexTargetBall.y]);

			if (pathMove[(int)indexTargetBall.x, (int)indexTargetBall.y] > 0)
			{
				pathMove[(int)indexTargetPos.x, (int)indexTargetPos.y] = 0;
				indexRunBall = new Vector3(indexTargetBall.x, indexTargetBall.y, 0);
				Ball.BallMovingTime = (int)(Time.time * 1000);
				targetBall.IsAnimation = false;
				BALL_MOVING_EVENT.isHanddle = true;
			}
			BALL_START_MOVE_EVENT.isHanddle = false;
			return;
		}

		ChooseBall();

		for (int i = 0; i < GM.numberRow; i++)
			for (int j = 0; j < GM.numberColumn; j++)
				if (board[i, j] != null)
					board[i, j].Update();


	}

	void ChooseBall()
	{

		if (Input.GetMouseButtonDown(0))//(Input.GetKeyDown(KeyCode.L))

        {

			Vector2 positionToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

			for (int i = 0; i < GM.numberRow; i++)
				for (int j = 0; j < GM.numberColumn; j++)
					//if (board [i, j] != null) {
					if (Pos.Contains(new Vector3(rootBoardPos.x + j * GM.unit * 1.4f, rootBoardPos.y - i * GM.unit * 1.4f, -2), ballSize, positionToWorldPoint))
					{

						//board [i, j].Scale = 0;
						if (board[i, j] != null && board[i, j].type > 100 && targetBall == null)
						{
							board[i, j].IsAnimation = true;
							targetBall = board[i, j];
							indexTargetBall = new Vector3(i, j, 0);
                            //Debug.Log("BALL TYPE:" + board[i, j].type);
							//targetBall.Scale = 0;
						}
						else if ((board[i, j] == null || board[i, j].type < 100) && targetBall != null)
						{

							//Move Event
							indexTargetPos = new Vector3(i, j, 0);
							BALL_START_MOVE_EVENT.isHanddle = true;

						}
						else if (board[i, j] != null && board[i, j].type > 100 && targetBall != null)
						{

							//Reset target
							targetBall.IsAnimation = false;
							targetBall = null;

						}

						//}
					}
			//}
		}

		int tapCount = 0;
		while (tapCount < Input.touches.Length)
		{
			Touch touch = Input.GetTouch(tapCount);
			tapCount++;
			GM.debugText.text = "Choose Ball";

			Vector2 positionToWorldPoint = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);

			for (int i = 0; i < GM.numberRow; i++)
				for (int j = 0; j < GM.numberColumn; j++)
					//if (board[i, j] != null)
				{
					//if (Pos.Contains(board[i, j].Position, ballSize, positionToWorldPoint))
					if (Pos.Contains(new Vector3(rootBoardPos.x + j * GM.unit * 1.4f, rootBoardPos.y - i * GM.unit * 1.4f, -2), ballSize, positionToWorldPoint))
					{
						if (touch.phase == TouchPhase.Began)
						{
							//board [i, j].Scale = 0;

						}
						else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
						{

							if (board[i, j] != null && board[i, j].type > 100 && targetBall == null)
							{
								board[i, j].IsAnimation = true;
								targetBall = board[i, j];
								indexTargetBall = new Vector3(i, j, 0);
							}
							else if ((board[i, j] == null || board[i, j].type < 100) && targetBall != null)
							{

								//Move Event
								Debug.Log("Choose Ball Small");
								indexTargetPos = new Vector3(i, j, 0);
								BALL_START_MOVE_EVENT.isHanddle = true;

							}
							else if (board[i, j] != null && board[i, j].type > 100 && targetBall != null)
							{

								//Reset target
								targetBall.IsAnimation = false;
								targetBall = null;

							}


						}
						else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
						{

						}
						else
						{

						}


					}
					else
					{

					}
				}
		}
        if (Input.GetKey(KeyCode.L))
        {
            printPath();
        }

	}
	public void printPath()
	{

		for (int ii = 0; ii < GM.numberRow; ii++)
		{
			string s = "";
			for (int jj = 0; jj < GM.numberColumn; jj++)
			{
				if (board[ii, jj] != null)
					s += board[ii, jj].type + 1 +"  ";
				else
					s += 0 +"  ";
			}
			Debug.Log("... " + s);
		}
	}
	void Explode(int typePos, int x, int y)
	{
		if (typePos == 1)
			for (int i = 0; i < GM.numberRow; i++)
				if (board[i, y] != null)
				{
					countBall(board[i, y]);
					board[i, y].Destroy();
					board[i, y] = null;
				}
		if (typePos == 2)
			for (int i = 0; i < GM.numberColumn; i++)
				if (board[x, i] != null)
				{
					countBall(board[x, i]);
					board[x, i].Destroy();
					board[x, i] = null;
				}


		if (typePos == 3)
			for (int i = 0; i < GM.numberRow; i++)
				for (int j = 0; j < GM.numberColumn; j++)
					if (i - j == x - y && board[i, j] != null)
					{
						countBall(board[i, j]);
						board[i, j].Destroy();
						board[i, j] = null;
					}
		//0 -8 , 1 - 7

		if (typePos == 4)
			for (int i = 0; i < GM.numberRow; i++)
				for (int j = 0; j < GM.numberColumn; j++)
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
		GM.lineScore++;
		if (ball.type == 1)
			numberBlueObtain++;
		if (ball.type == 2)
			numberYellowObtain++;
		if (ball.type == 3)
			numberGreenObtain++;
		if (ball.type == 4)
			numberRedObtain++;
		if (ball.type == 5)
			numberPurpleObtain++;

		if (ball.type == 110)
			numberSuperObtain++;
		if (ball.type == 111)
			numberSuperObtain++;
		if (ball.type == 112)
			numberSuperObtain++;

		if (ball.type == 120)
			numberUltraObtain++;

		if (ball.type == 130)
			numberFreezeObtain++;
		if (ball.type == 131)
			numberAllcolorObtain++;
		if (ball.type == 132)
			numberExplodeObtain++;

	}

}
