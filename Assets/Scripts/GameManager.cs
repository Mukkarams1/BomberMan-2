using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    private int Score1 = 0;
    private int Score2 = 0;
    public Text Scoretxt;
    public Text ScoreTxt2;
    public Transform clone1;
    public Transform clone2;
    [SerializeField] GameObject pausepanel;
 
    private void Start()
    {
        
        SwitchControls();
        DualSwitchControls();
        Score1 = PlayerPrefs.GetInt("Score1");
        Score2 = PlayerPrefs.GetInt("Score2");
        pausepanel.SetActive(false);
        Scoretxt.text = Score1.ToString();
        ScoreTxt2.text = Score2.ToString();
        
    }

    public void CheckWinState()
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf) {
                aliveCount++;
            }
        }

        if (aliveCount <= 1) {
            FindObjectOfType<Admob>().loadInterstitial();
            Invoke(nameof(NewRound), 3f);
        }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void OnExitClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void OnPauseCLicked()
    {
        Time.timeScale = 0;
        pausepanel.SetActive(true);
    }
    public void OnPausepanelCLose()
    {
        Time.timeScale = 1;
        pausepanel.SetActive(false);
    }
    public void ScoreIncrement(string playername)
    {
       if(playername == "Player 1")
        {
            Score1 += 1;
            PlayerPrefs.SetInt("Score1", Score1);
            Scoretxt.text = Score1.ToString();
        }
       else if(playername == "Player 2")
        {
            Score2 += 1;
            PlayerPrefs.SetInt("Score2", Score2);
            ScoreTxt2.text = Score2.ToString();
        }
    }
    private void SwitchControls()
    {
        if (SceneManager.GetActiveScene().buildIndex != 21)
        {
            if (PlayerPrefs.GetInt("FlipControls") > 0)
            {
                Transform joystickpos = GameObject.FindGameObjectWithTag("SinglePlayerJoystick").transform;
                Transform BombBtnPos = GameObject.FindGameObjectWithTag("SinglePlayerBombBtn").transform;


                joystickpos.transform.localPosition = new Vector3(740, -124, 0);
                BombBtnPos.transform.localPosition = new Vector3(-716, -157, 0);
            }
        }
        
    }
    private void DualSwitchControls()
    {
        if(SceneManager.GetActiveScene().buildIndex == 21)
        {
            if (PlayerPrefs.GetInt("DualFlipControls") > 0)
            {
                Transform DualOnejoystickpos = GameObject.FindGameObjectWithTag("DualJoystickPlayerOne").transform;
                Transform DualOneBombBtnPos = GameObject.FindGameObjectWithTag("DualBombBtnOne").transform;

                Transform DualTwojoystickpos = GameObject.FindGameObjectWithTag("DualJoystickPlayerTwo").transform;
                Transform DualTwoBombBtnPos = GameObject.FindGameObjectWithTag("DualBombBtnTwo").transform;



                DualOnejoystickpos.transform.position = clone1.transform.position;
                DualOneBombBtnPos.transform.localPosition = new Vector3(-720, 301, 0);

                DualTwojoystickpos.transform.position = clone2.transform.position;
                DualTwoBombBtnPos.transform.localPosition = new Vector3(736, -285, 0);
            }
        }
       
    }
    
      
    
}
