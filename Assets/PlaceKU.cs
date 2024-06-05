using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKU : MonoBehaviour
{
    void Start()
    {
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
        Vector3 position = new Vector3(0, 0, 0) + mainCamera.transform.position;
        kuObject.transform.position = position;

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
