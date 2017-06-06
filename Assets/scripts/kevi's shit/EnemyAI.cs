using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {

    
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

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Debug.LogError("Spieler nicht gefunden!!");
            return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

    }

    public void OnPathComplete (Path p)
    {
        Debug.Log("Pfad gefunden. Pfad fehlerhaft?" + p.error);
        return;
    }
}
