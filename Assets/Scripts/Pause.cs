using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool canPause;
    private float curTimeScale;
    public Image loadBackground;
    public Image loadIcon;
    public Canvas pauseCanvas;
    private float fade = 1;

    private void Start()
    {
        canPause = true;
        StartCoroutine(LoadFade());
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
            yield return new WaitForSeconds(0.1f);
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
            yield return null;
        }
    }
}
