using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.A))
		//	doBFS ();
	}

	public static void Print(Ball[,] board)
	{
		int[,] boardInt = new int[board.GetLength (0), board.GetLength (1)];

        for (int i = GM.numberRow - 1; i >= 0 ; i--)
        {
            string s = "";
            for (int j = 0; j < GM.numberColumn; j++)
            {
                if (board[j, i] != null)
                    ;// boardInt[j, i] = 0;
                else
                    ;// boardInt[j, i] = board[j, i].type %  10;
                s += board[j, i] != null ? (board[j, i].type + 1) +"   " : "0  ";
            }
            Debug.Log("... " + s);
        }
	}

	public static int[,] doBFS(Ball[,] board, Vector3 startPos, Vector3 finishPos, bool isEther = false)
	{
		//int w = 5;
		//int h = 5;
//		int[,] a = {{ 0, 1, 0, 0, 0 },
//					{ 0, 0, 0, 0, 0 },
//					{ 0, -1, 0, -1, 0 },
//					{ 0, 0, 0, 0, 0 },
//					{ 0, 0, 1, 0, 0 },
//		};
		int[,] boardInt = new int[board.GetLength (0), board.GetLength (1)];
		//int w = board.GetLength (0);
		//int h = board.GetLength (1);
		for (int i = 0; i < GM.numberColumn; i++) {
			string s = "";
			for (int j = 0; j < GM.numberRow; j++) {
				if (board [i, j] != null && board [i, j].type >= 100)
					boardInt [i, j] = isEther ? 0 : -1;
				else
					boardInt [i, j] = 0;
				s += boardInt [i, j] + "   ";
			}
			//Debug.Log ("... "+s);
		}

		Queue stk = new Queue ();
		Queue stkpos = new Queue ();
		boardInt [(int)finishPos.x, (int)finishPos.y] = 0;
		stk.Enqueue (boardInt [(int)startPos.x, (int)startPos.y]);
		stkpos.Enqueue (new Vector3 ((int)startPos.x, (int)startPos.y, 0));
		int count = 0;
		while (stk.Count > 0) {
			if (count++ > 500)// || boardInt [(int)finishPos.x, (int)finishPos.y] > 0)
				break;
			int val = (int)stk.Dequeue ();
			Vector3 pos = (Vector3)stkpos.Dequeue ();
			int x = (int)pos.x;
			int y = (int)pos.y;
			//Debug.Log ("Pop " + x + " " + y + ": " + a [x, y]);
			for (int i = x - 1; i <= x + 1; i++)
				for (int j = y - 1; j <= y + 1; j++)
					if ((i != x || j != y) && i >= 0 && j >= 0 && i < GM.numberColumn && j < GM.numberRow && (Mathf.Abs (x - i) + Mathf.Abs (y - j) == 1) && (boardInt [i, j] == 0 || boardInt [i, j] > boardInt [x, y] + 1))
                    {

						boardInt [i, j] = boardInt [x, y] + 1;
						stk.Enqueue (boardInt [i, j]);
						stkpos.Enqueue (new Vector3 (i, j, 0));

					}
		}
        /*
		if (count >= 500)
			Debug.Log ("Break With Count > 500");
		Debug.Log ("--------------------------------------------------");
		for (int i = 0; i < GM.numberColumn; i++) {
			string s = "";
			for (int j = 0; j < GM.numberRow; j++)
				s += boardInt [i, j] + "  ";
			//Debug.Log (s);
		}
		Debug.Log ("--------------------------------------------------");
        */
		return boardInt;
	}

    public static Vector2 ChooseRandomBall(Ball[,] board, int x, int y)
    {
        int countnotnul = 0;
        for (int i = 0; i < GM.numberColumn; i++)
            for (int j = 0; j < GM.numberRow; j++)
                if (board[i, j] != null && !board[i, j].isDie && !board[i, j].isScored && board[i, j].type > 99 && (i != x || j != y))
                    countnotnul++;
        int choose = Random.Range(0, countnotnul);
        countnotnul = 0;
        for (int i = 0; i < GM.numberColumn; i++)
            for (int j = 0; j < GM.numberRow; j++)
                if (board[i, j] != null && !board[i, j].isDie && !board[i, j].isScored && board[i,j].type > 99 && (i != x || j != y))
                {
                    countnotnul++;
                    if (countnotnul == choose)
                        return new Vector2(i, j);
                }
        return Vector2.zero;
    }
}
