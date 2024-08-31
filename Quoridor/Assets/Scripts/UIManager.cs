using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _turnTxt;
    [SerializeField] private GameObject _gameoverPanel;
    [SerializeField] private TextMeshProUGUI _resultTxt;

    public void ShowCurrectTurn(int turn)
    {
        if (turn == 1)
        {
            _turnTxt.text = "<color=#F50000>Player1</color>'s Turn!";
        }
        else if (turn == 2)
        {
            _turnTxt.text = "<color=#4698F5>Player2</color>'s Turn!";
        }
    }

    public void PlayerWin(int player)
    {
        _gameoverPanel.SetActive(true);

        if (player == 1)
        {
            _resultTxt.text = "Congratulation!<br><color=#F50000>Player1</color> Wins!";
        }
        else if (player == 2)
        {
            _resultTxt.text = "Congratulation!<br><color=#4698F5>Player2</color> Wins!";
        }
    }

    //public void RestartBtnClicked()
    //{
    //    SceneManager.LoadScene("QuoridorScene");
    //}
}
