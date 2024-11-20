using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;

public class Agent : MonoBehaviour
{
	#region Properties

	public SlotButtonUI destiny { get; set; }
	[field: SerializeField] public float RepeatRate { get; set; }
	#endregion

	#region Fields
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
  {
		if(gameObject != null)
		{
			Movement();
			InvokeRepeating(nameof(Click), 1, RepeatRate);
			SlotButtonUI.OnSlotClicked += SetDestiny;

		}
    }

	private void SetDestiny(SlotButtonUI newDestiny)
	{
		if(gameObject != null)
		{
			destiny = newDestiny;
			Movement();

		}
	}

	private void Click()
	{
		destiny.Click(1, true);
		//Only Angel
   
		if (destiny.ClicksLeft < 0 && gameObject != null)
			Destroy(gameObject); // LUEGO INTENTA VOLVER A ACCEDER A EL, ¿Desactivar? 
	}

	// Update is called once per frame
	void Update()
    {
        
    }
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	protected void Movement()
	{
		if(gameObject != null)
		transform.DOMove(destiny.transform.position, 1);
	}

	IEnumerator AngelsOut()
	{
		yield return new WaitForSeconds(10);
		this.gameObject.SetActive(false);
	}
	#endregion   
}
