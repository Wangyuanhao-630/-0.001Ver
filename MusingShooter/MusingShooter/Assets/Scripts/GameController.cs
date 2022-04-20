using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    //�����
    //�ļ���ȡ
   public Queue<LineClass> LineEvent = new Queue<LineClass>();
   public List<NoteClass> NoteEvent = new List<NoteClass>();


    //����
    Queue<LineClass> RedLinePool = new Queue<LineClass>();
    Queue<LineClass> GreenLinePool = new Queue<LineClass>();
    Queue<LineClass> BlueLinePool = new Queue<LineClass>();

    //����
    //����ʱ���ӳ�
    public float delayTime;
    public float musicTime=135.000f;
    public float BPM=200.000f;
    //�ĺ�
    public float Signaturenumber=4.000f;
    public float Totalbar;
    public float WaitToplay = 3.000f;
    //�����ٶ�
    public float NoteSpeed;
    public float NoteCreatTimeOffset;

    //��ʱ��
    public float MusicPlayingTimeVal;
    public float GuildLineCreatTimeval;

    //GameObject
    //С����
    public GameObject GuildLine;
    //����������
    public GameObject NoteCreater;
    //�ж���
    public GameObject JudgmentLine;
    //����Ԥ����
    public GameObject NoteLine;
    //��ƵԴ
    AudioSource MusicClip;

    // Start is called before the first frame update
    void Start()
    {
        Totalbar = BPM / 60 * musicTime / Signaturenumber;
        GuildLineCreatTimeval = -NoteCreatTimeOffset;
        MusicClip = GetComponent<AudioSource>();
        //TODO:װ������������
        while (LineEvent.Count != 0)
        {
            if (LineEvent.Peek()._linecolor == Ncolor.R)
            {
                RedLinePool.Enqueue(LineEvent.Dequeue());
            }
            if (LineEvent.Peek()._linecolor == Ncolor.G)
            {
                GreenLinePool.Enqueue(LineEvent.Dequeue());
            }
            if (LineEvent.Peek()._linecolor == Ncolor.B)
            {
                BlueLinePool.Enqueue(LineEvent.Dequeue());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MusicPlayingTimeVal += Time.deltaTime *  BPM/60 / (Signaturenumber-(0.007f + 0.000005f * BPM));
        

        

        //TODO����ǰ��������
        if (MusicPlayingTimeVal >= WaitToplay)
        {
            //TODO:��Ϸ����


            //��������
            //CreatLine();
            //��������
            

        }
        else
        {
            MusicClip.Play();



        }
        if (MusicPlayingTimeVal >= NoteCreatTimeOffset)
        {
            GuildLineCreatTimeval += Time.deltaTime * BPM / 60 / (Signaturenumber - (0.007f + 0.000005f * BPM));
            if (GuildLineCreatTimeval > 1 - NoteCreatTimeOffset)
            {
                Instantiate(GuildLine, new Vector3(JudgmentLine.transform.position.x
                    , JudgmentLine.transform.position.y,
                    NoteCreatTimeOffset * NoteSpeed
                    + JudgmentLine.transform.position.z)
                    , transform.rotation);
                GuildLineCreatTimeval = -NoteCreatTimeOffset;
            }
        }
    }
    //��ȡ��ǰ������Ϣ
public LineClass GetRedThisLine()
    {
        return RedLinePool.Dequeue();
    }
    public LineClass GetGreenThisLine()
    {
        return GreenLinePool.Dequeue();
    }
    public LineClass GetBlueThisLine()
    {
        return BlueLinePool.Dequeue();
    }

    public void CreatLine()
    {
        if (MusicPlayingTimeVal - RedLinePool.Peek()._lineStartTime + WaitToplay > 0)
        {
            GameObject RLine = Instantiate(NoteLine, RedLinePool.Peek()._LinePosition
                 , Quaternion.identity);
            RLine.GetComponent<LineConreoller>().ThisLine = RedLinePool.Dequeue();
        }
        if (MusicPlayingTimeVal - GreenLinePool.Peek()._lineStartTime + WaitToplay > 0)
        {
            GameObject GLine = Instantiate(NoteLine, GreenLinePool.Peek()._LinePosition
                 , Quaternion.identity);
            GLine.GetComponent<LineConreoller>().ThisLine = GreenLinePool.Dequeue();
        }
        if (MusicPlayingTimeVal - BlueLinePool.Peek()._lineStartTime + WaitToplay > 0)
        {
            GameObject GLine = Instantiate(NoteLine, BlueLinePool.Peek()._LinePosition
                 , Quaternion.identity);
            GLine.GetComponent<LineConreoller>().ThisLine = BlueLinePool.Dequeue();
        }

    }
}
