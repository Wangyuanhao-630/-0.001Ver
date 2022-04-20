using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//音符颜色
public enum Ncolor
{
    R,
    G,
    B
}
public class NoteClass : MonoBehaviour
{
    //属性

    //音符事件开始时间（小节）
    #region 属性
    public double _NoteEventStartBar
    {
        get;
        set;
    }
    //音符事件结束时间（小节）
    public double _NoteEventEndBar
    {
        get;
        set;
    }
    //音符颜色（枚举）
    public Ncolor _noteColor
    {
        get;
        set;
    }
    //音符类型（判断Tap，hold，flick）
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
    //是否存在多压
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
    //音符存储音轨
    public int _LineNum
    {
        get;
        set;
    }
    #endregion


    //音符初始化方法；
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
