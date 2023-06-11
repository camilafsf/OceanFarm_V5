using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform[] movePoints;
    public GameObject npcPrefab;
    public float spawnInterval = 10f;
    public float destroyDelay = 5f;


    private void Start()
    {
        InvokeRepeating("SpawnNPC", 0f, spawnInterval);
    }

    private void SpawnNPC()
    {
        GameObject npc = Instantiate(npcPrefab);
        npc.transform.position = spawnPoint.position;

        Animator npcAnimator = npc.GetComponent<Animator>();
        NPCcontroller npcController = npc.AddComponent<NPCcontroller>();
        npcController.Initialize(movePoints, npcAnimator, destroyDelay);
    }
}

