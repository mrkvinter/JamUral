using UnityEngine;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
        private bool jump;

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            jump = Input.GetButtonDown("Jump");
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