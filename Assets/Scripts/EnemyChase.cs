using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyChase : MonoBehaviour
{
    public float spotRadius = 10f;
    public float enemySpeed = 2;
    public float rotateSpeed = 2;
    public float distance;
    public NavMeshAgent enemy;
    [SerializeField] Transform player;
    Vector3 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(enemy.position-transform.position), rotateSpeed*Time.deltaTime);
        //decide if i want a spot radius or indefinite chase
        if(distance <= spotRadius) {
            chasePlayer();
            if(transform.position.y > 0) {
                transform.position += Vector3.down * Time.deltaTime * enemySpeed;
            }
        }
    }

    void chasePlayer() {
        enemy.SetDestination(player.position);
    }
}
