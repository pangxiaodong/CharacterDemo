using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    public Transform m_playerRoot;
    public Transform m_cacheRoot;
    public CharacterData m_charData;
    public List<Player> m_playerCache = new List<Player>();

    public Player CreatePlayer(int charIndex)
    {
        // search player in cache
        Player player = null;
        for (int i = 0; i < m_playerCache.Count; i++)
        {
            player = m_playerCache[i];
            if (player.m_charIndex == charIndex)
            {                
                m_playerCache.RemoveAt(i);
                player.transform.SetParent(m_playerRoot);
                player.transform.localRotation = Quaternion.identity;
                player.gameObject.SetActive(true);
                return player;
            }
        }

        // create player    
        GameObject prefab = m_charData.m_charPrefabs[charIndex];
        GameObject createObj = GameObject.Instantiate(prefab, m_playerRoot);
        createObj.transform.localRotation = Quaternion.identity;
        player = createObj.GetComponent<Player>();
        player.m_charIndex = charIndex;
        return player;
    }

    public void CachePlayer(Player player)
    {
        m_playerCache.Add(player);
        player.gameObject.SetActive(false);
        player.transform.SetParent(m_cacheRoot);        
    }
}
