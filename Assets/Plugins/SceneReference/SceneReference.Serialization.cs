#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneReference
{
    public partial class SceneReference : ISerializationCallbackReceiver
    {
        [SerializeField] private SceneAsset _sceneAsset;

        public void OnBeforeSerialize()
        {
            if (_sceneAsset == null)
            {
                SetInvalidValues();
                return;
            }

            Name = _sceneAsset.name;
            SetSceneBuildIndex();
        }

        public void OnAfterDeserialize() { }

        private void SetInvalidValues()
        {
            Name = "Undefined Scene Asset";
            BuildIndex = -1;
        }

        private void SetSceneBuildIndex()
        {
            string sceneAssetPath = AssetDatabase.GetAssetOrScenePath(_sceneAsset);
            BuildIndex = SceneUtility.GetBuildIndexByScenePath(sceneAssetPath);
        }
    }
}
#endif
