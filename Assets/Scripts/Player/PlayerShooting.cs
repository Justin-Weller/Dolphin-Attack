using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnLoc;
    private bool canShoot = true;
    public float shotCooldown = 0.3f;
    private float nextShotTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Only allow the weapon to be used if the game is unpaused. Prevents spawning projectiles while paused.
		if(!PauseMenuController.isPaused)
        {
            shoot();
        }
    }
    
    // Handles the logic for shooting the weapon
    private void shoot()
    {
        // If left clicked and the shot isn't on cooldown
        if(Input.GetMouseButton(0) && canShoot == true)
        {
            // Gets the direction between the mouse and gun
            Vector2 bulletDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletSpawnLoc.position;

            float angle = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Instantiate(bullet, bulletSpawnLoc.position, rotation);
            nextShotTime = Time.time + shotCooldown;
            canShoot = false;
        }

        // If the shot cooldown is over
        if(Time.time > nextShotTime)
        {
            canShoot = true;
        }
    }
}
