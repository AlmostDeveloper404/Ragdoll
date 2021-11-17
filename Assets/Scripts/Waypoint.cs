using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Waypoint : MonoBehaviour
{
    public List<Enemy> enemiesInWaypoint = new List<Enemy>();
    [SerializeField] int WaypointIndex;


    Waypoints waypoints;

    private void Start()
    {
        waypoints = Waypoints.instance;
        SetWaypointsForEnemies();
    }

    void SetWaypointsForEnemies()
    {
        for (int i = 0; i < enemiesInWaypoint.Count; i++)
        {
            enemiesInWaypoint[i].Waypoint = this;
        }
    }

    public void RemoveFromList(Enemy enemy)
    {
        enemiesInWaypoint.Remove(enemy);
        if (enemiesInWaypoint.Count==0)
        {
            waypoints.ChangeWaypoint(WaypointIndex);
        }

    }


}
