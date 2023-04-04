using UnityEngine;

namespace Services.InputService
{
    public class StandaloneInputService : IInputService
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        public Vector3 Axis => new(Input.GetAxis(HorizontalAxisName), Input.GetAxis(VerticalAxisName));
    }
}