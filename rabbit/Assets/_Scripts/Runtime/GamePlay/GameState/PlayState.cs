using System;
using UnityEngine;
using System.Collections;
using Assets.Code.Interfaces;
using UnityEngine.SceneManagement;

namespace Assets.Code.States
{
    public class PlayState: IStateBase
    {
        private StateManager manager;
        private GameObject player;
        
        public PlayState(StateManager managerRef)
        {
            // Scene currentScene = SceneManager.GetActiveScene();
            // string currentSceneName = currentScene.name;
            manager = managerRef;
            if(SceneManager.GetActiveScene().name != "Scene1")
                SceneManager.LoadScene("Scene1");
            
            player = GameObject.Find("Player");
            foreach(GameObject camera in manager.gameDataRef.cameras)
                {
                    if(camera.name != "CameraFollow")
                        camera.SetActive(false);
                    else
                        camera.SetActive(true);
                }
                
        }

        public void StateUpdate()
        {
           //GameData.TimerCountdown()
        }

        public void ShowIt()
        {
            
        }
    }
}