using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject enemyprojectile;

    public Transform playerPos;
    private Player player;



    // Start is called before the first frame update
    void Start()
    {
        //playerPos = GameObject.FindGameObjectsWithTag("playerPos").transform;
        playerPos = GameObject.FindWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);//hreyfa naer
        } else if(Vector2.Distance(transform.position, playerPos.position) > stoppingDistance && Vector2.Distance(transform.position, playerPos.position) > retreatDistance) {
            transform.position = this.transform.position; //vera kjurr
        } else if(Vector2.Distance(transform.position, playerPos.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -speed * Time.deltaTime);
        }
        if(timeBtwShots <= 0)
        {
            Instantiate(enemyprojectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        if (timeBtwShots > 0) {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void FixedUpdate() //snyr til spilaran
    {
        float z = Mathf.Atan2((playerPos.transform.position.y - transform.position.y), (playerPos.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;//snunings reikning
        transform.eulerAngles = new Vector3(0, 0, z); //snua
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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
