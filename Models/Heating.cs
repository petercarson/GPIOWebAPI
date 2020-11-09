using GPIOWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPIOWebAPI
{
    public class Heating
    {
        private int currentTemperature;

        public Heating(int id, string name, int currentTemperature, int setTemperature, bool enabled)
        {
            Id = id;
            Name = name;
            CurrentTemperature = currentTemperature;
            SetTemperature = setTemperature;
            Enabled = enabled;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CurrentTemperature
        {
            get 
            {
                switch (Id - 1)
                {
                    case HeatingArray.BASEMENT_FLOOR:
                        if (GPIOArray.gpioArray[GPIOArray.THERMOSTAT_BASEMENT].Value == 0)
                        {
                            currentTemperature = 24;
                        }
                        else
                        {
                            currentTemperature = 26;
                        }
                        break;

                    case HeatingArray.MASTER_ENSUITE:
                        if (GPIOArray.gpioArray[GPIOArray.THERMOSTAT_MASTER_ENSUITE].Value == 0)
                        {
                            currentTemperature = 24;
                        }
                        else
                        {
                            currentTemperature = 26;
                        }
                        break;

                    default:
                        break;
                }
                return currentTemperature; 
            }
            set { currentTemperature = value; }
        }

        public int SetTemperature { get; set; }

        public bool Enabled { get; set; }
    }
}
