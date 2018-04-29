using System.Collections;
using System.Collections.Generic;
using LD41;
using UnityEngine;

public class NoteData
{
    public int key;
    public int beatIdx;
    public int duriation = 1;
}

public class Song : MonoBehaviour {
    public List<NoteData> notes;
    public float beatTime = 1000;
    public int length = 30000;


    public int GetCurrentBeat(int playingTimeInMilliSecond)
    {
        if (playingTimeInMilliSecond < 0)
            return -1;
        int currentBeat = (int)(playingTimeInMilliSecond / beatTime);
        return currentBeat;
    }
}
