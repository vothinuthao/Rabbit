using UnityEngine;
using Assets.Code.Interfaces;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Code.States
{
    public class SetupState :IStateBase
    {
        private StateManager manager;
        // private GameObject player;
        // private PlayerMovement movement;
        public SetupState (StateManager managerRef)
        {
            manager = managerRef;
            if (SceneManager.GetActiveScene().name != "Scene0")
            {
                SceneManager.LoadScene("Scene0");
            }
 
            // player = GameObject.Find("Player");
            // if (player == null)
            // {
            //     Debug.Log("Player not found in scene!");
            //     return;
            // }
            //
            // // Lấy component PlayerMovement
            // movement = player.GetComponent<PlayerMovement>();
            // if (movement == null)
            // {
            //     Debug.Log("PlayerMovement component not found on Player!");
            //     return;
            // }
            
            
        }

        public void Start()
        {
           
        }
        public void StateUpdate()
        {
            
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void ShowIt()
        {
            if (manager.gameDataScene0Ref != null)
            {
                manager.gameDataScene0Ref.ShowUI();
            }
            else
            {
                Debug.LogError("gameDataScene0Ref is null!");
            }
             
            if (GUI.Button(new Rect(10, 10, 270, 30), 
                    "Click Here or Space key to play") || 
                Input.GetKeyUp (KeyCode.Space))
            {
                manager.SwitchState (new PlayState (manager));
                //manager.gameDataScene0Ref.HideUI();
            }
        }
        
       



    }
}