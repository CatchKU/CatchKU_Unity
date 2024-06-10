using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKU : MonoBehaviour
{
    // public float distance = 1f; // 카메라로부터의 고정 거리
    // private float angle; // 초기 회전 각도 (0 ~ 360도)

    void Start()
    {
        // angle = Random.Range(0.0f, 360.0f);
        PlaceKUObject();
    }

    void PlaceKUObject()
    {
        // 이름이 'KU'인 GameObject를 찾습니다.
        GameObject kuObject = GameObject.Find("KU");

        if (kuObject == null)
        {
            Debug.LogError("No GameObject named 'KU' found in the scene.");
            return;
        }

        Camera mainCamera = Camera.main;

        // 카메라를 기준으로 KU 오브젝트를 위치 설정
        Vector3 position = new Vector3(1, 0, -3) + mainCamera.transform.position;
        kuObject.transform.position = position;

        // // 각도를 라디안으로 변환
        // float radians = angle * Mathf.Deg2Rad;

        // // 새로운 위치 계산 (카메라 위치 + 회전된 위치)
        // Vector3 offset = new Vector3(Mathf.Cos(radians) * distance, 0, Mathf.Sin(radians) * distance);
        // kuObject.transform.position = mainCamera.transform.position + offset;


        // KU 오브젝트가 카메라를 향하게 회전
        kuObject.transform.LookAt(mainCamera.transform);
        float y = kuObject.transform.rotation.eulerAngles.y + 180;
        if (y > 360)
        {
            y -= 360;
        }
        kuObject.transform.rotation = Quaternion.Euler(0, y , 0);

        Debug.Log("KU position: " + kuObject.transform.position);
        Debug.Log("KU rotation: " + kuObject.transform.rotation.eulerAngles);
        Debug.Log("KU active: " + kuObject.activeSelf);
    }
}