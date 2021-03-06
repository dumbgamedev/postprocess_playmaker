// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing SSR")]
	[Tooltip("Set Screen Space Relection Screen Edge Mask in Post Processing Effects.")]
	public class  setSSRScreenEdgeMask : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		public FsmFloat intensity;
		
		public FsmBool everyFrame;
			       
		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	
		public override void Reset()
		{

			
			intensity = new FsmFloat{ UseVariable = true};
			everyFrame = false;
		}

		public override void OnEnter()
		{

			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			behavior = go.GetComponent<UnityEngine.PostProcessing.Utilities.PostProcessingController>();

			doPostProcess();
			
			if (!everyFrame.Value)
			{
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

			if(!intensity.IsNone)  
			{			
				behavior.screenSpaceReflection.screenEdgeMask.intensity = intensity.Value;
			}

			
		}

	}
}