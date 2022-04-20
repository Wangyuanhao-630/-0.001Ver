using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDrop : MonoBehaviour
{
    //Note各种属性
    public NoteClass TapClass;
    //Tap贴图
    public Sprite[] TapSprites;
    public Sprite TapSprite;
    private void Start()
    {
        //获得当前挂载的渲染组件,更换贴图
        TapSprite = GetComponent<SpriteRenderer>().sprite;
        
    }
    private void OnEnable()
    {
        ChangeTapSprites(TapClass._noteColor);
    }
    //更换Tap贴图
    public void ChangeTapSprites(Ncolor ncolor)
    {
        switch (ncolor)
        {
            case Ncolor.R:
                TapSprite = TapSprites[0];
                break;
            case Ncolor.G:
                TapSprite = TapSprites[1];
                break;
            case Ncolor.B:
                TapSprite = TapSprites[2];
                break;
        }

    }
}
