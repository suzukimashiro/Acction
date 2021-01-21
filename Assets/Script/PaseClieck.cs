using UnityEngine;
using System.Collections;

public class PaseClieck : MonoBehaviour
{
    [SerializeField]
    //ポーズしたときのUIのプレハブ
    public GameObject pauseUIPrefab;
    //ポーズUIのインスタンス
    public GameObject pauseUIInstance;
    public void OnClieck()
    {
        if (pauseUIInstance == null)
        {
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            Time.timeScale = 0f;
        }
        else
        {
            Destroy(pauseUIInstance);
            Time.timeScale = 1f;
        }

    }
}
