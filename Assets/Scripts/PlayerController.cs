using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    #region Variables
    public Rigidbody2D playerRigidbody;
    private float elapsedTime;
    private bool alive;
    private float curr_score;

    [SerializeField]
    [Tooltip("Death message")]
    private Text m_death;
    #endregion

    #region Initialization
    void Start () {
        curr_score = 0;
        Cursor.lockState = CursorLockMode.Locked;
        alive = true;
        playerRigidbody = GetComponent<Rigidbody2D>();
        elapsedTime = 0;
	}
    #endregion

    #region Updates
    // Update is called once per frame
    void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (alive == true)
        {
            curr_score += Time.deltaTime;
            ScoreManager.Singleton.AddScore(curr_score);
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            playerRigidbody.velocity = movement * 2;
        }
	}
    #endregion

    #region Collision Methods
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall") {
            playerRigidbody.velocity = Vector2.zero;
        }

        if (other.gameObject.tag == "Enemy")
        {
            alive = false;
            m_death.text = "YOU DIED";
            StartCoroutine(Death());
        }
    }

    #endregion

    #region Dying method
    private IEnumerator Death()
    {
        elapsedTime = elapsedTime + Time.deltaTime;
        Color currColor = GetComponent<SpriteRenderer>().color;
        Color newColor = Color.black;
        while (currColor != newColor)
        {
            currColor = Color.Lerp(currColor, newColor, elapsedTime / 0.3f);
            GetComponent<SpriteRenderer>().color = currColor;
            yield return null;
        }
        SceneManager.LoadScene("Menu");
    }
    #endregion

}
