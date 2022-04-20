using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConreoller : MonoBehaviour
{
    public GameController Manager;
    public LineClass ThisLine;
    public Transform _Body;
    public Transform _Start;
    public Transform _End;
    
    
    //音符池
    public Stack<TapDrop> TapPool = new Stack<TapDrop>();
    public Stack<HoldDrop> HoldPool = new Stack<HoldDrop>();
    public Stack<FlickDrop> FlickPool = new Stack<FlickDrop>();
    //音符预制体
    public TapDrop Tap;
    public HoldDrop Hold;
    public FlickDrop Flick;


    //音轨精灵
    public Sprite[] lineSprites;
   
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
        //替换精灵
        #region
        if (ThisLine._linecolor == Ncolor.R)
        {
            GetComponent<SpriteRenderer>().sprite = lineSprites[0];
        }
        else if (ThisLine._linecolor == Ncolor.G)
        {
            GetComponent<SpriteRenderer>().sprite = lineSprites[1];
        }
        else if(ThisLine._linecolor == Ncolor.B)
        {
            GetComponent<SpriteRenderer>().sprite = lineSprites[2];
        }
        #endregion
        //装填
        ThisLine.TakeIntoPool(Manager);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //在音轨上生成音符
    public void CreatNewNote(float Timeval)
    {
        while (ThisLine. notesEventPool.Count > 0)
        {
            //到达生成时刻
            if (ThisLine.notesEventPool.Peek()._NoteEventStartBar+Manager.delayTime == Timeval)
            {
                //判断生成的是什么音符
                if (ThisLine.notesEventPool.Peek()._isTap) GetFreshTap();
                if (ThisLine.notesEventPool.Peek()._isHold) GetFreshHold();
                if (ThisLine.notesEventPool.Peek()._isFlick) GetFreshFlick(
                    ThisLine.notesEventPool.Peek()._isLeft);
            }
        }
    }
    //获取音符方法
    //Tap
    public TapDrop GetFreshTap()
    {
        TapDrop Tobj;
        if (TapPool.Count > 0)
        {
            Tobj = TapPool.Pop();
        }
        else
        {
            Tobj = Instantiate(Tap);
        }
        //音符的位置
        Tobj.gameObject.transform.position = ThisLine. _LinePosition;
        Tobj.gameObject.SetActive(true);
        Tobj.enabled = true;
        Tobj.TapClass._noteColor = ThisLine._linecolor;

        return Tobj;
    }
    //hold
    public HoldDrop GetFreshHold()
    {
        HoldDrop Hobj;
        if (HoldPool.Count > 0)
        {
            Hobj = HoldPool.Pop();
        }
        else
        {
            Hobj = Instantiate(Hold);
        }
        //音符的位置
        Hobj.HoldClass._noteColor = ThisLine._linecolor;
        Hobj.gameObject.transform.position = ThisLine._LinePosition;
        Hobj.gameObject.SetActive(true);
        Hobj.enabled = true;


        return Hobj;
    }
    //Flick
    public FlickDrop GetFreshFlick(bool isleft)
    {
        FlickDrop Hobj;
        if (HoldPool.Count > 0)
        {
            Hobj = FlickPool.Pop();
        }
        else
        {
            Hobj = Instantiate(Flick);
        }
        //音符的位置
        Hobj.FlickClass._isLeft = isleft;
        Hobj.gameObject.transform.position = ThisLine._LinePosition;
        Hobj.gameObject.SetActive(true);
        Hobj.enabled = true;

        return Hobj;
    }
}
