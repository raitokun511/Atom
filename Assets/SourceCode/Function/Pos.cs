using UnityEngine;
using System.Collections;

public class Pos {

	public static int OUT_ON_LEFT =1;
	public static int OUT_ON_TOP =2;
	public static int OUT_ON_RIGHT =3;
	public static int OUT_ON_BOTTOM =4;
	public static int OUT =5;
	public static int IN_BE_BOUND = 6;
	public static int IN_BOUND = 7;
	public static int COLLIDE = 8;


	public static bool Contains( Vector3  rectPosition, Vector3 rectSize, Vector2 position)
	{
		if (position.x >= (rectPosition.x - rectSize.x / 2.0f) && position.x <= (rectPosition.x + rectSize.x / 2.0f))
		if (position.y >= (rectPosition.y - rectSize.y / 2.0f) && position.y <= (rectPosition.y + rectSize.y / 2.0f))
			return true;

		return false;

	}

	public static int Collider(Vector3 object1Pos, Vector3 object1Rect, Vector3 object2Pos, Vector3 object2Rect)
	{

		if (object1Pos.x + object1Rect.x / 2 < object2Pos.x - object2Rect.x / 2)
			return Pos.OUT_ON_LEFT;
		if (object1Pos.x - object1Rect.x / 2 > object2Pos.x + object2Rect.x / 2)
			return Pos.OUT_ON_RIGHT;
		if (object1Pos.y + object1Rect.y / 2 < object2Pos.y - object2Rect.y / 2)
			return Pos.OUT_ON_BOTTOM;
		if (object1Pos.y - object1Rect.y / 2 > object2Pos.y + object2Rect.y / 2)
			return Pos.OUT_ON_TOP;



		Vector3 TopRight1 = new Vector3 (object1Pos.x + object1Rect.x / 2, object1Pos.y + object1Rect.y / 2, 0);
		Vector3 TopLeft1 = new Vector3 (object1Pos.x - object1Rect.x / 2, object1Pos.y + object1Rect.y / 2, 0);
		Vector3 BottomRight1 = new Vector3 (object1Pos.x + object1Rect.x / 2, object1Pos.y - object1Rect.y / 2, 0);
		Vector3 BottomLeft1 = new Vector3 (object1Pos.x - object1Rect.x / 2, object1Pos.y - object1Rect.y / 2, 0);

		Vector3 TopRight2 = new Vector3 (object2Pos.x + object2Rect.x / 2, object2Pos.y + object2Rect.y / 2, 0);
		Vector3 TopLeft2 = new Vector3 (object2Pos.x - object2Rect.x / 2, object2Pos.y + object2Rect.y / 2, 0);
		Vector3 BottomRight2 = new Vector3 (object2Pos.x + object2Rect.x / 2, object2Pos.y - object2Rect.y / 2, 0);
		Vector3 BottomLeft2 = new Vector3 (object2Pos.x - object2Rect.x / 2, object2Pos.y - object2Rect.y / 2, 0);

		bool inTopRight = Pos.Contains (object2Pos, object2Rect, TopRight1);
		bool inTopLeft = Pos.Contains (object2Pos, object2Rect, TopLeft1);
		bool inBottomRight = Pos.Contains (object2Pos, object2Rect, BottomRight1);
		bool inBottomLeft = Pos.Contains (object2Pos, object2Rect, BottomLeft1);
		bool inMiddle = Pos.Contains (object2Pos, object2Rect, object1Pos);
		if (inTopRight && inTopLeft && inBottomLeft && inBottomRight && inMiddle)
			return Pos.IN_BE_BOUND;
		else {
			if ( Pos.Contains (object1Pos, object1Rect, TopRight2) &&
				Pos.Contains (object1Pos, object1Rect, TopLeft2) &&
				Pos.Contains (object1Pos, object1Rect, BottomRight2) &&
				Pos.Contains (object1Pos, object1Rect, BottomLeft2) &&
				!inTopRight && !inTopLeft && !inBottomLeft && !inBottomRight && !inMiddle)
				return Pos.IN_BOUND;
		}
		return Pos.COLLIDE;
	}

	public static int LightCollider(Vector3 lightPos, Vector3 lightRect, Vector3 objectPos, Vector3 objectRect)
	{
		if (lightPos.x + lightRect.x / 2 >= objectPos.x - objectRect.x / 2 && lightPos.x - lightRect.x / 2 <= objectPos.x + objectRect.x / 2
			&& lightPos.y + lightRect.y / 2  >= objectPos.y - objectRect.y / 2 && lightPos.y - lightRect.y / 2  <= objectPos.y + objectRect.y / 2)
			return Pos.COLLIDE;
		return Pos.OUT;
	}

	public static int[,] findBallPath(Ball[,] board, Vector3 startPos, Vector3 finishPos)
	{
		int[,] boardInt = new int[board.GetLength (0), board.GetLength (1)];
		int w = board.GetLength (0);
		int h = board.GetLength (1);
		for (int i = 0; i < w; i++)
			for (int j = 0; j < w; j++)
				if (board [i, j] != null)
					boardInt [i, j] = -1;
				else
					boardInt [i, j] = 0;

		Stack stack = new Stack ();
		Stack stackPos = new Stack ();
		stack.Push (boardInt [(int)startPos.x, (int)startPos.y]);
		stackPos.Push (startPos);
		boardInt [(int)startPos.x, (int)startPos.y] = 1;
		int count = 0;

		while (stack.Count > 0) {
			int value = (int)stack.Pop ();
			Vector3 pos = (Vector3) stackPos.Pop ();
			int x = (int)pos.x;
			int y = (int)pos.y;
			count++;
			if (count > 500)
				break;
			for (int i = x - 1; i <= x + 1; i++)
				for (int j = y - 1; j <= y + 1; j++)
					if (i >= 0 && j >= 0 && i < boardInt.GetLength (0) && j < boardInt.GetLength (1) && (boardInt[i,j] >= 0 || boardInt[x, y] + 1 < boardInt[i,j])) {
						stack.Push (boardInt [i, j]);
						stackPos.Push (new Vector3 (i, j, 0));
						boardInt [i, j] = boardInt [x, y] + 1;
					}
		}

		Debug.Log ("DONE");
		for (int i = 0; i < w; i++) {
			string s = "";
			for (int j = 0; j < w; j++)
				s += boardInt [i, j] + " ";
			Debug.Log (s);
		}
		return boardInt;
	}


}
