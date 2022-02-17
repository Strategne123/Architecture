using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text _profileInfo;

    private void Start()
    {
        Player player = new Player();
        _profileInfo.text = Player.GetParameters();
        Player.changeParameters += UpdateProfile;
        Figure.click += ClickFigure;
    }

    private void UpdateProfile()
    {
        _profileInfo.text = Player.GetParameters();
    }

    public void ClickFigure(Figure figure)
    {
        print(figure.Size);
    }
}
