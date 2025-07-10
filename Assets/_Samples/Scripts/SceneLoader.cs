using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace n11ckz.SceneReference.Samples
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        private bool _isLoading;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        public void LoadScene(SceneReference scene) =>
            StartCoroutine(LoadSceneAsync(scene));

        public IEnumerator LoadSceneAsync(SceneReference scene)
        {
            if (IsValidScene(scene) == false || _isLoading == true)
                yield break;

            _isLoading = true;
            AsyncOperation loading = SceneManager.LoadSceneAsync(scene.BuildIndex);

            while (loading.isDone == false)
                yield return null;

            _isLoading = false;
        }

        private bool IsValidScene(SceneReference scene)
        {
            bool isValid = scene.IsAddedInBuild == true;

            if (isValid == false)
                Debug.Log($"Scene «{scene.Name}» was not added in the build");

            return isValid;
        }
    }
}
