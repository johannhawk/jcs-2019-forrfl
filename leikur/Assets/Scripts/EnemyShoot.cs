using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectsWithTag("Player").transform;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);//hreyfa naer
        } else if(Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
            transform.position = this.transform.position; //vera kjurr
        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }

    void FixedUpdate() //snyr til spilaran
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;//snunings reikning
        transform.eulerAngles = new Vector3(0, 0, z); //snua
    }


}
