using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static Pause pause;
    public bool canPause;
    private float curTimeScale = 1;
    public Image loadBackground;
    public Image loadIcon;
    public Canvas pauseCanvas;
    private float fade = 1;
    private WaitForSeconds fadeDelay = new WaitForSeconds(0.1f);

    private void Awake()
    {
        pause = this;
    }

    private void Start()
    {
        if (pauseCanvas != null)
        {
            canPause = true;
        }
        else
        {
            canPause = false;
        }
        System.GC.Collect();
        StartCoroutine(LoadFade());
        if (!DataPackage.NewGame && LoadScript.loader != null) { LoadScript.loader.Load(); DataPackage.NewGame = false; }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause")) { PauseToggle(); }
    }

    public void PauseToggle()
    {
        if (canPause)
        {
            if (Time.timeScale == 0)
            {
                pauseCanvas.enabled = false;
                Time.timeScale = curTimeScale;
                PlayerMove.player.isControlled = true;
                CameraMenu.camMenu.allowChange = true;
            }
            else
            {
                pauseCanvas.enabled = true;
                curTimeScale = Time.timeScale;
                Time.timeScale = 0;
                CameraMenu.camMenu.allowChange = false;
                PlayerMove.player.isControlled = false;
            }
        }
    }

    public void PauseToggle(bool pauseStatus)
    {
        if (canPause)
        {
            if (pauseStatus)
            {
                pauseCanvas.enabled = true;
                curTimeScale = Time.timeScale;
                Time.timeScale = 0;
                CameraMenu.camMenu.allowChange = false;
                PlayerMove.player.isControlled = false;
            }
            else
            {
                pauseCanvas.enabled = false;
                Time.timeScale = curTimeScale;
                PlayerMove.player.isControlled = true;
                CameraMenu.camMenu.allowChange = true;
            }
        }
    }

    public void ChangeScene()
    {
        PauseToggle(false);
        canPause = false;
        loadBackground.enabled = true;
        loadIcon.enabled = true;
        StartCoroutine(LoadingScreen());
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    public void ChangeScene(string sceneName)
    {
        PauseToggle(false);
        canPause = false;
        loadBackground.enabled = true;
        loadIcon.enabled = true;
        StartCoroutine(LoadingScreen());
        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator LoadingScreen()
    {
        while (fade < 1)
        {
            fade += Time.deltaTime;
            Color c = loadBackground.color;
            c.a = fade;
            loadBackground.color = c;
            c = loadIcon.color;
            c.a = fade;
            loadIcon.color = c;
            yield return fadeDelay;
        }
    }

    IEnumerator LoadFade()
    {
        while(fade > 0)
        {
            fade -= Time.deltaTime;
            Color c = loadBackground.color;
            c.a = fade;
            loadBackground.color = c;
            c = loadIcon.color;
            c.a = fade;
            loadIcon.color = c;
            yield return fadeDelay;
        }
    }

    public void NewGame()
    {
        DataPackage.NewGame = true;
        LoadScript.loader.DelLoad();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
