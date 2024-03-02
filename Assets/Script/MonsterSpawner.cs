using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject MonsterPrefab;
    private GameObject Monster;
    public float spawnCooldown = 3f;
    private bool isSpawning = false; // ���� ���Ͱ� ���� ������ ���θ� Ȯ���ϴ� �÷���

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
        isSpawning = true; // ���� ������ �����ߴٰ� ǥ��
        yield return new WaitForSeconds(delay);

        // ���͸� �����ϰ� ��ġ�� �����մϴ�.
        Monster = Instantiate(MonsterPrefab) as GameObject;
        Monster.transform.parent = this.transform;
        Monster.transform.position = this.transform.position;

        isSpawning = false;
    }
}
