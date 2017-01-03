﻿using UnityEngine;


public class Bullet : MonoBehaviour {

    private Transform target;

    public GameObject impactEffect;
    public float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //hit something - prevents overshooting
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        //On hit damage enemy
        Destroy(target.gameObject);
        PointsManager.instance.AllocatePointsForHit();
        PointsManager.instance.AllocatePointsForKill(); //TODO: remove this when implementing health system for enemy

        Destroy(gameObject);
    }

}
