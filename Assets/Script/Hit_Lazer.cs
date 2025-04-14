using System.Data;
using UnityEngine;

public class Hit_Lazer : MonoBehaviour
{
    float Speed = 50f;
    Vector2 MousePos;
    Transform tr;
    Vector3 dir;

    float angle;
    Vector3 dirNo;


    void Start()
    {

        tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        Vector3 Pos = new Vector3(MousePos.x, MousePos.y, 0);
        dir = Pos - tr.position; //마우스 - 플레이어 포지션 빼면 마우스를 바라보는 벡터

        //바라보는 각도구하기
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


        //normalized 단위벡터
        dirNo = new Vector3(dir.x, dir.y, 0).normalized;

        Destroy(gameObject, 4f);
    }


    void Update()
    {

        // 회전에는 Quaternion(사원수)을 사용하는 것이 좋음
        // 이유: 1. Gimbal Lock 방지
        // - 오일러 각도(Euler Angle) 방식은 특정 회전 각도에서 축이 겹치며 회전이 막히는 문제가 있음
        // - 예: X축을 90도 돌리면 Y, Z축이 겹쳐서 정상 회전 안 됨
        //
        // 2. 부드러운 회전 처리 (Interpolation)
        // - Quaternion은 회전을 자연스럽고 매끄럽게 이어주는 Lerp/Slerp이 가능
        //
        // 3. 안정적인 연산
        // - Quaternion은 축 겹침, 값 튐 등의 문제가 적고 수학적으로 더 안전함


        //회전적용
        transform.rotation = Quaternion.Euler(0f, 0f, angle);


        //이동
        transform.position += dirNo * Speed * Time.deltaTime;
    }
}