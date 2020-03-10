using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaeData {
    public static int SCORE = 0;

}

public class enums : MonoBehaviour {

    public void LoadGameScene () {
        SceneManager.LoadScene ("2dPlatformer");
    }
}