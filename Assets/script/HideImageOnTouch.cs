using UnityEngine;

public class HideImageOnTouch : MonoBehaviour
{
    public GameObject imageObject; // 비활성화할 이미지 오브젝트
    public LayerMask touchLayer; // 터치 감지 레이어

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Screen touched at position: " + touch.position);

                // 터치 위치를 월드 좌표로 변환 (이미지 오브젝트의 z 위치를 사용)
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -Camera.main.transform.position.z));
                Debug.Log("World touch position: " + touchPosition);

                // 터치 위치 주변을 감지하여 이미지 오브젝트와 상호작용
                Collider2D hitCollider = Physics2D.OverlapPoint(touchPosition, touchLayer);
                Debug.Log("HitCollider: " + hitCollider);
                if (hitCollider != null)
                {
                    Debug.Log("Hit object: " + hitCollider.transform.name);
                    Debug.Log("ImageObject position: " + imageObject.transform.position);

                    // 터치된 오브젝트가 imageObject인지 확인
                    if (hitCollider.transform == imageObject.transform)
                    {
                        Debug.Log("Image object has been hidden.");
                        // 이미지 오브젝트 비활성화
                        imageObject.SetActive(false);
                        Application.Quit();
                    }
                }
                else
                {
                    Debug.Log("Raycast did not hit any objects.");
                }
            }
        }
    }
}