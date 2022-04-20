using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldDrop : MonoBehaviour
{
    //Note各种属性
    public NoteClass HoldClass;
    //贴图
    public Sprite[] StartSprites;
    public Sprite StartSprite;

    public Sprite[] BodySprites;
    public Sprite BodySprite;

    public Sprite[] EndSprites;
    public Sprite EndSprite;
    void Start()
    {
        //获得渲染组件
        StartSprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        BodySprite = transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
        EndSprite = transform.GetChild(2).GetComponent<SpriteRenderer>().sprite;
    }
    private void OnEnable()
    {
        ChangeTapSprites(HoldClass._noteColor);
    }

    public void ChangeTapSprites(Ncolor ncolor)
    {
        switch (ncolor)
        {
            case Ncolor.R:
                StartSprite = StartSprites[0];
                BodySprite = BodySprites[0];
                EndSprite = EndSprites[0];
                break;
            case Ncolor.G:
                StartSprite = StartSprites[1];
                BodySprite = BodySprites[1];
                EndSprite = EndSprites[1];
                break;
            case Ncolor.B:
                StartSprite = StartSprites[2];
                BodySprite = BodySprites[2];
                EndSprite = EndSprites[2];
                break;
        }

    }

}
