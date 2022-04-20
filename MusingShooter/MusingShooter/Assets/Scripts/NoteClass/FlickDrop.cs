using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickDrop : MonoBehaviour
{
    public NoteClass FlickClass;
    //Flick贴图
    public Sprite[] FlickSprites;
    public Sprite FlickSprite;
    private void Start()
    {
        //获得当前挂载的渲染组件,更换贴图
        FlickSprite = GetComponent<SpriteRenderer>().sprite;

    }
    private void OnEnable()
    {       
        ChangeTapSprites(FlickClass._isLeft);
    }
    //更换Flick贴图
    public void ChangeTapSprites(bool isLeft)
    {
        if (isLeft)
        {
            FlickSprite = FlickSprites[0];
        }
        else
        {
            FlickSprite = FlickSprites[1];
        }
    }
}
