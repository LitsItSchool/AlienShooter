using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 lookPoint;
    public float speed;
    public GameObject bulletPrefab;
    public Transform shootPoint;

    private void Start ()
    {
		
	}

    private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Piu");
            Shot();
        }
        Look();

        transform.LookAt(new Vector3(lookPoint.x,transform.position.y,lookPoint.z));
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x,transform.position.y,targetPosition.z), Time.deltaTime * speed);
        
    }

    private void Move()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            targetPosition = hit.point;
        }
    }

    private void Look()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            lookPoint = hit.point;
        }

    }

    public void Shot()
    {
        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = shootPoint.position;
        newBullet.transform.eulerAngles = shootPoint.eulerAngles;
        Destroy(newBullet, 2f);
    }
}
