///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 22/10/2019 17:44
///-----------------------------------------------------------------

using System;
using UnityEngine;

namespace Com.Hugo.Teyssier.Common.CustomBase
{
	public abstract class StateMonoBehaviour : MonoBehaviour
	{

		protected Action DoAction;

		protected virtual void SetModeVoid()
		{
			DoAction = DoActionVoid;
		}

		protected void DoActionVoid()
		{

		}

		protected virtual void SetModeNormal()
		{
			DoAction = DoActionNormal;
		}

		protected virtual void DoActionNormal()
		{

		}
	}
}
