using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    GameObject enemy;

    private void Update()
    {
        if (AreEnemiesDead())
        {
            print("Enemies have been created!");
            CreateEnemies();
        }
    }

    public void CreateEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject _enemy = Instantiate(enemy, child.transform.position, Quaternion.identity) as GameObject;
            _enemy.transform.parent = child;
        }

        Transform availablePosition = NextAvailablePosition();

        if (availablePosition)
        {
            GameObject _enemy = Instantiate(enemy, availablePosition.transform.position, Quaternion.identity) as GameObject;
            _enemy.transform.parent = availablePosition;
        }

    }

    Transform NextAvailablePosition()
    {
        foreach (Transform positionOfChildren in transform)
        {
            if (positionOfChildren.childCount == 0)
            {
                print("Empty space!");
                return positionOfChildren;
            }
        }
        return null;
    }

    bool AreEnemiesDead()
    {
        foreach(Transform positionOfChildren in transform)
        {
            if(positionOfChildren.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

}
