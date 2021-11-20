using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{

    [SerializeField]Gun[] playerGuns;
    Gun currentGun;

    private void Start()
    {
        currentGun = playerGuns[0];
        for (int i = 0; i < playerGuns.Length; i++)
        {
            playerGuns[i].gameObject.SetActive(playerGuns[i].GunIndex==currentGun.GunIndex);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeGun(1);
        }
    }
    void ChangeGun(int GunIndex)
    {
        if (GunIndex==currentGun.GunIndex) 
            return;

        playerGuns[GunIndex].gameObject.SetActive(true);
        currentGun.gameObject.SetActive(false);
        currentGun = playerGuns[GunIndex];
    }
}
