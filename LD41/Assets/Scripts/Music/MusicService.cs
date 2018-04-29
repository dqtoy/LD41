using System.Collections;
using System.Collections.Generic;
using LD41;
using UnityEngine;

public class MusicService : SingletonBehaviour<MusicService> {
    public List<Song> songs;



    //mock data
    List<int> song1_NoteKeys = new List<int>(){
        7,6,2,4,
        9,9,11,7,7,7,9,6,
        9,9,4,7,7,7,9,6,
        4,4,4,7,4,4,4,2,
        4,7,7,6,
        4,7,7,9,
        4,7,9,7,9,11,9,11,
        12,11,7,6,4,5,7,9,11,
        9,4,7,7,7,6,2,2, 
        4,4,4,7,7,7,7,9
    };
    List<int> song1_NoteBeats = new List<int>(){
        6,8,9,10,
        12,13,14,15,18,19,20,21,
        24,25,26,27,30,31,32,33,
        36,37,38,39,42,43,44,45,
        48,51,54,57,
        60,63,66,69,
        72,74,75,76,78,79,81,82,
        84,85,86,87,88,90,91,93,94,
        96,98,99,100,102,104,105,106,
        108,109,110,111,114,115,116,117
    };
    List<int> song1_NoteDurations = new List<int>(){
        1,1,1,1,1,1,1
    };

	void Start () {
        LoadSongs();
	}

    private void LoadSongs()
    {
        songs = new List<Song>();
        LoadSong1();
    }

    private void LoadSong1()
    {
        Song song = new Song();
        song.length = 107200;
        song.beatTime = (float)song.length / 125;
        List<NoteData> notes = new List<NoteData>();

        int noteLengh = song1_NoteKeys.Count;
        for (int i = 0; i < noteLengh; i++)
        {
            NoteData note = new NoteData();
            note.key = song1_NoteKeys[i];
            note.beatIdx = song1_NoteBeats[i];
            note.duriation = 1;
            notes.Add(note);
        }
        song.notes = notes;
        songs.Add(song);
    }
}
