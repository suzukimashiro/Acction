using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    [SerializeField]
    //ポーズしたときのUIのプレハブ
    private GameObject pauseUIPrefab;
    //ポーズUIのインスタンス
    private GameObject pauseUIInstance;

    private void Update()
    {
        if (Input.GetKeyUp("q"))
        {
            if(pauseUIInstance == null)
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
}
