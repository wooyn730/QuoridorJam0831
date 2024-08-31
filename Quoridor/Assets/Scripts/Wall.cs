using UnityEngine;
using UnityEngine.EventSystems;

public class Wall : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private WallBoardController _wallBoardController;

    private Vector3 _initPos;
    private Vector3 _offset;
    //private GameObject clonedObject;

    private void Start()
    {
        _wallBoardController = FindObjectOfType<WallBoardController>();
        if (_wallBoardController == null)
            Debug.Log("_wallBoardController Missing");

        _initPos = transform.parent.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //clonedObject = Instantiate(gameObject, transform.position, transform.rotation);
        Debug.Log("시작이염");
        _offset = transform.parent.position - GetMouseWorldPosition();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.parent.position = GetMouseWorldPosition() + _offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 newPos = _wallBoardController.GetNearestPoint(transform.parent.position);
        if (newPos == new Vector3(-5000, 0, 0))
        {
            transform.parent.position = _initPos;
        }
        else
        {
            transform.parent.position = newPos;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.parent.position).z; // z값을 설정해줘야 올바르게 변환됨
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

}
