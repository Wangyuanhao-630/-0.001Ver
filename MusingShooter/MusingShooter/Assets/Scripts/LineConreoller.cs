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
    
    
    //������
    public Stack<TapDrop> TapPool = new Stack<TapDrop>();
    public Stack<HoldDrop> HoldPool = new Stack<HoldDrop>();
    public Stack<FlickDrop> FlickPool = new Stack<FlickDrop>();
    //����Ԥ����
    public TapDrop Tap;
    public HoldDrop Hold;
    public FlickDrop Flick;


    //���쾫��
    public Sprite[] lineSprites;
   
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
        //�滻����
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
        //װ��
        ThisLine.TakeIntoPool(Manager);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //����������������
    public void CreatNewNote(float Timeval)
    {
        while (ThisLine. notesEventPool.Count > 0)
        {
            //��������ʱ��
            if (ThisLine.notesEventPool.Peek()._NoteEventStartBar+Manager.delayTime == Timeval)
            {
                //�ж����ɵ���ʲô����
                if (ThisLine.notesEventPool.Peek()._isTap) GetFreshTap();
                if (ThisLine.notesEventPool.Peek()._isHold) GetFreshHold();
                if (ThisLine.notesEventPool.Peek()._isFlick) GetFreshFlick(
                    ThisLine.notesEventPool.Peek()._isLeft);
            }
        }
    }
    //��ȡ��������
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
        //������λ��
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
        //������λ��
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
        //������λ��
        Hobj.FlickClass._isLeft = isleft;
        Hobj.gameObject.transform.position = ThisLine._LinePosition;
        Hobj.gameObject.SetActive(true);
        Hobj.enabled = true;

        return Hobj;
    }
}
