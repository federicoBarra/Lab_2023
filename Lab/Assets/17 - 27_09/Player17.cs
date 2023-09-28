using UnityEngine;
using UnityEngine.InputSystem;

public class Player17 : MonoBehaviour
{
    void Update()
    {
	    if (Keyboard.current.spaceKey.wasPressedThisFrame)
	    {
		    IPoolable recycledBullet = PoolManager.Get().GetBulletFromPool();
		    Bullet17 bullet = (Bullet17)recycledBullet;
		    bullet.ShootForward();
		}
    }
}
