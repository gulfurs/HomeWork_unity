using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            Destroy(this.transform.gameObject);
            Debug.Log("ypp");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
