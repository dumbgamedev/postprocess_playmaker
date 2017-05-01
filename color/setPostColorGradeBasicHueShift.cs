// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Color Grading")]
	[Tooltip("Set Color Grading Basic Post Processing Effects Hue Shift.")]
	public class setPostColorGradeBasicHueShift : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		public FsmFloat hueShift;
		public FsmBool everyFrame;

		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

		public override void Reset()
		{
			hueShift = null;
			everyFrame = null;
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

			behavior.colorGrading.basic.hueShift = hueShift.Value;

		}

	}
}