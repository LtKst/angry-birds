using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Enemy : MonoBehaviour {

    private static List<Enemy> enemyList = new List<Enemy>();

    private void OnEnable() {
        enemyList.Add(this);
    }

    private void OnDisable() {
        RemoveEnemy();
    }

    private void RemoveEnemy() {
        enemyList.Remove(this);

        if (enemyList.Count == 0) {
            GameEnd.instance.EndGame(true);
        }
    }
}
