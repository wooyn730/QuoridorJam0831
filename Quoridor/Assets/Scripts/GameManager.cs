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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdatePlayerSquare(Vector2 pos)
    {
        if (_turn == 1)
            _boardController.player1Square = _boardController._squares[(int)pos.y, (int)pos.x];
        else
            _boardController.player2Square = _boardController._squares[(int)pos.y, (int)pos.x];
    }

    public void StartTurn()
    {
        _uiManager.ShowCurrectTurn(_turn);
        _boardController.SelectPlayer(_turn);
    }

    public void NextTurn()
    {
        // 게임의 승패 검사
        // 안 끝났다면 턴 넘기기

        // Player에서 호출..??
        _boardController.InactiveAllSquares();

        _turn = 3 - _turn;

        StartTurn();
    }

    public PlayerController GetCurrentPlayer()
    {
        if (_turn == 1)
            return Player1;
        else
            return Player2;
    }
}
