using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Networking;
using System.Security.Cryptography;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class AquaData {

    public int AdvanInfo;
    public int TotalCoin;
    public int strategy_score;
    public int strategy_level;
    public int action_level;
    public int action_score;
    public int leveltut;
    public int[] board_strastate;
    public short[] hardzard_strastate;
    public int[] board_actstate;
    public short[] hardzard_actstate;
    public bool strategystate = false;
    public bool actionstate = false;
    public int stra_infostate;
    public int bombmeter;
    public int diamond;


    public static void Save(Ball[,] board = null, bool isPlaying = false)
    {
        //PlayerData data = new PlayerData();
        AquaData data = new AquaData();
        data.TotalCoin = GM.totalCoin;
        data.strategy_level = GM.strategyLevel * 1000 + GM.strategymeter;
        data.action_level = GM.actionLevel * 1000 + GM.actionmeter;
        data.strategy_score = GM.strategyScore;
        data.action_score = GM.actionScore;
        data.leveltut = GM.Mode == 1 ? AtomStage.TUT_TIME.type : GM.tutLevel;
        data.bombmeter = GM.bombMeter;
        data.diamond = GM.Diamond;
        data.stra_infostate = GM.atomCollect * 10000000 + GM.moculeMade * 100000 + GM.bonusMocule * 1000 + GM.bonusUpgrade * 100 + GM.biggestCombo;
        if (GM.Mode == 1)
        {
            data.strategystate = board != null ? true : false;
            data.actionstate = GM.boardacttype;
        }
        if (GM.Mode == 2)
        {
            data.strategystate = GM.boardstratype;
            data.actionstate = board != null ? true : false;
            Debug.Log("dataactstate " + data.actionstate +"  " +(board != null));

        }
        data.board_strastate = new int[18];
        data.board_actstate = new int[18];
        List<short> listhz = new List<short>();
        if (board != null)
        {
            if (GM.Mode == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    int pow = 1;
                    for (int j = 0; j < 4; j++)
                    {
                        data.board_strastate[i * 2] += ConvertBoard(board[i, j] != null && !board[i,j].isDie && !board[i,j].isScored ? board[i, j].type : -1) * pow;
                        pow *= 100;
                    }

                    pow = 1;
                    for (int j = 0; j < 4; j++)
                    {
                        data.board_strastate[i * 2 + 1] += ConvertBoard(board[i, j + 4] != null && !board[i, j + 4].isDie && !board[i, j + 4].isScored ? board[i, j + 4].type : -1) * pow;
                        pow *= 100;
                    }
                    Debug.Log("i(" + i + ")" + data.board_strastate[i * 2] + "  " + data.board_strastate[i * 2 + 1]);

                }

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j] != null && !board[i, j].isDie && !board[i, j].isScored && board[i, j].Hazard > 0)
                        {
                            listhz.Add((short)(board[i, j].Hazard * 1000 + i * 100 + j));
                            //Debug.Log("hazard " + i + "," + j +" val:" + (board[i, j].Hazard * 10000 + i * 100 + j));
                        }
                    }
                }
                data.hardzard_strastate = new short[listhz.Count];
                for (int i = 0; i < listhz.Count; i++)
                    data.hardzard_strastate[i] = listhz[i];
            }
            if (GM.Mode == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    int pow = 1;
                    for (int j = 0; j < 4; j++)
                    {
                        //Debug.Log("dong" + i + "  " + ConvertBoard(board[j, i] != null ? board[j, i].type : -1) + " andpow " + pow + "  = " + data.boardstate[i * 2]);
                        data.board_actstate[i * 2] += ConvertBoard((board[i, j] != null  && !board[i,j].isDie && !board[i, j].isScored) ? board[i, j].type : -1) * pow;
                        pow *= 100;
                    }

                    pow = 1;
                    for (int j = 0; j < 4; j++)
                    {
                        data.board_actstate[i * 2 + 1] += ConvertBoard((board[i, j + 4] != null && !board[i, j + 4].isDie && !board[i, j + 4].isScored) ? board[i, j + 4].type : -1) * pow;
                        pow *= 100;
                    }
                    Debug.Log("i(" + i + ")" + data.board_actstate[i * 2] + "  " + data.board_actstate[i * 2 + 1]);

                }

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j] != null && !board[i, j].isDie && !board[i, j].isScored && board[i, j].Hazard > 0)
                        {
                            listhz.Add((short)(board[i, j].Hazard * 1000 + i * 100 + j));
                            //Debug.Log("hazard " + i + "," + j +" val:" + (board[i, j].Hazard * 10000 + i * 100 + j));
                        }
                    }
                }
                data.hardzard_actstate = new short[listhz.Count];
                for (int i = 0; i < listhz.Count; i++)
                    data.hardzard_actstate[i] = listhz[i];
            }
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (File.Exists(Application.persistentDataPath + "/strategy_guest.dat"))
        {

            file = File.Open(Application.persistentDataPath + "/strategy_guest.dat", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/strategy_guest.dat");
        }
        if (GM.Mode == 2)
        {
            if (!File.Exists(Application.persistentDataPath + "/action_guest.dat"))
            {
                FileStream fileact = File.Create(Application.persistentDataPath + "/action_guest.dat");
                fileact.Close();
            }
        }

        bf.Serialize(file, data);
        file.Close();

    }
    public static int[] Load()
    {
        bool dataChange = false;

        if (File.Exists(Application.persistentDataPath + "/strategy_guest.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter ();
            FileStream file = File.Open (Application.persistentDataPath + "/strategy_guest.dat", FileMode.Open);
            AquaData data = (AquaData)bf.Deserialize (file);
            file.Close ();
            GM.totalCoin = data.TotalCoin;
            GM.Diamond = data.diamond;
            GM.strategyLevel = data.strategy_level / 1000;
            GM.strategymeter = data.strategy_level % 1000;
            GM.actionLevel = data.action_level / 1000;
            GM.actionmeter = data.action_level % 1000;
            GM.strategyScore = data.strategy_score;
            GM.actionScore = data.action_score;
            GM.tutLevel = data.leveltut;
            AtomStage.TUT_TIME.type = data.leveltut;
            GM.bombMeter = data.bombmeter;
            GM.boardstratype = data.strategystate;
            GM.boardacttype = data.actionstate;
            GM.atomCollect = (short)(data.stra_infostate / 10000000);
            GM.moculeMade = (short)(data.stra_infostate / 100000 % 100);
            GM.bonusMocule = (short)(data.stra_infostate / 1000 % 100);
            GM.bonusUpgrade = (short)(data.stra_infostate % 1000 / 100);
            GM.biggestCombo = (short)(data.stra_infostate % 100);
            if (GM.listsavehazard == null)
                GM.listsavehazard = new List<short>();
            GM.listsavehazard.Clear();

            if (GM.Mode == 1 && data.hardzard_strastate != null)
                for (int i = 0; i < data.hardzard_strastate.Length; i++)
                {
                    GM.listsavehazard.Add(data.hardzard_strastate[i]);
                    Debug.Log("listhz " + GM.listsavehazard[i]);
                }
            if (GM.Mode == 2 && data.hardzard_actstate != null)
                for (int i = 0; i < data.hardzard_actstate.Length; i++)
                {
                    GM.listsavehazard.Add(data.hardzard_actstate[i]);
                    Debug.Log("listhz " + GM.listsavehazard[i]);
                }
            //
            
            for (int i = 0; i < data.board_actstate.Length; i++)
            {
                Debug.Log("i(" + i + "):" + UnConvertBoard(data.board_actstate[i] % 100) + "," + UnConvertBoard(data.board_actstate[i] / 100 % 100) + "," +
                    UnConvertBoard(data.board_actstate[i] / 10000 % 100) + "," + UnConvertBoard(data.board_actstate[i] / 1000000 % 100));
            }
            Debug.Log("Tutlevel " + GM.tutLevel);
            
            if (GM.Mode == 1)
                return data.board_strastate;
            if (GM.Mode == 2)
                return data.board_actstate;


        }
        else
        {
            GM.totalCoin = 0;
            GM.strategyLevel = 1;
            GM.actionLevel = 1;
            GM.strategyScore = 0;
            GM.actionScore = 0;
            GM.tutLevel = 1;
            GM.bombMeter = 0;
            GM.Diamond = 0;
            GM.bagItem = new List<int>();
        }
        return null;
        if (dataChange)
            AquaData.Save();
    }

    public static void Delete()
    {
        File.Delete(Application.persistentDataPath + "/strategy_guest.dat");
        File.Delete(Application.persistentDataPath + "/action_guest.dat");

    }



    public static int ConvertBoard(int type)
    {
        if (type >= 100 && type <= 116)
            return type - 100 + 1;
        if (type == 120)
            return 18;
        if (type > 200 && type < 300)
            return type - 200 + 7;
        if (type > 300)
            return type - 300 + 12;
        if (type < 100)
        {
            if (type < 20)
                return 50 + type + 1;
            if (type == 20)
                return 68;
        }
        return 0;
    }
    public static int UnConvertBoard(int cvtype)
    {
       
        if (cvtype == 0)
            return -1;
        if (cvtype >= 1 && cvtype <= 17)
            return cvtype + 100 - 1;
        if (cvtype == 18)
            return 120;
        if (cvtype >= 19 && cvtype <= 23)
            return cvtype + 200 - 7;
        if (cvtype >= 24 && cvtype < 50)
            return cvtype + 300 - 12;
        if (cvtype > 50)
        {
            if (cvtype < 68)
                return cvtype - 50 - 1;
            if (cvtype == 68)
                return 20;
        }
        return -1;
    }

    public static bool CheckSavedStrategy()
    {
        if (File.Exists(Application.persistentDataPath + "/strategy_guest.dat"))
            return true;
        return false;
    }
    public static bool CheckSavedAction()
    {
        if (File.Exists(Application.persistentDataPath + "/action_guest.dat"))
            return true;
        return false;
    }

}
