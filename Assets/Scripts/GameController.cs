using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text _profileInfo;
    [SerializeField] private GameObject _levelsWindow;
    [SerializeField] private Transform _figuresTransform;
    [SerializeField] private Transform _levelsTransform;
    [SerializeField] private Button _tempLevel;
    public FigureController FigureController;
    public LevelsController LevelsController;

    private void Start()
    {
        Player player = new Player();
        _profileInfo.text = Player.GetParameters();
        Player.ÑhangeParameters += UpdateProfile;
        Figure.click += ClickFigure;
        LevelsController.Levels.Clear();
        Dictionary<string, bool> t = new Dictionary<string, bool>();
        t.Add("Ad1",false);
        t.Add("Ad2", false);
        LevelsController.Levels.TryAdd("Lvl1",t);
        print(LevelsController.Levels["Lvl1"].First());
    }

    private void UpdateProfile()
    {
        _profileInfo.text = Player.GetParameters();
    }

    private void UpdateLevels()
    {
        var numberLevel = 0;
        foreach (var level in LevelsController.Levels)
        {
            var tempLevel = Instantiate(_tempLevel, _levelsTransform);
            tempLevel.GetComponentInChildren<TMP_Text>().text = level.Key;
            tempLevel.onClick.AddListener(delegate {SelectLevel(numberLevel);});
            numberLevel++;
        }
    }

    public void ClickFigure(Figure figure)
    {
        print(figure.Size);
    }

    public void ShowLevels(bool visibility)
    {
        _levelsWindow.SetActive(visibility);
    }

    public void SelectLevel(int number)
    {
        SceneManager.LoadScene(number-1);
    }

    public void AddFigure(GameObject figure)
    {
        Instantiate(figure,_figuresTransform);
    }

    public void AddScene()
    {
        var caption = "Lvl" + LevelsController.Levels.Count + 1;
        SceneManager.CreateScene(caption);
        //LevelsController.Levels.Add(new Level(caption));

    }
}
