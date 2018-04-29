using System.Collections;
using System.Collections.Generic;
using LD41;
using UnityEngine;

public class CGManager : SingletonBehaviour<CGManager> {

    public List<Transform> emitterRoot_Fixed;

    public void PlayCG()
    {
        StartCoroutine(PlayCGCoroutin());
    }

    private IEnumerator PlayCGCoroutin()
    {
        yield return new WaitForSeconds(10);

        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[0].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[1].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[2].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[0].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[4].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[5].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[3].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[2].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[0].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[4].position, new Vector3(-90, -90, 0));
        ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[5].position, new Vector3(-90, -90, 0));

        yield return new WaitForSeconds(2);
        int firstRound = 1000;
        for (int i = 0; i < firstRound; i++)
        {
            int randomIdx = Random.Range(0, 6);
            ObjectPooler.Instance.SpawnFromPool("CGBomb", emitterRoot_Fixed[randomIdx].position, new Vector3(-90, -90, 0));

            int randomDelay = Random.Range(1, 5);
            yield return new WaitForSeconds(randomDelay);
        }

  

    }

}
