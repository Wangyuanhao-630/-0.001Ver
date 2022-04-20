using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickDrop : MonoBehaviour
{
    public NoteClass FlickClass;
    //Flick��ͼ
    public Sprite[] FlickSprites;
    public Sprite FlickSprite;
    private void Start()
    {
        //��õ�ǰ���ص���Ⱦ���,������ͼ
        FlickSprite = GetComponent<SpriteRenderer>().sprite;

    }
    private void OnEnable()
    {       
        ChangeTapSprites(FlickClass._isLeft);
    }
    //����Flick��ͼ
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
