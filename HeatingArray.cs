﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Timers;

namespace GPIOWebAPI
{
  internal static class HeatingArray
  {
    public const int BASEMENT_FLOOR = 0;
    public const int MASTER_ENSUITE = 1;
    public const int KATE_BEDROOM = 2;
    public const int KATE_BATHROOM = 3;
    public const int MEDIA_ROOM = 4;
    public const int BASEMENT_BATHROOM = 5;
    public const int BRETT_BATHROOM = 6;

    public static Heating[] heatingArray;
    private static System.Timers.Timer heatingTimer;


    public static void InitializeHeating()
    {
      heatingArray = new Heating[]
        {
      new Heating(BASEMENT_FLOOR + 1, "Basement Floor", 24, 25, true),
      new Heating(MASTER_ENSUITE + 1, "Master Ensuite", 24, 25, true),
      new Heating(KATE_BEDROOM + 1, "Kate Bedroom", 24, 25, false),
      new Heating(KATE_BATHROOM + 1, "Kate Bathroom", 24, 25, false),
      new Heating(MEDIA_ROOM + 1, "Media Room", 24, 25, false),
      new Heating(BASEMENT_BATHROOM + 1, "Basement Bathroom", 24, 22, true),
      new Heating(BRETT_BATHROOM + 1, "Brett Bathroom", 24, 25, true)
        };

      // Create a timer with a two second interval.
      heatingTimer = new System.Timers.Timer(2000);
      // Hook up the Elapsed event for the timer. 
      heatingTimer.Elapsed += OnTimedEvent;
      heatingTimer.AutoReset = true;
      heatingTimer.Enabled = true;
      OnTimedEvent(null, null);
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
      // Start by assuming that all the pumps will be off (High) unless one of the systems needs them
      int valuePumpHWTank = 1,
        valuePumpFloorHeat = 1,
        valuePumpRads = 1;

      // Master ensuite thermostat is calling for heat
      if (heatingArray[HeatingArray.MASTER_ENSUITE].CurrentTemperature < heatingArray[HeatingArray.MASTER_ENSUITE].SetTemperature)
      {
        // Master ensuite needs the hot water tank and floor heat pumps
        valuePumpHWTank = 0;
        valuePumpFloorHeat = 0;
        // Open the solenoid for the master ensuite floor heat
        GPIOArray.gpioArray[GPIOArray.SOLENOID_MASTER_ENSUITE].Value = 0;
      }
      // No heat needed for the master ensuite
      else
      {
        // Close the solenoid for the master ensuite floor heat
        GPIOArray.gpioArray[GPIOArray.SOLENOID_MASTER_ENSUITE].Value = 1;
      }

      // Basement thermostat is calling for heat
      if (heatingArray[HeatingArray.BASEMENT_FLOOR].Enabled)
      {
        if (heatingArray[HeatingArray.BASEMENT_FLOOR].CurrentTemperature < heatingArray[HeatingArray.BASEMENT_FLOOR].SetTemperature)
        {
          // Basement floor needs the hot water tank and floor heat pumps
          valuePumpHWTank = 0;
          valuePumpFloorHeat = 0;
          // Open the solenoid for the basement floor heat
          GPIOArray.gpioArray[GPIOArray.SOLENOID_BASEMENT_OFFICE].Value = 0;
          GPIOArray.gpioArray[GPIOArray.SOLENOID_BASEMENT_HALLWAY].Value = 0;
        }
        // No heat needed for the basement floor
        else
        {
          // Close the solenoid for the basement floor heat
          GPIOArray.gpioArray[GPIOArray.SOLENOID_BASEMENT_OFFICE].Value = 1;
          GPIOArray.gpioArray[GPIOArray.SOLENOID_BASEMENT_HALLWAY].Value = 1;
        }
      }

      // Basement bathroom thermostat is calling for heat
      if (heatingArray[HeatingArray.BASEMENT_BATHROOM].Enabled)
      {
        if (heatingArray[HeatingArray.BASEMENT_BATHROOM].CurrentTemperature < heatingArray[HeatingArray.BASEMENT_BATHROOM].SetTemperature)
        {
          // Basement floor needs the hot water tank and floor heat pumps
          valuePumpHWTank = 0;
          valuePumpFloorHeat = 0;
          // Open the solenoid for the basement bathroom floor heat
          GPIOArray.gpioArray[GPIOArray.SOLENOID_BASEMENT_BATHROOM].Value = 0;
        }
        // No heat needed for the basement bathroom floor
        else
        {
          // Close the solenoid for the basement floor heat
          GPIOArray.gpioArray[GPIOArray.SOLENOID_BASEMENT_BATHROOM].Value = 1;
        }
      }

      // Kate's rad is enabled
      if (heatingArray[HeatingArray.KATE_BEDROOM].Enabled)
      {
        // Open the solenoid for Kate's rad
        GPIOArray.gpioArray[GPIOArray.SOLENOID_KATE_RAD].Value = 0;
        // Rads need the hot water tank and rad pumps
        valuePumpHWTank = 0;
        valuePumpRads = 0;
      }
      // No heat needed for Kate's rad
      else
      {
        // Close the solenoid for the Kate's rad
        GPIOArray.gpioArray[GPIOArray.SOLENOID_KATE_RAD].Value = 1;
      }

      // Kate's bathroom is enabled
      if (heatingArray[HeatingArray.KATE_BATHROOM].Enabled)
      {
        // Open the solenoid for Kate's bathroom
        GPIOArray.gpioArray[GPIOArray.SOLENOID_KATE_BATHROOM].Value = 0;
        // Floor needs the hot water tank and floor heat pumps
        valuePumpHWTank = 0;
        valuePumpFloorHeat = 0;
      }
      // No heat needed for Kate's bathroom
      else
      {
        // Close the solenoid for the Kate's bathroom
        GPIOArray.gpioArray[GPIOArray.SOLENOID_KATE_BATHROOM].Value = 1;
      }

      // Brett's bathroom is enabled
      if (heatingArray[HeatingArray.BRETT_BATHROOM].Enabled)
      {
        // Open the solenoid for Kate's bathroom
        GPIOArray.gpioArray[GPIOArray.SOLENOID_BRETT_BATHROOM].Value = 0;
        // Floor needs the hot water tank and floor heat pumps
        valuePumpHWTank = 0;
        valuePumpFloorHeat = 0;
      }
      // No heat needed for Brett's bathroom
      else
      {
        // Close the solenoid for the Brett's bathroom
        GPIOArray.gpioArray[GPIOArray.SOLENOID_BRETT_BATHROOM].Value = 1;
      }

      // Media room rad is enabled
      if (heatingArray[HeatingArray.MEDIA_ROOM].Enabled)
      {
        // Open the solenoid for Media room rad
        GPIOArray.gpioArray[GPIOArray.SOLENOID_MEDIA_ROOM_RAD].Value = 0;
        // Rads need the hot water tank and rad pumps
        valuePumpHWTank = 0;
        valuePumpRads = 0;
      }
      // No heat needed for Media room rad
      else
      {
        // Close the solenoid for the Media room rad
        GPIOArray.gpioArray[GPIOArray.SOLENOID_MEDIA_ROOM_RAD].Value = 1;
      }

      // Turn the pumps on or off as needed
      GPIOArray.gpioArray[GPIOArray.PUMP_HW_TANK].Value = valuePumpHWTank;
      GPIOArray.gpioArray[GPIOArray.PUMP_FLOOR_HEAT].Value = valuePumpFloorHeat;
      GPIOArray.gpioArray[GPIOArray.PUMP_RADS].Value = valuePumpRads;
    }
  }
}
