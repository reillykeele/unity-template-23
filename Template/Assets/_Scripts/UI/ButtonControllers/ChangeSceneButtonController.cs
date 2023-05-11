using ReiBrary.Coroutine;
using ReiBrary.Systems;
using ReiBrary.UI.Controllers.Selectables.Buttons;

namespace Template.UI.ButtonControllers
{
    public class ChangeSceneButtonController : AButtonController
    {
        public string TargetScene;
        public float Delay = 0f;

        protected override void OnClick()
        {
            // _canvasAudioController?.FadeOutBackgroundMusic();
            StartCoroutine(CoroutineReiBrary.WaitForExecute(() => LoadingSystem.Instance.LoadSceneCoroutine(TargetScene), Delay));
        }
    }
}
