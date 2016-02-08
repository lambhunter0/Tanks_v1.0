using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {

    public Transform muzzle;
    public Missile missile;
    public float msBetweenShots = 1500;
    public float muzzleVel = 12;

    float nextShotTime;

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Missile newMissile = Instantiate(missile, muzzle.position, muzzle.rotation) as Missile;
            newMissile.setSpeed(muzzleVel);
        }
    } 
}
