using UnityEngine;
using UnityEngine.EventSystems;

public class Wall : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private WallBoardController _wallBoardController;

    private Vector3 _initPos;
    private Vector3 _offset;
    public bool IsDragging = false;
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
        IsDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.parent.position = GetMouseWorldPosition() + _offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        IsDragging = false;
        transform.parent.position = _initPos;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

}
