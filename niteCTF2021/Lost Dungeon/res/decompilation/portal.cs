using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200000F RID: 15
public class Portal : Collidable
{
	// Token: 0x0600002B RID: 43 RVA: 0x00002B01 File Offset: 0x00000D01
	protected override void b(Collider2D a)
	{
		if (a.name == "Wizard")
		{
			GameManager.instance.SaveState();
			SceneManager.LoadScene(this.sceneNames[Random.Range(2, this.sceneNames.Length)]);
		}
	}

	// Token: 0x04000031 RID: 49
	public string[] sceneNames;
}