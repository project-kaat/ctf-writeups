using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
public abstract class Mover : Fighter
{
	// Token: 0x06000023 RID: 35 RVA: 0x00002836 File Offset: 0x00000A36
	protected virtual void Start()
	{
		this.bn = base.GetComponent<BoxCollider2D>();
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002844 File Offset: 0x00000A44
	protected virtual void o(Vector3 a)
	{
		this.bo = new Vector3(a.x * this.br, a.y * this.bq, 0f);
		if (this.bo.x > 0f)
		{
			base.transform.localScale = Vector3.one;
		}
		else if (this.bo.x < 0f)
		{
			base.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.bp = Physics2D.BoxCast(base.transform.position, this.bn.size, 0f, new Vector2(0f, this.bo.y), Mathf.Abs(this.bo.y * Time.deltaTime), LayerMask.GetMask(new string[]
		{
			"Actor",
			"Blocking"
		}));
		if (this.bp.collider == null)
		{
			base.transform.Translate(0f, this.bo.y * Time.deltaTime, 0f);
		}
		this.bp = Physics2D.BoxCast(base.transform.position, this.bn.size, 0f, new Vector2(this.bo.x, 0f), Mathf.Abs(this.bo.x * Time.deltaTime), LayerMask.GetMask(new string[]
		{
			"Actor",
			"Blocking"
		}));
		if (this.bp.collider == null)
		{
			base.transform.Translate(this.bo.x * Time.deltaTime, 0f, 0f);
		}
	}

	// Token: 0x0400002A RID: 42
	protected BoxCollider2D bn;

	// Token: 0x0400002B RID: 43
	protected Vector3 bo;

	// Token: 0x0400002C RID: 44
	protected RaycastHit2D bp;

	// Token: 0x0400002D RID: 45
	protected float bq = 0.5f;

	// Token: 0x0400002E RID: 46
	protected float br = 0.5f;
}