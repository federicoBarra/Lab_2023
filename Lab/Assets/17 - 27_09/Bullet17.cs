using UnityEngine;

public class Bullet17 : MonoBehaviour, IPoolable
{
	private Rigidbody rig;
	public float force = 10;
	public float destroyIn = 3;
    void Awake()
    {
	    rig = GetComponent<Rigidbody>();
    }

    public void PoolInstantiation()
    {
		rig.Sleep();
		gameObject.SetActive(false);
	}

    public void Restart()
    {
        transform.position = Vector3.up;
	    gameObject.SetActive(true);
		rig.WakeUp();
		Invoke(nameof(Recycle), destroyIn);
    }

    public void ShootForward()
    {
        rig.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }

    public void Recycle()
    {
	    rig.Sleep();
        gameObject.SetActive(false);
		PoolManager.Get().ReturnToPool(this);
    }
}
