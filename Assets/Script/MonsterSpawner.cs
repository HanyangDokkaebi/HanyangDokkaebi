using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject MonsterPrefab;
    private GameObject Monster;
    public float spawnCooldown = 3f;
    private bool isSpawning = false; // 현재 몬스터가 생성 중인지 여부를 확인하는 플래그

    private void Start()
    {
        Monster = Instantiate(MonsterPrefab) as GameObject;
        Monster.transform.parent = this.transform;
        Monster.transform.position = this.transform.position;
    }

    void Update()
    {
        if (!isSpawning && this.transform.childCount == 0)
        {
            StartCoroutine(SpawnMonsterAfterDelay(spawnCooldown));
        }
    }

    IEnumerator SpawnMonsterAfterDelay(float delay)
    {
        isSpawning = true; // 몬스터 생성을 시작했다고 표시
        yield return new WaitForSeconds(delay);

        // 몬스터를 생성하고 위치를 설정합니다.
        Monster = Instantiate(MonsterPrefab) as GameObject;
        Monster.transform.parent = this.transform;
        Monster.transform.position = this.transform.position;

        isSpawning = false;
    }
}
