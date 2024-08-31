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
        // 게임의 승패 검사
        // 안 끝났다면 턴 넘기기

        // Player에서 호출..??
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
