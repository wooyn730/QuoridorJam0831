using UnityEngine;
using UnityEngine.EventSystems;

public class Wall : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // 판에서 벽을 드래그하면 벽이 따라온다
    // 드롭하면 벽은 항상 원래 위치로 돌아간다
    // 적절한 위치였다면 벽은 해당 위치에 복사된다.

    private Vector3 offset;
    //private GameObject clonedObject;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // clonedObject = Instantiate(gameObject, transform.position, transform.rotation);
        Debug.Log("시작이염");
        offset = transform.parent.position - GetMouseWorldPosition();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.parent.position = GetMouseWorldPosition() + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    private Vector3 GetMouseWorldPosition()
    {
        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

}
