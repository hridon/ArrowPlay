using System;
using UnityEngine;

// Token: 0x020009D5 RID: 2517
public abstract class PauseObject : MonoBehaviour
{
	// Token: 0x0600508A RID: 20618 RVA: 0x000F678E File Offset: 0x000F4B8E
	private void Update()
	{
		if (Time.timeScale > 0f)
		{
			this.UpdateProcess();
		}
	}

	// Token: 0x0600508B RID: 20619 RVA: 0x000F67AF File Offset: 0x000F4BAF
	protected virtual void UpdateProcess()
	{
	}

	// Token: 0x04002898 RID: 10392
	protected bool useLateUpdate;

	// Token: 0x04002899 RID: 10393
	private int DeltaTime;
}
