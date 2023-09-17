using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cubethon.Command
{
    public class Jump : Command
    {
        private PlayerMovement _playerMovement;
        public Jump(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        public override void Execute()
        {
            _playerMovement.Jump();
        }
    }
}
