using System.Collections.Generic;
using UnityEngine;

namespace n11ckz.SceneReference.Samples
{
    [CreateAssetMenu(fileName = nameof(FieldViewInScriptableObject), menuName = "Debug/" + nameof(FieldViewInScriptableObject))]
    public class FieldViewInScriptableObject : ScriptableObject
    {
        [SerializeField] private List<SceneReference> _sceneReferences;
        [SerializeField] private SceneReference _sceneReference;
    }
}