using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    //BLOCK 1
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        //Cloning prefab
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); //POsition and no rotation
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}
