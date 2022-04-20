using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineClass : MonoBehaviour
{
    //音轨颜色
    public Ncolor _linecolor
    {
        get;
        set;
    }
    //音轨下标
    public int _lineIndex
    {
        get;
        set;
    }
    //音轨生成时间
    public double _lineStartTime
    {
        get;
        set;
    }
    //音轨结束时间
    public double _lineEndTime
    {
        get;
        set;
    }
    //音轨位置
    public Vector3 _LinePosition
    {
        get;
        set;
    }
    //音轨存储的音符事件池
    public Queue<NoteClass> notesEventPool = new Queue<NoteClass>();

    //装填音符
    public void TakeIntoPool(GameController Manager)
    {
        foreach (var item in Manager.NoteEvent)
        {
            if (item._noteColor == _linecolor && item._LineNum == _lineIndex)
            {
                notesEventPool.Enqueue(item);
                Manager.NoteEvent.Remove(item);
            }
        }
    }
}
