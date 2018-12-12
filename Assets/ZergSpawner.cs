using UnityEngine;
using System.Collections;

public class ZergSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int countOfZergs;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < countOfZergs; i++)
            {
                var newZerg = Instantiate(prefab);
                newZerg.transform.position = new Vector3(transform.position.x+Random.Range(-5f,5f), 0.5f, transform.position.z+Random.Range(-5f, 5f));
            }
        }
    }
}
