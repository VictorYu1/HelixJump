using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour {

    public GameObject[] rings;

    public int noOfRings = 10;
    public float ringDistance = 5f;
    float yPos;

    private void Start() {
        noOfRings = GameManager.CurrentLevelIndex + 5;

        for (int i = 0; i < noOfRings; i++) {
            if (i == 0) {
                // Spawn the first ring
                SpawnRings(0);
            } else { 
                // Spawn the middle rings except the 0, the last one
                SpawnRings(Random.Range(1, rings.Length - 1));
            }
        }
        // Last ring spawn
        SpawnRings(rings.Length - 1);
    }

    private void SpawnRings(int index) { 
        GameObject newRing = Instantiate(rings[index], new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity);
        yPos -= ringDistance;
        newRing.transform.parent = transform;
    }
}
