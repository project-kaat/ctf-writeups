using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class Collectable : Collidable
{
	// Token: 0x06000004 RID: 4 RVA: 0x000021B3 File Offset: 0x000003B3
	protected override void b(Collider2D a)
	{
		if (a.name == "Player")
		{
			this.c();
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000021CD File Offset: 0x000003CD
	protected virtual void c()
	{
		this.p = true;
	}

	// Token: 0x04000004 RID: 4
	protected bool p;
}