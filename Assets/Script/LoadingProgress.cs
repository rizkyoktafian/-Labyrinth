using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingProgress : MonoBehaviour
{
    //untuk loading scene biasanya pake coroutine
    [SerializeField] Image image;

    private void Start() {
        //memulai coroutine setelah 1 frame awal
        StartCoroutine(Progress());
    }

    IEnumerator Progress() {
        image.fillAmount=0;
        yield return new WaitForSeconds(1);

        var asyncOp = SceneManager.LoadSceneAsync(SceneLoader.SceneToLoad);

        while (asyncOp.isDone == false)
        {
            image.fillAmount = asyncOp.progress;
            Debug.Log(asyncOp.progress*100);
            yield return null;
        }
    }
}
