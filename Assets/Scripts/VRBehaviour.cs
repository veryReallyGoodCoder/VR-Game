using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBehaviour : MonoBehaviour
{
    //prefab you want to instantiate
    public GameObject destroyedPrefab;
    public GameObject fire;

    private Vector3 startPos;

    private bool isDestoyed;

    public bool hasFire;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Debug.Log(startPos);

        isDestoyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnObject(startPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            //instantiate prefab
            GameObject deadAsset = Instantiate(destroyedPrefab, transform.position, transform.rotation);
            SpawnFire(hasFire);

            float count = 0;
            count += Time.deltaTime;
            if(count >= 7)
            {
                SpawnObject(startPos);
            }

            Destroy(this.gameObject);
            Destroy(deadAsset, 7);

            //WaitForSeconds(7);
            isDestoyed = true;
        }
    }

    private void SpawnObject(Vector3 start)
    {
        if(isDestoyed)
        {
            Debug.Log("Inactive, respwan running");

            Instantiate(gameObject, start.normalized, Quaternion.identity);
        }
    }

    private void SpawnFire(bool hasFire)
    {
        if (hasFire)
        {
            Instantiate(fire, transform.position, transform.rotation);
            Debug.Log("fire spawned");
        }
    }
}
