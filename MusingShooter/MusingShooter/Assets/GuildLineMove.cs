using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildLineMove : MonoBehaviour
{
    public GameController Manager;
    // Start is called before the first frame update
    public Vector3 Speed;
    public AudioSource AudioS;
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        AudioS = GetComponent<AudioSource>();
        Speed = new Vector3(0,0,Manager.NoteSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0,-Speed.z* Time.deltaTime *Manager.BPM/60);
        if (transform.position.z < Manager.JudgmentLine.transform.position.z)
        {
            AudioS.Play();
            Destroy(this.gameObject);
        }

    }

    
}
