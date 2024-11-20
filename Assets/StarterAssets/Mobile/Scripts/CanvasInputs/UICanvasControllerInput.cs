using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private float _speed = 1;
        [SerializeField] private SpriteRenderer _player;
        private Vector2 _movement;

		private void Update()
		{
            //Si hay movimientohacemos translate en elspaci Workld, para que la rotacion no nos afecte
			if (_movement.magnitude > 0)
                _player.transform.Translate(_movement, Space.World);
		}

		//Movement Joystick
		public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            //Guardamos la cantidad de movimiento
            _movement = virtualMoveDirection * Time.deltaTime * _speed;
        }

        //Rotation Joystick (podría ser shoot)
        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            //Si hay direccion la aplicamos al player a su eje Up
            if (virtualLookDirection != Vector2.zero)
			{
                _player.transform.up = new Vector2(virtualLookDirection.x, -virtualLookDirection.y);
                //Instanciamos la bala en la posición del player + 1 en up. Damos a la bala la rotación del player. 
                Instantiate(_bullet, _player.transform.position + _player.transform.up, _player.transform.rotation);
            }
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            _player.color = Color.black;
        }

        public void VirtualSprintInput(bool virtualSprintState)

        {
            _player.color = Color.blue;
            
        }
    }
}
