using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveConfig", menuName = "Test/SaveConfig")]
public class SaveConfig : ConfigSingleton<SaveConfig>
{
	public string saveFileName = "save";
	private SaveData currentSave = new SaveData();
	public SettingsDataSO testSave;

	public enum EnumSaveStrategy
	{
		PlayerPrefs,
		File,
		Steam,
		SettingsDataSO
	}

	public EnumSaveStrategy saveStrategy;
	public EnumSaveStrategy loadStrategy;

	public SaveData SaveData
	{
		get
		{
			if (currentSave == null)
				currentSave = new SaveData();
			return currentSave;
		}
	}

	public void Save()
	{
#if UNITY_EDITOR

		switch (saveStrategy)
		{
			case EnumSaveStrategy.PlayerPrefs:
				new SavePlayerPrefStrategy().Save(currentSave, saveFileName);
				break;
			case EnumSaveStrategy.File:
				new SaveFileStrategy().Save(currentSave, saveFileName);
				break;
			case EnumSaveStrategy.Steam:
				new SaveSteamStrategy().Save(currentSave, saveFileName);
				break;
		}
#else
	new SaveFileStrategy().Save(currentSave, saveFileName);
#endif


	}

	public void Load()
	{
		SaveStrategy strat = null;

		//QUE PROBLEMA HAY CON ESTO
		switch (loadStrategy)
		{
			case EnumSaveStrategy.PlayerPrefs:
				strat = new SavePlayerPrefStrategy();
				break;
			case EnumSaveStrategy.File:
				strat = new SaveFileStrategy();
				break;
			case EnumSaveStrategy.Steam:
				strat = new SaveSteamStrategy();
				break;
			case EnumSaveStrategy.SettingsDataSO:
				strat = new SaveSettingDataSOStrategy(testSave.saveData);
				break;
		}
		if (strat != null)
			currentSave = strat.Load(saveFileName);

		//currentSave = new SaveFileStrategy().Load(saveFileName); 
	}

	public void SetSO(SettingsDataSO so)
	{
		testSave = so;
	}

	public void SetLoadStrategy(EnumSaveStrategy _loadStrategy)
	{
		loadStrategy = _loadStrategy;
	}

}

[Serializable]
public class SaveData //: ICloneable
{
	public float gold = 1;
	public string playerName = "";

	public List<int> itemsIDs = new List<int>();

	public int enemyMaxCount = 10;

	public float playerHealth;
	public int playerLevel;


	//public object Clone()
	//{
	//	return this.MemberwiseClone();
	//}
}

public interface SaveStrategy
{
	void Save(SaveData sd, string fileName);
	SaveData Load(string fileName);
}

public class SavePlayerPrefStrategy : SaveStrategy
{
	public void Save(SaveData sd, string fileName)
	{
		string json = JsonUtility.ToJson(sd);

		Debug.Log(json);

		PlayerPrefs.SetString(fileName, json);
	}

	public SaveData Load(string fileName)
	{
		string data02 = PlayerPrefs.GetString(fileName);

		SaveData sd = JsonUtility.FromJson<SaveData>(data02);

		return sd;
	}
}

public class SaveFileStrategy : SaveStrategy
{
	public void Save(SaveData sd, string fileName)
	{
		string destination = Application.persistentDataPath + "/" + fileName + ".dat";

		Debug.Log("Saving to: " + destination);

		FileStream file;

		if (File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);

		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(file, sd);
		file.Close();
	}

	public SaveData Load(string fileName)
	{
		string destination = Application.persistentDataPath + "/" + fileName + ".dat";
		
		Debug.Log("Loading from: " + destination);

		FileStream file;

		if (File.Exists(destination)) file = File.OpenRead(destination);
		else
		{
			Debug.LogError("File not found");
			return null;
		}

		BinaryFormatter bf = new BinaryFormatter();
		SaveData data = (SaveData)bf.Deserialize(file);
		file.Close();

		return data;
	}
}

public class SaveSteamStrategy : SaveStrategy
{
	public void Save(SaveData sd, string fileName)
	{
		//Accedé a Steam Cloud y pim pam pum
	}

	public SaveData Load(string fileName)
	{
		//Accedé a Steam Cloud y pim pam pum
		return null;
	}
}

public class SaveSettingDataSOStrategy : SaveStrategy
{
	private SaveData save;

	public SaveSettingDataSOStrategy(SaveData _save)
	{
		save = _save;
	}

	public void Save(SaveData sd, string fileName)
	{
		//throw new NotImplementedException();
	}

	public SaveData Load(string fileName)
	{
		return save;
	}
}
