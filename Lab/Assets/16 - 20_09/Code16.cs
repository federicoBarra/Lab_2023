using System.Collections.Generic;
using UnityEngine;

//public class Wave : ScriptableObject
//{
//	public int enemiesCountMax;
//	public int enemiesCountMin;

// public int enemiesCountMax; FIJO
//
//	public List<EnemyConfig> possibleEnemies;
//
//	public float timerMin;
//	public float timerMax;
//}
//
//public class LevelWaves : ScriptableObject
//{
//	public List<Wave> waves;
//}

public class Code16 : MonoBehaviour
{
	public enum EnemyState
	{
        Idle,
        FollowingPlayer,
        AttackingPlayer
	}

	public EnemyState currentState;

	public float attackDistance = 1;
	public float speed = 1;


	// Update is called once per frame
	void Update()
    {
		switch (currentState)
		{
			case EnemyState.Idle:
				// no hagas nada
				break;
			case EnemyState.FollowingPlayer:
				//hace follow del player
				// en algun momento hace SetState(AttackingPlayer)

				break;
			case EnemyState.AttackingPlayer:
				//atacá al player
				//si el player se aleja mucho SetState(FollowingPlayer)
				break;
		}

		fsm.Update();
	}

    void SetState(EnemyState es)
    {
		//Procesar que pasa en el estadoq ue estyo dejando
	    switch (currentState)
	    {
		    case EnemyState.Idle:
			    break;
		    case EnemyState.FollowingPlayer:
			    break;
		    case EnemyState.AttackingPlayer:
			    break;
	    }

		currentState = es;


		// procesar el entrando al siguiente estado
	    switch (currentState)
	    {
		    case EnemyState.Idle:
			    break;
		    case EnemyState.FollowingPlayer:
			    break;
		    case EnemyState.AttackingPlayer:
			    break;
	    }
    }

    private StateMachine fsm;

	void CreateStateMachine()
    {
	    fsm = new StateMachine();

		fsm.AddState<EnemyIdleState16>(new EnemyIdleState16(fsm));
		fsm.AddState<EnemyFollowingPlayerState16>(new EnemyFollowingPlayerState16(fsm));

		fsm.ChangeState<EnemyIdleState16>();
    }

    public class EnemyIdleState16 : State
    {
	    public EnemyIdleState16(StateMachine _machine) : base(_machine)
	    {
		    conditions.Add(typeof(LowHeathCondition), new LowHeathCondition(null));
		}

	    public override void Enter()
	    {
	    }

	    public override void Update()
	    {
			//if (CheckCondition<LowHeathCondition>())
			//{
			//	machine.ChangeState<EnemyFollowingPlayerState16>();
			//}

			//	CODIGO GIGANTE SOBRE si el player esta cerca y si esta cerca:
			// machine.ChangeState<EnemyFollowingPlayerState16>();

		}

		public override void Exit()
	    {
	    }
    }

    public class EnemyFollowingPlayerState16 : State
    {
	    public EnemyFollowingPlayerState16(StateMachine _machine) : base(_machine)
	    {
	    }

	    public override void Enter()
	    {
	    }

	    public override void Update()
	    {
		    //hace follow del player
		    // en algun momento hace SetState(AttackingPlayer)
		}

		public override void Exit()
	    {
	    }
    }




























	public Enemy enemigo01;
    public Enemy enemigo02;
    public Enemy enemigo03;
	void Awake()
    {
	    Dictionary<int, string> idConIntQueGuardaStrings = new Dictionary<int, string>();

		idConIntQueGuardaStrings.Add(0, "Pepe");
		idConIntQueGuardaStrings.Add(1, "Tito");


		Dictionary<string, List<Enemy>> nombreEnStringQueContieneUnaListaDeEnemigos = new Dictionary<string, List<Enemy>>();

		List<Enemy> idsDeEnemigosDeNacho = new List<Enemy>();
		idsDeEnemigosDeNacho.Add(enemigo01);
		idsDeEnemigosDeNacho.Add(enemigo02);

		List<Enemy> idsDeEnemigosDeDario = new List<Enemy>();
		idsDeEnemigosDeDario.Add(enemigo01);
		idsDeEnemigosDeDario.Add(enemigo03);

		nombreEnStringQueContieneUnaListaDeEnemigos.Add("Nacho", idsDeEnemigosDeNacho); // en mi caja no etiqueta "Nacho" pongo la lista de enemigos de nacho
		nombreEnStringQueContieneUnaListaDeEnemigos.Add("Dario", idsDeEnemigosDeDario);

		foreach (Enemy enemy in nombreEnStringQueContieneUnaListaDeEnemigos["Dario"])
		{
			
		}


		Dictionary<Recipe, List<Ingredient>> IngredientesNecesariosParaLaReceta = new Dictionary<Recipe, List<Ingredient>>();

		Recipe milanesa = new Recipe();
		milanesa.name = "Milanga";

		Recipe milanesaDePollo = new Recipe();
		milanesaDePollo.name = "Milanga";


		Ingredient panRallado = new Ingredient();
		panRallado.name = "Rallau";
		Ingredient huevo = new Ingredient();
		huevo.name = "Huevo";
		Ingredient carne = new Ingredient();
		carne.name = "Carnaza";

		IngredientesNecesariosParaLaReceta.Add(milanesa, new List<Ingredient>(){panRallado, huevo, carne});

		List<Ingredient> ingrefintesParaLamilanga = IngredientesNecesariosParaLaReceta[milanesa];

		List<Ingredient> ingrefintesParaLamilanga02;

		if (IngredientesNecesariosParaLaReceta.TryGetValue(milanesa, out ingrefintesParaLamilanga02))
		{
			//exite
			// llena esto ingrefintesParaLamilanga02
		}
		else
		{
			//no existe
		}

		if (IngredientesNecesariosParaLaReceta.ContainsKey(milanesa))
		{
			ingrefintesParaLamilanga = IngredientesNecesariosParaLaReceta[milanesa];
		}

		for (int i = 0; i < IngredientesNecesariosParaLaReceta.Count; i++)
		{
			//List<Ingredient> iList = IngredientesNecesariosParaLaReceta[i];

		}

		foreach (KeyValuePair<Recipe, List<Ingredient>> keyValuePair in IngredientesNecesariosParaLaReceta)
		{
			//keyValuePair.Key => va a ser la etiqueta;
			//keyValuePair.Value => esto va a ser la lista de ingredientes;
		}





		//foreach (var item in ingredientsInCauldron)
		//{
		//	if (!dict.TryAdd(item, 1))
		//		dict[item]++;
		//}
		//get primero
	}
}

public class Recipe
{
	public string name;
}

public class Ingredient
{
	public string name;
}
