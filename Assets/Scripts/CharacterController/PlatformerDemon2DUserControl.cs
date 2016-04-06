using UnityEngine;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof(PlayerMonsterMove2D))]
    public class PlatformerDemon2DUserControl : MonoBehaviour
    {
        private PlayerMonsterMove2D character;
        private bool jump;

        private void Awake()
        {
            character = GetComponent<PlayerMonsterMove2D>();
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {

            // Read the inputs.
            var crouch = Input.GetKey(KeyCode.LeftControl);
            var h = Input.GetAxis("Horizontal");
            var w = Input.GetAxis("Vertical");
            // Pass all parameters to the character control script.
            character.Move(new Vector2(h, w), crouch, jump);
            jump = false;
        }
    }
}