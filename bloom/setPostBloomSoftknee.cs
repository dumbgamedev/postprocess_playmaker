// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Bloom")]
	[Tooltip("Set Bloom Post Processing Effects Softkness.")]
	public class  setPostBloomSoftknee : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		public FsmFloat softKnee;
		public FsmBool everyFrame;

		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;
	
		public override void Reset()
		{
			softKnee = null;
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

			behavior.bloom.bloom.softKnee = softKnee.Value;

		}

	}
}