using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBehaviour : MonoBehaviour
{
    public GameObject destroyedPrefab;
    
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
        if(collision.gameObject.CompareTag("Ground"))
        {
            GameObject deadAsset = Instantiate(destroyedPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(deadAsset, 7);
        }
    }
}
