using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFrame
{
    public Image frameBG;
    public List<Image> listball;
    Vector3 rootPos;
    public bool DelTime = false;

    public BonusFrame(int type, int color1, int color2)
    {
        float scale = GM.scaleRatio;
        Sprite[] sprites = null;
        if (type == 0)
            frameBG = new Image("UI/MakeGroups", GM.BoardPos - new Vector3(GM.BoardSize.x / 1.28f, -GM.BoardSize.y / 7f, 4.0f), Vector3.one * scale / 4.2f);
        else
        {
            frameBG = new Image("UI/BonusFrame", GM.BoardPos - new Vector3(GM.BoardSize.x / 1.28f, -GM.BoardSize.y / 7f, 4.0f), Vector3.one * scale / 4.2f);
            listball = new List<Image>();
            sprites = Resources.LoadAll<Sprite>("game_items/Atoms");
        }
        if (type == 1)
        {
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
        }
        if (type == 2)
        {
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
        }
        if (type == 3)
        {
            listball.Add(new Image(sprites[12], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[12], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[12], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[12], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[12], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
        }
        if (type == 4)
        {
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
        }
        if (type == 5)
        {
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
        }
        if (type == 6)
        {
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
        }
        if (type == 7)
        {
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));

        }
        if (type == 8)
        {
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));

        }

        if (type == 50)
        {
            listball.Add(new Image(sprites[36], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
        }
        if (type == 51)
        {
            listball.Add(new Image(sprites[45], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2/ 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2/ 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2/ 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2/ 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2/ 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2/ 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2/ 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2/ 7, -0.1f), Vector3.one * scale / 12));
        }
        if (type == 52)
        {
            listball.Add(new Image(sprites[54], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
        }




        if (type == 70)
        {
            listball.Add(new Image(sprites[36], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[6], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[0], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));

        }
        if (type == 71)
        {
            listball.Add(new Image(sprites[45], frameBG.Position + new Vector3(0 + frameBG.Size.x / 70f, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[3], frameBG.Position + new Vector3(frameBG.Size.x / 70f, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));

            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f - frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x/ 7, -frameBG.Size.y / 30f + frameBG.Size.y / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x / 7, -frameBG.Size.y / 30f + frameBG.Size.y/ 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2 / 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f + frameBG.Size.x * 2/ 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2/ 7, -frameBG.Size.y / 30f + frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));
            listball.Add(new Image(sprites[9], frameBG.Position + new Vector3(frameBG.Size.x / 70f - frameBG.Size.x * 2/ 7, -frameBG.Size.y / 30f - frameBG.Size.y * 2 / 7, -0.1f), Vector3.one * scale / 12));

        }

    }

    public Vector3 Position
    {
        set
        {
            frameBG.Position = value;
            if (listball != null)
                for (int i = 0; i < listball.Count; i++)
                    listball[i].Position = value;
        }
        get { return frameBG.Position; }
    }
    public void DelayPosition(Vector3 distanceVec)
    {
            rootPos = this.Position;
        frameBG.Position += distanceVec;
        if (listball != null)
            for (int i = 0; i < listball.Count; i++)
                listball[i].Position += distanceVec;

    }
    public bool isDie
    {
        get { return frameBG == null; }
    }
    // Update is called once per frame
    public void Update()
    {
        if (!DelTime)
        {
            Vector3 moveVec = Vector3.MoveTowards(this.Position, rootPos, frameBG.Size.x / 40);
            Vector3 tmpold = frameBG.Position;
            frameBG.Position = new Vector3(moveVec.x, moveVec.y, this.Position.z);
            tmpold = frameBG.Position - tmpold;
            if (listball != null)
                for (int i = 0; i < listball.Count; i++)
                    listball[i].Position += tmpold;
        }
        if (DelTime)
        {
            Vector3 moveVec = Vector3.MoveTowards(this.Position, new Vector3(-GM.width, this.Position.y, this.Position.z), frameBG.Size.x / 40);
            Vector3 tmpold = frameBG.Position;
            frameBG.Position = new Vector3(moveVec.x, moveVec.y, this.Position.z);
            tmpold = frameBG.Position - tmpold;
            if (listball != null)
                for (int i = 0; i < listball.Count; i++)
                    listball[i].Position += tmpold;
            if (frameBG.Position.x < -GM.width / 1.5f)
                Destroy();
        }

    }

    public static int levelRandomBonus(int level, bool superlvl, Ball[,] board = null)
    {
        if (superlvl)
        {

        }
        if (level < 4)
            return 1020000;
        if (level >= 4 && level < 30)
        {
            //type == 1 return 1020000;
            //type == 2 return 2300000;
            //type == 3 return 3400000;
            //type == 4 return 4200000;
            //type == 5 return 5100000;
            //type == 6 return 6020000;
            //type == 7 return 7300000;
            //type == 8 return 8200000;
            //type == 50 return 50022000;
            //type == 51 return 51303000;
            //type == 52 return 52204000;
            //type == 70 return 70022000;
            //type == 71 return 71133000;
            bool isFire1 = false;
            bool isIce1 = false;
            bool isWind1 = false;
            bool isEther1 = false;
            bool isLight1 = false;
            bool isFire2 = false;
            bool isIce2 = false;
            bool isWind2 = false;
            bool isEther2 = false;
            bool isLight2 = false;

            if (board != null)
            {
                for (int i = 0; i < GM.numberColumn; i++)
                    for (int j = 0; j < GM.numberRow; j++)
                    {
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 112)
                            isFire1 = true;
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 113)
                            isIce1 = true;
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 114)
                            isWind1 = true;
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 115)
                            isEther1 = true;
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 116)
                            isLight1 = true;
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 212)
                            isFire2 = true;
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 213)
                            isIce2 = true;
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 214)
                            isWind2 = true;
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 21)
                            isEther2 = true;
                        if (board[i, j] != null && !board[i, j].isDie && board[i, j].isScored && board[i, j].type == 216)
                            isLight2 = true;
                    }
            }

            int rand = Random.Range(0, 100);
            if (rand > 80 && isFire1)
            {
                return 50022000;
            }
            else if (rand > 80 && isIce1)
            {
                return 51303000;

            }
            else if (rand > 80 && isWind1)
            {
                return 52204000;

            }
            else if (rand > 80 && isEther1)
            {

            }
            else if (rand > 80 && isLight1)
            {

            }
            else if (rand > 80 && isFire2)
            {
                return 70022000;

            }
            else if (rand > 80 && isIce2)
            {
                return 71133000;
            }
            else if (rand > 80 && isWind2)
            {

            }
            else if (rand > 80 && isEther2)
            {

            }
            else if (rand > 80 && isLight2)
            {

            }
            else
            {
                rand = Random.Range(0, 24);
                if (rand < 3)
                    return 1020000;
                else if (rand < 6)
                    return 2300000;
                else if (rand < 9)
                    return 3400000;
                else if (rand < 12)
                    return 4200000;
                else if (rand < 15)
                    return 5100000;
                else if(rand < 18)
                    return 6020000;
                else if (rand < 21)
                    return 7300000;
                else if (rand < 24)
                    return 8200000;
                /*
                if (rand < 30)
                    return 1020000;//Fire
                else if (rand < 50)
                    return 2300000;//Ice
                else if (rand < 70)
                    return 3020000;//Wind
                else if (rand < 85)
                    return 4020000;//Ether
                else
                    return 5020000;//Light
                    */
            }
        }
        return 1020000;
    }
    public static int checkBonus(int typebonus, Ball[,] board, int x, int y, int c_enter, int c_round1, int c_round2)
    {
        if (typebonus == 1)
        {
            c_enter += 100;
            c_round1 += 100;
            if (x - 1 < 0 || x + 1 >= GM.numberColumn || y - 1 < 0 || y + 1 >= GM.numberRow)
                return -1;
            if (board[x - 1, y] == null || board[x - 1, y].isDie || board[x + 1, y] == null || board[x + 1, y].isDie ||
                board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie)
                return -1;
            if (board[x, y].type == c_enter && board[x - 1, y].type == c_round1 && board[x + 1, y].type == c_round1 &&
                board[x, y - 1].type == c_round1 && board[x, y + 1].type == c_round1)
            {
                board[x, y].isScored = true;
                board[x - 1, y].isScored = true;
                board[x + 1, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                return 1;
            }
        }
        else if (typebonus == 2)
        {
            c_enter += 100;
            if (x - 1 < 0 || x + 1 >= GM.numberColumn || y - 1 < 0 || y + 1 >= GM.numberRow)
                return -1;
            if (board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie ||
                board[x - 1, y - 1] == null || board[x - 1, y - 1].isDie || board[x - 1, y + 1] == null || board[x - 1, y + 1].isDie ||
                board[x + 1, y - 1] == null || board[x + 1, y - 1].isDie || board[x + 1, y + 1] == null || board[x + 1, y + 1].isDie)
                return -1;
            if (board[x, y].type == c_enter && board[x, y - 1].type == c_enter && board[x, y + 1].type == c_enter &&
                board[x - 1, y - 1].type == c_enter && board[x - 1, y + 1].type == c_enter &&
                board[x + 1, y - 1].type == c_enter && board[x + 1, y + 1].type == c_enter)
            {
                board[x, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                board[x - 1, y - 1].isScored = true;
                board[x - 1, y + 1].isScored = true;
                board[x + 1, y - 1].isScored = true;
                board[x + 1, y + 1].isScored = true;
                return 2;
            }
        }
        else if (typebonus == 3)
        {
            c_enter += 100;
            if (x - 1 < 0 || x + 1 >= GM.numberColumn || y - 1 < 0 || y + 1 >= GM.numberRow)
                return -1;
            if (board[x - 1, y] == null || board[x - 1, y].isDie || board[x + 1, y] == null || board[x + 1, y].isDie ||
                board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie)
                return -1;
            if (board[x, y].type == c_enter && board[x - 1, y].type == c_enter && board[x + 1, y].type == c_enter &&
                board[x, y - 1].type == c_enter && board[x, y + 1].type == c_enter)
            {
                board[x, y].isScored = true;
                board[x - 1, y].isScored = true;
                board[x + 1, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                return 1;
            }
        }
        else if (typebonus == 4)
        {
            c_enter = c_enter + 100;
            if (x - 1 < 0 || x + 1 >= GM.numberColumn || y - 1 < 0 || y + 1 >= GM.numberRow)
                return -1;
            if (board[x - 1, y - 1] == null || board[x - 1, y - 1].isDie || board[x + 1, y - 1] == null || board[x + 1, y - 1].isDie ||
                board[x + 1, y + 1] == null || board[x + 1, y + 1].isDie || board[x - 1, y + 1] == null || board[x - 1, y + 1].isDie)
                return -1;
            if (board[x, y].type == c_enter && board[x - 1, y - 1].type == c_enter && board[x + 1, y + 1].type == c_enter &&
                board[x + 1, y - 1].type == c_enter && board[x - 1, y + 1].type == c_enter)
                //if (board[x, y].type % 100 == c_enter && board[x - 1, y - 1].type % 100 == c_enter && board[x + 1, y + 1].type % 100 == c_enter &&
                //board[x + 1, y - 1].type % 100 == c_enter && board[x - 1, y + 1].type % 100 == c_enter)
            {
                board[x, y].isScored = true;
                board[x - 1, y + 1].isScored = true;
                board[x + 1, y - 1].isScored = true;
                board[x - 1, y - 1].isScored = true;
                board[x + 1, y + 1].isScored = true;
                return 1;
            }
        }
        else if (typebonus == 5)
        {
            c_enter += 100;
            if (x - 1 < 0 || x + 1 >= GM.numberColumn || y - 1 < 0 || y + 1 >= GM.numberRow)
                return -1;
            if (board[x - 1, y] == null || board[x - 1, y].isDie || board[x + 1, y] == null || board[x + 1, y].isDie ||
                board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie)
                return -1;
            if (board[x - 1, y].type == c_enter && board[x + 1, y].type == c_enter &&
                board[x, y - 1].type == c_enter && board[x, y + 1].type == c_enter)
            {
                if (board[x, y] != null && !board[x, y].isDie)
                    board[x, y].isScored = true;
                board[x - 1, y].isScored = true;
                board[x + 1, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                return 1;
            }
        }
        else if (typebonus == 6)
        {
            c_enter += 100;
            c_round1 += 100;
            if (x - 1 < 0 || x + 1 >= GM.numberColumn || y - 1 < 0 || y + 1 >= GM.numberRow)
                return -1;
            if (board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie ||
                board[x - 1, y] == null || board[x - 1, y].isDie || board[x + 1, y] == null || board[x + 1, y].isDie ||
                board[x - 1, y - 1] == null || board[x - 1, y - 1].isDie || board[x - 1, y + 1] == null || board[x - 1, y + 1].isDie ||
                board[x + 1, y - 1] == null || board[x + 1, y - 1].isDie || board[x + 1, y + 1] == null || board[x + 1, y + 1].isDie)
                return -1;
            if (board[x, y].type == c_enter && board[x, y - 1].type == c_round1 && board[x, y + 1].type == c_round1 &&
                board[x - 1, y].type == c_round1 && board[x + 1, y].type == c_round1 &&
                board[x - 1, y - 1].type == c_round1 && board[x - 1, y + 1].type == c_round1 &&
                board[x + 1, y - 1].type == c_round1 && board[x + 1, y + 1].type == c_round1)
            {
                board[x, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                board[x - 1, y - 1].isScored = true;
                board[x - 1, y + 1].isScored = true;
                board[x + 1, y - 1].isScored = true;
                board[x + 1, y + 1].isScored = true;
                board[x - 1, y].isScored = true;
                board[x + 1, y].isScored = true;
                return 2;
            }
        }
        else if (typebonus == 7)
        {
            c_enter += 100;
            if (x - 1 < 0 || x + 1 >= GM.numberColumn || y - 1 < 0 || y + 1 >= GM.numberRow)
                return -1;
            if (board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie ||
                board[x - 1, y] == null || board[x - 1, y].isDie || board[x + 1, y] == null || board[x + 1, y].isDie ||
                board[x - 1, y - 1] == null || board[x - 1, y - 1].isDie || board[x - 1, y + 1] == null || board[x - 1, y + 1].isDie ||
                board[x + 1, y - 1] == null || board[x + 1, y - 1].isDie || board[x + 1, y + 1] == null || board[x + 1, y + 1].isDie)
                return -1;
            if (board[x, y - 1].type == c_enter && board[x, y + 1].type == c_enter &&
                board[x - 1, y].type == c_enter && board[x + 1, y].type == c_enter &&
                board[x - 1, y - 1].type == c_enter && board[x - 1, y + 1].type == c_enter &&
                board[x + 1, y - 1].type == c_enter && board[x + 1, y + 1].type == c_enter)
            {
                if (board[x, y] != null && !board[x, y].isDie)
                    board[x, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                board[x - 1, y - 1].isScored = true;
                board[x - 1, y + 1].isScored = true;
                board[x + 1, y - 1].isScored = true;
                board[x + 1, y + 1].isScored = true;
                board[x - 1, y].isScored = true;
                board[x + 1, y].isScored = true;
                return 2;
            }
        }
        else if (typebonus == 8)
        {
            c_enter += 100;
            if (x - 1 < 0 || x + 1 >= GM.numberColumn || y - 1 < 0 || y + 1 >= GM.numberRow)
                return -1;
            if (board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie ||
                board[x - 1, y] == null || board[x - 1, y].isDie || board[x + 1, y] == null || board[x + 1, y].isDie ||
                board[x - 1, y - 1] == null || board[x - 1, y - 1].isDie || board[x - 1, y + 1] == null || board[x - 1, y + 1].isDie ||
                board[x + 1, y - 1] == null || board[x + 1, y - 1].isDie || board[x + 1, y + 1] == null || board[x + 1, y + 1].isDie)
                return -1;
            if (board[x, y - 1].type == c_enter && board[x, y + 1].type == c_enter &&
                board[x - 1, y].type == c_enter && board[x + 1, y].type == c_enter &&
                board[x - 1, y - 1].type == c_enter && board[x - 1, y + 1].type == c_enter &&
                board[x + 1, y - 1].type == c_enter && board[x + 1, y + 1].type == c_enter)
            {
                if (board[x, y] != null && !board[x, y].isDie)
                    board[x, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                board[x - 1, y - 1].isScored = true;
                board[x - 1, y + 1].isScored = true;
                board[x + 1, y - 1].isScored = true;
                board[x + 1, y + 1].isScored = true;
                board[x - 1, y].isScored = true;
                board[x + 1, y].isScored = true;
                return 2;
            }
        }




        else if (typebonus == 50)
        {
            c_round1 += 100;
            c_enter += 100;
            if (x - 2 < 0 || x + 2 >= GM.numberColumn || y - 2 < 0 || y + 2 >= GM.numberRow)
                return -1;
            if (board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie ||
                board[x - 1, y] == null || board[x - 1, y].isDie || board[x + 1, y] == null || board[x + 1, y].isDie ||
                board[x, y - 2] == null || board[x, y - 2].isDie || board[x, y + 2] == null || board[x, y + 2].isDie ||
                board[x - 2, y] == null || board[x - 2, y].isDie || board[x + 2, y] == null || board[x + 2, y].isDie)
                return -1;
            if (board[x,y].type % 100 == 10 + c_round2 &&
                board[x, y - 1].type == c_round1 && board[x, y + 1].type == c_round1 &&
                board[x - 1, y].type == c_round1 && board[x + 1, y].type == c_round1 &&
                board[x, y - 2].type == c_enter && board[x, y + 2].type == c_enter &&
                board[x - 2, y].type == c_enter && board[x + 2, y].type == c_enter)
            {
                board[x, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                board[x - 1, y].isScored = true;
                board[x + 1, y].isScored = true;
                board[x, y - 2].isScored = true;
                board[x, y + 2].isScored = true;
                board[x + 2, y].isScored = true;
                board[x - 2, y].isScored = true;
                
                return 2;
            }
        }
        else if (typebonus == 51)
        {
            c_enter += 100;
            if (x - 2 < 0 || x + 2 >= GM.numberColumn || y - 2 < 0 || y + 2 >= GM.numberRow)
                return -1;
            if (board[x - 1, y - 1] == null || board[x - 1, y - 1].isDie || board[x + 1, y + 1] == null || board[x + 1, y + 1].isDie ||
                board[x - 1, y + 1] == null || board[x - 1, y + 1].isDie || board[x + 1, y - 1] == null || board[x + 1, y- 1].isDie ||
                board[x - 2, y - 2] == null || board[x - 2, y - 2].isDie || board[x + 2, y + 2] == null || board[x + 2, y + 2].isDie ||
                board[x - 2, y + 2] == null || board[x - 2, y + 2].isDie || board[x + 2, y - 2] == null || board[x + 2, y - 2].isDie)
                return -1;
            if (board[x, y].type % 100 == 10 + c_round2 &&
                board[x - 1, y - 1].type == c_enter && board[x + 1, y + 1].type == c_enter &&
                board[x - 1, y + 1].type == c_enter && board[x + 1, y - 1].type == c_enter &&
                board[x - 2, y - 2].type == c_enter && board[x + 2, y + 2].type == c_enter &&
                board[x - 2, y + 2].type == c_enter && board[x + 2, y - 2].type == c_enter)
            {
                board[x, y].isScored = true;
                board[x - 1, y - 1].isScored = true;
                board[x + 1, y + 1].isScored = true;
                board[x - 1, y + 1].isScored = true;
                board[x + 1, y - 1].isScored = true;
                board[x - 2, y - 2].isScored = true;
                board[x + 2, y + 2].isScored = true;
                board[x + 2, y - 2].isScored = true;
                board[x - 2, y + 2].isScored = true;

                return 2;
            }
        }
        else if (typebonus == 52)
        {
            c_enter += 100;
            if (x - 2 < 0 || x + 2 >= GM.numberColumn || y - 2 < 0 || y + 2 >= GM.numberRow)
                return -1;
            if (board[x - 1, y - 1] == null || board[x - 1, y - 1].isDie || board[x + 1, y + 1] == null || board[x + 1, y + 1].isDie ||
                board[x - 1, y + 1] == null || board[x - 1, y + 1].isDie || board[x + 1, y - 1] == null || board[x + 1, y - 1].isDie ||
                board[x - 2, y - 2] == null || board[x - 2, y - 2].isDie || board[x + 2, y + 2] == null || board[x + 2, y + 2].isDie ||
                board[x - 2, y + 2] == null || board[x - 2, y + 2].isDie || board[x + 2, y - 2] == null || board[x + 2, y - 2].isDie)
                return -1;
            if (board[x, y].type % 100 == 10 + c_round2 &&
                board[x - 1, y - 1].type == c_enter && board[x + 1, y + 1].type == c_enter &&
                board[x - 1, y + 1].type == c_enter && board[x + 1, y - 1].type == c_enter &&
                board[x - 2, y - 2].type == c_enter && board[x + 2, y + 2].type == c_enter &&
                board[x - 2, y + 2].type == c_enter && board[x + 2, y - 2].type == c_enter)
            {
                board[x, y].isScored = true;
                board[x - 1, y - 1].isScored = true;
                board[x + 1, y + 1].isScored = true;
                board[x - 1, y + 1].isScored = true;
                board[x + 1, y - 1].isScored = true;
                board[x - 2, y - 2].isScored = true;
                board[x + 2, y + 2].isScored = true;
                board[x + 2, y - 2].isScored = true;
                board[x - 2, y + 2].isScored = true;

                return 2;
            }
        }



        else if (typebonus == 70)
        {
            c_enter += 100;
            c_round1 += 100;
            if (x - 2 < 0 || x + 2 >= GM.numberColumn || y - 2 < 0 || y + 2 >= GM.numberRow)
                return -1;
            if (board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie ||
                board[x - 1, y] == null || board[x - 1, y].isDie || board[x + 1, y] == null || board[x + 1, y].isDie ||
                board[x - 2, y - 2] == null || board[x - 2, y - 2].isDie || board[x + 2, y + 2] == null || board[x + 2, y + 2].isDie ||
                board[x - 2, y + 2] == null || board[x - 2, y + 2].isDie || board[x + 2, y - 2] == null || board[x + 2, y - 2].isDie ||
                board[x - 2, y - 1] == null || board[x - 2, y - 1].isDie || board[x - 1, y - 2] == null || board[x - 1, y - 2].isDie ||
                board[x - 2, y + 1] == null || board[x - 2, y + 1].isDie || board[x - 1, y + 2] == null || board[x - 1, y + 2].isDie ||
                board[x + 1, y - 2] == null || board[x + 1, y - 2].isDie || board[x + 2, y - 1] == null || board[x + 2, y - 1].isDie ||
                board[x + 1, y + 2] == null || board[x + 1, y + 2].isDie || board[x + 2, y + 1] == null || board[x + 2, y + 1].isDie)
                return -1;
            if (board[x, y].type % 100 == 10 + c_round2 &&
                board[x, y - 1].type == c_round1 && board[x, y + 1].type == c_round1 &&
                board[x - 1, y].type == c_round1 && board[x + 1, y].type == c_round1 &&
                board[x - 2, y - 2].type == c_round1 && board[x - 2, y + 2].type == c_round1 &&
                board[x + 2, y - 2].type == c_round1 && board[x + 2, y + 2].type == c_round1 &&
                board[x - 2, y - 1].type == c_enter && board[x - 1, y - 2].type == c_enter &&
                board[x - 2, y + 1].type == c_enter && board[x - 1, y + 2].type == c_enter &&
                board[x - 2, y - 1].type == c_enter && board[x - 1, y - 2].type == c_enter &&
                board[x + 2, y + 1].type == c_enter && board[x + 1, y + 2].type == c_enter)
            {
                board[x, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                board[x - 1, y].isScored = true;
                board[x + 1, y].isScored = true;
                board[x - 2, y - 2].isScored = true;
                board[x + 2, y + 2].isScored = true;
                board[x + 2, y - 2].isScored = true;
                board[x - 2, y + 2].isScored = true;

                board[x - 2, y - 1].isScored = true;
                board[x - 1, y - 2].isScored = true;
                board[x - 2, y + 1].isScored = true;
                board[x - 1, y + 2].isScored = true;
                board[x + 2, y - 1].isScored = true;
                board[x + 1, y - 2].isScored = true;
                board[x + 2, y + 1].isScored = true;
                board[x + 1, y + 2].isScored = true;

                return 2;
            }
        }
        else if (typebonus == 71)
        {
            c_enter += 100;
            c_round1 += 100;
            if (x - 2 < 0 || x + 2 >= GM.numberColumn || y - 2 < 0 || y + 2 >= GM.numberRow)
                return -1;
            if (board[x, y - 1] == null || board[x, y - 1].isDie || board[x, y + 1] == null || board[x, y + 1].isDie ||
                board[x - 1, y] == null || board[x - 1, y].isDie || board[x + 1, y] == null || board[x + 1, y].isDie ||
                board[x, y - 2] == null || board[x, y - 2].isDie || board[x + 2, y] == null || board[x + 2, y ].isDie ||
                board[x, y + 2] == null || board[x, y + 2].isDie || board[x - 2, y] == null || board[x - 2, y].isDie ||
                board[x - 1, y - 1] == null || board[x - 1, y - 1].isDie || board[x - 1, y + 1] == null || board[x - 1, y + 1].isDie ||
                board[x + 1, y + 1] == null || board[x + 1, y + 1].isDie || board[x + 1, y - 1] == null || board[x + 1, y - 1].isDie ||
                board[x - 2, y - 2] == null || board[x - 2, y - 2].isDie || board[x - 2, y + 2] == null || board[x - 2, y + 2].isDie ||
                board[x + 2, y + 2] == null || board[x + 2, y + 2].isDie || board[x + 2, y - 2] == null || board[x + 2, y - 2].isDie)
                return -1;
            if (board[x, y].type % 100 == 10 + c_round2 &&
                board[x, y - 1].type == c_enter && board[x, y + 1].type == c_enter &&
                board[x - 1, y].type == c_enter && board[x + 1, y].type == c_enter &&
                board[x, y - 2].type == c_enter && board[x, y + 2].type == c_enter &&
                board[x + 2, y].type == c_enter && board[x - 2, y].type == c_enter &&
                board[x - 1, y - 1].type == c_round1 && board[x - 1, y + 1].type == c_round1 &&
                board[x + 1, y + 1].type == c_round1 && board[x + 1, y - 1].type == c_round1 &&
                board[x - 2, y - 2].type == c_round1 && board[x - 2, y + 2].type == c_round1 &&
                board[x + 2, y + 2].type == c_round1 && board[x + 2, y - 2].type == c_round1)
            {
                board[x, y].isScored = true;
                board[x, y - 1].isScored = true;
                board[x, y + 1].isScored = true;
                board[x - 1, y].isScored = true;
                board[x + 1, y].isScored = true;
                board[x, y - 2].isScored = true;
                board[x, y + 2].isScored = true;
                board[x + 2, y].isScored = true;
                board[x - 2, y].isScored = true;

                board[x - 1, y - 1].isScored = true;
                board[x - 1, y + 1].isScored = true;
                board[x + 1, y + 1].isScored = true;
                board[x + 1, y - 1].isScored = true;
                board[x + 2, y - 2].isScored = true;
                board[x - 2, y - 2].isScored = true;
                board[x - 2, y + 2].isScored = true;
                board[x + 2, y + 2].isScored = true;

                return 2;
            }
        }
        return -1;
    }

    public void Destroy()
    {
        if (frameBG != null)
            frameBG.Destroy();
        frameBG = null;
        foreach (Image b in listball)
            b.Destroy();
        listball.Clear();
    }
}
