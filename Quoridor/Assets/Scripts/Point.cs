using UnityEngine;

public class Point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("지나감!");

        if (!other.GetComponent<Wall>().IsDragging)
            Debug.Log("내려놔@");
        // 드래그중이 아니라면 무시

        // 벽을 복제해서 나의 자식으로 둔다.
        // 복제해서 이 자리에 두기
    }
}
