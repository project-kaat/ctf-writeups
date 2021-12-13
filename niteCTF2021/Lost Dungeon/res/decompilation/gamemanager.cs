using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200000B RID: 11
public class GameManager : MonoBehaviour
{
	// Token: 0x0600001D RID: 29 RVA: 0x0000274C File Offset: 0x0000094C
	private void Awake()
	{
		if (GameManager.instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		PlayerPrefs.DeleteAll();
		GameManager.instance = this;
		SceneManager.sceneLoaded += this.n;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002799 File Offset: 0x00000999
	public void l()
	{
		this.player.transform.position = GameObject.Find("RespawnPoint").transform.position;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x000027BF File Offset: 0x000009BF
	public void m(string a, int b, Color c, Vector3 d, Vector3 e, float f)
	{
		this.floatingTextManager.j(a, b, c, d, e, f);
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000027D8 File Offset: 0x000009D8
	public void SaveState()
	{
		string text = "";
		text += this.coins.ToString();
		PlayerPrefs.SetString("SaveState", text);
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00002808 File Offset: 0x00000A08
	public void n(Scene a, LoadSceneMode b)
	{
		this.player.transform.position = GameObject.Find("SpawnPoint").transform.position;
	}

	// Token: 0x04000026 RID: 38
	public static GameManager instance;

	// Token: 0x04000027 RID: 39
	public Player player;

	// Token: 0x04000028 RID: 40
	public FloatingTextManager floatingTextManager;

	// Token: 0x04000029 RID: 41
	public int coins;
}