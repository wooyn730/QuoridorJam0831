using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image)), RequireComponent(typeof(Button))]
public class SquareController : MonoBehaviour
{
    public Vector2 Pos;
    private Image _img;
    private Button _btn;

    private void Start()
    {
        _img = GetComponent<Image>();
        _btn = GetComponent<Button>();
    }

    public void ActiveSquare()
    {
        // 색 변경
        // TODO: 색 변경을 버튼 활성화
        _img.color = new Color(255 / 255f, 244 / 255f, 143 / 255f);
        // 버튼 활성화
        _btn.interactable = true;
    }

    public void InactiveSquare()
    {
        _img.color = new Color(1f, 1f, 1f);
        // 버튼 활성화
        _btn.interactable = false;
    }    

    public void MovePlayerHere()
    {
        GameManager.Instance.GetCurrentPlayer().Move(Pos);
        GameManager.Instance.NextTurn();
        // 버튼이 눌리면 플레이어를 내 자식으로 가져오고 턴을 넘긴다.
        // 턴을 넘기면 모든 버튼들을 초기화
        // 해당되는 버튼 활성화
    }
}
