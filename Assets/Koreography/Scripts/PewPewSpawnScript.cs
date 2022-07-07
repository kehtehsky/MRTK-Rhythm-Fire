using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class PewPewSpawnScript : MonoBehaviour
{
    public GameObject PrefabToSpawn;
    public float speed = 1200;

    

    public void Spawn(MixedRealityPointerEventData eventData)
    {

        Vector3 zeropoint = new Vector3(0, 0, 0);
        //spawnPosition.transform.position

        var result = eventData.Pointer.Result;
        GameObject projectile = Instantiate(PrefabToSpawn, zeropoint, Quaternion.LookRotation(result.Details.Point)) as GameObject;
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed); //Set the speed of the projectile by applying force to the rigidbody

        //The vector3 position of the pointer
        //Debug.Log(result.Details.Point);
    }
}
