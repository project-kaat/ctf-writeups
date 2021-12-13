using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000009 RID: 9
public class FloatingTextManager : MonoBehaviour
{
	// Token: 0x06000015 RID: 21 RVA: 0x000025C3 File Offset: 0x000007C3
	private void Start()
	{
		Object.DontDestroyOnLoad(base.transform.parent.gameObject);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000025DC File Offset: 0x000007DC
	private void Update()
	{
		foreach (a a in this.bm)
		{
			a.h();
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x0000262C File Offset: 0x0000082C
	public void j(string a, int b, Color c, Vector3 d, Vector3 e, float f)
	{
		a a2 = this.k();
		a2.bg.text = a;
		a2.bg.fontSize = b;
		a2.bg.color = c;
		a2.bf.transform.position = Camera.main.WorldToScreenPoint(d);
		a2.bh = e;
		a2.bi = f;
		a2.f();
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002694 File Offset: 0x00000894
	private a k()
	{
		a a = this.bm.Find(new Predicate<a>(FloatingTextManager.<>c.bk.i));
		if (a == null)
		{
			a = new a();
			a.bf = Object.Instantiate<GameObject>(this.textPrefab);
			a.bf.transform.SetParent(this.textContainer.transform);
			a.bg = a.bf.GetComponent<Text>();
			this.bm.Add(a);
		}
		return a;
	}

	// Token: 0x04000021 RID: 33
	public GameObject textContainer;

	// Token: 0x04000022 RID: 34
	public GameObject textPrefab;

	// Token: 0x04000023 RID: 35
	private List<a> bm = new List<a>();
}