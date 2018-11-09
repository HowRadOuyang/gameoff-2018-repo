using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject shot;
    public AudioClip shootSound;

    private Transform playerPos;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start ()
    {
        playerPos = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        // 0 = left mouse; 1 = right; 2 = middle
        if (Input.GetMouseButtonDown(0))
        {
            source.PlayOneShot(shootSound, 1F);
            Instantiate(shot, playerPos.position, Quaternion.identity);
        }

    }
}
