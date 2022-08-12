using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    int timeToSound = -1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = new GameObject("createmole");
        AudioSource audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/CreateMolecule");
        go.transform.parent = this.gameObject.transform;


        go = new GameObject("select");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/SelectAtom");
        go.transform.parent = this.gameObject.transform;


        go = new GameObject("appear");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/AtomAppear");
        go.transform.parent = this.gameObject.transform;

        go = new GameObject("move");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/MoveAtom");
        go.transform.parent = this.gameObject.transform;

        go = new GameObject("moveBio");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/MoveBioAtom");
        go.transform.parent = this.gameObject.transform;

        go = new GameObject("magnet");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/Magnet");
        go.transform.parent = this.gameObject.transform;


        go = new GameObject("elec");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/Electric1");
        go.transform.parent = this.gameObject.transform;

        go = new GameObject("freeze");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/Freeze");
        go.transform.parent = this.gameObject.transform;

        go = new GameObject("nuke");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/NukeBlast");
        go.transform.parent = this.gameObject.transform;

        go = new GameObject("geiger");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/Geiger1");
        go.transform.parent = this.gameObject.transform;


        go = new GameObject("beat");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/heartbeat");
        go.transform.parent = this.gameObject.transform;


        go = new GameObject("LowWhoosh");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/LowWhoosh");
        go.transform.parent = this.gameObject.transform;

        //12
        go = new GameObject("Whoosh");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/Whoosh");
        go.transform.parent = this.gameObject.transform;

        //13
        go = new GameObject("swoop");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Sound/swoop");
        go.transform.parent = this.gameObject.transform;

        go = new GameObject("14");
        go.transform.parent = this.gameObject.transform;
        go = new GameObject("15");
        go.transform.parent = this.gameObject.transform;
        go = new GameObject("16");
        go.transform.parent = this.gameObject.transform;
        go = new GameObject("17");
        go.transform.parent = this.gameObject.transform;

        //18
        go = new GameObject("ready");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/getready");
        go.transform.parent = this.gameObject.transform;
        go = new GameObject("go");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/go");
        go.transform.parent = this.gameObject.transform;

        //20
        go = new GameObject("combo");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/combo");
        go.transform.parent = this.gameObject.transform;

        //21
        go = new GameObject("scombo");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/supercombo");
        go.transform.parent = this.gameObject.transform;

        //22
        go = new GameObject("mega");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/megacombo");
        go.transform.parent = this.gameObject.transform;

        //23
        go = new GameObject("ultra");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/ultracombo");
        go.transform.parent = this.gameObject.transform;

        //24
        go = new GameObject("hyper");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/hypercombo");
        go.transform.parent = this.gameObject.transform;

        //25
        go = new GameObject("max");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/maxcombo");
        go.transform.parent = this.gameObject.transform;

        //26
        go = new GameObject("bonismoleready");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/bonusmoleculeready");
        go.transform.parent = this.gameObject.transform;

        //27
        go = new GameObject("bonusmole");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/bonusmolecule");
        go.transform.parent = this.gameObject.transform;

        //28
        go = new GameObject("bonusmoleUp");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/bonusmoleculeupgraded");
        go.transform.parent = this.gameObject.transform;

        //29
        go = new GameObject("biohazard");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/biohazard");
        go.transform.parent = this.gameObject.transform;

        //30
        go = new GameObject("bio");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/biohazardalert");
        go.transform.parent = this.gameObject.transform;

        //31
        go = new GameObject("atomic");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/atomicbomb");
        go.transform.parent = this.gameObject.transform;

        //32
        go = new GameObject("atomicbomb");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/atomicbombready");
        go.transform.parent = this.gameObject.transform;

        //33
        go = new GameObject("levelup");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/levelup");
        go.transform.parent = this.gameObject.transform;

        //34
        go = new GameObject("levelcom");
        audioBackground = go.AddComponent<AudioSource>();
        audioBackground.loop = false;
        audioBackground.clip = (AudioClip)Resources.Load("Voice/levelcomplete");
        go.transform.parent = this.gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChangeVolume()
    {
        for (int i = 0; i < 33; i++)
            if (i < gameObject.transform.childCount && gameObject.transform.GetChild(i).GetComponent<AudioSource>() != null)
                this.gameObject.transform.GetChild(i).GetComponent<AudioSource>().volume = GM.soundlevel;

    }
    public void ClickBall()
    {
        this.gameObject.transform.GetChild(1).GetComponent<AudioSource>().Play();
    }
    public void CreateBall()
    {
        this.gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
    }
    public void AppearBall()
    {
        this.gameObject.transform.GetChild(2).GetComponent<AudioSource>().Play();
    }
    public void MoveBall()
    {
        this.gameObject.transform.GetChild(3).GetComponent<AudioSource>().Play();
    }
    public void MoveBioBall()
    {
        this.gameObject.transform.GetChild(4).GetComponent<AudioSource>().Play();
    }
    public void Magnet()
    {
        this.gameObject.transform.GetChild(5).GetComponent<AudioSource>().Play();
    }
    public void Electric()
    {
        this.gameObject.transform.GetChild(6).GetComponent<AudioSource>().Play();
    }
    public void Freeze()
    {
        this.gameObject.transform.GetChild(7).GetComponent<AudioSource>().Play();
    }
    public void Nuke()
    {
        this.gameObject.transform.GetChild(8).GetComponent<AudioSource>().Play();
    }
    public void Geiger()
    {
        this.gameObject.transform.GetChild(9).GetComponent<AudioSource>().Play();
    }
    public void Beat()
    {
        this.gameObject.transform.GetChild(10).GetComponent<AudioSource>().Play();
    }
    public void LowWhoosh()
    {
        this.gameObject.transform.GetChild(11).GetComponent<AudioSource>().Play();
    }
    public void Whoosh()
    {
        this.gameObject.transform.GetChild(12).GetComponent<AudioSource>().Play();
    }
    public void GetReady()
    {
        this.gameObject.transform.GetChild(18).GetComponent<AudioSource>().Play();
    }
    public bool GetReadyPlaying()
    {
        return this.gameObject.transform.GetChild(18).GetComponent<AudioSource>().isPlaying;
    }
    public void Go()
    {
        this.gameObject.transform.GetChild(19).GetComponent<AudioSource>().Play();
        StageMenu.MOUTH_TALK.isHanddle = true;
        StageMenu.MOUTH_TALK.type = 005;
    }
    public bool GoPlaying()
    {
        return this.gameObject.transform.GetChild(19).GetComponent<AudioSource>().isPlaying;
    }
    public void Combo()
    {
        this.gameObject.transform.GetChild(20).GetComponent<AudioSource>().Play();
        StageMenu.MOUTH_TALK.isHanddle = true;
        StageMenu.MOUTH_TALK.type = 1020;
    }
    public void SuperCombo()
    {
        this.gameObject.transform.GetChild(21).GetComponent<AudioSource>().Play();
    }
    public void MegaCombo()
    {
        this.gameObject.transform.GetChild(22).GetComponent<AudioSource>().Play();
    }
    public void UltraCombo()
    {
        this.gameObject.transform.GetChild(23).GetComponent<AudioSource>().Play();
    }
    public void HyperCombo()
    {
        this.gameObject.transform.GetChild(24).GetComponent<AudioSource>().Play();
    }
    public void MaxCombo()
    {
        this.gameObject.transform.GetChild(25).GetComponent<AudioSource>().Play();
    }
    public void BonusMoleculeReady()
    {
        this.gameObject.transform.GetChild(26).GetComponent<AudioSource>().Play();
    }
    public void BonusMolecule()
    {
        this.gameObject.transform.GetChild(27).GetComponent<AudioSource>().Play();
    }
    public void BonusMoleculeUpgrade()
    {
        this.gameObject.transform.GetChild(28).GetComponent<AudioSource>().Play();
    }
    public void BioHazard()
    {
        this.gameObject.transform.GetChild(29).GetComponent<AudioSource>().Play();
    }
    public void BioHazardReady()
    {
        this.gameObject.transform.GetChild(30).GetComponent<AudioSource>().Play();
    }
    public void AtomicBomb()
    {
        this.gameObject.transform.GetChild(31).GetComponent<AudioSource>().Play();
    }
    public bool AtomicBombPlaying()
    {
        return this.gameObject.transform.GetChild(31).GetComponent<AudioSource>().isPlaying;
    }
    public AudioSource AtomicReady()
    {
        return this.gameObject.transform.GetChild(32).GetComponent<AudioSource>();
    }
    public void LevelUp()
    {
        this.gameObject.transform.GetChild(33).GetComponent<AudioSource>().Play();
    }
    public void NukeBlashAfter(float time)
    {
        StartCoroutine(IENukeBlashAfter(time));
    }



    IEnumerator IENukeBlashAfter(float time)
    {

        yield return new WaitForSecondsRealtime(time);
        Nuke();
    }
}
