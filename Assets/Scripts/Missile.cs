using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public LayerMask collisionMask;
    float damage = 5;
    float speed = 12;
	
    public void setSpeed (float newSpeed)
    {
        speed = newSpeed;
    }

	// Update is called once per frame
	void Update () {
        float distance = speed * Time.deltaTime;
        CheckCollisions(distance);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

    void CheckCollisions(float distance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit collision;

        if (Physics.Raycast(ray, out collision, distance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHit(collision);
        }
    }
    //Reduce health eventually
    void OnHit (RaycastHit hit)
    {
        Damageable damageableObj = hit.collider.GetComponent<Damageable>();
        if (damageableObj != null)
        {
            damageableObj.TakeHit(damage, hit);
        }
        print(hit.collider.gameObject.name);
        GameObject.Destroy(gameObject);
    }
}
