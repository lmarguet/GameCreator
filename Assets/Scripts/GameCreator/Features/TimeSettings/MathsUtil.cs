using UnityEngine;

namespace GameCreator.Features.TimeSettings
{
    public static class MathsUtil
    {
        const float KelvinOffset = 273.15f; 
        
        public static int ConvertKelvinToCelsius(float kelvinTemperature)
        {
            return Mathf.RoundToInt(kelvinTemperature - KelvinOffset);
        }
    }
}