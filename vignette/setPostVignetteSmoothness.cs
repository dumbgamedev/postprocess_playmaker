// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Vignette")]
	[Tooltip("Set Post Processing Stack Vignette smoothness.")]
	public class setPostVignetteSmoothness : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

        public FsmFloat smoothness;
        public FsmBool everyFrame;

		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	public override void Reset()
		{
            smoothness = null;
            everyFrame = false;
		}

        public override void OnEnter()
        {

            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            behavior = go.GetComponent<UnityEngine.PostProcessing.Utilities.PostProcessingController>();

            if (!everyFrame.Value)
            {
                doPostProcess();
                Finish();
            }

        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                doPostProcess();
            }
        }


        void doPostProcess()
		{

			var go = Fsm.GetOwnerDefaultTarget (gameObject);
			behavior = go.GetComponent<UnityEngine.PostProcessing.Utilities.PostProcessingController>();

            behavior.vignette.smoothness = smoothness.Value;

		}

	}
}