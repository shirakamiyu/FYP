using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    private Image _image;
    public Button startButton; // 启动按钮
    public Button exitButton;  // 退出按钮
    public GameObject bgImage; // 背景图像对象

    private void Awake()
    {
        // 检查是否已存在 EventSystem
        if (Object.FindFirstObjectByType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _image = GetComponentInChildren<Image>();

        startButton.onClick.AddListener(OnStartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnStartButtonClick()
    {
        StartCoroutine(Load());
    }

    private void OnExitButtonClick()
    {
        // 退出应用程序
        Application.Quit();
    }

    private IEnumerator Load()
    {
        _image.raycastTarget = true;
        yield return _image.DOFade(1, 1).WaitForCompletion();

        // 禁用背景图像和按钮
        bgImage.SetActive(false);
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        yield return SceneManager.LoadSceneAsync(1); // 替换为你要加载的场景索引

        yield return _image.DOFade(0, 1).WaitForCompletion();
        _image.raycastTarget = false;
    }
}