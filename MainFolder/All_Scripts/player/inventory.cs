using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    [SerializeField] weapon[] IWPs;
    [SerializeField] Transform default_WeaponSlot;
    [SerializeField] Transform[] weaponSlots;
    List<weapon> weaponList;
    int currentWeapon = -1;
    private void Start()
    {
        initializWeapon();
    }

    private void initializWeapon()
    {
        weaponList = new List<weapon>();
        foreach(weapon Weapon in IWPs)
        {
            Transform weaponSlot = default_WeaponSlot;
            foreach(Transform slot in weaponSlots)
            {
                if (slot.gameObject.tag == Weapon.GetAttachSlotTag())
                {
                    weaponSlot = slot;
                }
            }
            weapon newWeapon = Instantiate(Weapon, weaponSlot);
            newWeapon.init(gameObject);
            weaponList.Add(newWeapon);
        }
        nextWeapon();
    }

    public void nextWeapon()
    {
        int NextWeaponIndext = currentWeapon + 1;
        if(NextWeaponIndext >= weaponList.Count)
        {
            NextWeaponIndext = 0;
        }
        equipWeappon(NextWeaponIndext);
    }

    private void equipWeappon(int WeaponIndext)
    {
        if (WeaponIndext < 0 || WeaponIndext >= weaponList.Count)
            return;

        if (currentWeapon >= 0 && currentWeapon < weaponList.Count)
        {
            weaponList[currentWeapon].UnEqupid();
        }
        weaponList[WeaponIndext].Equpid();
        currentWeapon = WeaponIndext;   
    }

    internal weapon GetActiveWeapon()
    {
        return weaponList[currentWeapon];
    }
}
