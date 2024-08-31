using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BoardController _boardController;

    public void Move(Vector2 pos)
    {
        // ���� ������ �� �˰��־�� ��?
        transform.SetParent(_boardController._squares[(int)pos.y, (int)pos.x].transform);
        transform.localPosition = new Vector3(0, 0, 0);
    }
}