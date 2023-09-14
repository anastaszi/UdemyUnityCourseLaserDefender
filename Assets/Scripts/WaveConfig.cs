using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config", fileName="EnemyWaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 2f;

    public Transform GetStartingWaypoint() {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab) {
            waypoints.Add(child);
        }
        return waypoints;
    }   
    public float GetMoveSpeed() {
        return moveSpeed;
    }
}
