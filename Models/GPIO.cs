using System;
using System.Device.Gpio;

namespace GPIOWebAPI
{
    public class GPIO
    {
        private int id;
        private int pin;
        private string name;
        private PinMode pinMode;
        private int pinValue;

        public GPIO(int Id, int Pin, string Name, PinMode PinMode, int PinValue)
        {
            id = Id;
            pin = Pin;
            name = Name;
            pinMode = PinMode;

            if (!GPIOArray.EMULATOR)
            {
                GPIOArray.gpioController.OpenPin(pin, pinMode);
            }

            Value = PinValue;
        }

        public int Id 
        {
            get { return id; } 
            set { id = value; } 
        }

        public int Pin
        {
            get { return pin; }
            set { pin = value; } 
        }

        public string Name
        {
            get { return name; } 
            set { name = value; } 
        }

        public PinMode Mode
        {
            get { return pinMode; }
            set { pinMode = value; }
        }

        public int Value
        {
            get {
                if (!GPIOArray.EMULATOR && pinMode != PinMode.Output)
                {
                    if (GPIOArray.gpioController.Read(pin) == PinValue.Low)
                    {
                        pinValue = 0;
                    }
                    else
                    {
                        pinValue = 1;
                    }
                    
                }
                
                return pinValue; 
            }
            set 
            { 
                pinValue = value;
                if (!GPIOArray.EMULATOR && pinMode == PinMode.Output)
                {
                    if (value == 0)
                    {
                        GPIOArray.gpioController.Write(pin, PinValue.Low);
                    }
                    else if (value == 1)
                    {
                        GPIOArray.gpioController.Write(pin, PinValue.High);
                    }
                }
            }
        }
    }
}
