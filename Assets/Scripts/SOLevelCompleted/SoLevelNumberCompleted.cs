using System;
using UnityEngine;

namespace SOLevelCompleted
{
    [CreateAssetMenu(fileName = "Level Number Completed", menuName = "Create Level Completed")]
    public class SoLevelNumberCompleted : ScriptableObject
    {
        [SerializeField] private int _levelCompleted;

        public int LevelCompleted
        {
            get => _levelCompleted;
            set => _levelCompleted = value;
        }
    }
}