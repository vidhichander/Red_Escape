using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    #region Editor Variables
    [SerializeField]
    [Tooltip("Region containing highscore field")]
    private Text m_highscore;
    #endregion

    #region Private Variables
    private string p_hscore;
    #endregion

    #region Initialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        p_hscore = m_highscore.text;
        m_highscore.text = "Highscore: 0";
    }

    private void Start()
    {
        UpdateHighScore();
    }
    #endregion

    #region Highscore methods
    private void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("HS"))
        {
            m_highscore.text = p_hscore.Replace("%s", PlayerPrefs.GetInt("HS").ToString());
        }
        else
        {
            PlayerPrefs.SetInt("HS", 0);
            m_highscore.text = p_hscore.Replace("%s", "0");
        }
    }
    #endregion

    #region General Button Methods
    public void PlayArena()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HS", 0);
        m_highscore.text = p_hscore.Replace("%s", "0");
    }
    #endregion

}
