using GPIOWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace GPIOWebAPI
{
  public class Heating
  {
    private float currentTemperature;

    public Heating(int id, string name, float currentTemperature, float setTemperature, bool enabled)
    {
      Id = id;
      Name = name;
      CurrentTemperature = currentTemperature;
      SetTemperature = setTemperature;
      Enabled = enabled;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public float CurrentTemperature
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

          case HeatingArray.BASEMENT_BATHROOM:
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("http://192.168.2.165/cm?cmnd=status%2010").Result;
            string result = response.Content.ReadAsStringAsync().Result;
            result = Regex.Replace(result, ".*Temperature\":", "");
            result = Regex.Replace(result, ",\"Humidity.*", "");
            currentTemperature = float.Parse(result);
            break;

          default:
            break;
        }
        return currentTemperature;
      }
      set { currentTemperature = value; }
    }

    public float SetTemperature { get; set; }

    public bool Enabled { get; set; }
  }
}
