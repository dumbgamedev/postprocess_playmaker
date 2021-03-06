// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Vignette")]
	[Tooltip("Set Post Processing Stack Vignette color.")]
	public class setPostVignetteColor : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

        public FsmColor color;
        public FsmBool everyFrame;

		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	public override void Reset()
		{
            color = Color.black;
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

            behavior.vignette.color = color.Value;

		}

	}
}