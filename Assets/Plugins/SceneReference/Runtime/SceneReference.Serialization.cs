#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace n11ckz.SceneReference
{
    public partial class SceneReference : ISerializationCallbackReceiver
    {
        [SerializeField] private SceneAsset _sceneAsset;

        [Obsolete("This method will not be included in build", true)]
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

        [Obsolete("This method will not be included in build", true)]
        public void OnAfterDeserialize() { }

        private void SetInvalidValues()
        {
            Name = Constants.UndefinedSceneName;
            BuildIndex = Constants.InvalidSceneBuildIndex;
        }

        private void SetSceneBuildIndex()
        {
            string sceneAssetPath = AssetDatabase.GetAssetOrScenePath(_sceneAsset);
            BuildIndex = SceneUtility.GetBuildIndexByScenePath(sceneAssetPath);
        }
    }
}
#endif
