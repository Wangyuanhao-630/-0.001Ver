using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDrop : MonoBehaviour
{
    //Note��������
    public NoteClass TapClass;
    //Tap��ͼ
    public Sprite[] TapSprites;
    public Sprite TapSprite;
    private void Start()
    {
        //��õ�ǰ���ص���Ⱦ���,������ͼ
        TapSprite = GetComponent<SpriteRenderer>().sprite;
        
    }
    private void OnEnable()
    {
        ChangeTapSprites(TapClass._noteColor);
    }
    //����Tap��ͼ
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
