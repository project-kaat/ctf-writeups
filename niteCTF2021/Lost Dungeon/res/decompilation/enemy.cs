using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class Enemy : Mover
{
	// Token: 0x0600000B RID: 11 RVA: 0x00002264 File Offset: 0x00000464
	protected override void Start()
	{
		base.Start();
		this.x = GameManager.instance.player.transform;
		this.y = base.transform.position;
		this.z = this.x.GetChild(0).GetComponent<BoxCollider2D>();
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000022B4 File Offset: 0x000004B4
	private void FixedUpdate()
	{
		if (Vector3.Distance(this.x.position, this.y) < this.chaseLenght)
		{
			this.v = (Vector3.Distance(this.x.position, this.y) < this.triggerLenght);
			if (this.v)
			{
				if (!this.w)
				{
					this.o((this.x.position - base.transform.position).normalized);
				}
			}
			else
			{
				this.o(this.y - base.transform.position);
			}
		}
		else
		{
			this.o(this.y - base.transform.position);
			this.v = false;
		}
		this.w = false;
		this.bn.OverlapCollider(this.filter, this.ba);
		for (int i = 0; i < this.ba.Length; i++)
		{
			if (!(this.ba[i] == null))
			{
				if (this.ba[i].tag == "Fighter" && this.ba[i].name == "Player")
				{
					this.w = true;
				}
				this.ba[i] = null;
			}
		}
	}

	// Token: 0x0400000B RID: 11
	public int xpValue = 1;

	// Token: 0x0400000C RID: 12
	public float triggerLenght = 1f;

	// Token: 0x0400000D RID: 13
	public float chaseLenght = 5f;

	// Token: 0x0400000E RID: 14
	private bool v;

	// Token: 0x0400000F RID: 15
	private bool w;

	// Token: 0x04000010 RID: 16
	private Transform x;

	// Token: 0x04000011 RID: 17
	private Vector3 y;

	// Token: 0x04000012 RID: 18
	public ContactFilter2D filter;

	// Token: 0x04000013 RID: 19
	private BoxCollider2D z;

	// Token: 0x04000014 RID: 20
	private Collider2D[] ba = new Collider2D[10];
}