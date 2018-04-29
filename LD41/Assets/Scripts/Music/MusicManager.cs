using System.Collections;
using LD41;
using UnityEngine;

public enum SongStatus
{
    Invalid, Idle, Playing
}
    

public class MusicManager : SingletonBehaviour<MusicManager>
{
    public Song song;
    public SongStatus songStatus;
    public long startTime;
    public int nextSpawnNoteIdx = 0;
    public int nextSpawnNoteTime = 0;
    public int nextMuteNoteIdx = 0;
    public int nextMuteNoteTime = 0;
    public int fallingTime = 3000;

    public void Init()
    {
        songStatus = SongStatus.Idle;
        nextSpawnNoteIdx = -1;
        nextMuteNoteIdx = -1;
    }

	public void Update()
	{
        if (songStatus != SongStatus.Playing)
            return;

        if (nextSpawnNoteIdx >= 0 && UIFunctions.Instance.gameStarted)
            CheckSpawn();

        //if (nextMuteNoteIdx >= 0)
            //CheckMute();
	}

    private void LoadSong(int songIdx)
    {
        if (songIdx >= MusicService.Instance.songs.Count)
        {
            Debug.LogError("Only have " + MusicService.Instance.songs.Count + " songs");
            return;
        }
        song = MusicService.Instance.songs[songIdx];
    }

	void PlaySong(int songIdx)
    {
        LoadSong(songIdx);
        startTime = TimeUtil.GetUnixTimeMilliseconds();
        nextSpawnNoteIdx = -1;
        UpdateNextSpawnNote();
        nextMuteNoteIdx = -1;
        UpdateNextMuteNote();

        songStatus = SongStatus.Playing;
        AudioManager.Instance.PlayMusic(song);
    }

    public void PlaySong(int songIdx, float delay)
    {
        StartCoroutine(DelayPlay(songIdx, delay));
    }

    private IEnumerator DelayPlay(int songIdx, float delay)
    {
        yield return new WaitForSeconds(delay);
        PlaySong(songIdx);
    }

    private void CheckSpawn()
    {
        long nowTime = TimeUtil.GetUnixTimeMilliseconds();
        long milliSecondsElapsed = nowTime - startTime;
        if (milliSecondsElapsed > nextSpawnNoteTime)
        {
            NoteSpawner.Instance.Spawn(song.notes[nextSpawnNoteIdx]);
            UpdateNextSpawnNote();
        }
    }

    private void CheckMute()
    {
        long nowTime = TimeUtil.GetUnixTimeMilliseconds();
        long milliSecondsElapsed = nowTime - startTime;
        if (milliSecondsElapsed > nextMuteNoteTime)
        {
            //NoteSpawner.Instance.Spawn(song.notes[nextSpawnNoteIdx]);
            AudioManager.Instance.ReduceMusicVolumnForSeconds(1);
            UpdateNextMuteNote();
        }
    }

    private void UpdateNextSpawnNote()
    {
        nextSpawnNoteIdx++;
        if (nextSpawnNoteIdx < song.notes.Count)
        {
            nextSpawnNoteTime = (int)(song.notes[nextSpawnNoteIdx].beatIdx * song.beatTime) - fallingTime;
        }
        else
        {
            nextSpawnNoteIdx = -1;
            nextSpawnNoteTime = -1;
        }
    }

    private void UpdateNextMuteNote()
    {
        nextMuteNoteIdx++;
        if (nextMuteNoteIdx < song.notes.Count)
        {
            nextMuteNoteTime = (int)(song.notes[nextMuteNoteIdx].beatIdx * song.beatTime);
        }
        else
        {
            nextMuteNoteIdx = -1;
            nextMuteNoteTime = -1;
        }
    }

}
