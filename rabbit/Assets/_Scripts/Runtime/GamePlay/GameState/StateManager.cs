using UnityEngine;
using Assets.Code.States;
using Assets.Code.Interfaces;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    private IStateBase activeState;
 
    [HideInInspector]
    public GameData gameDataRef;
    
    [HideInInspector]
    public GameDataScene0 gameDataScene0Ref;
 
    private static StateManager _instanceRef;
 
    void Awake ()
    {
        if(_instanceRef == null)
        {
            _instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    void Start ()
    {
        activeState = new SetupState(this);
        gameDataRef = GetComponent<GameData>();
        gameDataScene0Ref = GetComponent<GameDataScene0>();
    }
    void Update()
    {
        if (activeState != null)
            activeState.StateUpdate();
    }
    void OnGUI()
    {
        if(activeState != null)
            activeState.ShowIt();
    }
    public void SwitchState(IStateBase newState)
    {
        activeState = newState;
    }
 
    public void Restart()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Scene0");
    }
}