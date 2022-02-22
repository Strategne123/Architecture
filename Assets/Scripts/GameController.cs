using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEditor;
using UnityEditor.SceneManagement;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public Dictionary<string, int> Parameters = new Dictionary<string, int>();
    private delegate void ChangeParameters();
    private event ChangeParameters ÑhangeParameters;
    private static List<EditorBuildSettingsScene> Scenes=EditorBuildSettings.scenes.ToList();
    [SerializeField] private TMP_Text _profileInfo;
    [SerializeField] private GameObject _levelsWindow;
    [SerializeField] private Transform _figuresTransform;
    [SerializeField] private Transform _levelsTransform;
    [SerializeField] private Button _tempLevel;
    public List<GameObject> Figures;
    [HideInInspector] public List<Addon> Addons;// = new List<Addon>();


    private void Start()
    {
        _profileInfo.text = GetParameters();
        ÑhangeParameters += UpdateProfile;
        Figure.click += ClickFigure;
        AddParameter("Moves", 0);
        InitParameters();
        //Addons = Resources.FindObjectsOfTypeAll<Addon>().ToList();
    }

    private void InitParameters()
    {
        foreach (var addon in Addons.Where(addon => addon.isActive))
        {
            addon.InitParameter(this);
        }
    }

    public void AddParameter(string caption, int value)
    {
        Parameters.Add(caption, value);
        ÑhangeParameters?.Invoke();
    }

    public void RemoveParameter(string caption)
    {
        Parameters.Remove(caption);
        ÑhangeParameters?.Invoke();
        
    }

    public void TryChangeValue(string _key, int _magnitude)
    {
        try
        {
            Parameters[_key] += _magnitude;
            ÑhangeParameters?.Invoke();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void UpdateProfile()
    {
        _profileInfo.text = GetParameters();
    }

    public string GetParameters()
    {
        var str = "";
        foreach (var _parameter in Parameters)
        {
            str += _parameter.Key + ": " + _parameter.Value + " ";
        }
        return str;
    }

    private void UpdateLevels()
    {
       /* var numberLevel = 0;
        foreach (var level in LevelsController.Levels)
        {
            var tempLevel = Instantiate(_tempLevel, _levelsTransform);
            tempLevel.GetComponentInChildren<TMP_Text>().text = level.Key;
            tempLevel.onClick.AddListener(delegate {SelectLevel(numberLevel);});
            numberLevel++;
        }*/
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
        var tempFigure = Instantiate(figure,_figuresTransform);
        tempFigure.GetComponent<Figure>().GameController = this;
    }

    public void AddScene()
    {
        var caption = "Lvl" + SceneManager.sceneCountInBuildSettings + 1;
        SceneManager.CreateScene(caption);
        var newScene = new EditorBuildSettingsScene();
        Scenes.Add(newScene);
        //EditorBuildSettings.scenes= Scenes.Select(newScene => newScene.path).ToList();
    }

    /*private CloneContent()
    {
        SceneManager.MoveGameObjectToScene();
    }*/

    public void RemFig()
    {
        Figures.Remove(Figures.Last());
    }
}
