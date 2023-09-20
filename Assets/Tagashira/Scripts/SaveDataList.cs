using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataList : MonoBehaviour
{
    public static SaveDataList instance;    // �C���X�^���X�̒�`

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
            // ���g���C���X�^���X�Ƃ���
            instance = this;
            _loadStory = Story.another;

            // ���ݑ��݂���X�g�[���[�̐������z�������
            _saveData = new SaveData[(int)_lastStory];
        }
        else
        {
            // �d�����Ȃ��悤�Ɏ��g������
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // �V�[�����ׂ��ł����̃I�u�W�F�N�g����������Ȃ��悤�ɂ���
        DontDestroyOnLoad(this);

        // Main�V�[���ł��邱�Ƃ𔻒�
        bool isMainScene = SceneManager.GetActiveScene().name == _mainSceneName;

        if (isMainScene)
        {
            // �Z�[�u�f�[�^�}�l�[�W���[���擾
            _saveDataManagerO = GameObject.FindWithTag("SaveDataManager");
            _saveDataManager = _saveDataManagerO.GetComponent<SaveDataManager>();
        }
    }
}
