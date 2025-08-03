using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    private Image _image;
    public Button startButton; // ������ť
    public Button exitButton;  // �˳���ť
    public GameObject bgImage; // ����ͼ�����

    private void Awake()
    {
        // ����Ƿ��Ѵ��� EventSystem
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
        // �˳�Ӧ�ó���
        Application.Quit();
    }

    private IEnumerator Load()
    {
        _image.raycastTarget = true;
        yield return _image.DOFade(1, 1).WaitForCompletion();

        // ���ñ���ͼ��Ͱ�ť
        bgImage.SetActive(false);
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        yield return SceneManager.LoadSceneAsync(1); // �滻Ϊ��Ҫ���صĳ�������

        yield return _image.DOFade(0, 1).WaitForCompletion();
        _image.raycastTarget = false;
    }
}