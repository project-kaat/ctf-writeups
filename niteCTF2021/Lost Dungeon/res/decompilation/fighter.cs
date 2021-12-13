using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class Fighter : MonoBehaviour
{
	// Token: 0x0600000E RID: 14 RVA: 0x00002438 File Offset: 0x00000638
	protected virtual void d(Damage a)
	{
		if (Time.time - this.bc > this.bb)
		{
			this.bc = Time.time;
			this.hitpoint -= a.t;
			this.bd = (base.transform.position - a.s).normalized * a.u;
			GameManager.instance.m(a.t.ToString(), 25, Color.red, base.transform.position, Vector3.zero, 0.5f);
			if (this.hitpoint <= 0)
			{
				this.hitpoint = 0;
				this.e();
			}
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x0000224B File Offset: 0x0000044B
	protected virtual void e()
	{
	}

	// Token: 0x04000015 RID: 21
	public int hitpoint = 10;

	// Token: 0x04000016 RID: 22
	public int maxHitpoint = 10;

	// Token: 0x04000017 RID: 23
	public float pushRecoverySpeed = 0.2f;

	// Token: 0x04000018 RID: 24
	protected float bb = 1f;

	// Token: 0x04000019 RID: 25
	protected float bc;

	// Token: 0x0400001A RID: 26
	protected Vector3 bd;
}