using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public static DamageDealer instance;
    bool canDealDamage;
    List<GameObject> hasDealtDamage;
    Collider collider;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    [SerializeField] LayerMask layer;
    void Start()
    {
        instance = this; 
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }

    void Update()
    {
        //if (canDealDamage)
        //{
        //    //float Range = 3f;
        //    //Collider[] colliderArray = Physics.OverlapSphere(transform.position, Range, layer);
        //    //foreach (Collider collider in colliderArray)
        //    //{
        //    //    Debug.Log(collider);

        //    //    if (collider.TryGetComponent(out Enemy enemy))
        //    //    {
        //    //        enemy.TakeDamage(weaponDamage);

        //    //        hasDealtDamage.Add(collider.transform.gameObject);

        //    //    }
        //    //}
        //    //RaycastHit hit;


        //    //if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layer))
        //    //{
        //    //    if (hit.transform.TryGetComponent(out Enemy enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
        //    //    {
        //    //        enemy.TakeDamage(weaponDamage);

        //    //        hasDealtDamage.Add(hit.transform.gameObject);
        //    //    }
        //    //}
        //}
    }
    public void StartDealDamage()
    {
        Debug.Log("StartDeal");
        canDealDamage = true;
        collider.enabled = true;
        hasDealtDamage.Clear();
    }
    public void EndDealDamage()
    {
        canDealDamage = false;
        collider.enabled = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Akfif");
            Enemy.Instance.TakeDamage(weaponDamage);
            hasDealtDamage.Add(collision.transform.gameObject);

        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    //}
}
