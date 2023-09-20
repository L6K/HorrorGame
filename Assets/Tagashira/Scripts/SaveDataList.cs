using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataList : MonoBehaviour
{
    public static SaveDataList instance;    // インスタンスの定義

    private SaveDataManager _saveDataManager;

    [SerializeField] private Story _lastStory;
    [SerializeField] private GameObject _saveDataManagerO;
    [SerializeField] private string _mainSceneName;

    public Story _loadStory;
    public SaveData[] _saveData;

    private void Awake()
    {
        if (instance == null)
        {
            // 自身をインスタンスとする
            instance = this;
            _loadStory = Story.another;

            // 現在存在するストーリーの数だけ配列を準備
            _saveData = new SaveData[(int)_lastStory];
        }
        else
        {
            // 重複しないように自身を消去
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // シーンを跨いでもこのオブジェクトが消去されないようにする
        DontDestroyOnLoad(this);

        // Mainシーンであることを判定
        bool isMainScene = SceneManager.GetActiveScene().name == _mainSceneName;

        if (isMainScene)
        {
            // セーブデータマネージャーを取得
            _saveDataManagerO = GameObject.FindWithTag("SaveDataManager");
            _saveDataManager = _saveDataManagerO.GetComponent<SaveDataManager>();
        }
    }
}
