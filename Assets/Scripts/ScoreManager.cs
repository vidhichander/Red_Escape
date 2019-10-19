using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager sc;
    public static ScoreManager Singleton
    {
        get
        {
            return sc;
        }
    }
    #region Editor Variables
    [SerializeField]
    [Tooltip("Region displaying score")]
    private Text m_score;
    #endregion

    #region Other Variables
    private float p_score;
    private int score;
    #endregion

    #region Initialization
    private void Awake()
    {
        p_score = 0;
        score = 0;
        sc = this;
    }
    #endregion

    #region Updates
    private void UpdateHighScore()
    {
        if (!PlayerPrefs.HasKey("HS")){
            PlayerPrefs.SetInt("HS", score);
        }
        int currentHS = PlayerPrefs.GetInt("HS");
        if (currentHS < p_score)
        {
            PlayerPrefs.SetInt("HS", score);
        }
    }

    public void AddScore(float value)
    {
        p_score += value;
        score = (int)p_score / 100;
        m_score.text = "Score: " + score.ToString().Replace("%s", p_score.ToString());
    }
    #endregion

    #region Destruction
    private void OnDestroy()
    {
        UpdateHighScore();
    }
    #endregion
}
