using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBreakScript : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Hand"))
        {
            Debug.Log("hand hit");
            GameObject destroyedGlass = Instantiate(prefab, transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
