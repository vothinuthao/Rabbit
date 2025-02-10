namespace Runtime.GamePlay.GameState
{ 
    using UnityEngine;

    [CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
    public class LevelData : ScriptableObject
    {
        [Header("Level Info")]
        public int levelNumber;
        public string sceneName;
        
        [Header("Level Requirements")]
        public FruitType requiredFruitType;
        public int requiredAmount;
        public float timeLimit = 180f; // 3 minutes default
        
        [Header("Level Description")]
        [TextArea(3, 5)]
        public string levelDescription;
    }
}