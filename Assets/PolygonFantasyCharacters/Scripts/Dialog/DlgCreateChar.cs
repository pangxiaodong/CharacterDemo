using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DlgCreateChar : MonoBehaviour
{
    public Dropdown m_dropSelPlayer;
    public Dropdown m_dropSelColor;

    public CharacterData m_charData;
    public PlayerFactory m_playerFactory;
    public Player m_player;
    public CameraControl m_cameraControl;

    // Start is called before the first frame update
    void Start()
    {
        InitUI();
        RefreshPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitUI()
    {
        List<string> charNames = new List<string>();
        for (int i = 0; i < m_charData.m_charPrefabs.Length; i++)
        {
            string name = m_charData.m_charPrefabs[i].name;
            name = name.Substring(name.IndexOf("_") + 1);
            charNames.Add(name);
        }
        m_dropSelPlayer.ClearOptions();
        m_dropSelPlayer.AddOptions(charNames);
        m_dropSelPlayer.onValueChanged.AddListener(OnSelPlayerChanged);

        List<string> matNames = new List<string>();
        for (int i = 0; i < m_charData.m_charMats.Length; i++)
        {
            string name = m_charData.m_charMats[i].name;
            name = name.Substring(name.IndexOf("Mat_") + 4);
            matNames.Add(name);
        }
        m_dropSelColor.ClearOptions();
        m_dropSelColor.AddOptions(matNames);
        m_dropSelColor.onValueChanged.AddListener(OnSelColorChanged);
    }

    void OnSelPlayerChanged(int index)
    {
        RefreshPlayer();
    }

    void OnSelColorChanged(int index)
    {
        RefreshPlayer();
    }

    void RefreshPlayer()
    {
        int charIndex = m_dropSelPlayer.value;
        int matIndex = m_dropSelColor.value;

        if (m_player == null)
            m_player = m_playerFactory.CreatePlayer(charIndex);

        if (m_player.m_charIndex != charIndex)
        {
            m_playerFactory.CachePlayer(m_player);
            m_player = m_playerFactory.CreatePlayer(charIndex);
        }
        m_player.ChangeMat(matIndex);
        m_cameraControl.m_lookAt = m_player.m_spine;
    }
}
