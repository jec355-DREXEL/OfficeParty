using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyBazooka : MonoBehaviour {

    public float shootForce;
    public float fireTime = .33f;
    public float projectileLifetime = 5f;
    public Transform muzzlePoint;
    public GameObject projectile;


    private float timeToFire;

    // Use this for initialization
    void Start()
    {
        timeToFire = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = transform.parent.gameObject;
        if (obj.GetComponent<TrackingSys>().lockedOn)
        {
            timeToFire -= Time.deltaTime;

            if (timeToFire <= 0f)
            {
                GameObject currProjectile = (GameObject)Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);
                currProjectile.GetComponent<Rigidbody>().AddForce(muzzlePoint.up * shootForce);
                Destroy(currProjectile, projectileLifetime);
                timeToFire = fireTime;
            }
        }

    }
}
