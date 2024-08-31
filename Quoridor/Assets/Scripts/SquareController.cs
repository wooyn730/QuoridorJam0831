using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image)), RequireComponent(typeof(Button))]
public class SquareController : MonoBehaviour
{
    private Image _img;
    private Button _btn;

    private void Start()
    {
        _img = GetComponent<Image>();
        _btn = GetComponent<Button>();
    }

    public void ActiveSquare()
    {
        // �� ����
        // TODO: �� ������ ��ư Ȱ��ȭ
        _img.color = new Color(255 / 255f, 244 / 255f, 143 / 255f);
        // ��ư Ȱ��ȭ
        _btn.interactable = true;
    }

    public void MovePlayerHere()
    {
        // ��ư�� ������ �÷��̾ �� �ڽ����� �������� ���� �ѱ��.
        // ���� �ѱ�� ��� ��ư���� �ʱ�ȭ
        // �ش�Ǵ� ��ư Ȱ��ȭ
    }
}
