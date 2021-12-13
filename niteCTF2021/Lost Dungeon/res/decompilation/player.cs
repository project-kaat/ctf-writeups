using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class Player : Mover
{
	// Token: 0x06000028 RID: 40 RVA: 0x00002AB1 File Offset: 0x00000CB1
	protected override void Start()
	{
		base.Start();
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002AC4 File Offset: 0x00000CC4
	private void FixedUpdate()
	{
		float axisRaw = Input.GetAxisRaw("Horizontal");
		float axisRaw2 = Input.GetAxisRaw("Vertical");
		this.o(new Vector3(axisRaw, axisRaw2, 0f));
	}
}