using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevelManager : MonoBehaviour
{

    public List<Button> LevelList;
    //public Sprite _highlightedSprite;

    public static LoadLevelManager instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void UnlockLevel(int level)
    {
        SpriteState st = new SpriteState();
        st.highlightedSprite = null;
        LevelList[level - 1].spriteState = st;
        LevelList[level - 1].onClick.AddListener(delegate { LoadLevel(level); });
    }
    private void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
