using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab_VR;
    public GameObject playerPrefab_nonVR;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public GameObject settings_file;

    void Start()
    {
        bool VR = true;

        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        if (VR == true)
        {
            Debug.Log("Inserting a VR player");
            PhotonNetwork.Instantiate(playerPrefab_VR.name, randomPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("Inserting a None VR player");
            PhotonNetwork.Instantiate(playerPrefab_nonVR.name, randomPosition, Quaternion.identity);
        }
    }
}
