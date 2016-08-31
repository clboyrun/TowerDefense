using UnityEngine;
using System.Collections;

public class Baddie : MonoBehaviour {

    public Vector3 targetPosition;

    private Seeker seeker;
    private CharacterController controller;

    public Pathfinding.Path path;

    public float speed = 100;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

	// Use this for initialization
	void Start () {
        seeker = GetComponent<Seeker>();
        controller = GetComponent<CharacterController>();

        seeker.StartPath(transform.position, targetPosition, OnPathComplete);
	}

    public void OnPathComplete(Pathfinding.Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;

            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null)
        {
            //We have no path to move after yet
            Debug.Log("Path is null");
            return;
        }

        Move();
    }

    void Move()
    {
        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("End Of Path Reached");
            return;
        }

        //Debug.Log (path.vectorPath [currentWaypoint]);
        Vector3 doot = path.vectorPath[currentWaypoint];
        doot.y++;
        transform.LookAt(doot);

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;
        controller.SimpleMove(dir);

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}
