using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.Hexart
{
    public class UIElementInFront : MonoBehaviour
    {
        void Start()
        {
            this.transform.SetAsFirstSibling();
        }
    }
}