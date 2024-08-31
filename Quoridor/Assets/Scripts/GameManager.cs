using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private BoardController _boardController;
    [SerializeField] private PlayerController Player1;
    [SerializeField] private PlayerController Player2;
    private int _turn = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }

    public void StartTurn()
    {
        _uiManager.ShowCurrectTurn(_turn);
        _boardController.SelectPlayer(_turn);
    }

    public void NextTurn(Vector2 pos)
    {
        // Player에서 호출..??
        _boardController.InactiveAllSquares();

        // 게임의 승패 검사
        if (!UpdatePlayerSquare(pos))
            return;

        // 안 끝났다면 턴 넘기기
        _turn = 3 - _turn;

        StartTurn();
    }

    private bool UpdatePlayerSquare(Vector2 pos)
    {
        if (_turn == 1)
        {
            if ((int)pos.y == 0)
            {
                ShowResults(1);
                return false;
            }
            _boardController.player1Square = _boardController._squares[(int)pos.y, (int)pos.x];
        }
        else if (_turn == 2)
        {
            if ((int)pos.y == 8)
            {
                ShowResults(2);
                return false;
            }
            _boardController.player2Square = _boardController._squares[(int)pos.y, (int)pos.x];
        }
        return true;
    }

    private void ShowResults(int player)
    {
        Debug.Log("Player"+player+" Win");
        _uiManager.PlayerWin(player);
    }

    public PlayerController GetCurrentPlayer()
    {
        if (_turn == 1)
            return Player1;
        else
            return Player2;
    }
}
