using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Device.Gpio;

namespace GPIOWebAPI
{
    internal static class GPIOArray
    {
        public const int PUMP_HW_TANK = 0;
        public const int PUMP_RADS = 1;
        public const int PUMP_FLOOR_HEAT = 2;
        public const int PUMP_ENSUITE_RETURN = 3;
        public const int SOLENOID_MASTER_ENSUITE = 4;
        public const int SOLENOID_BASEMENT_FLOOR = 5;
        public const int SOLENOID_KATE_BEDROOM = 6;
        public const int SOLENOID_KATE_BATHROOM = 7;
        public const int SOLENOID_MEDIA_ROOM = 8;
        public const int THERMOSTAT_MASTER_ENSUITE = 9;
        public const int THERMOSTAT_BASEMENT = 10;

        public static bool EMULATOR = false;

        public static GPIO[] gpioArray;

        public static GpioController gpioController;

        public static void InitializeGPIO()
        {
            try
            {
                gpioController = new GpioController();
            }
            catch
            {
                EMULATOR = true;
            }

            gpioArray = new GPIO[]
                {
                    new GPIO(PUMP_HW_TANK + 1, 13, "Pump HW Tank", PinMode.Output, 0),
                    new GPIO(PUMP_RADS + 1, 21, "Pump Rads", PinMode.Output, 1),
                    new GPIO(PUMP_FLOOR_HEAT + 1, 26, "Pump Floor Heat", PinMode.Output, 0),
                    new GPIO(PUMP_ENSUITE_RETURN + 1, 27, "Pump Ensuite Return", PinMode.Output, 1),
                    new GPIO(SOLENOID_MASTER_ENSUITE + 1, 17, "Solenoid Master Ensuite", PinMode.Output, 0),
                    new GPIO(SOLENOID_BASEMENT_FLOOR + 1, 18, "Solenoid Basement Floor", PinMode.Output, 0),
                    new GPIO(SOLENOID_KATE_BEDROOM + 1, 19, "Solenoid Kate Bedroom", PinMode.Output, 1),
                    new GPIO(SOLENOID_KATE_BATHROOM + 1, 20, "Solenoid Kate Bathroom", PinMode.Output, 1),
                    new GPIO(SOLENOID_MEDIA_ROOM + 1, 11, "Solenoid Media Room", PinMode.Output, 1),
                    new GPIO(THERMOSTAT_MASTER_ENSUITE + 1, 24, "Thermostat Master Ensuite", PinMode.InputPullUp, 0),
                    new GPIO(THERMOSTAT_BASEMENT + 1, 25, "Thermostat Basement", PinMode.InputPullUp, 0),
                };
        }
    }
}
