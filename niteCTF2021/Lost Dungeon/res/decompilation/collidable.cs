using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class Collidable : MonoBehaviour
{
	// Token: 0x06000007 RID: 7 RVA: 0x000021DE File Offset: 0x000003DE
	protected virtual void Start()
	{
		this.q = base.GetComponent<BoxCollider2D>();
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000021EC File Offset: 0x000003EC
	protected virtual void Update()
	{
		this.q.OverlapCollider(this.filter, this.r);
		for (int i = 0; i < this.r.Length; i++)
		{
			if (!(this.r[i] == null))
			{
				this.b(this.r[i]);
				this.r[i] = null;
			}
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x0000224B File Offset: 0x0000044B
	protected virtual void b(Collider2D a)
	{
	}

	// Token: 0x04000005 RID: 5
	public ContactFilter2D filter;

	// Token: 0x04000006 RID: 6
	private BoxCollider2D q;

	// Token: 0x04000007 RID: 7
	private Collider2D[] r = new Collider2D[10];
}