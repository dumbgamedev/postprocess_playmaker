// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing DOF")]
	[Tooltip("Set Depth of Field Focal Length Post Processing Effects.")]
	public class setDOFFocalLength : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		public FsmFloat focalLength;

		public FsmBool everyFrame;

		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

		public override void Reset()
		{

			focalLength = null;
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

			behavior.depthOfField.focalLength = focalLength.Value;

		}

	}
}