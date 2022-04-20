using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ɫ
public enum Ncolor
{
    R,
    G,
    B
}
public class NoteClass : MonoBehaviour
{
    //����

    //�����¼���ʼʱ�䣨С�ڣ�
    #region ����
    public double _NoteEventStartBar
    {
        get;
        set;
    }
    //�����¼�����ʱ�䣨С�ڣ�
    public double _NoteEventEndBar
    {
        get;
        set;
    }
    //������ɫ��ö�٣�
    public Ncolor _noteColor
    {
        get;
        set;
    }
    //�������ͣ��ж�Tap��hold��flick��
    public bool _isTap
    {
        get;
        set;
    }
    public bool _isHold
    {
        get;
        set;
    }
    public bool _isFlick
    {
        get;
        set;
    }
    //�Ƿ���ڶ�ѹ
    public bool _isEach
    {
        get;
        set;
    }
    public bool _isLeft
    {
        get;
        set;
    }
    //�����洢����
    public int _LineNum
    {
        get;
        set;
    }
    #endregion


    //������ʼ��������
    //Tap
    public NoteClass (Ncolor NoteColor
        , double NoteEventStartBar
        , bool isTap, bool isHold, bool isFlick,bool isEach
        , int LineNum)
    {
        _noteColor = NoteColor;
        _NoteEventStartBar = NoteEventStartBar;
        _isTap = isTap;
        _isHold = isHold;
        _isFlick = isFlick;
        _isEach = isEach;
        _LineNum = LineNum;
    }
    //Flick
    public NoteClass(double NoteEventStartBar
        , bool isTap, bool isHold, bool isFlick,bool isLeft
        , int LineNum,Ncolor NoteColor)
    {
        _noteColor = NoteColor;
        _NoteEventStartBar = NoteEventStartBar;
        _isTap = isTap;
        _isHold = isHold;
        _isFlick = isFlick;
        _isLeft = isLeft;
        _LineNum = LineNum;
    }
    //Hold
    public NoteClass(Ncolor NoteColor
        , double NoteEventStartBar, double NoteEventEndBar
        , bool isTap, bool isHold, bool isFlick, bool isEach
        , int LineNum)
    {
        _noteColor = NoteColor;
        _NoteEventStartBar = NoteEventStartBar;
        _NoteEventEndBar = NoteEventEndBar;
        _isTap = isTap;
        _isHold = isHold;
        _isFlick = isFlick;
        _isEach = isEach;
        _LineNum = LineNum;
    }

}
