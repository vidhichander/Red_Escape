using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    #region Variables
    public GameObject sentry;
    private float minX;
    private float minY;
    private float maxX;
    private float maxY;
    #endregion

    #region Initialization
    void Start () {
        minX = -1.5f;
        maxX = 1.5f;
        minY = -0.8f;
        maxY = 0.7f;

        StartCoroutine(Spawn());
	}
    #endregion

    #region Spawn
    private IEnumerator Spawn()
    {
        bool alwaysSpawn = true;
        while (alwaysSpawn)
        {
            yield return new WaitForSeconds(1);
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (spawnPos != player.GetComponent<Transform>().position)
            {
                Instantiate(sentry, spawnPos, Quaternion.identity);
            }
        }


    }


    #endregion
}