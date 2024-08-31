using UnityEngine;

public class WallBoardController : MonoBehaviour
{
    // 8*8개의 점을 가지고 있음
    [SerializeField] private Vector3[,] _points = new Vector3[8, 8];
    private float _offset = 0.5f;
    
    void Start()
    {
        AllocatePoints();
    }

    public Vector3 GetNearestPoint(Vector3 position)
    {
        foreach (Vector3 point in _points)
        {
            float distance = Vector3.Distance(position, point);
            Debug.Log(distance);

            if (distance < _offset)
            {
                return point;
            }
        }

        return new Vector3(-5000, 0, 0);
    }

    private void AllocatePoints()
    {
        int size = 8;
        int gap = 105;

        Vector3 originPoint = new Vector3(-368, 368, 0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Vector3 localPoint = new Vector3(originPoint.x + gap * i, originPoint.y - gap * j, 0);
                Debug.Log(localPoint);
                _points[i, j] = transform.TransformPoint(localPoint);
                Debug.Log(_points[i, j]);
            }
        }
    }
}
