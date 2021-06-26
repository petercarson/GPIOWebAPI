using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Device.Gpio;

namespace GPIOWebAPI
{
  internal static class GPIOArray
  {
    private const int FRONT_YARD = 0;
    private const int SIDE_YARD = 1;
    private const int GRASS_STRIP = 2;
    private const int BACKYARD_RIGHT = 3;
    private const int BACKYARD_CENTRE = 4;
    private const int BACK_GARDENS = 5;

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
          new GPIO(FRONT_YARD + 1, 7, "Front Yard", PinMode.Output, 1),
          new GPIO(SIDE_YARD + 1, 2, "Side Yard", PinMode.Output, 1),
          new GPIO(GRASS_STRIP + 1, 4, "Grass Strip", PinMode.Output, 1),
          new GPIO(BACKYARD_RIGHT + 1, 5, "Backyard Right", PinMode.Output, 1),
          new GPIO(BACKYARD_CENTRE + 1, 3, "Backyard Centre", PinMode.Output, 1),
          new GPIO(BACK_GARDENS + 1, 6, "Back Gardens", PinMode.Output, 1)
        };
      }
  }
}
