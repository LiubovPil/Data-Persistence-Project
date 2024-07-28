using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreName;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private int loadingScene = 1;

    private const string bestScoreText = "Best Score: ";

    private void Start()
    {
        inputField.text = GameManager.Instance.BestPlayerName;
        bestScoreName.SetText(bestScoreText + GameManager.Instance.BestPlayerName + ": " +
            GameManager.Instance.BestScore.ToString());
    }

    public void StopEnteringName(string value)
    {
        if (inputField.text != GameManager.Instance.PlayerName)
        {
            GameManager.Instance.PlayerName = inputField.text;
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(loadingScene);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
}
