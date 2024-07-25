using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] private float bounceForce = 400f;
    [SerializeField] private GameObject splitPrefab;

    AudioManager audioManager;

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) { 
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);
        audioManager.Play("Land");

        GameObject newSplit = Instantiate(splitPrefab, new Vector3(transform.position.x, other.transform.position.y + 0.19f, transform.position.z),
            transform.rotation);

        newSplit.transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f);
        newSplit.transform.parent = other.transform;

        string materialName = other.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)") { 
            
        }
        if (materialName == "UnSafe (Instance)") {
            GameManager.gameOver = true;
            audioManager.Play("GameOver");
        }
        if (materialName == "LastRing (Instance)" && !GameManager.levelWin) {
            GameManager.levelWin = true;
            audioManager.Play("LevelWin");
        }
    }
}
