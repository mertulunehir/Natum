using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveController : MonoBehaviour {

	// PUBLIC
	public SimpleTouchController leftController;
	public SimpleTouchController rightController;
	public Transform headTrans;
	public float speedMovements = 0.1f;
	public float speedContinuousLook = 100f;
	public float speedProgressiveLook = 3000f;

   

    // PRIVATE
    private Rigidbody _rigidbody;
	[SerializeField] bool continuousRightController = true;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		rightController.TouchEvent += RightController_TouchEvent;
	}

	public bool ContinuousRightController
	{
		set{continuousRightController = value;}
	}

	void RightController_TouchEvent (Vector2 value)
	{
		if(!continuousRightController)
		{
			UpdateAim(value);
		}
	}

	void Update()
	{
		// move
		_rigidbody.MovePosition(transform.position + (transform.forward * leftController.GetTouchPosition.y * Time.deltaTime * speedMovements) +
			(transform.right * leftController.GetTouchPosition.x * Time.deltaTime * speedMovements) );


        

        if (continuousRightController)
		{
			UpdateAim(rightController.GetTouchPosition);
		}
	}

	void UpdateAim(Vector2 value)
	{

        if (_rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z)), Time.deltaTime * 20);
        }

        Quaternion rot = Quaternion.Euler(transform.localEulerAngles.x - value.y * Time.deltaTime * speedProgressiveLook,
				transform.localEulerAngles.y + value.x * Time.deltaTime * speedProgressiveLook,
				0f);

			_rigidbody.MoveRotation(rot);
		
	}

	void OnDestroy()
	{
		rightController.TouchEvent -= RightController_TouchEvent;
	}

}
