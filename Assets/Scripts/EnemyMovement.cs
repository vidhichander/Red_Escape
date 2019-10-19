using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    #region Variables
    bool moving;
    float elapsedTime;
    #endregion

    #region Initialization
    void Start () {
        moving = false;
        elapsedTime = 0;
	}
    #endregion



    #region Trigger Methods
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && moving == false)
        { 
            moving = true;
            StartCoroutine(MoveEnemies(collision.transform));
        }

    }

    private IEnumerator MoveEnemies(Transform playerPos)
    {
        elapsedTime += Time.deltaTime;
        while (transform.position != playerPos.position && moving)
        { 
        transform.position = Vector3.Lerp(transform.position, playerPos.position, elapsedTime / 2);
            yield return null;
        }
    }
    #endregion
}
