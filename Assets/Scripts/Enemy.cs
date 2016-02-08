using UnityEngine;
using System.Collections;
[RequireComponent (typeof(NavMeshAgent))]
public class Enemy : Alive {

    NavMeshAgent pathfinder;
    Transform target;
	// Use this for initialization
	protected override void Start () {
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator UpdatePath()
    {
        float refresh = 1; //.25f

        while (target !=  null)
        {
            Vector3 targetPos = new Vector3(target.position.x,0,target.position.z);
            if (!dead)
            {
                pathfinder.SetDestination(targetPos);
            }
            yield return new WaitForSeconds(refresh);
        }
    }
}
