using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000008 RID: 8
public class a
{
	// Token: 0x06000011 RID: 17 RVA: 0x0000251F File Offset: 0x0000071F
	public void f()
	{
		this.be = true;
		this.bj = Time.time;
		this.bf.SetActive(this.be);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002544 File Offset: 0x00000744
	public void g()
	{
		this.be = false;
		this.bf.SetActive(this.be);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002560 File Offset: 0x00000760
	public void h()
	{
		if (!this.be)
		{
			return;
		}
		if (Time.time - this.bj > this.bi)
		{
			this.g();
		}
		this.bf.transform.position += this.bh * Time.deltaTime;
	}

	// Token: 0x0400001B RID: 27
	public bool be;

	// Token: 0x0400001C RID: 28
	public GameObject bf;

	// Token: 0x0400001D RID: 29
	public Text bg;

	// Token: 0x0400001E RID: 30
	public Vector3 bh;

	// Token: 0x0400001F RID: 31
	public float bi;

	// Token: 0x04000020 RID: 32
	public float bj;
}