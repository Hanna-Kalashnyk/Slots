﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LuanchMegabuckScene : MonoBehaviour {
    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
