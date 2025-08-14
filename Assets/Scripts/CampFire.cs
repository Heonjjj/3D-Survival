using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;
    List<IDamageble> things =new List<IDamageble>();
    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage()
    {
        for(int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamageble damageIbe))
        {
            things.Add(damageIbe);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out IDamageble damageble))
        {
            things.Remove(damageble);
        }
    }
}
