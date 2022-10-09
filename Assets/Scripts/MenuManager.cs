using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    private TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        var highScore = Persistences.Instance.HighScore;

        var highScoreText = GameObject.Find("High Score Text").GetComponent<TextMeshProUGUI>();
        highScoreText.text = $"Best Score: {highScore.Name}: {highScore.Score}";

        nameInput = GameObject.Find("Name Input").GetComponent<TMP_InputField>();
        nameInput.text = Persistences.Instance.HighScore.Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Persistences.Instance.PlayerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
