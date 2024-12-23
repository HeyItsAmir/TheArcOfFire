using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public abstract class weapon : MonoBehaviour
{
    [SerializeField] string attachSlotTag;
    [SerializeField] float HamleRateMult = 1f;
    [SerializeField] AnimatorOverrideController overrideController;
    public abstract void Attack();
    public string GetAttachSlotTag()
    {
        return attachSlotTag;
    }
    
    public GameObject Owenr
    {
        get;
        private set;
       
    }
    public void init(GameObject owenr)
    {
        Owenr = owenr;
        UnEqupid();
    }
    public void Equpid()
    {
        gameObject.SetActive(true);
        Owenr.GetComponent<Animator>().runtimeAnimatorController = overrideController;
        Owenr.GetComponent<Animator>().SetFloat("HamleRateMult", HamleRateMult); 
    }
    public void UnEqupid()
    {
        gameObject.SetActive(false);
    }
    public void DamageObject(GameObject ObjectToDamage, float amt)
    {
        HealthBar healtC = ObjectToDamage.GetComponent<HealthBar>();
        if (healtC != null)
        {
            healtC.ChangeHealth(-amt, Owenr);
        }
    }

}
