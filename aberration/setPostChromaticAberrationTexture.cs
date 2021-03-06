// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Aberration")]
	[Tooltip("Set Chromatic Aberration Post Processing Effects Spectral Texture.")]
	public class  setPostChromaticAberrationTexture : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

        public FsmTexture spectralTexture;
		public FsmBool everyFrame;
		       
		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	public override void Reset()
		{
			spectralTexture = null;
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
			behavior.chromaticAberration.spectralTexture = (Texture2D)spectralTexture.Value;

		}

	}
}