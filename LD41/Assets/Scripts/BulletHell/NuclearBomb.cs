using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearBomb : MonoBehaviour, IPooledObject {

    public void OnObjectSpawn()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MusicalNoteDeadZone")
        {
            ObjectPooler.Instance.RecycleObject(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            PlayerMovement.Instance.LoseHealth();
            ObjectPooler.Instance.RecycleObject(gameObject);
        }
    }
}
