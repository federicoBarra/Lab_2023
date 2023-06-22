using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Transitioner : MonoBehaviour
{
	//ESTE CODIGO ES BASTANTE CACIUJA

	public GameObject player;
	public GameObject floorPrefab;
	public float floorPrefabLength = 10;
	public Vector3 playerEnterPos;

	public float generatedFloorLength;
	public float visibilityOffset = 20;

	public bool loadingScene;

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		LoaderManager.OnLevelFinishedLoading += EndProcess;
	}

	void OnDisable()
	{
		LoaderManager.OnLevelFinishedLoading -= EndProcess;
	}

	// Update is called once per frame
    void Update()
    {
		if (!loadingScene)
			return;

	    if ((player.transform.position - playerEnterPos).x + visibilityOffset > generatedFloorLength)
		    GenerateFloor();

	    if (LoaderManager.Get().loadingProgress >= 1)
		    EndProcess();

		//if (PlayerHealth<0) // ESTO NOOOOOOO!!!!
		//endlevel
    }

    void OnTriggerEnter(Collider other)
    {
		Debug.Log("OnTriggerEnter");

        if (loadingScene)
            return;
	    if (other.gameObject == player)
		    StartProcess();
    }

    void StartProcess()
    {
	    loadingScene = true;
	    playerEnterPos = player.transform.position;
	    GenerateFloor();
		LoaderManager.Get().LoadScene("Level 02");
    }

    void GenerateFloor()
    {
	    GameObject newFloor = Instantiate(floorPrefab, transform.position + Vector3.right * generatedFloorLength, Quaternion.identity);
	    generatedFloorLength += floorPrefabLength;
		newFloor.transform.parent = transform;
    }

    void EndProcess()
    {
	    loadingScene = false;
	    Vector3 playerPos = player.transform.position;

		// aca teleporteo el player y el contenido de este objeto.
	    float distance = (playerPos - transform.position).x;
	    transform.position = -Vector3.right * generatedFloorLength;
		player.transform.position = new Vector3(transform.position.x + distance, playerPos.y, playerPos.z);
	}
}


/*
 public delegate void ActionDefinidaPorMi(Enemy_Health enemy);
	
	public static ActionDefinidaPorMi OnEnemyDestroyed01;
	public static event Action<Enemy_Health> OnEnemyDestroyed02;


	private Action punteroAFuncion;
	void UsandoPunterosAfuncion()
	{
		punteroAFuncion += Metodo;
		punteroAFuncion += Metodo02;

		//punteroAFuncion -= Metodo;
		//punteroAFuncion -= Metodo02;

		punteroAFuncion(); // es lo mismo que hacer Metodo();
	}

	void Metodo()
	{
        Debug.Log("Metodo");
	}
	void Metodo02()
	{
		Debug.Log("Metodo02");
	}
 * */



/*
 *
 *
public class AchievementSystem
{
	private Dictionary<int, int> achievements; // [id, count]

	void AddCounter(int id, int count)
	{

	}
}


public class ThisGameAchievements
{
	void Start()
	{
        Enemy_Health.OnEnemyDestroyed02 += TankDied;
	}

	private void TankDied(Enemy_Health obj)
	{
		//AchievementSystem.addCounter(id, 1)
		//agrego el achievemente
	}
}

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] private float Maxhealth;
    [SerializeField] private float health;
    [SerializeField] private bool isAlive;
    [SerializeField] private bool DestroyWhenDie;

	public static event Action<Enemy_Health> OnEnemyDestroyed02;

	private void Start()
    {
		health = Maxhealth;
        isAlive = true;
    }
    private void Update()
    {
        if (health <= 0)
        {
            isAlive = false;
            //AchievemetnManager.Get().addTankDestro() NOOOOOOOO
            OnEnemyDestroyed02?.Invoke(this);
		}

        if (!isAlive && DestroyWhenDie)
        {
            Destroy(gameObject);
        }
    }
    public void GetDamage(float damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public float GetMaxHealth()
    {
        return Maxhealth;
    }
}
*
 * */