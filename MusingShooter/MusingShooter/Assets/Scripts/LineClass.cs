using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineClass : MonoBehaviour
{
    //������ɫ
    public Ncolor _linecolor
    {
        get;
        set;
    }
    //�����±�
    public int _lineIndex
    {
        get;
        set;
    }
    //��������ʱ��
    public double _lineStartTime
    {
        get;
        set;
    }
    //�������ʱ��
    public double _lineEndTime
    {
        get;
        set;
    }
    //����λ��
    public Vector3 _LinePosition
    {
        get;
        set;
    }
    //����洢�������¼���
    public Queue<NoteClass> notesEventPool = new Queue<NoteClass>();

    //װ������
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
