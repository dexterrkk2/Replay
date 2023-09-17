using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public float score;
    public int difficulty;
    public bool isRecording;
    public bool isReplaying;
    public static Data instance;
    public float timer;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
    public void ResetTimer()
    {
        timer = 0;
    }
}
