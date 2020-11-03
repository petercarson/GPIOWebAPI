using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Device.Gpio;

namespace GPIOWebAPI
{
    internal static class GPIOArray
    {
        public const bool EMULATOR = true;

        public static GPIO[] gpioArray = new GPIO[]
                {
                    new GPIO(1, 13, "HW Tank", PinMode.Output, 0),
                    new GPIO(2, 21, "Rads", PinMode.Output, 0),
                    new GPIO(3, 26, "Floor Heat", PinMode.Output, 0),
                    new GPIO(4, 27, "Ensuite Return", PinMode.Output, 0)
                };

        // public static GpioController gpioController;

        public static void InitializeGPIO()
        {
            if (!GPIOArray.EMULATOR)
            {
                // GPIOArray.gpioController = new GpioController();
            }
        }
    }
}
