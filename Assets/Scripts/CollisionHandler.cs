using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("YOU WIN!");
                break;
            case "Friendly":
                Debug.Log("Mission Start!");
                break;
            case "Fuel":
                Debug.Log("Refuel!");
                break;
            default:
                Debug.Log("DEATH!!");
                break;
        }
    }
}
