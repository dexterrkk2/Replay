using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text text;
    public void Start()
    {
        text.text = Data.instance.score.ToString("0");
    }
}
