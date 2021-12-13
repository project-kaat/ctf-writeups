using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class CameraMotor : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		this.lookAt = GameObject.Find("Player").transform;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
	private void LateUpdate()
	{
		Vector3 zero = Vector3.zero;
		float num = this.lookAt.position.x - base.transform.position.x;
		if (num > this.boundX || num < -this.boundX)
		{
			if (base.transform.position.x < this.lookAt.position.x)
			{
				zero.x = num - this.boundX;
			}
			else
			{
				zero.x = num + this.boundX;
			}
		}
		float num2 = this.lookAt.position.y - base.transform.position.y;
		if (num2 > this.boundY || num2 < -this.boundY)
		{
			if (base.transform.position.y < this.lookAt.position.y)
			{
				zero.y = num2 - this.boundY;
			}
			else
			{
				zero.y = num2 + this.boundY;
			}
		}
		base.transform.position += new Vector3(zero.x, zero.y, 0f);
	}

	// Token: 0x04000001 RID: 1
	public Transform lookAt;

	// Token: 0x04000002 RID: 2
	public float boundX = 0.15f;

	// Token: 0x04000003 RID: 3
	public float boundY = 0.05f;
}