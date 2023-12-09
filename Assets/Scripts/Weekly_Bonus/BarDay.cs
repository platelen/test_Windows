using UnityEngine;
using UnityEngine.UI;

namespace Weekly_Bonus
{
    public class BarDay : MonoBehaviour
    {
        [SerializeField] private Slider _sliderDay;


        public void SetMaxDay(int day)
        {
            _sliderDay.maxValue = day;
        }

        public void SetBarDay(int day)
        {
            day++;
            _sliderDay.value = day;
        }
    }
}