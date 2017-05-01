// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Antialias")]
	[Tooltip("Set Antialiasing Post Processing Effects Blending Stationary.")]
	public class  setPostAntialiasingBlending : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		public FsmFloat blendingStationary;
		public FsmBool everyFrame;

			       
		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	
		public override void Reset()
		{
			blendingStationary = null;
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

			behavior.antialiasing.taaSettings.stationaryBlending = blendingStationary.Value;

		}

	}
}