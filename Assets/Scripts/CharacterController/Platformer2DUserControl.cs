using UnityEngine;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
        private bool jump;

        public bool IsDemon;

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!jump)
                jump = Input.GetButtonDown("Jump");
        }

        private void FixedUpdate()
        {

            // Read the inputs.
            var crouch = Input.GetKey(KeyCode.LeftControl);
            var h = Input.GetAxis("Horizontal");
            var w = Input.GetAxis("Vertical");
            //jump = Input.GetButtonDown("Jump");
            // Pass all parameters to the character control script.
            if (!IsDemon)
                character.Move(new Vector2(h, w), crouch, jump);
            else
                character.Move(Vector2.zero, false, false);
            jump = false;
        }
    }
}