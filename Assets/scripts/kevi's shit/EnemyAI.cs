using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {

    bool awake = false;
    public Transform target;

    //wie oft in einer sekunde geupdatet wird
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    //berechneter Pfad
    public Path path;

    //KI Speed per second
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //max distanz von KI zu anderem wegpunkt
    public float nextWaypointDistance = 3;

    //aktueller ausgesuchter Wegpunkt
    private int currentWaypoint = 0;

    private bool searchingForPlayer = false;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        // Startet neuen pfad zum Ziel, gibt ergebnis zurück für onpathcomplete methode
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine (UpdatePath ());

    }

    IEnumerator SearchForPlayer()
    {
       GameObject search = GameObject.FindGameObjectWithTag ("Player");
       if (search == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        }
       else
        {
            target = search.transform;
            searchingForPlayer = false;
            StartCoroutine(UpdatePath());
            yield return false;
        }
    }
    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            yield return false;
        }

        // Startet neuen pfad zum Ziel, gibt ergebnis zurück für onpathcomplete methode
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete (Path p)
    {
        //Debug.Log("Pfad gefunden. Pfad fehlerhaft?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate ()
    {
        if (awake)
        {
            if (target == null)
            {
                if (!searchingForPlayer)
                {
                    searchingForPlayer = true;
                    StartCoroutine(SearchForPlayer());
                }
                return;
            }
            //TODO: Always look at player?

            if (path == null)
                return;
            if (currentWaypoint >= path.vectorPath.Count)
            {
                if (pathIsEnded)
                    return;

                //Debug.Log("Ende des Pfades erreicht?");
                pathIsEnded = true;
                return;
            }
            pathIsEnded = false;

            //weg zum nächsten wegpunkt
            Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            dir *= speed * Time.fixedDeltaTime;

            //KI Bewegung

            rb.AddForce(dir, fMode);

            float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (dist < nextWaypointDistance)
            {
                currentWaypoint++;
                return;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "BarriereRight")
        {
            awake = true;
        }
    }
}
