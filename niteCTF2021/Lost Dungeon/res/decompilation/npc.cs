using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class NPC : Collectable
{
	// Token: 0x06000026 RID: 38 RVA: 0x00002A44 File Offset: 0x00000C44
	protected override void c()
	{
		if (!this.p)
		{
			this.p = true;
			base.GetComponent<SpriteRenderer>().sprite = this.emptyChest;
			GameManager.instance.m(this.message[0], 15, Color.yellow, base.transform.position, Vector3.up * 15f, 5f);
		}
	}

	// Token: 0x0400002F RID: 47
	public Sprite emptyChest;

	// Token: 0x04000030 RID: 48
	public string[] message;
}