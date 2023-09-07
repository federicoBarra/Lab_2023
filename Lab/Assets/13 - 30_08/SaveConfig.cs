using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

	void OnValidate()
	{
		Debug.Log("OnValidate");
		var type = typeof(SaveStrategy);
		var types = AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(s => s.GetTypes())
			.Where(p => type.IsAssignableFrom(p));

		//PrintAssemblies();
		//PrintAllAssemblyTypes();
		//PrintTypesImplementingSaveStrategy()
		//PrintClassInfo();

		SaveStrategy ss = (SaveStrategy)Activator.CreateInstance(types.ToList()[2]);
		Debug.Log("current playerName: " + ss.Load(saveFileName).playerName);
	}

	void PrintAssemblies()
	{
		Debug.Log("-------------------------------------------------------");
		var types = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in types)
		{
			Debug.Log("Assembly: " + assembly.FullName);
		}
	}

	void PrintAllAssemblyTypes()
	{
		Debug.Log("-------------------------------------------------------");
		var types = AppDomain.CurrentDomain.GetAssemblies();
		List<Assembly> assemblies = types.ToList();
		var assemblyTypes = assemblies[1].GetTypes();

		int i = 0;
		foreach (Type type in assemblyTypes)
		{
			Debug.Log("type: " + type.FullName);
			i++;
			if (i > 1000)
				break;
		}
	}

	void PrintTypesImplementingSaveStrategy()
	{
		Debug.Log("-------------------------------------------------------");
		var type = typeof(SaveStrategy);
		var types = AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(s => s.GetTypes())
			.Where(p => type.IsAssignableFrom(p));

		foreach (Type strategy in types)
		{
			Debug.Log("type: " + strategy);
		}
	}

	void PrintClassInfo()
	{
		Debug.Log("-------------------------------------------------------");

		var type = typeof(SaveConfig);
		var methods = type.GetRuntimeMethods();

		foreach (MethodInfo info in methods)
		{
			string data = "Method: " + info.Name + " => params: ";
			foreach (ParameterInfo parameter in info.GetParameters())
			{
				data += " p: " + parameter.Name + " - " + parameter.ParameterType.Name;
			}
			Debug.Log(data);
		}
		//OTRAS FORMAS DE ACCEDER
		//Type type = assembly.GetType("MyNamespace.MyType");
		//FieldInfo field = type.GetField("fieldName");
		//PropertyInfo property = type.GetProperty("propertyName");
		//MethodInfo method = type.GetMethod("methodName");
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

	public List<string> StrategyTypes
	{
		get
		{
			var type = typeof(SaveStrategy);
			var types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => type.IsAssignableFrom(p));
			List<string> stringList = new List<string>();
			foreach (Type strategy in types)
			{
				stringList.Add(strategy.Name);
			}
			return stringList;
		}
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

