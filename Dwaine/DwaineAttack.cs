using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwaineAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.GetComponent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        if (col.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

    }
}
