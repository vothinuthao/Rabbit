using UnityEngine;
using Assets.Code.Interfaces;
using UnityEngine.SceneManagement;

namespace Assets.Code.States
{
    public class WinState : IStateBase
    {
        private StateManager manager;

        public WinState(StateManager managerRef)
        {
            manager = managerRef;
            if (SceneManager.GetActiveScene().name != "Scene0")
                SceneManager.LoadScene("Scene0");
        }

        public void StateUpdate()
        {
        }

        public void ShowIt()
        {
        }
    }
}