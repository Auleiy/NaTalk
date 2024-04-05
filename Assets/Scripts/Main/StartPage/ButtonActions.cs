using NPT.Main.Types;

using UnityEditor;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace NPT.Main.StartPage
{
    public class ButtonActions : MonoBehaviour
    {
        [SceneName]
        public string EditorScene;

        public LoadingPage EditorLoadingPage;

        public void OpenEditor()
        {
            AsyncOperation opr = SceneManager.LoadSceneAsync(EditorScene, LoadSceneMode.Single);
            EditorLoadingPage.Operation = opr;
            EditorLoadingPage.Show(.5f);
        }

        public void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit(0);
#endif
        }
    }
}
