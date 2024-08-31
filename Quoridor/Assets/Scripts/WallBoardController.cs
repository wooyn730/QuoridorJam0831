using UnityEngine;

public class WallBoardController : MonoBehaviour
{
    // 8*8개의 점을 가지고 있음
    [SerializeField] private Transform _wallBoard;
    [SerializeField] private GameObject[,] _points = new GameObject[8, 8];
    
    void Start()
    {
        AllocatePoints();
    }

    // 마우스를 드래그앤드롭하면 모든 포인트들을 순회함
    // 해당 포인트와 특정 거리 이내라면 스냅
    // 아니면 그냥 행동이 취소됨

    private void AllocatePoints()
    {
        int size = 8;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                _points[i, j] = _wallBoard.GetChild(i * size + j).gameObject;
                // _points[i, j].Pos = new Vector2(j, i);
            }
        }
    }
}
