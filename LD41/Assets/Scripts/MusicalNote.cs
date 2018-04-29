using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalNote : MonoBehaviour {

    public NoteData musicalNote;

    public void Init(NoteData note)
	{
        musicalNote = note;
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MusicalNoteDeadZone")
        {
            ObjectPooler.Instance.RecycleObject(gameObject);
        }

        if (UIFunctions.Instance.gameStarted && other.gameObject.tag == "Player")
        {
            PlayerMovement.Instance.AddHealth();
            AudioManager.Instance.PlayNote(musicalNote);
            ObjectPooler.Instance.RecycleObject(gameObject);
        }
    }
}
