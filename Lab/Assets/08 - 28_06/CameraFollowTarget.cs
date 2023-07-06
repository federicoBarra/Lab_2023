using UnityEngine;

namespace WC
{
	public class CameraFollowTarget : MonoBehaviour
	{
		public Transform target;
		public Vector3 offset;

		public float zoomSpeed = 2;
		[Range(0f, 1f)]
		public float zoomPercent = 0;
		float zoom = 0;

		public Vector3 minOffset;
		public Vector3 maxOffset;

		Vector3 finalOffset;

		[Header("CameraDamping")] 
		public bool enableDumping;
		public float dampingSpeed = 5;

		private Vector3 lastPos;
		public void CameraFocusOn(Transform target)
		{
			this.target = target;
			lastPos = target.transform.position;
		}

		void Update()
		{
			if (!enableDumping)
				return;

			if( target == null )
				return;

			if( target.gameObject == null ) // Some sanity check in case someone deletes the targeted game object
			{
				target = null;
				return;
			}
			zoomPercent = Mathf.Clamp01(zoomPercent);

			zoom = Mathf.Lerp(zoom, zoomPercent, zoomSpeed * Time.deltaTime);
			zoom = Mathf.Clamp01(zoom);
			
			finalOffset = offset;

			finalOffset.x = minOffset.x + (maxOffset.x - minOffset.x) * zoom;
			finalOffset.y = minOffset.y + (maxOffset.y - minOffset.y) * zoom;
			finalOffset.z = minOffset.z + (maxOffset.z - minOffset.z) * zoom;

			lastPos = Vector3.Lerp(lastPos, target.transform.position, dampingSpeed * Time.deltaTime);

			transform.position = lastPos + finalOffset;
			transform.LookAt(lastPos);
		}

		void LateUpdate()
		{
			if (enableDumping)
				return;

			if (target == null)
				return;

			if (target.gameObject == null) // Some sanity check in case someone deletes the targeted game object
			{
				target = null;
				return;
			}
			zoomPercent = Mathf.Clamp01(zoomPercent);

			zoom = Mathf.Lerp(zoom, zoomPercent, zoomSpeed * Time.deltaTime);
			zoom = Mathf.Clamp01(zoom);

			finalOffset = offset;

			finalOffset.x = minOffset.x + (maxOffset.x - minOffset.x) * zoom;
			finalOffset.y = minOffset.y + (maxOffset.y - minOffset.y) * zoom;
			finalOffset.z = minOffset.z + (maxOffset.z - minOffset.z) * zoom;

			lastPos = target.transform.position;

			transform.position = lastPos + finalOffset;
			transform.LookAt(lastPos);
		}

	}
}
