using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cubethon.Command
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker _invoker;
        private PlayerMovement _playermvmt;
        private Command _buttonA, _buttonD, _buttonUp;
        // Start is called before the first frame update
        void Start()
        {
            
            _invoker = gameObject.AddComponent<Invoker>();
            _invoker.Record();
            _playermvmt = FindObjectOfType<PlayerMovement>();
            _buttonA = new TurnLeft(_playermvmt);
            _buttonD = new TurnRight(_playermvmt);
            _buttonUp = new Jump(_playermvmt);
        }
        // Update is called once per frame
        void Update()
        {
            if (!_invoker._isReplaying && _invoker._isRecording)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    _invoker.ExecuteCommand(_buttonA);
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    _invoker.ExecuteCommand(_buttonD);
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    _invoker.ExecuteCommand(_buttonUp);
                }
            }
        }
    }
}
