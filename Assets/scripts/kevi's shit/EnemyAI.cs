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
}
