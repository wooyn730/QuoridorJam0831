using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
    [SerializeField] private Transform _board;
    private SquareController[,] _squares = new SquareController[9, 9];
    [SerializeField] private Vector2 player1Pos;
    [SerializeField] private Vector2 player2Pos;
    [SerializeField] private Vector2[] around = new Vector2[4];

    // ������ 9*9 ������ ������ �ִ´�
    // �÷��̾��� ��ġ�� Ȯ���Ѵ�
    // �÷��̾ �̵� ������ ������ ���� �ٲ��ش�
    // ������ �÷��̾ �ش� ��ġ�� �̵��Ѵ�

    private void Start()
    {
        InitAround();
        AllocateSquares();
        player1Pos = new Vector2(4, 8);
        player2Pos = new Vector2(4, 0);
        Player1Turn();
    }

    private void Player1Turn()
    {
        ActiveSquares(player1Pos);
    }

    private void ActiveSquares(Vector2 playerPos)
    {
        // �� �� �ִ� ĭ Ȱ��ȭ
        for (int i=0; i<around.Length; i++)
        {
            int newX = (int)(playerPos.x + around[i].x);
            int newY = (int)(playerPos.y + around[i].y);

            if (newX >= 0 && newX < 9 && newY >= 0 && newY < 9)
            {
                _squares[newY, newX].ActiveSquare();
            }
        }
    }

    private void AllocateSquares()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                // Debug.Log(_board.GetChild(i * 9 + j));
                _squares[i, j] = _board.GetChild(i * 9 + j).GetComponent<SquareController>();
            }
        }
    }

    private void InitAround()
    {
        around[0] = new Vector2(-1, 0);
        around[1] = new Vector2(1, 0);
        around[2] = new Vector2(0, -1);
        around[3] = new Vector2(0, 1);
    }
}
