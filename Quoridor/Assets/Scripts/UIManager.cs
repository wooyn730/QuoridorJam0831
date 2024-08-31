using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _turnTxt;

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
}
