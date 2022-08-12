using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    //https://youtu.be/OhvWCXX5l1k
    //https://www.youtube.com/watch?v=8BPWy-uQvCY&list=PLKXRiiMdHqb6J_2HL89pbCxVYj77diRMR
    //Ligntning: https://youtu.be/b8e-OJunpVA?t=633
    //Ether: https://youtu.be/D-KIVjMChe0?t=237
    //Ice: https://youtu.be/D-KIVjMChe0?t=438
    //Wind: https://youtu.be/PWaObcYSTNs?t=858
    //https://appadvice.com/game/app/line-98-color-ball-puzzle/1466182327


    public static List<Ball> StartList()
    {
        List<Ball> list = new List<Ball>();


        //
        if (GM.Mode == 1)
        {
            if (GM.TestMode == 30)
            {
                list.Add(new Ball(0, 4, 4, false));
                list.Add(new Ball(0, 3, 4, true));
                list.Add(new Ball(0, 5, 4, true));
                list.Add(new Ball(0, 4, 3, true));
                list.Add(new Ball(0, 4, 5, true));
                list.Add(new Ball(1, 5, 5, true));
                list.Add(new Ball(1, 3, 3, true));
                list.Add(new Ball(1, 5, 3, true));
                list.Add(new Ball(1, 3, 5, true));
                list.Add(new Ball(2, 6, 6, true));
                list.Add(new Ball(2, 2, 2, true));
                list.Add(new Ball(2, 6, 2, true));
                list.Add(new Ball(2, 2, 6, true));
                

                return list;
            }
            if (GM.TestMode == 40)
            {
                list.Add(new Ball(0, 4, 4, false));
                list.Add(new Ball(0, 3, 4, true));
                list.Add(new Ball(0, 5, 4, true));
                list.Add(new Ball(0, 4, 3, true));
                list.Add(new Ball(0, 4, 5, true));
                list.Add(new Ball(1, 5, 5, false));
                list.Add(new Ball(1, 3, 3, false));
                list.Add(new Ball(1, 5, 3, false));
                list.Add(new Ball(1, 3, 5, false));
                list.Add(new Ball(2, 6, 6, true));
                list.Add(new Ball(2, 2, 2, true));
                list.Add(new Ball(2, 6, 2, true));
                list.Add(new Ball(2, 2, 6, true));


                return list;
            }
            if (GM.TestMode == 10)
            {
                list.Add(new Ball(0, 1, 1, true));
                list.Add(new Ball(1, 3, 6, true));
                list.Add(new Ball(3, 6, 6, true));
                list.Add(new Ball(2, 1, 7, true));
                list.Add(new Ball(1, 2, 1, true));
                list.Add(new Ball(3, 6, 3, true));
                list.Add(new Ball(4, 4, 4, true));
                list.Add(new Ball(5, 3, 5, true));
                list.Add(new Ball(2, 1, 4, true));
                list.Add(new Ball(1, 3, 2, true));
                list.Add(new Ball(4, 2, 2, true));
                list.Add(new Ball(2, 7, 0, true));
                list.Add(new Ball(2, 8, 0, true));
                list.Add(new Ball(3, 7, 2, true));
                list.Add(new Ball(0, 7, 4, true));
                list.Add(new Ball(4, 7, 6, true));
                list.Add(new Ball(4, 8, 6, true));
                list.Add(new Ball(4, 2, 6, true));
                list.Add(new Ball(5, 5, 1, true));
                list.Add(new Ball(0, 0, 6, true));
                list.Add(new Ball(4, 3, 4, true));

                list.Add(new Ball(0, 3, 0, false));
                list.Add(new Ball(1, 5, 5, false));
                list.Add(new Ball(2, 4, 2, false));
                list.Add(new Ball(112, 2, 3, true));
                return list;
            }
            if (GM.TestMode == 20)//Booom
            {
                list.Add(new Ball(0, 1, 1, true)); list.Add(new Ball(7, 1, 7, true));
                list.Add(new Ball(2, 3, 6, true)); list.Add(new Ball(7, 1, 6, true));
                list.Add(new Ball(1, 6, 6, true)); list.Add(new Ball(7, 4, 5, true));
                list.Add(new Ball(2, 2, 7, true)); list.Add(new Ball(5, 0, 3, true));
                list.Add(new Ball(3, 2, 1, true)); list.Add(new Ball(5, 1, 5, true));
                list.Add(new Ball(2, 6, 3, true)); list.Add(new Ball(5, 6, 2, true));
                list.Add(new Ball(4, 4, 4, true)); list.Add(new Ball(0, 7, 1, true));
                list.Add(new Ball(2, 3, 5, true)); list.Add(new Ball(0, 8, 1, true));
                list.Add(new Ball(6, 1, 4, true)); list.Add(new Ball(2, 4, 6, true));
                list.Add(new Ball(1, 3, 2, true)); list.Add(new Ball(120, 7, 7, true));
                list.Add(new Ball(6, 2, 2, true)); list.Add(new Ball(1, 4, 2, true));
                list.Add(new Ball(2, 7, 0, true));
                list.Add(new Ball(1, 8, 0, true));
                list.Add(new Ball(3, 8, 3, true));
                list.Add(new Ball(0, 8, 4, true));
                list.Add(new Ball(2, 7, 5, true));
                list.Add(new Ball(3, 8, 6, true));
                list.Add(new Ball(4, 2, 6, true));
                list.Add(new Ball(0, 5, 1, true));
                list.Add(new Ball(1, 0, 6, true));
                list.Add(new Ball(4, 3, 4, true));
                list.Add(new Ball(1, 0, 0, true));

                list.Add(new Ball(0, 1, 2, false));
                list.Add(new Ball(1, 7, 4, false));
                list.Add(new Ball(2, 6, 1, false));
                list.Add(new Ball(2, 2, 3, true));
                GM.bombMeter = 30;
                return list;
            }
            
        }
        if (GM.Mode == 1 && GM.strategyLevel == 8)
        {
            list.Add(new Ball(0, 0, 1, true));
            list.Add(new Ball(0, 1, 0, true));
            list.Add(new Ball(0, 0, 0, true));
            
            list.Add(new Ball(1, 0, 2, true));
            
            list.Add(new Ball(0, 1, 1, false));
            list.Add(new Ball(3, 7, 7, true));

            return list;
        }
        if (GM.Mode == 2 || GM.Mode == 3)
        {
            int maxcolor = 4;
            int bigs = 12;
            int small = 3;
            List<int> listempty = new List<int>();
            for (int i = 0; i < 72; i++)
                listempty.Add(i);
            int countsmall = small;
            for (int i = 0; i < bigs + small; i++)
            {
                int pos = Random.Range(0, listempty.Count);
                int r = listempty[pos];
                listempty.RemoveAt(pos);
                list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, countsmall-- > 0 ? false : true));
            }
            return list;
        }
        if (GM.strategyLevel == 1)
        {
            list.Add(new Ball(0, 4, 4, true));
            list.Add(new Ball(0, 5, 4, true));
            list.Add(new Ball(0, 5, 3, true));
            list.Add(new Ball(0, 1, 2, true));
        }
        else if (GM.strategyLevel == 2)
        {
            int rand = 0;// Random.Range(0, 4);
            int r1 = rand == 0 ? 106 : rand == 1 ? 605 : 202;
            int r2 = rand == 0 ? 605 : rand == 1 ? 202 : 106;
            int r3 = rand == 0 ? 202 : rand == 1 ? 106 : 605;
            list.Add(new Ball(0, r1 / 100, r1 % 100, true));
            list.Add(new Ball(0, r1 / 100 + 1, r1 % 100, true));
            list.Add(new Ball(0, r1 / 100, r1 % 100 - 1, true));
            list.Add(new Ball(0, r1 / 100 + 2, r1 % 100 - 1, true));

            list.Add(new Ball(1, r2 / 100, r2 % 100, true));
            list.Add(new Ball(1, r2 / 100 + 1, r2 % 100, true));
            list.Add(new Ball(1, r2 / 100 - 1, r2 % 100 - 1, true));
            list.Add(new Ball(1, r2 / 100 + 1, r2 % 100 - 1, true));

            list.Add(new Ball(2, r3 / 100, r3 % 100, true));
            list.Add(new Ball(2, r3 / 100 + 1, r3 % 100 + 1, true));
            list.Add(new Ball(2, r3 / 100, r3 % 100 - 1, true));
            list.Add(new Ball(2, r3 / 100 + 1, r3 % 100 - 1, true));

            list.Add(new Ball(Random.Range(0, 3), 7, 1, true));

            list.Add(new Ball(Random.Range(0, 3), Random.Range(0, 2), Random.Range(0, 2), false));
            list.Add(new Ball(Random.Range(0, 3), Random.Range(4, 7), Random.Range(0, 2), false));
            list.Add(new Ball(Random.Range(0, 3), Random.Range(4, 7), Random.Range(6, 8), false));

        }
        else if (GM.strategyLevel == 3)
        {
            Ball hzball = new Ball(0, 4, 3, true);
            hzball.Hazard = 5;
            list.Add(hzball);
            list.Add(new Ball(0, 2, 3, true));
            list.Add(new Ball(0, 6, 3, true));
            list.Add(new Ball(0, 4, 1, true));
            list.Add(new Ball(0, 4, 5, true));

            list.Add(new Ball(2, 1, 0, true));
            list.Add(new Ball(2, 1, 6, true));
            list.Add(new Ball(2, 7, 0, true));
            list.Add(new Ball(2, 7, 6, true));

            list.Add(new Ball(1, 2, 1, false));
            list.Add(new Ball(1, 2, 5, false));
            list.Add(new Ball(1, 6, 1, false));
            list.Add(new Ball(1, 6, 5, false));
        }
        else if (GM.strategyLevel == 4)
        {
            list.Add(new Ball(20, 3, 3, true));
            list.Add(new Ball(20, 4, 3, true));
            list.Add(new Ball(20, 5, 3, true));
            list.Add(new Ball(20, 3, 4, true));
            list.Add(new Ball(20, 4, 4, true));
            list.Add(new Ball(20, 5, 4, true));

            list.Add(new Ball(1, 1, 1, true));
            list.Add(new Ball(1, 1, 6, true));
            list.Add(new Ball(0, 7, 1, true));
            list.Add(new Ball(3, 7, 6, true));

            list.Add(new Ball(1, 4, 1, false));
            list.Add(new Ball(3, 4, 6, false));
            list.Add(new Ball(2, 4, 7, false));
        }
        else if (GM.strategyLevel == 5 || GM.strategyLevel == 10 || GM.strategyLevel == 15 || GM.strategyLevel == 20 ||
            GM.strategyLevel == 25 || GM.strategyLevel == 30)
        {
            //8 10 12 14 16
            //9 11 13
            List<int> listempty = new List<int>();
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    listempty.Add(i * 100 + j);
            int numEven = Random.Range(3, 7) * 2;
            int numEvent2 = Random.Range(3, 7) * 2;
            int numEven3 = GM.strategyLevel < 10 ? 0 : Random.Range(2, 4) * 2;
            int numEven4 = GM.strategyLevel < 15 ? 0 : 4;
            int numOdd1 = Random.Range(3, 7) * 2 + 1;
            int numOdd2 = Random.Range(3, 7) * 2 + 1;
            int numchrom = 2;
            int randColor = 0;
            int count = 1000;
            int total = numEven + numEvent2 + numOdd1 + numOdd2 + numEven3 + numEven4 + 2;
            Debug.Log("even:" + numEven + "  even:" + numEvent2 + "  event:" + numEven3 + "  event:" + numEven4 +
                " odd:" + numOdd1 + "  odd:" + numOdd2 + "  total:" + total);
            while (total > 0 && count-- > 0)
            {
                int pos = Random.Range(0, listempty.Count);
                int rand = listempty[pos];
                if (total > numchrom)//(numOdd2 > 0 || numEven3 > 0)
                    list.Add(new Ball(randColor, rand / 100, rand % 100, true));
                else
                    list.Add(new Ball(20, rand / 100, rand % 100, true));

                total--;
                if (numEven == 1 || numEvent2 == 1 || numEven3 == 1 || numOdd1 == 1 || numOdd2 == 1 || numEven4 == 1)
                    randColor++;
                if (numEven > 0)
                    numEven--;
                else if (numEvent2 > 0)
                    numEvent2--;
                else if (numOdd1 > 0)
                    numOdd1--;
                else if (numOdd2 > 0)
                    numOdd2--;
                else if (numEven3 > 0)
                    numEven3--;
                else if (numEven4 > 0)
                    numEven4--;
                else if (numchrom > 0)
                    numchrom--;

                listempty.RemoveAt(pos);
            }
            Debug.Log("total " + total);


        }
        else if (GM.strategyLevel == 6)
        {
            list.Add(new Ball(Random.Range(0, 5), 0, 0, true));
            list.Add(new Ball(Random.Range(0, 5), 2, 2, true));
            list.Add(new Ball(Random.Range(0, 5), 3, 4, true));
            list.Add(new Ball(Random.Range(0, 5), 4, 5, true));
            list.Add(new Ball(Random.Range(0, 5), 5, 2, true));
            list.Add(new Ball(Random.Range(0, 5), 0, 5, true));
            list.Add(new Ball(Random.Range(0, 5), 0, 6, true));
            list.Add(new Ball(Random.Range(0, 5), 4, 7, true));
        }
        else if (GM.strategyLevel == 7 || GM.strategyLevel == 8 || GM.strategyLevel == 9)
        {
            /*
            list.Add(new Ball(Random.Range(0, 6), 2, 3, true));
            list.Add(new Ball(Random.Range(0, 6), 2, 2, true));
            list.Add(new Ball(Random.Range(0, 6), 0, 4, true));
            list.Add(new Ball(Random.Range(0, 6), 6, 2, true));
            list.Add(new Ball(Random.Range(0, 6), 7, 2, true));
            list.Add(new Ball(Random.Range(0, 6), 7, 5, true));
            list.Add(new Ball(Random.Range(0, 6), 7, 5, true));
            //8
            list.Add(new Ball(Random.Range(0, 6), 0, 6, true));
            list.Add(new Ball(Random.Range(0, 6), 1, 2, true));
            list.Add(new Ball(Random.Range(0, 6), 2, 2, true));
            list.Add(new Ball(Random.Range(0, 6), 2, 4, true));
            list.Add(new Ball(Random.Range(0, 6), 4, 3, true));
            list.Add(new Ball(Random.Range(0, 6), 3, 1, false));
            list.Add(new Ball(Random.Range(0, 6), 5, 0, false));
            list.Add(new Ball(Random.Range(0, 6), 5, 6, false));
            */
            //9*8 = 72
            int maxcolor = 6;
            int bigs = 5;
            int small = 3;
            List<int> listempty = new List<int>();
            for (int i = 0; i < 72; i++)
                listempty.Add(i);
            int countsmall = small;
            for (int i = 0; i < bigs + small; i++)
            {
                int pos = Random.Range(0, listempty.Count);
                int r = listempty[pos];
                listempty.RemoveAt(pos);
                list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, countsmall-- > 0 ? false : true));
            }


        }
        else if (GM.strategyLevel == 90)
        {
            int rand = Random.Range(0, 9);
            list.Add(new Ball(Random.Range(0, 6), Random.Range(0, 9), Random.Range(0, 2), true));
            list.Add(new Ball(Random.Range(0, 6), Random.Range(0, 9), 2, true));
            list.Add(new Ball(Random.Range(0, 6), Random.Range(0, 9), 3, true));
            list.Add(new Ball(Random.Range(0, 6), Random.Range(0, 9), 4, true));
            list.Add(new Ball(Random.Range(0, 6), rand, 5, true));
            list.Add(new Ball(Random.Range(0, 6), (rand + Random.Range(0, 9)) % 9, Random.Range(5, 7), false));
            rand = Random.Range(0, 9);
            list.Add(new Ball(Random.Range(0, 6), rand, 7, false));
            list.Add(new Ball(Random.Range(0, 6), (rand + Random.Range(0, 9)) % 9, 7, false));
        }
        else if (GM.strategyLevel == 11)
        {
            //7*8 = 56
            int r = Random.Range(0, 5);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(5, 10);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(10, 15);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(15, 20);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(20, 24);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(24, 28);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(28, 32);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(32, 36);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(36, 40);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(40, 46);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(46, 51);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(51, 56);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true));
        }
        else if (GM.strategyLevel == 12)
        {
            //7*8 = 56
            int r = Random.Range(0, 5);
            list.Add(new Ball(20, r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(5, 10);
            list.Add(new Ball(20, r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(10, 15);
            Ball b = new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true);
            b.Hazard = 5;
            list.Add(b);
            r = Random.Range(15, 20);
            b = new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true);
            b.Hazard = 5;
            list.Add(b);
            r = Random.Range(20, 24);
            list.Add(new Ball(20, r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(24, 28);
            b = new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true);
            b.Hazard = 5;
            list.Add(b);
            r = Random.Range(28, 32);
            b = new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, true);
            b.Hazard = 5;
            list.Add(b);
            r = Random.Range(32, 36);
            list.Add(new Ball(20, r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(36, 40);
            list.Add(new Ball(20, r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(40, 46);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, false));
            r = Random.Range(46, 51);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, false));
            r = Random.Range(51, 56);
            list.Add(new Ball(Random.Range(0, 6), r / GM.numberColumn, r % GM.numberRow, false));
        }
        else if (GM.strategyLevel == 13 || GM.strategyLevel == 14)
        {
            int maxcolor = GM.strategyLevel == 13 ? 7 : 6;
            int r = Random.Range(0, 5);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(5, 10);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(10, 15);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(15, 20);
            list.Add(new Ball(GM.strategyLevel == 13 ? maxcolor : Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(20, 24);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(24, 28);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(28, 32);
            list.Add(new Ball(maxcolor - 1, r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(32, 36);
            list.Add(new Ball(Random.Range(0, maxcolor + 1), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(36, 40);
            list.Add(new Ball(Random.Range(0, maxcolor + 1), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(40, 46);
            list.Add(new Ball(Random.Range(0, maxcolor + 1), r / GM.numberColumn, r % GM.numberRow, false));
            r = Random.Range(46, 51);
            list.Add(new Ball(Random.Range(0, maxcolor - 1), r / GM.numberColumn, r % GM.numberRow, false));
            r = Random.Range(51, 56);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, false));
        }
        else if (GM.strategyLevel == 16)
        {
            //7*8 = 56
            //lv 16 random to 7, no ball small
            int maxcolor = GM.strategyLevel == 16 ? 7 : 7;
            int r = Random.Range(0, 5);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(5, 10);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(10, 15);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(15, 20);
            list.Add(new Ball(GM.strategyLevel == 13 ? maxcolor : Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(20, 24);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(24, 28);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(28, 32);
            list.Add(new Ball(maxcolor - 1, r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(32, 36);
            list.Add(new Ball(Random.Range(0, maxcolor + 1), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(36, 40);
            list.Add(new Ball(Random.Range(0, maxcolor + 1), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(40, 46);
            list.Add(new Ball(Random.Range(0, maxcolor + 1), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(46, 51);
            list.Add(new Ball(Random.Range(0, maxcolor - 1), r / GM.numberColumn, r % GM.numberRow, true));
            r = Random.Range(51, 56);
            list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, true));
        }
        else if (GM.strategyLevel == 17 || GM.strategyLevel == 24 || GM.strategyLevel == 29 || GM.strategyLevel == 33)
        {
            //9*8 = 72
            int maxcolor = GM.strategyLevel == 17 ? 6 : 8;
            int bigs = 5;
            int small = 3;
            List<int> listempty = new List<int>();
            for (int i = 0; i < 72; i++)
                listempty.Add(i);
            int countsmall = small;
            for (int i = 0; i < bigs + small; i++)
            {
                int pos = Random.Range(0, listempty.Count);
                int r = listempty[pos];
                listempty.RemoveAt(pos);
                list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, countsmall-- > 0 ? false : true));
            }

        }
        else if (GM.strategyLevel == 18)
        {
            int maxcolor = GM.strategyLevel == 18 ? 9 : 9;
            int pos = 0;
            int small = Random.Range(0, 4) * 1000 + Random.Range(4, 9) * 100 + Random.Range(9, 15);
            for (int i = 0; i < 15; i++)
            {
                int r = Random.Range(pos, pos < 72 ? pos + 5 : 72 - pos);
                pos += 5;
                pos += Random.Range(0, 2);
                Debug.Log("r " + r);
                list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow,
                    i == small / 1000 || i == small % 1000 / 100 || i == small % 100 ? false : true));
            }
        }
        else if (GM.strategyLevel == 19)
        {
            int chrome = 6;
            int small = 3;
            List<int> listempty = new List<int>();
            for (int i = 0; i < 72; i++)
                listempty.Add(i);
            for (int i = 0; i < 9; i++)
            {
                int pos = Random.Range(0, listempty.Count);
                int r = listempty[pos];
                listempty.RemoveAt(pos);
                //Debug.Log("r " + r);
                list.Add(new Ball(small > 0 ? 20 : chrome > 0 ? 120 : Random.Range(0, 3), r / GM.numberColumn, r % GM.numberRow, chrome > 0 && small > 0 ? false : true));
                if (chrome <= 0)
                    list[list.Count - 1].Hazard = 5;
                chrome--;
                small--;
            }
        }
        else if (GM.strategyLevel == 21 || GM.strategyLevel == 23 || GM.strategyLevel == 27 || GM.strategyLevel == 28 ||
            GM.strategyLevel == 31 || GM.strategyLevel == 32)
        {
            int bigs = GM.strategyLevel == 28 ? 9 : GM.strategyLevel == 21 || GM.strategyLevel == 31 ? 15 : 12;//23, 32 == 12 ball,
            int small = GM.strategyLevel == 21 || GM.strategyLevel == 31 ? 0 : 3;//lv23,28, 32 small == 3
            int maxcolor = GM.strategyLevel == 31 || GM.strategyLevel == 32 ? 6 : GM.strategyLevel == 21 ? 12 : 12;
            List<int> listempty = new List<int>();
            for (int i = 0; i < 72; i++)
                listempty.Add(i);
            int countsmall = small;
            for (int i = 0; i < bigs + small; i++)
            {
                int pos = Random.Range(0, listempty.Count);
                int r = listempty[pos];
                listempty.RemoveAt(pos);
                list.Add(new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, countsmall-- > 0 ? false : true));
            }
        }
        else if (GM.strategyLevel == 22 || GM.strategyLevel == 26)
        {
            int bigs = GM.strategyLevel == 22 ? 9 : 12;
            int small = GM.strategyLevel == 22 ? 3 : 0;
            int haz = GM.strategyLevel == 22 ? 8 : 12;
            int maxcolor = GM.strategyLevel == 22 ? 6 : 7;
            List<int> listempty = new List<int>();
            for (int i = 0; i < 72; i++)
                listempty.Add(i);
            int countsmall = small;
            for (int i = 0; i < bigs + small; i++)
            {
                int pos = Random.Range(0, listempty.Count);
                int r = listempty[pos];
                listempty.RemoveAt(pos);
                Ball b = new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, countsmall-- > 0 ? false : true);
                if (countsmall < 1 && haz > 0)
                {
                    b.Hazard = 5;
                    haz--;
                }
                list.Add(b);
            }
        }
        else if (GM.strategyLevel == 34)
        {
            int bigs = GM.strategyLevel == 34 ? 7 : 7;
            int small = GM.strategyLevel == 34 ? 3 : 3;
            int haz = GM.strategyLevel == 34 ? 6 : 6;
            int chrome = 2;
            int maxcolor = GM.strategyLevel == 34 ? 6 : 6;
            List<int> listempty = new List<int>();
            for (int i = 0; i < 72; i++)
                listempty.Add(i);
            int countsmall = small;
            for (int i = 0; i < bigs + small; i++)
            {
                int pos = Random.Range(0, listempty.Count);
                int r = listempty[pos];
                listempty.RemoveAt(pos);
                Ball b = new Ball(Random.Range(0, maxcolor), r / GM.numberColumn, r % GM.numberRow, countsmall-- > 0 ? false : true);
                if (countsmall < 1 && haz > 0)
                {
                    b.Hazard = 5;
                    haz--;
                }
                list.Add(b);
            }
            for (int i = 0; i < chrome; i++)
            {
                int pos = Random.Range(0, listempty.Count);
                int r = listempty[pos];
                listempty.RemoveAt(pos);
                Ball b = new Ball(120, r / GM.numberColumn, r % GM.numberRow, true);
                list.Add(b);
            }
        }
        return list;
    }
    public static List<Ball> LoadList(int[] data)
    {
        List<Ball> list = new List<Ball>();
        int indexhz = 0;
        if (data != null)
        {
            for (int i = 0; i < data.Length; i++)
                if (i % 2 == 0)
                {
                    //Debug.Log(" " + i / 2 + " | 0,1,2,3... list hz " + GM.listsavehazard[0] + "  " + (GM.listsavehazard[0] % 1000 / 100) + "   " + GM.listsavehazard[0] % 100);

                    int balltype = AquaData.UnConvertBoard(data[i] % 100);
                    if (balltype >= 0)
                    {
                        Ball b = new Ball(balltype % 100, i / 2, 0, balltype < 100 ? false : true);
                        if (GM.listsavehazard != null && GM.listsavehazard.Count > 0 && indexhz < GM.listsavehazard.Count && 
                            GM.listsavehazard[indexhz] % 1000 / 100 == i / 2 && GM.listsavehazard[indexhz] % 100 == 0)
                        {
                            b.Hazard = (short)(GM.listsavehazard[0] / 1000);
                            indexhz++;
                        }
                        list.Add(b);
                    }
                    balltype = AquaData.UnConvertBoard(data[i] / 100 % 100);
                    if (balltype >= 0)
                    {
                        Ball b = new Ball(balltype % 100, i / 2, 1, balltype < 100 ? false : true);
                        if (GM.listsavehazard != null && GM.listsavehazard.Count > 0 && indexhz < GM.listsavehazard.Count && 
                            GM.listsavehazard[indexhz] % 1000 / 100 == i / 2 && GM.listsavehazard[indexhz] % 100 == 1)
                        {
                            b.Hazard = (short)(GM.listsavehazard[0] / 1000);
                            indexhz++;
                        }
                        list.Add(b);
                    }
                    balltype = AquaData.UnConvertBoard(data[i] / 10000 % 100);
                    if (balltype >= 0)
                    {
                        Ball b = new Ball(balltype % 100, i / 2, 2, balltype < 100 ? false : true);
                        if (GM.listsavehazard != null && GM.listsavehazard.Count > 0 && indexhz < GM.listsavehazard.Count && 
                            GM.listsavehazard[indexhz] % 1000 / 100 == i / 2 && GM.listsavehazard[indexhz] % 100 == 2)
                        {
                            b.Hazard = (short)(GM.listsavehazard[0] / 1000);
                            indexhz++;
                        }
                        list.Add(b);
                    }
                    balltype = AquaData.UnConvertBoard(data[i] / 1000000 % 100);
                    if (balltype >= 0)
                    {
                        Ball b = new Ball(balltype % 100, i / 2, 3, balltype < 100 ? false : true);
                        if (GM.listsavehazard != null && GM.listsavehazard.Count > 0 && indexhz < GM.listsavehazard.Count && 
                            GM.listsavehazard[indexhz] % 1000 / 100 == i / 2 && GM.listsavehazard[indexhz] % 100 == 3)
                        {
                            b.Hazard = (short)(GM.listsavehazard[0] / 1000);
                            indexhz++;
                        }
                        list.Add(b);
                    }
                    balltype = AquaData.UnConvertBoard(data[i + 1] % 100);
                    if (balltype >= 0)
                    {
                        Ball b = new Ball(balltype % 100, i / 2, 4, balltype < 100 ? false : true);
                        if (GM.listsavehazard != null && GM.listsavehazard.Count > 0 && indexhz < GM.listsavehazard.Count && 
                            GM.listsavehazard[indexhz] % 1000 / 100 == i / 2 && GM.listsavehazard[indexhz] % 100 == 4)
                        {
                            b.Hazard = (short)(GM.listsavehazard[0] / 1000);
                            indexhz++;
                        }
                        list.Add(b);
                    }
                    balltype = AquaData.UnConvertBoard(data[i + 1] / 100 % 100);
                    if (balltype >= 0)
                    {
                        Ball b = new Ball(balltype % 100, i / 2, 5, balltype < 100 ? false : true);
                        if (GM.listsavehazard != null && GM.listsavehazard.Count > 0 && indexhz < GM.listsavehazard.Count && 
                            GM.listsavehazard[indexhz] % 1000 / 100 == i / 2 && GM.listsavehazard[indexhz] % 100 == 5)
                        {
                            b.Hazard = (short)(GM.listsavehazard[0] / 1000);
                            indexhz++;
                        }
                        list.Add(b);
                    }
                    balltype = AquaData.UnConvertBoard(data[i + 1] / 10000 % 100);
                    if (balltype >= 0)
                    {
                        Ball b = new Ball(balltype % 100, i / 2, 6, balltype < 100 ? false : true);
                        if (GM.listsavehazard != null && GM.listsavehazard.Count > 0 && indexhz < GM.listsavehazard.Count && 
                            GM.listsavehazard[indexhz] % 1000 / 100 == i / 2 && GM.listsavehazard[indexhz] % 100 == 6)
                        {
                            b.Hazard = (short)(GM.listsavehazard[0] / 1000);
                            indexhz++;
                        }
                        list.Add(b);
                    }
                    balltype = AquaData.UnConvertBoard(data[i + 1] / 1000000 % 100);
                    if (balltype >= 0)
                    {
                        Ball b = new Ball(balltype % 100, i / 2, 7, balltype < 100 ? false : true);
                        if (GM.listsavehazard != null && GM.listsavehazard.Count > 0 && indexhz < GM.listsavehazard.Count && 
                            GM.listsavehazard[indexhz] % 1000 / 100 == i / 2 && GM.listsavehazard[indexhz] % 100 == 7)
                        {
                            b.Hazard = (short)(GM.listsavehazard[0] / 1000);
                            indexhz++;
                        }
                        list.Add(b);
                    }
                }
        }
        return list;

    }

    public static bool checkWin(int score, Ball[,] board, bool checkRadianSolve = false)
    {
        if (GM.Mode == 1 && GM.strategyLevel == 1 && score >= 9)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 2 && score >= 13)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 3 && score >= 17)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 4 && score >= 20)
            return true;
        if (GM.Mode == 1 && (GM.strategyLevel == 5 || GM.strategyLevel == 10 || GM.strategyLevel == 15 || GM.strategyLevel == 20 ||
            GM.strategyLevel == 25 || GM.strategyLevel == 30))
        {
            int numball = 0;
            short[] countball = new short[13];
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                {
                    numball = board[i, j] == null ? numball : board[i, j] != null && !board[i, j].isDie && !board[i, j].isScored ? numball + 1 : numball;
                    if (board[i, j] != null && !board[i, j].isDie && board[i,j].type >= 100 && !board[i, j].isScored)
                    {
                        if (board[i, j].type < 112)
                            countball[board[i, j].type - 100]++;
                        if (board[i, j].type == 120)
                            countball[12]++;
                    }
                }
            //if (numball == 0)
            //    return true;
            for (int i = 0; i < countball.Length - 1; i++)
                if (countball[i] + countball[12] >= 4)
                    return false;
            if (checkRadianSolve)
            for (int i = 0; i < countball.Length - 1; i++)
                if (countball[i] + countball[12] >= 1)
                    return false;
            if (checkRadianSolve && numball > 0)
                return false;
            return true;
        }
        if (GM.Mode == 1 && GM.strategyLevel == 6 && score >= 25)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 7 && score >= 30)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 8 && score >= 13)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 9 && score >= 35)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 11 && score >= 35)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 12 && score >= 25)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 13 && score >= 40)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 14 && score >= 140)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 15 && score >= 40)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 16 && score >= 46)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 17 && score >= 17)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 18 && score >= 50)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 19 && score >= 25)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 21 && score >= 50)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 22 && score >= 26)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 23 && score >= 45)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 24 && score >= 16)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 26 && score >= 26)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 27 && score >= 51)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 28 && score >= 26)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 29 && score >= 17)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 31 && score >= 26)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 32 && score >= 31)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 33 && score >= 21)
            return true;
        if (GM.Mode == 1 && GM.strategyLevel == 34 && score >= 36)
            return true;
        return false;
    }
    public static bool checkFail(int score, Ball[,] board)
    {
        if (GM.strategyLevel == 19)
        {
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (board[i, j] != null && !board[i, j].isDie && !board[i, j].isScored && board[i, j].type != 120 && board[i, j].type != 20)
                    {
                        //Debug.Log("Found " + i + "," + j + " = " + board[i, j].type);
                        return false;
                    }
            return true;
        }
        else
        {
            int count = 0;
            for (int i = 0; i < GM.numberColumn; i++)
                for (int j = 0; j < GM.numberRow; j++)
                    if (board[i, j] != null && !board[i, j].isDie && !board[i, j].isScored)
                    {
                        if (board[i, j].type < 100)
                        {
                            //Debug.Log("Found " + i + "," + j + " = " + board[i, j].type);
                            return false;
                        }
                        else
                            count++;
                        
                    }
            if (GM.Mode < 3 && count == 72)
                return true;
            return false;
        }
    }
    public static int fullScore()
    {
        if (GM.Mode == 2)
        {
            return 1000;
        }
        if (GM.Mode == 1 && GM.strategyLevel == 1)
            return 9;
        if (GM.Mode == 1 && GM.strategyLevel == 2)
            return 13;
        if (GM.Mode == 1 && GM.strategyLevel == 3)
            return 17;
        if (GM.Mode == 1 && GM.strategyLevel == 4)
            return 20;
        if (GM.Mode == 1 && (GM.strategyLevel == 5 || GM.strategyLevel == 10 || GM.strategyLevel == 15 || GM.strategyLevel == 20
            || GM.strategyLevel == 25 || GM.strategyLevel == 30))
        {
                return 20;
        }
        if (GM.Mode == 1 && GM.strategyLevel == 6)
            return 25;
        if (GM.Mode == 1 && GM.strategyLevel == 7)
            return 30;
        if (GM.Mode == 1 && GM.strategyLevel == 8)
            return 13;
        if (GM.Mode == 1 && GM.strategyLevel == 9)
            return 35;
        if (GM.Mode == 1 && GM.strategyLevel == 11)
            return 35;
        if (GM.Mode == 1 && GM.strategyLevel == 12)
            return 25;
        if (GM.Mode == 1 && GM.strategyLevel == 13)
            return 40;
        if (GM.Mode == 1 && GM.strategyLevel == 14)
            return 140;
        if (GM.Mode == 1 && GM.strategyLevel == 15)
            return 40;
        if (GM.Mode == 1 && GM.strategyLevel == 16)
            return 46;
        if (GM.Mode == 1 && GM.strategyLevel == 17)
            return 17;
        if (GM.Mode == 1 && GM.strategyLevel == 18)
            return 50;
        if (GM.Mode == 1 && GM.strategyLevel == 19)
            return 25;
        if (GM.Mode == 1 && GM.strategyLevel == 20)
            return 25;
        if (GM.Mode == 1 && GM.strategyLevel == 21)
            return 50;
        if (GM.Mode == 1 && GM.strategyLevel == 22)
            return 26;
        if (GM.Mode == 1 && GM.strategyLevel == 23)
            return 45;
        if (GM.Mode == 1 && GM.strategyLevel == 24)
            return 16;
        if (GM.Mode == 1 && GM.strategyLevel == 26)
            return 26;
        if (GM.Mode == 1 && GM.strategyLevel == 27)
            return 51;
        if (GM.Mode == 1 && GM.strategyLevel == 28)
            return 26;
        if (GM.Mode == 1 && GM.strategyLevel == 29)
            return 17;
        if (GM.Mode == 1 && GM.strategyLevel == 30)
            return 50;
        if (GM.Mode == 1 && GM.strategyLevel == 31)
            return 26;
        if (GM.Mode == 1 && GM.strategyLevel == 32)
            return 31;
        if (GM.Mode == 1 && GM.strategyLevel == 33)
            return 21;
        if (GM.Mode == 1 && GM.strategyLevel == 34)
            return 36;

        return 1;
    }

    public static int RandomBall(bool ishazard = false, Ball[,] board = null)
    {
        if (GM.Mode == 3)
        {
            return Random.Range(0, 6);
        }
        if (GM.Mode == 2)
        {
            if (GM.actionLevel == 1)
                return Random.Range(0, 4);
            if (GM.actionLevel == 2)
                return Random.Range(0, 5);
            if (GM.actionLevel == 3)
                return Random.Range(0, 6);
            if (GM.actionLevel == 4)
                return Random.Range(0, 7);
            if (GM.actionLevel == 5)
                return Random.Range(0, 8);
            if (GM.actionLevel == 6)
                return Random.Range(0, 9);
            if (GM.actionLevel == 7)
                return Random.Range(0, 10);
            if (GM.actionLevel == 8)
                return Random.Range(0, 11);
            if (GM.actionLevel > 8)
                return Random.Range(0, 12);
            return 0;
        }
        if (GM.strategyLevel < 2)
            return Random.Range(0, 3);
        else if (GM.strategyLevel < 4)
            return Random.Range(0, 4);
        else if (GM.strategyLevel < 7)
        {
            int val = Random.Range(0, 6);
            if (val == 5 && Random.Range(0, 100) < 30)
                return 20;
            else return val % 5;
        }
        else if (GM.strategyLevel == 8)
        {
            /*
            if (board != null)
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                    {
                        if (board[i, j] == null || board[i,j].isDie)
                        {
                            if (i + 1 < GM.numberColumn && j - 1 >= 0 &&
                                board[i + 1, j] != null && board[i, j - 1] != null && board[i + 1, j - 1] != null &&
                                board[i + 1, j].type >= 100 && board[i, j - 1].type >= 100 && board[i + 1, j - 1].type >= 100 &&
                                board[i + 1, j].type == board[i, j - 1].type && board[i, j - 1].type == board[i + 1, j - 1].type)
                                return 10000 + i * 1000 + j * 100 + board[i + 1, j].type % 100;
                            if (i - 1 >= 0 && j - 1 >= 0 &&
                                board[i - 1, j] != null && board[i, j - 1] != null && board[i - 1, j - 1] != null &&
                                board[i - 1, j].type >= 100 && board[i, j - 1].type >= 100 && board[i - 1, j - 1].type >= 100 &&
                                board[i - 1, j].type == board[i, j - 1].type && board[i, j - 1].type == board[i - 1, j - 1].type)
                                return 10000 + i * 1000 + j * 100 + board[i - 1, j].type % 100;
                        }


                    }
                    */
            int val = Random.Range(0, 5);
            if (val == 4 && Random.Range(0, 100) < 30)
                return 20;
            else return val % 4;
        }
        else if (GM.strategyLevel < 9)
        {
            int val = Random.Range(0, 7);
            if (val == 6 && Random.Range(0, 100) < 30)
                return 20;
            else return val % 6;
        }
        else if (GM.strategyLevel == 9)
        {
            int val = Random.Range(0, 8);
            if (val == 7 && Random.Range(0, 100) < 30)
                return 20;
            else return val % 7;
        }
        else if (GM.strategyLevel == 11 || GM.strategyLevel == 14)
        {
            int val = Random.Range(0, 8);
            if (val == 7 && Random.Range(0, 100) < 30 && GM.strategyLevel != 14)
                return 20;
            else return val % 7;
        }
        else if (GM.strategyLevel == 12)
        {
            int val = Random.Range(0, 5);
            if (val == 4 && Random.Range(0, 100) < 50)
                return 20;
            else return val % 4;
        }
        else if (GM.strategyLevel == 13)
        {
            int val = Random.Range(0, 9);
            if (val == 8 && Random.Range(0, 100) < 10)
                return 20;
            else return val % 8;
        }
        else if (GM.strategyLevel == 16)
        {
            int val = Random.Range(0, 8);
            if (val == 7 && Random.Range(0, 100) < 10)
                return 20;
            else return val % 7;
        }

        else if (GM.strategyLevel == 17)
        {
            int val = Random.Range(0, 7);
            if (val == 6 && Random.Range(0, 100) < 30)
                return 20;
            else return val % 6;
        }
        else if (GM.strategyLevel == 18 || GM.strategyLevel == 33)
        {
            int val = Random.Range(0, 10);
            if (val == 9 && Random.Range(0, 100) < 20)
                return 20;
            else return val % 9;
        }
        else if (GM.strategyLevel == 19)
        {
            if (ishazard)
                return Random.Range(0, 6);
            else
                return 20;
        }
        else if (GM.strategyLevel == 21 || GM.strategyLevel == 23 || GM.strategyLevel == 24 || GM.strategyLevel == 27 || 
            GM.strategyLevel == 28 || GM.strategyLevel == 29)
        {
            int val = Random.Range(0, 13);
            if (val == 12 && Random.Range(0, 100) < 20)
                return 20;
            else return val % 12;
        }
        else if (GM.strategyLevel == 22)
        {
            int val = Random.Range(0, 7);
            if (val == 6 && Random.Range(0, 100) < 20)
                return 20;
            else return val % 6;
        }
        else if (GM.strategyLevel == 26 || GM.strategyLevel == 34)
        {
            int val = Random.Range(0, 8);
            if (val == 7 && Random.Range(0, 100) < 20)
                return 20;
            else return val % 7;
        }
        else if (GM.strategyLevel == 31 || GM.strategyLevel == 32)
        {
            int val = Random.Range(0, 7);
            if (val == 6 && Random.Range(0, 100) < 15)
                return 20;
            else return val % 6;
        }
        return 3;
    }
    public static bool TutTimeWithLevel()
    {
        if (GM.Mode == 1)
        {
            //if (GM.strategyLevel <= 4)
                return true;
        }

        return false;
    }
    public static Vector3 tutTipPos(Vector3 boardBGSize, Vector3 boardBGPos)
    {
        if (GM.strategyLevel == 2 && AtomStage.TUT_TIME.type == 1)
            return new Vector3(1000, 1000, 1000);//return boardBGPos - new Vector3(0, boardBGSize.y / 16, 5);
        //if (GM.strategyLevel == 3 && AtomStage.TUT_TIME.type == 1)
        //    return boardBGPos - new Vector3(boardBGSize.x / 2, boardBGSize.y / 2, 5);
        if (AtomStage.TUT_TIME.type / 1000 == 1)
            return boardBGPos - new Vector3(GM.unit / 5, boardBGSize.y / 2.6f, 5);
        if (AtomStage.TUT_TIME.type / 1000 == 2)
            return boardBGPos + new Vector3(-GM.unit / 5, boardBGSize.y / 2.6f, -5);
        if (GM.strategyLevel == 1 && AtomStage.TUT_TIME.type == 1)
            return boardBGPos - new Vector3(boardBGSize.x * 0.37f, boardBGSize.y * 0.28f, 5);
        if (GM.strategyLevel == 3 && AtomStage.TUT_TIME.type == 1)
            return boardBGPos - new Vector3(boardBGSize.x / 18f, boardBGSize.y / 7f, 5);
        return Vector3.zero;
    }

    public static Ball BallWithBonus(int level, int x, int y)
    {
        Debug.Log("New BONUS BALL " + x + "  " + y);
        if (level == 1)
            return new Ball(12, x, y, true);
        else if (level == 2)
            return new Ball(13, x, y, true);
        else if (level == 3)
            return new Ball(12, x, y, true);
        else if (level == 4)
            return new Ball(14, x, y, true);
        else if (level == 5)
            return new Ball(15, x, y, true);
        else if (level == 6)
            return new Ball(12, x, y, true);
        else if (level == 7)
            return new Ball(13, x, y, true);
        else if (level == 8)
            return new Ball(14, x, y, true);

        else if (level == 50)
        {
            Ball.elmLevel = 2;
            return new Ball(12, x, y, true);
        }
        else if (level == 51)
        {
            Ball.elmLevel = 2;
            return new Ball(13, x, y, true);
        }
        else if (level == 52)
        {
            Ball.elmLevel = 2;
            return new Ball(14, x, y, true);
        }

        else if (level == 70)
        {
            Ball.elmLevel = 3;
            return new Ball(12, x, y, true);
        }
        else if (level == 71)
        {
            Ball.elmLevel = 3;
            return new Ball(13, x, y, true);
        }
        return new Ball();
    }

    public static int RankStripID(int score)
    {
        if (score < 1000)
            return 0;
        else if (score < 2000)
            return 1;
        else if (score < 5000)
            return 2;
        else if (score < 10000)
            return 3;
        else if (score < 20000)
            return 4;
        else if (score < 30000)
            return 5;
        else if (score < 50000)
            return 6;
        else if (score < 70000)
            return 7;
        else if (score < 100000)
            return 8;
        else if (score < 200000)
            return 9;
        else if (score < 300000)
            return 10;
        else if (score < 500000)
            return 11;
        else if (score < 600000)
            return 12;
        else if (score < 800000)
            return 13;
        else if (score < 200000)
            return 14;
        else if (score < 200000)
            return 15;
        else if (score < 200000)
            return 16;
        else if (score < 200000)
            return 17;
        else if (score < 200000)
            return 18;
        else if (score < 200000)
            return 19;
        else if (score < 200000)
            return 20;

        return 0;
    }
    public static int NextRank(int score)
    {
        if (score < 1000)
            return 1000;
        else if (score < 2000)
            return 2000;
        else if (score < 5000)
            return 5000;
        else if (score < 10000)
            return 10000;
        else if (score < 20000)
            return 4;
        else if (score < 30000)
            return 5;
        else if (score < 50000)
            return 6;
        else if (score < 70000)
            return 7;
        else if (score < 100000)
            return 8;
        else if (score < 200000)
            return 9;
        else if (score < 300000)
            return 10;
        else if (score < 500000)
            return 11;
        else if (score < 600000)
            return 12;
        else if (score < 800000)
            return 13;
        else if (score < 200000)
            return 14;
        else if (score < 200000)
            return 15;
        else if (score < 200000)
            return 16;
        else if (score < 200000)
            return 17;
        else if (score < 200000)
            return 18;
        else if (score < 200000)
            return 19;
        else if (score < 200000)
            return 20;

        return 0;
    }

    public static List<Effect> FloatScore(int score, Ball ball)
    {
        List<Effect> floatlist = new List<Effect>();
        Vector3 scale = Vector3.one * GM.ScaleSizeBG() * 0.205f;
        Effect e = ball != null ? new Effect(10 * 1000 + ball.type, ball.Position + new Vector3(-ball.Size.x / 1.1f, 0, -2), ball.Scale * Vector3.one, false)
                            : new Effect(10 * 1000 + 120, GM.BoardPos + new Vector3(-GM.BoardSize.x / 7.8f, 0, -2), scale, false);
        e.DestroyAfter(3000);
        floatlist.Add(e);

        if (score == 80)
        {
            e.Position += new Vector3(ball.Size.x / 2.9f, 0, 0);
            e = new Effect(8 * 1000 + ball.type, ball.Position + new Vector3(0, 0, -2), ball.Scale * Vector3.one, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
            e = new Effect(0 * 1000 + ball.type, ball.Position + new Vector3(ball.Size.x / 2f, 0, -2), ball.Scale * Vector3.one, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
        }
        else if (score == 160)
        {
            e.Position += new Vector3(ball.Size.x / 4f, 0, 0);
            e = new Effect(1 * 1000 + ball.type, ball.Position + new Vector3(-ball.Size.x / 2.8f, 0, -2), ball.Scale * Vector3.one, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
            e = new Effect(6 * 1000 + ball.type, ball.Position + new Vector3(ball.Size.x / 20f, 0, -2), ball.Scale * Vector3.one, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
            e = new Effect(0 * 1000 + ball.type, ball.Position + new Vector3(ball.Size.x / 1.6f, 0, -2), ball.Scale * Vector3.one, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
        }
        else if (score > 160 && score < 1000)
        {
            e = new Effect((score / 100 % 10) * 1000 + ball.type, ball.Position + new Vector3(-ball.Size.x / 2.8f, 0, -2), ball.Scale * Vector3.one, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
            e = new Effect((score / 10 % 10) * 1000 + ball.type, ball.Position + new Vector3(ball.Size.x / 4.5f, 0, -2), ball.Scale * Vector3.one, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
            e = new Effect((score % 10) * 1000 + ball.type, ball.Position + new Vector3(ball.Size.x / 1.2f, 0, -2), ball.Scale * Vector3.one, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
        }
        else if (score >= 1000 && ball == null)
        {
            e = new Effect((score / 1000 % 10) * 1000 + 120, GM.BoardPos + new Vector3(-GM.BoardSize.x / 12f, 0, -2), scale, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
            e = new Effect((score / 100 % 10) * 1000 + 120, GM.BoardPos + new Vector3(-GM.BoardSize.x / 30f, 0, -2), scale, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
            e = new Effect((score / 10 % 10) * 1000 + 120, GM.BoardPos + new Vector3(GM.BoardSize.x / 30, 0, -2), scale, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
            e = new Effect((score % 10) * 1000 + 120, GM.BoardPos + new Vector3(GM.BoardSize.x / 10f, 0, -2), scale, false);
            e.DestroyAfter(3000);
            floatlist.Add(e);
        }

        return floatlist;
    }

    public static List<Image> LevelText(Image gameSlogan, Sprite[] anous, float scaleRatio)
    {
        List<Image> list = new List<Image>();
        Color c = new Color(157f / 255f, 161f / 255f, 160f / 255f);
        Vector3 pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 4, gameSlogan.Size.y / 1.3f, 0);
        
        list.Add(new Image(anous[11], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
        list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
        list.Add(new Image(anous[21], pos + new Vector3(gameSlogan.Size.x * 2 / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
        list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 3 / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
        list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 4 / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
        list.Add(new Image(anous[GM.strategyLevel / 10 + 26], pos + new Vector3(gameSlogan.Size.x * 5.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
        list.Add(new Image(anous[GM.strategyLevel % 10 + 26], pos + new Vector3(gameSlogan.Size.x * 6.3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        Debug.Log("level text " + GM.strategyLevel);
        if (GM.strategyLevel == 1)//lv1
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.7f, -gameSlogan.Size.y / 1.3f, 0);
            //Quick-n-easy
            list.Add(new Image(anous[16], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 1.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], pos + new Vector3(gameSlogan.Size.x * 2.45f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[10], pos + new Vector3(gameSlogan.Size.x * 3.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[37], pos + new Vector3(gameSlogan.Size.x * 4.25f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 5.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[37], pos + new Vector3(gameSlogan.Size.x * 6.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 6.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 7.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[18], pos + new Vector3(gameSlogan.Size.x * 8.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[24], pos + new Vector3(gameSlogan.Size.x * 9.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[39], pos + new Vector3(gameSlogan.Size.x * 10.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 2)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.8f, -gameSlogan.Size.y / 1.3f, 0);
            //get atomic
            list.Add(new Image(anous[6], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 0.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 1.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 4.05f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[12], pos + new Vector3(gameSlogan.Size.x * 6.2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 7.2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], pos + new Vector3(gameSlogan.Size.x * 7.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[39], pos + new Vector3(gameSlogan.Size.x * 8.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 3)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 3.0f, -gameSlogan.Size.y / 1.3f, 0);
            //It's alive
            list.Add(new Image(anous[8], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 0.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[41], pos + new Vector3(gameSlogan.Size.x * 1.2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[18], pos + new Vector3(gameSlogan.Size.x * 1.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 4.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 5.2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[21], pos + new Vector3(gameSlogan.Size.x * 6.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[39], pos + new Vector3(gameSlogan.Size.x * 7.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 4)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 3.1f, -gameSlogan.Size.y / 1.3f, 0);
            //Reflection
            list.Add(new Image(anous[17], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 0.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[5], pos + new Vector3(gameSlogan.Size.x * 1.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 2.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 3.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], pos + new Vector3(gameSlogan.Size.x * 4.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 5.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 6.35f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 7.15f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 8.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[18], pos + new Vector3(gameSlogan.Size.x * 9.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 5)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.1f, -gameSlogan.Size.y / 1.3f, 0);
            //Radiation round
            list.Add(new Image(anous[17], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 2.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 4.3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 5.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 8.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 9.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 10.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 12.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 6)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.1f, -gameSlogan.Size.y / 1.3f, 0);
            //Molecular soup
            list.Add(new Image(anous[12], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 2.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], pos + new Vector3(gameSlogan.Size.x * 3.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 4.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 5.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 6.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 7.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 9.2f / 13f, 0, 0);
            list.Add(new Image(anous[18], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[15], spos + new Vector3(gameSlogan.Size.x * 2.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 7)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.5f, -gameSlogan.Size.y / 1.3f, 0);
            //gone fission
            list.Add(new Image(anous[6], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
           
            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 5f / 13f, 0, 0);
            list.Add(new Image(anous[5], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], spos + new Vector3(gameSlogan.Size.x * 0.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[18], spos + new Vector3(gameSlogan.Size.x * 1.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[18], spos + new Vector3(gameSlogan.Size.x * 2.35f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], spos + new Vector3(gameSlogan.Size.x * 3.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 3.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 4.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 8)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.4f, -gameSlogan.Size.y / 1.3f, 0);
            //Magnet round
            list.Add(new Image(anous[12], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[6], pos + new Vector3(gameSlogan.Size.x * 2.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 3.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 4.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 6.7f / 13f, 0, 0);
            list.Add(new Image(anous[17], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 9)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 3.7f, -gameSlogan.Size.y / 1.3f, 0);
            //Nuke it!
            list.Add(new Image(anous[13], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[10], pos + new Vector3(gameSlogan.Size.x * 1.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 2.93f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 4.4f / 13f, 0, 0);
            list.Add(new Image(anous[8], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], spos + new Vector3(gameSlogan.Size.x * 0.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[39], spos + new Vector3(gameSlogan.Size.x * 1.15f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 10)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 1.9f, -gameSlogan.Size.y / 1.3f, 0);
            //Radiation round 2
            list.Add(new Image(anous[17], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 2.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 4.3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 5.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 8.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 9.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 10.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 12.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[28], pos + new Vector3(gameSlogan.Size.x * 13.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 11)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.4f, -gameSlogan.Size.y / 1.3f, 0);
            //Atomic attack
            list.Add(new Image(anous[0], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 0.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[12], pos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 3.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], pos + new Vector3(gameSlogan.Size.x * 4.65f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 6.2f / 13f, 0, 0);
            list.Add(new Image(anous[0], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], spos + new Vector3(gameSlogan.Size.x * 0.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], spos + new Vector3(gameSlogan.Size.x * 1.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], spos + new Vector3(gameSlogan.Size.x * 2.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], spos + new Vector3(gameSlogan.Size.x * 3.35f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[10], spos + new Vector3(gameSlogan.Size.x * 4.33f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 12)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.2f, -gameSlogan.Size.y / 1.3f, 0);
            //Contamination
            list.Add(new Image(anous[2], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 2.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[12], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 5.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 7.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 8.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 9.25f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 10.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            
        }
        if (GM.strategyLevel == 13)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 1.85f, -gameSlogan.Size.y / 1.3f, 0);
            //Molecule madness
            list.Add(new Image(anous[12], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 2.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], pos + new Vector3(gameSlogan.Size.x * 3.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 4.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 5.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 6.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 8.3f / 13f, 0, 0);
            list.Add(new Image(anous[12], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], spos + new Vector3(gameSlogan.Size.x * 1.2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 2.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 3.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], spos + new Vector3(gameSlogan.Size.x * 4.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[18], spos + new Vector3(gameSlogan.Size.x * 5.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[18], spos + new Vector3(gameSlogan.Size.x * 6.05f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 14)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.4f, -gameSlogan.Size.y / 1.3f, 0);
            //hotspot round
            list.Add(new Image(anous[7], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 1.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[18], pos + new Vector3(gameSlogan.Size.x * 2.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[15], pos + new Vector3(gameSlogan.Size.x * 3.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 4.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 5.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            
            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 7.1f / 13f, 0, 0);
            list.Add(new Image(anous[17], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 15)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 1.9f, -gameSlogan.Size.y / 1.3f, 0);
            //Radiation round 3
            list.Add(new Image(anous[17], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 2.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 4.3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 5.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 8.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 9.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 10.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 12.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[29], pos + new Vector3(gameSlogan.Size.x * 13.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 16)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.4f, -gameSlogan.Size.y / 1.3f, 0);
            //Supercollider
            list.Add(new Image(anous[18], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 0.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[15], pos + new Vector3(gameSlogan.Size.x * 1.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 2.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 3.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
           
            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 4.5f / 13f, 0, 0);
            list.Add(new Image(anous[2], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], spos + new Vector3(gameSlogan.Size.x * 2.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], spos + new Vector3(gameSlogan.Size.x * 3.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 4.3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], spos + new Vector3(gameSlogan.Size.x * 5.25f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[17], spos + new Vector3(gameSlogan.Size.x * 6.2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 17)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.2f, -gameSlogan.Size.y / 1.3f, 0);
            //Magnet round 2
            list.Add(new Image(anous[12], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[6], pos + new Vector3(gameSlogan.Size.x * 2.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 3.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 4.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 6.5f / 13f, 0, 0);
            list.Add(new Image(anous[17], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[28], spos + new Vector3(gameSlogan.Size.x * 5.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 18)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.3f, -gameSlogan.Size.y / 1.3f, 0);
            //Chain Reaction
            list.Add(new Image(anous[2], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[7], pos + new Vector3(gameSlogan.Size.x * 0.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 2.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 3.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 5.2f / 13f, 0, 0);
            list.Add(new Image(anous[17], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], spos + new Vector3(gameSlogan.Size.x * 0.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], spos + new Vector3(gameSlogan.Size.x * 1.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], spos + new Vector3(gameSlogan.Size.x * 2.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], spos + new Vector3(gameSlogan.Size.x * 3.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], spos + new Vector3(gameSlogan.Size.x * 4.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 5.15f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 6.15f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 19)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.6f, -gameSlogan.Size.y / 1.3f, 0);
            //Chromeland
            list.Add(new Image(anous[2], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[7], pos + new Vector3(gameSlogan.Size.x * 0.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 1.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 2.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[12], pos + new Vector3(gameSlogan.Size.x * 4.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 5.2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 6.1f / 13f, 0, 0);
            list.Add(new Image(anous[11], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], spos + new Vector3(gameSlogan.Size.x * 1.02f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 2.02f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 3.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            
        }
        if (GM.strategyLevel == 20)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 1.9f, -gameSlogan.Size.y / 1.3f, 0);
            //Radiation round 4
            list.Add(new Image(anous[17], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 2.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 4.3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 5.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 8.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 9.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 10.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 12.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[30], pos + new Vector3(gameSlogan.Size.x * 13.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 21)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 3.1f, -gameSlogan.Size.y / 1.3f, 0);
            //Meltdown
            list.Add(new Image(anous[12], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 1.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 2.65f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 3.55f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 4.55f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[22], pos + new Vector3(gameSlogan.Size.x * 5.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 7.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            
        }
        if (GM.strategyLevel == 22)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.0f, -gameSlogan.Size.y / 1.3f, 0);
            //Contamination 2
            list.Add(new Image(anous[2], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 2.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[12], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 5.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 7.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 8.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 9.25f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 10.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[28], pos + new Vector3(gameSlogan.Size.x * 12.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 23)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.7f, -gameSlogan.Size.y / 1.3f, 0);
            //Nuclear war
            list.Add(new Image(anous[13], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], pos + new Vector3(gameSlogan.Size.x * 1.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 2.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 3.78f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 4.78f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 5.78f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 7.7f / 13f, 0, 0);
            list.Add(new Image(anous[22], spos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[17], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            
        }
        if (GM.strategyLevel == 24)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.2f, -gameSlogan.Size.y / 1.3f, 0);
            //Magnet round 3
            list.Add(new Image(anous[12], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[6], pos + new Vector3(gameSlogan.Size.x * 2.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 3.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 4.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 6.5f / 13f, 0, 0);
            list.Add(new Image(anous[17], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[29], spos + new Vector3(gameSlogan.Size.x * 5.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 25)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 1.9f, -gameSlogan.Size.y / 1.3f, 0);
            //Radiation round 5
            list.Add(new Image(anous[17], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 2.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 4.3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 5.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 8.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 9.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 10.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 12.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[31], pos + new Vector3(gameSlogan.Size.x * 13.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 26)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.0f, -gameSlogan.Size.y / 1.3f, 0);
            //Contamination 3
            list.Add(new Image(anous[2], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 2.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[12], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 5.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 7.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 8.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 9.25f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 10.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[29], pos + new Vector3(gameSlogan.Size.x * 12.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 27)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.3f, -gameSlogan.Size.y / 1.3f, 0);
            //Neutron dance
            list.Add(new Image(anous[13], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 1.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 2.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 3.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 4.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 5.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 7.5f / 13f, 0, 0);
            list.Add(new Image(anous[3], spos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[2], spos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], spos + new Vector3(gameSlogan.Size.x * 4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 28)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.0f, -gameSlogan.Size.y / 1.3f, 0);
            //hotspot round 2
            list.Add(new Image(anous[7], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 1.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[18], pos + new Vector3(gameSlogan.Size.x * 2.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[15], pos + new Vector3(gameSlogan.Size.x * 3.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 4.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 5.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 7.1f / 13f, 0, 0);
            list.Add(new Image(anous[17], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[28], spos + new Vector3(gameSlogan.Size.x * 5.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 29)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.2f, -gameSlogan.Size.y / 1.3f, 0);
            //Magnet round 4
            list.Add(new Image(anous[12], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[6], pos + new Vector3(gameSlogan.Size.x * 2.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 3.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 4.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 6.5f / 13f, 0, 0);
            list.Add(new Image(anous[17], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[30], spos + new Vector3(gameSlogan.Size.x * 5.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 30)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 1.9f, -gameSlogan.Size.y / 1.3f, 0);
            //Radiation round 6
            list.Add(new Image(anous[17], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 2.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 4.3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 5.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.8f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[17], pos + new Vector3(gameSlogan.Size.x * 8.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 9.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 10.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], pos + new Vector3(gameSlogan.Size.x * 12.4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[32], pos + new Vector3(gameSlogan.Size.x * 13.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 31)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 3.7f, -gameSlogan.Size.y / 1.3f, 0);
            //Half life
            list.Add(new Image(anous[7], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[11], pos + new Vector3(gameSlogan.Size.x * 2.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[5], pos + new Vector3(gameSlogan.Size.x * 2.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            
            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 4.5f / 13f, 0, 0);
            list.Add(new Image(anous[11], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], spos + new Vector3(gameSlogan.Size.x * 0.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[5], spos + new Vector3(gameSlogan.Size.x * 1.5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], spos + new Vector3(gameSlogan.Size.x * 2.45f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            
        }
        if (GM.strategyLevel == 32)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.3f, -gameSlogan.Size.y / 1.3f, 0);
            //Quantum craze
            list.Add(new Image(anous[16], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 2.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 3.85f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], pos + new Vector3(gameSlogan.Size.x * 4.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[12], pos + new Vector3(gameSlogan.Size.x * 5.9f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 7.5f / 13f, 0, 0);
            list.Add(new Image(anous[2], spos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[17], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[25], spos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], spos + new Vector3(gameSlogan.Size.x * 3.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 33)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.2f, -gameSlogan.Size.y / 1.3f, 0);
            //Magnet round 5
            list.Add(new Image(anous[12], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 1.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[6], pos + new Vector3(gameSlogan.Size.x * 2.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 3.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[4], pos + new Vector3(gameSlogan.Size.x * 4.1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 5f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            Vector3 spos = pos + new Vector3(gameSlogan.Size.x * 6.5f / 13f, 0, 0);
            list.Add(new Image(anous[17], spos + new Vector3(0, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], spos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[20], spos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], spos + new Vector3(gameSlogan.Size.x * 3f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[3], spos + new Vector3(gameSlogan.Size.x * 4f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[31], spos + new Vector3(gameSlogan.Size.x * 5.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        if (GM.strategyLevel == 34)
        {
            pos = gameSlogan.Position + new Vector3(-gameSlogan.Size.x / 2.0f, -gameSlogan.Size.y / 1.3f, 0);
            //Contamination 4
            list.Add(new Image(anous[2], pos, new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 1f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 2f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 2.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 3.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[12], pos + new Vector3(gameSlogan.Size.x * 4.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 5.95f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 6.7f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[0], pos + new Vector3(gameSlogan.Size.x * 7.75f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[19], pos + new Vector3(gameSlogan.Size.x * 8.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[8], pos + new Vector3(gameSlogan.Size.x * 9.25f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[14], pos + new Vector3(gameSlogan.Size.x * 10.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));
            list.Add(new Image(anous[13], pos + new Vector3(gameSlogan.Size.x * 11.0f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

            list.Add(new Image(anous[30], pos + new Vector3(gameSlogan.Size.x * 12.6f / 13f, 0, 0), new Vector3(1, 1, 1) * scaleRatio * 0.21f, c));

        }
        return list;
    }
}
