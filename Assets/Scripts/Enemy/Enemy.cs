using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }
    [SerializeField] float Health;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Health);
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
