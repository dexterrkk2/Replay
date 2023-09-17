using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuScript : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public  void DifficultySelector(int value)
    {
        Data.instance.difficulty = value + 1;
    }
}
