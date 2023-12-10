using UnityEngine;

namespace Shop
{
    public class BankTicketsPlayer : MonoBehaviour
    {
        [SerializeField] private float _bankTicketsPlayer = 10000;

        public float TicketsPlayer => _bankTicketsPlayer;
    }
}
