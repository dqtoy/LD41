using System.Collections;
using System.Collections.Generic;
using LD41;
using UnityEngine;

public class BulletHellManager : SingletonBehaviour<BulletHellManager> {

    public List<Transform> emitterRoot_Moving;
    public List<Transform> emitterRoot_Fixed;


    public UnityEngine.Events.UnityAction delayedCallback;


    private void Start()
    {
        //delayedCallback += PlayPattern1;
        //BulletHellUtil.CallFunctionAfterTime(1, delayedCallback);
    }

    public void StartDestroying()
    {
        StartCoroutine(StartDestroyingCoroutine());
    }

    private IEnumerator StartDestroyingCoroutine()
    {
        yield return new WaitForSeconds(15);

        int firstRound = 5;
        for (int i = 0; i < firstRound; i++)
        {
            if (UIFunctions.Instance.gameStarted)
                yield return null;
            
            int randomHellIdx = Random.Range(1, 12);
            switch(randomHellIdx)
            {
                case 1:
                    PlayPattern1();
                    break;
                case 2:
                    PlayPattern2();
                    break;
                case 3:
                    PlayPattern3();
                    break;
                case 4:
                    PlayPattern4();
                    break;
                case 5:
                    PlayPattern5();
                    break;
                case 6:
                    PlayPattern6();
                    break;
                case 7:
                    PlayPattern7();
                    break;
                case 8:
                    PlayPattern8();
                    break;
                case 9:
                    PlayPattern9();
                    break;
                case 10:
                    PlayPattern10();
                    break;
                case 11:
                    PlayPattern11();
                    break;
                case 12:
                    PlayPattern12();
                    break;
            }
            yield return new WaitForSeconds(8);
        }


        int secondRound = 999;
        for (int i = 0; i < secondRound; i++)
        {
            if (UIFunctions.Instance.gameStarted)
                yield return null;
            
            int randomHellIdx = Random.Range(1, 12);
            switch (randomHellIdx)
            {
                case 1:
                    PlayPattern1();
                    break;
                case 2:
                    PlayPattern2();
                    break;
                case 3:
                    PlayPattern3();
                    break;
                case 4:
                    PlayPattern4();
                    break;
                case 5:
                    PlayPattern5();
                    break;
                case 6:
                    PlayPattern6();
                    break;
                case 7:
                    PlayPattern7();
                    break;
                case 8:
                    PlayPattern8();
                    break;
                case 9:
                    PlayPattern9();
                    break;
                case 10:
                    PlayPattern10();
                    break;
                case 11:
                    PlayPattern11();
                    break;
                case 12:
                    PlayPattern12();
                    break;
            }
            yield return new WaitForSeconds(2);
        }

    }

    public void PlayPattern1()
    {
        Transform emitter = GetRandomMovingEmitter();
        BulletHellService.Instance.PlayPattern1(emitter);
    }
    public void PlayPattern2()
    {
        Transform emitter = GetRandomFixedEmitter();
        BulletHellService.Instance.PlayPattern1(emitter);
    }
    public void PlayPattern3()
    {
        Transform emitter = GetRandomMovingEmitter();
        BulletHellService.Instance.PlayPattern2(emitter);
    }
    public void PlayPattern4()
    {
        Transform emitter = GetRandomFixedEmitter();
        BulletHellService.Instance.PlayPattern2(emitter);
    }
    public void PlayPattern5()
    {
        Transform emitter = GetRandomMovingEmitter();
        BulletHellService.Instance.PlayPattern3(emitter);
    }
    public void PlayPattern6()
    {
        Transform emitter = GetRandomFixedEmitter();
        BulletHellService.Instance.PlayPattern3(emitter);
    }

    public void PlayPattern7()
    {
        Transform emitter = GetRandomMovingEmitter();
        BulletHellService.Instance.PlayPattern4(emitter);
    }
    public void PlayPattern8()
    {
        Transform emitter = GetRandomFixedEmitter();
        BulletHellService.Instance.PlayPattern4(emitter);
    }
    public void PlayPattern9()
    {
        Transform emitter = GetRandomMovingEmitter();
        BulletHellService.Instance.PlayPattern5(emitter);
    }
    public void PlayPattern10()
    {
        Transform emitter = GetRandomFixedEmitter();
        BulletHellService.Instance.PlayPattern5(emitter);
    }
    public void PlayPattern11()
    {
        Transform emitter = GetRandomMovingEmitter();
        BulletHellService.Instance.PlayPattern6(emitter);
    }
    public void PlayPattern12()
    {
        Transform emitter = GetRandomFixedEmitter();
        BulletHellService.Instance.PlayPattern6(emitter);
    }


    private Transform GetRandomMovingEmitter()
    {
        int randomIdx = Random.Range(0, emitterRoot_Moving.Count - 1);
        return emitterRoot_Moving[randomIdx];
    }

    private Transform GetRandomFixedEmitter()
    {
        int randomIdx = Random.Range(0, emitterRoot_Fixed.Count - 1);
        return emitterRoot_Fixed[randomIdx];
    }


}
