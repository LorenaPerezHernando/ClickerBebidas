using UnityEngine;
using System;
using DG.Tweening;
using TMPro;

public class PointsElementUI : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private TextMeshProUGUI _clicksText;
	[SerializeField] private float _duration = 3;
	private GameController _game;
	
	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_game = FindObjectOfType<GameController>();
	}
	// Start is called before the first frame update
	void Start()
    {
		DoEffect();
    }

	private void DoEffect()
	{
		_clicksText.transform.Translate(Vector3.back);
		//Set Clicks text
		_clicksText.text = "+" + _game.ClickRatio.ToString();

		//Mov
		transform.DOMoveY(transform.position.y + UnityEngine.Random.Range(100, 500), _duration);


		//Color Fade
		_clicksText.DOColor(new Color(0, 0, 0, 0), _duration);

		// Parámetros del movimiento sinusoidal
		_game.Pool.AddToPool(this, _duration);
	}

	// Update is called once per frame
	public void Initialize(Transform transformClick)
    {
		_clicksText.color = Color.white;
		gameObject.SetActive(true);
		transform.parent = transformClick;
		transform.localPosition = Vector3.zero;
		DoEffect();
	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion   
}
