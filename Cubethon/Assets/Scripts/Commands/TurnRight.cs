using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cubethon.Command
{
    public class TurnRight : Command
    {
        private PlayerMovement _playerMovement;
        public TurnRight(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        public override void Execute()
        {
            _playerMovement.TurnRight();
        }
    }
}
