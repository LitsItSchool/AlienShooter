using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zergRush : MonoBehaviour
{
    public enum EnemyMode
    {
        FOLLOW,
        WANDERING,
        PATROL,
    }
    // Use this for initialization
    public GameObject target;
    public float speed;
    public EnemyMode enemyMode;
    private Vector3 startPoint;
    private Vector3 wanderingPoint;


    private float attackDistance = 15f;
    private float minXValue = 0f;
    private float maxXValue = 15f;
    private float minZValue = 0f;
    private float maxZValue = 15f;
    public Transform[] patrolPoints;
    private int currentPoint=0;
    void Start()
    {
        target = GameObject.Find("Player");
        startPoint = transform.position;
        wanderingPoint = new Vector3(Random.Range(minXValue, maxXValue), 0.5f, Random.Range(minZValue, maxZValue));
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyMode)
        {
            case EnemyMode.FOLLOW:
                if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), Time.deltaTime * speed);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPoint.x, transform.position.y, startPoint.z), Time.deltaTime * speed);
                }
                break;
            case EnemyMode.WANDERING:
                if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), Time.deltaTime * speed);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(wanderingPoint.x, transform.position.y, wanderingPoint.z), Time.deltaTime * speed);
                    if (Vector3.Distance(transform.position, wanderingPoint) < 1)
                    {
                        wanderingPoint = new Vector3(Random.Range(minXValue, maxXValue), 0.5f, Random.Range(minZValue, maxZValue));
                    }
                }
                break;
            case EnemyMode.PATROL:
                if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), Time.deltaTime * speed);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(patrolPoints[currentPoint].position.x, transform.position.y, patrolPoints[currentPoint].position.z), Time.deltaTime * speed);
                    if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 1)
                    {
                        currentPoint++;

                        if (currentPoint >= patrolPoints.Length)
                        {
                            currentPoint = 0;
                        }
                    }
                }
                break;
            default:
                break;
        }

    }
}
