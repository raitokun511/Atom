using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estimate : MonoBehaviour
{

	public static void EstimateNumberLine(Ball[,] board, int x, int y, int typeBall, int superTypeBall, ref int numberHorizontal, ref int numberVertical, ref int numberDelta1, ref int numberDelta2)
	{
		int i = x;

		while (i > 0 && board[i - 1, y] != null && Estimate.matchBall(board[i - 1, y].type, typeBall))
		{
			i--;
			numberHorizontal++;
		}
		i = x;
		while (i + 1 < GM.numberRow && board[i + 1, y] != null && Estimate.matchBall(board[i + 1, y].type, typeBall) )
		{
			i++;

			numberHorizontal++;
		}
		//Do chieu ngang
		i = y;
		while (i > 0 && board[x, i - 1] != null && Estimate.matchBall(board[x, i - 1].type, typeBall))
		{
			i--;
			numberVertical++;
		}
		i = y;
		while (i + 1 < GM.numberColumn && board[x, i + 1] != null && Estimate.matchBall(board[x, i + 1].type, typeBall))
		{
			i++;
			numberVertical++;
		}
		//Debug.Log ("Vertical: " + numberVertical);
		//Do d1
		i = x;
		int j = y;
		while (i > 0 && j > 0 && board[i - 1, j - 1] != null && Estimate.matchBall(board[i - 1, j - 1].type, typeBall))
		{
			i--;
			j--;
			numberDelta1++;
		}
		i = x;
		j = y;
		while (i + 1 < GM.numberRow && j + 1 < GM.numberColumn && board[i + 1, j + 1] != null && Estimate.matchBall(board[i + 1, j + 1].type, typeBall))
		{
			i++;
			j++;
			numberDelta1++;
		}
		//Debug.Log ("D1: " + numberDelta1);

		//Do d2
		i = x;
		j = y;
		while (i > 0 && j + 1 < GM.numberColumn && board[i - 1, j + 1] != null && Estimate.matchBall(board[i - 1, j + 1].type, typeBall))
		{
			i--;
			j++;
			numberDelta2++;
		}
		i = x;
		j = y;
        while (i + 1 < GM.numberRow && j > 0 && board[i + 1, j - 1] != null && Estimate.matchBall(board[i + 1, j - 1].type, typeBall))
        {
            i++;
            j--;
            numberDelta2++;
        }
		//Debug.Log ("D2: " + numberDelta2);

	}


	public static void Mark(Ball[,] board, int x, int y, int typeBall,int superTypeBall, bool getHorizontal, bool getVertical, bool getD1, bool getD2)
	{
		Debug.Log("type: " + typeBall + " " + getHorizontal + "  " + getVertical + "  " + getD1 + "  " + getD2);
		if (getHorizontal)
		{
			board[x, y].isScored = true;
			int i = x;
            while (i > 0 && board[i - 1, y] != null && Estimate.matchBall(board[i - 1, y].type, typeBall))
            {
                i--;
                board[i, y].isScored = true;
                //Debug.Log("b[" + i + "," + y + "]");
            }
			i = x;
            while (i + 1 < GM.numberRow && board[i + 1, y] != null && Estimate.matchBall(board[i + 1, y].type, typeBall))
            {
                i++;
                board[i, y].isScored = true;
                //Debug.Log("b[" + i + "," + y + "]");
            }
		}
		if (getVertical)
		{
			board[x, y].isScored = true;
			int i = y;
            while (i > 0 && board[x, i - 1] != null && Estimate.matchBall(board[x, i - 1].type, typeBall))
            {
                i--;
                board[x, i].isScored = true;
                //Debug.Log("b[" + x + "," + i + "]");
            }
			i = y;
            while (i + 1 < GM.numberColumn && board[x, i + 1] != null && Estimate.matchBall(board[x, i + 1].type, typeBall))
            {
                i++;
                board[x, i].isScored = true;
                //Debug.Log("b[" + x + "," + i + "]");
            }
		}
		if (getD1)
		{
			board[x, y].isScored = true;
			int i = x;
			int j = y;
            while (i > 0 && j > 0 && board[i - 1, j - 1] != null && Estimate.matchBall(board[i - 1, j - 1].type, typeBall))
            {
                i--;
                j--;
                board[i, j].isScored = true;
            }
			i = x;
			j = y;
            while (i + 1 < GM.numberRow && j + 1 < GM.numberColumn && board[i + 1, j + 1] != null && Estimate.matchBall(board[i + 1, j + 1].type, typeBall))
            {
                i++;
                j++;
                board[i, j].isScored = true;
            }
		}
		if (getD2)
		{
			board[x, y].isScored = true;
			int i = x;
			int j = y;
            while (i > 0 && j + 1 < GM.numberColumn && board[i - 1, j + 1] != null && Estimate.matchBall(board[i - 1, j + 1].type, typeBall))
            {
                i--;
                j++;
                board[i, j].isScored = true;
            }
			i = x;
			j = y;
            while (i + 1 < GM.numberRow && j > 0 && board[i + 1, j - 1] != null && Estimate.matchBall(board[i + 1, j - 1].type, typeBall))
            {
                i++;
                j--;
                board[i, j].isScored = true;
            }
		}

	}
    static bool matchBall(int type1, int type2)
    {
        if (type1 == type2)
            return true;
        return false;

    }
    static bool matchLineBall(int type1, int type2, int superType1, int superType2)
	{
        //B Y G R P
		if (type1 == 120 || type2 == 120)//and not other special
			return true;
		if (type1 == type2)
			return true;
        int binType1 = 1 << (superType1 < 0 ? 5 - (type1 % 100) + 1: 0);
        int binType2 = 1 << (superType2 < 0 ? 5 - (type2 % 100) + 1 : 0);
        if (superType1 >= 0)
        {
            if (superType1 == 0)
                binType1 = 11;// 01011
            if (superType1 == 1)
                binType1 = 13;// 01101
            if (superType1 == 2)
                binType1 = 26;// 11010
            if (superType1 == 3)
                binType1 = 14;// 01110
            if (superType1 == 4)
                binType1 = 28;// 11100
            
        }
        if (superType2 >= 0)
        {
            if (superType2 == 0)
                binType2 = 11;// 01011
            if (superType2 == 1)
                binType2 = 13;// 01101
            if (superType2 == 2)
                binType2 = 26;// 11010
            if (superType2 == 3)
                binType2 = 14;// 01110
            if (superType2 == 4)
                binType2 = 28;// 11100
        }
        if (superType1 >= 0 || superType2 >= 0)
            Debug.Log("bin1:" + binType1 + " bin2:" + binType2 + " sup1:" + superType1 + " sup2:" + superType2 +" type1:" + type1+" type2:"+type2);

        if ((binType1 & binType2) != 0)
            return true;

		if (type1 == 101 && (type2 == 110 || type2 == 111 || type2 == 112))
			return true;
		if (type2 == 101 && (type1 == 110 || type1 == 111 || type1 == 112))
			return true;
		

		return false;
		
	}

	public static int EstimateBallReward(int numberHorizontal, int numberVertical, int numberDelta1, int numberDelta2)
	{
		//An 5 o
		if (numberHorizontal == GM.MIN_EXPLODE && numberVertical < GM.MIN_SCORE && numberDelta1 < GM.MIN_SCORE && numberDelta2 < GM.MIN_SCORE)
			return 1;
		if (numberHorizontal < GM.MIN_SCORE && numberVertical == GM.MIN_EXPLODE && numberDelta1 < GM.MIN_SCORE && numberDelta2 < GM.MIN_SCORE)
			return 2;
		if (numberHorizontal < GM.MIN_SCORE && numberVertical < GM.MIN_SCORE && numberDelta1 == GM.MIN_EXPLODE && numberDelta2 < GM.MIN_SCORE)
			return 3;
		if (numberHorizontal < GM.MIN_SCORE && numberVertical < GM.MIN_SCORE && numberDelta1 < GM.MIN_SCORE && numberDelta2 == GM.MIN_EXPLODE)
			return 4;

		if (numberHorizontal == GM.CREATE_BALL3_SCORE && numberVertical < GM.MIN_SCORE && numberDelta1 < GM.MIN_SCORE && numberDelta2 < GM.MIN_SCORE)
			return 110;
		if (numberHorizontal < GM.MIN_SCORE && numberVertical == GM.CREATE_BALL3_SCORE && numberDelta1 < GM.MIN_SCORE && numberDelta2 < GM.MIN_SCORE)
			return 111;
		if (numberHorizontal < GM.MIN_SCORE && numberVertical < GM.MIN_SCORE && numberDelta1 == GM.CREATE_BALL3_SCORE && numberDelta2 < GM.MIN_SCORE)
			return 112;
		if (numberHorizontal < GM.MIN_SCORE && numberVertical < GM.MIN_SCORE && numberDelta1 < GM.MIN_SCORE && numberDelta2 == GM.CREATE_BALL3_SCORE)
			return 113;

		if (numberHorizontal == GM.CREATE_BALL5_SCORE && numberVertical < GM.MIN_SCORE && numberDelta1 < GM.MIN_SCORE && numberDelta2 < GM.MIN_SCORE)
			return 120;
		if (numberHorizontal < GM.MIN_SCORE && numberVertical == GM.CREATE_BALL5_SCORE && numberDelta1 < GM.MIN_SCORE && numberDelta2 < GM.MIN_SCORE)
			return 120;
		if (numberHorizontal < GM.MIN_SCORE && numberVertical < GM.MIN_SCORE && numberDelta1 == GM.CREATE_BALL5_SCORE && numberDelta2 < GM.MIN_SCORE)
			return 120;
		if (numberHorizontal < GM.MIN_SCORE && numberVertical < GM.MIN_SCORE && numberDelta1 < GM.MIN_SCORE && numberDelta2 == GM.CREATE_BALL5_SCORE)
			return 120;

        if (numberHorizontal == GM.MIN_SCORE || numberVertical == GM.MIN_SCORE || numberDelta1 == GM.MIN_SCORE || numberDelta2 == GM.MIN_SCORE)
            return 0;

		return -1;

	}

    public static int EstimateRound(Ball[,] board, int x, int y)
    {
        if (board[x, y] == null)
            return -1;
        int type = board[x, y].type;


        if (y - 1 >= 0 && y + 1 < GM.numberRow)
        {
            // X X
            // X O
            // X X
            if (x - 1 >= 0)
                if (board[x, y - 1] != null && board[x, y + 1] != null && board[x - 1, y - 1] != null && board[x - 1, y] != null && board[x - 1, y + 1] != null &&
                    !board[x, y - 1].isScored && !board[x, y + 1].isScored && !board[x - 1, y - 1].isScored && !board[x - 1, y].isScored &&
                    compareBall(board[x, y - 1].type, type) && compareBall(board[x, y + 1].type, type) && compareBall(board[x - 1, y - 1].type, type)
                    && compareBall(board[x - 1, y].type, type) && board[x - 1, y + 1] != null && compareBall(board[x - 1, y + 1].type, type))
                {
                    if (checkNotAllChromeBall(board[x, y], board[x, y - 1], board[x, y + 1], board[x - 1, y - 1], board[x - 1, y], board[x - 1, y + 1]))
                    {
                        board[x, y].isScored = true;
                        board[x, y - 1].isScored = true;
                        board[x, y + 1].isScored = true;
                        board[x - 1, y - 1].isScored = true;
                        board[x - 1, y].isScored = true;
                        board[x - 1, y + 1].isScored = true;
                        return 6;
                    }
                }

            // X X
            // O X
            // X X
            if (x + 1 < GM.numberColumn)
                if (board[x, y - 1] != null && board[x, y + 1] != null && board[x + 1, y - 1] != null && board[x + 1, y] != null && board[x + 1, y + 1] != null)
                    if (!board[x, y - 1].isScored && !board[x, y + 1].isScored && !board[x + 1, y - 1].isScored && !board[x + 1, y].isScored && !board[x + 1, y + 1].isScored)
                        if (compareBall(board[x, y - 1].type, type) && compareBall(board[x, y + 1].type, type) &&
                        compareBall(board[x + 1, y - 1].type, type) && compareBall(board[x + 1, y].type, type) && compareBall(board[x + 1, y + 1].type, type))
                    {
                            if (checkNotAllChromeBall(board[x, y], board[x, y - 1], board[x, y + 1], board[x + 1, y - 1], board[x + 1, y], board[x + 1, y + 1]))
                            {
                                board[x, y].isScored = true;
                                board[x, y - 1].isScored = true;
                                board[x, y + 1].isScored = true;
                                board[x + 1, y - 1].isScored = true;
                                board[x + 1, y].isScored = true;
                                board[x + 1, y + 1].isScored = true;
                                return 6;
                            }
                    }
        }

        if (x - 1 >= 0 && x + 1 < GM.numberColumn)
        {
            // X X X
            // X O X
            if (y + 1 < GM.numberRow)
                if (board[x - 1, y] != null && board[x + 1, y] != null && board[x - 1, y + 1] != null && board[x, y + 1] != null && board[x + 1, y + 1] != null)
                    if (!board[x - 1, y].isScored && !board[x + 1, y].isScored && !board[x - 1, y + 1].isScored && !board[x, y + 1].isScored && !board[x + 1, y + 1].isScored)
                        if (compareBall(board[x - 1, y].type, type) && compareBall(board[x + 1, y].type, type) &&
                        compareBall(board[x - 1, y + 1].type, type) && compareBall(board[x, y + 1].type, type) && compareBall(board[x + 1, y + 1].type, type))
                        {
                            if (checkNotAllChromeBall(board[x, y], board[x - 1, y], board[x + 1, y], board[x - 1, y + 1], board[x, y + 1], board[x + 1, y + 1]))
                            {
                                board[x, y].isScored = true;
                                board[x - 1, y].isScored = true;
                                board[x + 1, y].isScored = true;
                                board[x - 1, y + 1].isScored = true;
                                board[x, y + 1].isScored = true;
                                board[x + 1, y + 1].isScored = true;
                                return 6;
                            }
                        }
            // X O X
            // X X X
            if (y - 1 >= 0)
                if (board[x - 1, y] != null && board[x + 1, y] != null && board[x - 1, y - 1] != null && board[x, y - 1] != null && board[x + 1, y - 1] != null)
                    if (!board[x - 1, y].isScored && !board[x + 1, y].isScored && !board[x - 1, y - 1].isScored && !board[x, y - 1].isScored && !board[x + 1, y - 1].isScored)
                        if (compareBall(board[x - 1, y].type, type) && compareBall(board[x + 1, y].type, type) &&
                        compareBall(board[x - 1, y - 1].type, type) && compareBall(board[x, y - 1].type, type) && compareBall(board[x + 1, y - 1].type, type))
                        {
                            if (checkNotAllChromeBall(board[x, y], board[x - 1, y], board[x + 1, y], board[x - 1, y - 1], board[x, y - 1], board[x + 1, y - 1]))
                            {
                                board[x, y].isScored = true;
                                board[x - 1, y].isScored = true;
                                board[x + 1, y].isScored = true;
                                board[x - 1, y - 1].isScored = true;
                                board[x, y - 1].isScored = true;
                                board[x + 1, y - 1].isScored = true;
                                return 6;
                            }
                        }
        }

        // X X
        // X X
        /*
        Debug.Log("(" + x + "," + y + ") === " +
            (x + 1 < GM.numberColumn ? (board[x + 1, y] != null ? board[x + 1, y].type + "" : "boardnull") : "(x+1 over)") + " , " +
            (y + 1 < GM.numberRow ? (board[x, y + 1] != null ? board[x, y + 1].type + "" : "boardnull") + "" : "(y+1 over)") + " , " +
            (x + 1 < GM.numberColumn && y + 1 < GM.numberRow ? (board[x + 1, y + 1] != null ? board[x + 1, y + 1].type + "" : "boardnull") + "" : "x+1 y+1 over"));
            */
        if (x + 1 < GM.numberColumn && y + 1 < GM.numberRow)
            if (board[x + 1, y] != null && board[x, y + 1] != null && board[x + 1, y + 1] != null)
                if (!board[x + 1, y].isScored && !board[x, y + 1].isScored && !board[x + 1, y + 1].isScored)
                    if (compareBall(board[x + 1, y].type, type) && compareBall(board[x, y + 1].type, type) && compareBall(board[x + 1, y + 1].type, type))
                {
                        if (checkNotAllChromeBall(board[x, y], board[x+1, y], board[x, y + 1], board[x + 1, y + 1]))
                        {
                            board[x, y].isScored = true;
                            board[x + 1, y].isScored = true;
                            board[x, y + 1].isScored = true;
                            board[x + 1, y + 1].isScored = true;
                            return 4;
                        }
                }
        if (x + 1 < GM.numberColumn && y - 1 >= 0)
            if (board[x + 1, y] != null && board[x, y - 1] != null && board[x + 1, y - 1] != null)
                if (!board[x + 1, y].isScored && !board[x, y - 1].isScored && !board[x + 1, y - 1].isScored)
                    if (compareBall(board[x + 1, y].type, type) && compareBall(board[x, y - 1].type, type) && compareBall(board[x + 1, y - 1].type, type))
                    {
                        if (checkNotAllChromeBall(board[x, y], board[x + 1, y], board[x, y - 1], board[x + 1, y - 1]))
                        {
                            board[x, y].isScored = true;
                            board[x + 1, y].isScored = true;
                            board[x, y - 1].isScored = true;
                            board[x + 1, y - 1].isScored = true;
                            return 4;
                        }
                    }
        if (x - 1 >= 0 && y + 1 < GM.numberRow)
            if (board[x - 1, y] != null && board[x, y + 1] != null && board[x - 1, y + 1] != null)
                if (!board[x - 1, y].isScored && !board[x, y + 1].isScored && !board[x - 1, y + 1].isScored)
                    if (compareBall(board[x - 1, y].type, type) && compareBall(board[x, y + 1].type, type) && compareBall(board[x - 1, y + 1].type, type))
                {
                        if (checkNotAllChromeBall(board[x, y], board[x - 1, y], board[x, y + 1], board[x - 1, y + 1]))
                        {
                            board[x, y].isScored = true;
                            board[x - 1, y].isScored = true;
                            board[x, y + 1].isScored = true;
                            board[x - 1, y + 1].isScored = true;
                            return 4;
                        }
                }
        if (x - 1 >= 0 && y - 1 >= 0)
            if (board[x - 1, y] != null && board[x, y - 1] != null && board[x - 1, y - 1] != null)
                if (!board[x - 1, y].isScored && !board[x, y - 1].isScored && !board[x - 1, y - 1].isScored)
                    if (compareBall(board[x - 1, y].type, type) && compareBall(board[x, y - 1].type, type) && compareBall(board[x - 1, y - 1].type, type))
                {
                        if (checkNotAllChromeBall(board[x, y], board[x - 1, y], board[x, y - 1], board[x - 1, y - 1]))
                        {
                            board[x, y].isScored = true;
                            board[x - 1, y].isScored = true;
                            board[x, y - 1].isScored = true;
                            board[x - 1, y - 1].isScored = true;
                            return 4;
                        }
                }
        return -1;
    }
    public static int EstimatePatern(Ball[,] board, int x, int y)
    {
        if (board[x, y] == null)
            return -1;
        int type = board[x, y].type;


        if (y - 1 >= 0 && y + 1 < GM.numberRow)
        {
            // X X
            // X O
            // X X
            if (x - 1 >= 0)
                if (board[x, y - 1] != null && board[x, y + 1] != null && board[x - 1, y - 1] != null && board[x - 1, y] != null && board[x - 1, y + 1] != null &&
                    //!board[x, y - 1].isScored && !board[x, y + 1].isScored && !board[x - 1, y - 1].isScored && !board[x - 1, y].isScored &&
                    compareBall(board[x, y - 1].type, type) && compareBall(board[x, y + 1].type, type) && compareBall(board[x - 1, y - 1].type, type)
                    && compareBall(board[x - 1, y].type, type) && board[x - 1, y + 1] != null && compareBall(board[x - 1, y + 1].type, type))
                {
                    if (checkNotAllChromeBall(board[x, y], board[x, y - 1], board[x, y + 1], board[x - 1, y - 1], board[x - 1, y], board[x - 1, y + 1]))
                    {
                        if (x == 2 && y == 4)
                            return 6;
                        return -1;
                    }
                }

            // X X
            // O X
            // X X
            if (x + 1 < GM.numberColumn)
                if (board[x, y - 1] != null && board[x, y + 1] != null && board[x + 1, y - 1] != null && board[x + 1, y] != null && board[x + 1, y + 1] != null)
                    //if (!board[x, y - 1].isScored && !board[x, y + 1].isScored && !board[x + 1, y - 1].isScored && !board[x + 1, y].isScored && !board[x + 1, y + 1].isScored)
                        if (compareBall(board[x, y - 1].type, type) && compareBall(board[x, y + 1].type, type) &&
                        compareBall(board[x + 1, y - 1].type, type) && compareBall(board[x + 1, y].type, type) && compareBall(board[x + 1, y + 1].type, type))
                        {
                            if (checkNotAllChromeBall(board[x, y], board[x, y - 1], board[x, y + 1], board[x + 1, y - 1], board[x + 1, y], board[x + 1, y + 1]))
                            {
                                if (x == 1 && y == 4)
                                    return 6;
                                return -1;
                            }
                        }
        }

        if (x - 1 >= 0 && x + 1 < GM.numberColumn)
        {
            // X X X
            // X O X
            if (y + 1 < GM.numberRow)
                if (board[x - 1, y] != null && board[x + 1, y] != null && board[x - 1, y + 1] != null && board[x, y + 1] != null && board[x + 1, y + 1] != null)
                    //if (!board[x - 1, y].isScored && !board[x + 1, y].isScored && !board[x - 1, y + 1].isScored && !board[x, y + 1].isScored && !board[x + 1, y + 1].isScored)
                        if (compareBall(board[x - 1, y].type, type) && compareBall(board[x + 1, y].type, type) &&
                        compareBall(board[x - 1, y + 1].type, type) && compareBall(board[x, y + 1].type, type) && compareBall(board[x + 1, y + 1].type, type))
                        {
                            if (checkNotAllChromeBall(board[x, y], board[x - 1, y], board[x + 1, y], board[x - 1, y + 1], board[x, y + 1], board[x + 1, y + 1]))
                            {
                                if (x == 6 && y == 1)
                                    return 6;
                                return -1;
                            }
                        }
            // X O X
            // X X X
            if (y - 1 >= 0)
                if (board[x - 1, y] != null && board[x + 1, y] != null && board[x - 1, y - 1] != null && board[x, y - 1] != null && board[x + 1, y - 1] != null)
                    //if (!board[x - 1, y].isScored && !board[x + 1, y].isScored && !board[x - 1, y - 1].isScored && !board[x, y - 1].isScored && !board[x + 1, y - 1].isScored)
                        if (compareBall(board[x - 1, y].type, type) && compareBall(board[x + 1, y].type, type) &&
                        compareBall(board[x - 1, y - 1].type, type) && compareBall(board[x, y - 1].type, type) && compareBall(board[x + 1, y - 1].type, type))
                        {
                            if (checkNotAllChromeBall(board[x, y], board[x - 1, y], board[x + 1, y], board[x - 1, y - 1], board[x, y - 1], board[x + 1, y - 1]))
                            {
                                if (x == 6 && y == 2)
                                    return 6;
                                return -1;
                            }
                        }
        }

        // X X
        // X X
        if (x + 1 < GM.numberColumn && y + 1 < GM.numberRow)
            if (board[x + 1, y] != null && board[x, y + 1] != null && board[x + 1, y + 1] != null)
                //if (!board[x + 1, y].isScored && !board[x, y + 1].isScored && !board[x + 1, y + 1].isScored)
                    if (compareBall(board[x + 1, y].type, type) && compareBall(board[x, y + 1].type, type) && compareBall(board[x + 1, y + 1].type, type))
                    {
                        if ((x == 4 && y == 5) || (x == 2 && y == 0))//X  X
                            return 4;                                //O  X
                        if ((x == 1 && y == 3) || (x == 1 && y == 4))//X  X
                            return 4;                                //O  X
                        if ((x == 5 && y == 1) || (x == 6 && y == 1))//X  X
                            return 4;                                //O  X
                    }
        if (x + 1 < GM.numberColumn && y - 1 >= 0)
            if (board[x + 1, y] != null && board[x, y - 1] != null && board[x + 1, y - 1] != null)
                //if (!board[x + 1, y].isScored && !board[x, y - 1].isScored && !board[x + 1, y - 1].isScored)
                    if (compareBall(board[x + 1, y].type, type) && compareBall(board[x, y - 1].type, type) && compareBall(board[x + 1, y - 1].type, type))
                    {
                        if (checkNotAllChromeBall(board[x, y], board[x + 1, y], board[x, y - 1], board[x + 1, y - 1]))
                        {
                            if ((x == 4 && y == 6) || (x == 2 && y == 1))//O  X
                                return 4;                                //X  X
                            if ((x == 1 && y == 5) || (x == 1 && y == 4))//O  X
                                return 4;                                //X  X
                            if ((x == 5 && y == 2) || (x == 6 && y == 2))//O  X
                                return 4;                                //X  X
                        }
                    }
        if (x - 1 >= 0 && y + 1 < GM.numberRow)
            if (board[x - 1, y] != null && board[x, y + 1] != null && board[x - 1, y + 1] != null)
                //if (!board[x - 1, y].isScored && !board[x, y + 1].isScored && !board[x - 1, y + 1].isScored)
                    if (compareBall(board[x - 1, y].type, type) && compareBall(board[x, y + 1].type, type) && compareBall(board[x - 1, y + 1].type, type))
                    {
                        if (checkNotAllChromeBall(board[x, y], board[x - 1, y], board[x, y + 1], board[x - 1, y + 1]))
                        {
                            if ((x == 5 && y == 5) || (x == 3 && y == 0))//X  X
                                return 4;                                //X  O
                            if ((x == 2 && y == 3) || (x == 2 && y == 4))//X  X
                                return 4;                                //X  O
                            if ((x == 6 && y == 1) || (x == 7 && y == 1))//X  X
                                return 4;                                //X  O
                        }
                    }
        if (x - 1 >= 0 && y - 1 >= 0)
            if (board[x - 1, y] != null && board[x, y - 1] != null && board[x - 1, y - 1] != null)
//                if (!board[x - 1, y].isScored && !board[x, y - 1].isScored && !board[x - 1, y - 1].isScored)
                    if (compareBall(board[x - 1, y].type, type) && compareBall(board[x, y - 1].type, type) && compareBall(board[x - 1, y - 1].type, type))
                    {
                        if (checkNotAllChromeBall(board[x, y], board[x - 1, y], board[x, y - 1], board[x - 1, y - 1]))
                        {
                            if ((x == 5 && y == 6) || (x == 3 && y == 1))//X  O
                                return 4;                                //X  X
                            if ((x == 2 && y == 4) || (x == 2 && y == 5))//X  O
                                return 4;                                //X  X
                            if ((x == 6 && y == 2) || (x == 7 && y == 2))//X  O
                                return 4;                                //X  X
                        }
                    }
        return -1;
    }
    public static int EstimateLine(Ball[,] board, int x, int y)
    {
        if (board[x, y] == null)
            return -1;
        int type = board[x, y].type;
        int first = x;
        int last = x;
        while (first >= 0 && board[first, y] != null && !board[first, y].isScored && board[first, y].type == board[x, y].type)
        {
            first--;
        }
        while (first <= GM.numberRow && board[first, y] != null && !board[first, y].isScored && board[first, y].type == board[x, y].type)
        {
            first--;
        }

        if (y - 1 >= 0 && y + 1 < GM.numberRow)
        {
            // X X
            // X O
            // X X
            if (x - 1 >= 0)
                if (board[x, y - 1] != null && board[x, y + 1] != null && board[x - 1, y - 1] != null && board[x - 1, y] != null && board[x - 1, y + 1] != null &&
                    //!board[x, y - 1].isScored && !board[x, y + 1].isScored && !board[x - 1, y - 1].isScored && !board[x - 1, y].isScored &&
                    compareBall(board[x, y - 1].type, type) && compareBall(board[x, y + 1].type, type) && compareBall(board[x - 1, y - 1].type, type)
                    && compareBall(board[x - 1, y].type, type) && board[x - 1, y + 1] != null && compareBall(board[x - 1, y + 1].type, type))
                {
                    if (checkNotAllChromeBall(board[x, y], board[x, y - 1], board[x, y + 1], board[x - 1, y - 1], board[x - 1, y], board[x - 1, y + 1]))
                    {
                        if (x == 2 && y == 4)
                            return 6;
                        return -1;
                    }
                }

            // X X
            // O X
            // X X
            if (x + 1 < GM.numberColumn)
                if (board[x, y - 1] != null && board[x, y + 1] != null && board[x + 1, y - 1] != null && board[x + 1, y] != null && board[x + 1, y + 1] != null)
                    //if (!board[x, y - 1].isScored && !board[x, y + 1].isScored && !board[x + 1, y - 1].isScored && !board[x + 1, y].isScored && !board[x + 1, y + 1].isScored)
                    if (compareBall(board[x, y - 1].type, type) && compareBall(board[x, y + 1].type, type) &&
                    compareBall(board[x + 1, y - 1].type, type) && compareBall(board[x + 1, y].type, type) && compareBall(board[x + 1, y + 1].type, type))
                    {
                        if (checkNotAllChromeBall(board[x, y], board[x, y - 1], board[x, y + 1], board[x + 1, y - 1], board[x + 1, y], board[x + 1, y + 1]))
                        {
                            if (x == 1 && y == 4)
                                return 6;
                            return -1;
                        }
                    }
        }

        return -1;
    }

    public static bool compareBall(int type1, int type2)
    {
        if (type1 == type2 || type1 == 120 || type2 == 120)
            return true;
        return false;
    }
    public static bool checkNotAllChromeBall(Ball b1, Ball b2, Ball b3, Ball b4, Ball b5 = null, Ball b6 = null)
    {
        if (b1.type == 120 && b2.type == 120 && b3.type == 120 && b4.type == 120)
        {
            if (b5 != null && b5.type == 120 && b6 != null && b6.type == 120)
                return false;
            if (b5 == null || b6 == null)
                return false;
            if (b5 != null && b6 != null)
            {
                if (b5.type != 120 && b6.type != 120 && b5.type != b6.type)
                    return false;
            }
        }
        else
        {
            if (b1.type != 120 && b2.type != 120 && b1.type != b2.type)
                return false;
            if (b1.type != 120 && b3.type != 120 && b1.type != b3.type)
                return false;
            if (b1.type != 120 && b4.type != 120 && b1.type != b4.type)
                return false;
            if (b3.type != 120 && b2.type != 120 && b3.type != b2.type)
                return false;
            if (b4.type != 120 && b2.type != 120 && b4.type != b2.type)
                return false;
            if (b3.type != 120 && b4.type != 120 && b3.type != b4.type)
                return false;
        }

        return true;
    }
}
