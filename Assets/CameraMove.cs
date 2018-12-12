using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public GameObject target;
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), Time.deltaTime*speed);
    }
}
