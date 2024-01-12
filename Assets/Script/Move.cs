using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절 변수

    void Update()
    {
        // 상하좌우 키 입력을 받아 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // 주의: 이 예제는 단순한 이동 예제로, Rigidbody를 사용하지 않습니다.
        // 만약 물리적인 이동이 필요하다면 Rigidbody 컴포넌트를 사용해야 합니다.
    }
}
