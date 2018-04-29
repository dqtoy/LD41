using System.Collections;
using System.Collections.Generic;
using LD41;
using UnityEngine;

public class NoteSpawner : SingletonBehaviour<NoteSpawner> {

    //private
    [SerializeField]
    private float minX = 0.0f;
    [SerializeField]
    private float maxX = 0.0f;
    [SerializeField]
    private GameObject[] notes;    //Potential array of hazards

    public void Spawn(NoteData noteToSpawn)
    {
        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), 10.0f, 0.0f);  //Generate a spawnPosition
        string musicalNoteName = GetRandomNote();
        GameObject noteObject = ObjectPooler.Instance.SpawnFromPool(musicalNoteName, spawnPos, Vector3.zero);
        noteObject.GetComponent<MusicalNote>().Init(noteToSpawn);
        //Instantiate(notes[0], spawnPos, Quaternion.identity);  //Spawns the hazard
    }

    string GetRandomNote()
    {
        int randomIdx = Random.Range(1, 4);
        string nameString = "MusicalNote" + randomIdx.ToString();
        return nameString;
    }
}
