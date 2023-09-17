using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cubethon.Command
{
    public class TurnLeft : Command
    {
        private PlayerMovement _playerMovement;
        public TurnLeft(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        public override void Execute()
        {
            _playerMovement.TurnLeft();
        }
    }
}
