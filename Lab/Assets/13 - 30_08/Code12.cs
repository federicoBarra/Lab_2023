using UnityEngine;
using UnityEngine.UI;

public class Code12 : MonoBehaviour
{
	public Image image;

	public float goldAmount;
	public string playerName;

	public SaveConfig.EnumSaveStrategy loadingStrategy;
	public SettingsDataSO testSave;

	// Start is called before the first frame update
	void Start()
    {
	    image.color = UIConfig.Get().titleColor;

		if (image.sprite == null)
			image.sprite = UIConfig.Get().nullImage;


		SaveConfig.Get().SetLoadStrategy(loadingStrategy);
		SaveConfig.Get().SetSO(testSave);
	}

	public void Save()
    {
	    SaveData sd = SaveConfig.Get().SaveData;

	    sd.gold = goldAmount;
	    sd.playerName = playerName;
		SaveConfig.Get().Save();
    }

    public void Load()
    {
	    SaveConfig.Get().Load();
	    SaveData sd = SaveConfig.Get().SaveData;

		goldAmount = sd.gold;
		playerName = sd.playerName;
    }
}


