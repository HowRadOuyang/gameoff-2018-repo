using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    public GameObject effect;
    public AudioClip collideSound;

    private Transform playerPos;
    private Player player;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            Instantiate(effect, transform.position, Quaternion.identity);
            source.PlayOneShot(collideSound, 1F);
            player.health--;
            Debug.Log(player.health);
            Destroy(gameObject);
        }

        if (other.CompareTag("Projectile"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            source.PlayOneShot(collideSound, 1F);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
