using System.Collections.Generic;
using UnityEngine;
//XXX Implementacion Naive
public interface IPoolable
{
	void PoolInstantiation();
	void Restart();
	GameObject gameObject { get;}
	void Recycle();
}

public class PoolManager : MonoBehaviourSingleton<PoolManager>
{
	public GameObject bulletPrefab;
	public int amount;
	List<IPoolable> availableBullets = new List<IPoolable>();
	List<IPoolable> bulletsInUse = new List<IPoolable>();

	public override void Awake()
	{
		base.Awake();

		for (int i = 0; i < amount; i++)
		{
			GameObject go = Instantiate(bulletPrefab);
			IPoolable b = go.GetComponent<IPoolable>();
			b.PoolInstantiation();
			availableBullets.Add(b);
		}
	}

    public IPoolable GetBulletFromPool()
    {
	    IPoolable p = availableBullets[0];
	    availableBullets.Remove(p);
	    bulletsInUse.Add(p);
		p.Restart();

		return p;
    }

    public void ReturnToPool(IPoolable poolable)
    {
	    bulletsInUse.Remove(poolable);
		availableBullets.Add(poolable);
    }

}
