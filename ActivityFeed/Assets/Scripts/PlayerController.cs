using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
   public class PlayerController : MonoBehaviour
    {
        public event EmptyDelegate OnJump;
        public void update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (OnJump != null)
                    OnJump();
            }
        }
    }
}
