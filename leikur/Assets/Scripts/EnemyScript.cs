using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public Transform playerPos;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    void FixedUpdate() //snyr til spilaran
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;//snunings reikning
        transform.eulerAngles = new Vector3(0, 0, z); //snua
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")) {
                player.health--;//spilarin meidist
                Debug.Log(player.health);
                Destroy(gameObject);//ovinur hverfur eftir ad meida
        }
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        }
}

