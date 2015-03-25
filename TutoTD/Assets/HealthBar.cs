using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public GameObject healthBar;
	public Color goodColor;
	public Color middleColor;
	public Color badColor;

	void Start()
	{
		SetColor(1);
	}

	public void SetDamages(float value)
	{
		healthBar.GetComponent<Scrollbar>().size -= value;
		float totalValue = healthBar.GetComponent<Scrollbar> ().size;
		SetColor(totalValue);
	}

	void SetColor(float value)
	{
		if (value >= 0.5f) 
		{
			healthBar.transform.FindChild ("Mask").FindChild ("Sprite").GetComponent<Image> ().color = goodColor;
		} else if (value >= 0.25f && value < 0.5f) 
		{
			healthBar.transform.FindChild ("Mask").FindChild ("Sprite").GetComponent<Image> ().color = middleColor;
		} else 
		{
			healthBar.transform.FindChild ("Mask").FindChild ("Sprite").GetComponent<Image> ().color = badColor;

		}
	}
}
