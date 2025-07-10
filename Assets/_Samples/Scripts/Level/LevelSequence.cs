using System.Collections.Generic;
using UnityEngine;

namespace n11ckz.SceneReference.Samples
{
    [CreateAssetMenu(fileName = nameof(LevelSequence), menuName = "Configs/Level/" + nameof(LevelSequence))]
    public class LevelSequence : ScriptableObject
    {
        [SerializeField] private List<SceneReference> _levels;

        public IReadOnlyList<SceneReference> Levels => _levels;
    }
}
