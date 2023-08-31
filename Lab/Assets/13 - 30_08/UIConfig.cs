using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIConfig", menuName = "Test/UIConfig")]
public class UIConfig : ConfigSingleton<UIConfig>
{
	public Color titleColor;
	public Sprite nullImage;
}
