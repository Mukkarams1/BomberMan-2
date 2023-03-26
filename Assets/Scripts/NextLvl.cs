using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextLvl : MonoBehaviour
{
    [SerializeField] Text LvlTxt;
    public int Lvlno;
    // Start is called before the first frame update
    private void Awake()
    {
        Lvlno = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastPlayedLvl", Lvlno);
        LvlTxt.text = "Level =" + " " + Lvlno.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nextlvl();
        }
    }
    void nextlvl()
    {
        SceneManager.LoadScene(Nextlevel());
    }

    public int Nextlevel()
    {
        if(Lvlno < 20)
        {
            Lvlno += 1;
            
        }
        else
        {
            Lvlno = 0;
        }
        return Lvlno;
    }
}
