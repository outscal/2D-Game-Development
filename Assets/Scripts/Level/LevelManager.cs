using UnityEngine.SceneManagement;
using UnityEngine;
using System;

namespace Assests.Scripts.Level
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        public static LevelManager Instance { get { return instance; } }
        public string[] Levels;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
            {
                SetLevelStatus(Levels[0], LevelStatus.Unlocked);
            }
        }

        public void MarkCurrentLevelComplete()
        {
            //set level status to complete and unlock the next level
            int currentSceneIndex = Array.FindIndex(Levels, level => level == SceneManager.GetActiveScene().name);
            SetLevelStatus(Levels[currentSceneIndex], LevelStatus.Completed);
            int nextSceneIndex = currentSceneIndex + 1;
            Debug.Log("index incresed by 1");

            if (nextSceneIndex < Levels.Length)
            {
                Debug.Log("Going on next scene");
                SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            }
        }

        public LevelStatus GetLevelStatus(string level)
        {
            LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }
        public void SetLevelStatus(string level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(level, (int)levelStatus);
            Debug.Log("Setting Level:" + level + " Status: " + levelStatus);
        }
    }

}