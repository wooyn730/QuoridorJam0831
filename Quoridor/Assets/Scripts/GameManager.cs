using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    [SerializeField] private BoardController _boardController;
    [SerializeField] private PlayerController Player1;
    [SerializeField] private PlayerController Player2;
    private int turn = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StartTurn()
    {
        _boardController.SelectPlayer(turn);
    }

    public void NextTurn()
    {
        // ������ ���� �˻�
        // �� �����ٸ� �� �ѱ��

        // Player���� ȣ��..??
        _boardController.InactiveAllSquares();

        turn = 3 - turn;

        StartTurn();
    }

    public PlayerController GetCurrentPlayer()
    {
        if (turn == 1)
            return Player1;
        else
            return Player2;
    }
}
