using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    //对象池
    //文件读取
   public Queue<LineClass> LineEvent = new Queue<LineClass>();
   public List<NoteClass> NoteEvent = new List<NoteClass>();


    //音轨
    Queue<LineClass> RedLinePool = new Queue<LineClass>();
    Queue<LineClass> GreenLinePool = new Queue<LineClass>();
    Queue<LineClass> BlueLinePool = new Queue<LineClass>();

    //数据
    //生成时间延迟
    public float delayTime;
    public float musicTime=135.000f;
    public float BPM=200.000f;
    //拍号
    public float Signaturenumber=4.000f;
    public float Totalbar;
    public float WaitToplay = 3.000f;
    //音符速度
    public float NoteSpeed;
    public float NoteCreatTimeOffset;

    //计时器
    public float MusicPlayingTimeVal;
    public float GuildLineCreatTimeval;

    //GameObject
    //小节线
    public GameObject GuildLine;
    //音符生成器
    public GameObject NoteCreater;
    //判定线
    public GameObject JudgmentLine;
    //音轨预制体
    public GameObject NoteLine;
    //音频源
    AudioSource MusicClip;

    // Start is called before the first frame update
    void Start()
    {
        Totalbar = BPM / 60 * musicTime / Signaturenumber;
        GuildLineCreatTimeval = -NoteCreatTimeOffset;
        MusicClip = GetComponent<AudioSource>();
        //TODO:装填音符生成线
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
        

        

        //TODO：提前生成音轨
        if (MusicPlayingTimeVal >= WaitToplay)
        {
            //TODO:游戏进行


            //生成音轨
            //CreatLine();
            //播放音乐
            

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
    //获取当前音轨信息
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
