using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneUIManager : BaseUIManager {

    private bool _isGamePaused = false;
    
    public void OnClickPauseButton() {

        _isGamePaused = !_isGamePaused;
        if(_isGamePaused)
            _sceneManager.PauseGame();
        else
            _sceneManager.ResumeGame();
    }

    public void OnClickSpawnEnemyButton() {
    }
}
