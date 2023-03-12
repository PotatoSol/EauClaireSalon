using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    public string Name { get; set; }
    public DateTime NextAppointment { get; set; }
    public Stylist PersonalStylist { get; set; }
    public int Id {get;}

    private static List<Client> _instances = new List<Client> { };
    public Client(string name, DateTime nextAppointment, Stylist personalStylist) 
    {
      Name = name;
      NextAppointment = nextAppointment;
      PersonalStylist = personalStylist;
      Date = date;
      _instances.Add(this);
      Id = _instances.Count;
    }

  public static void ClearAll(){
    _instances.Clear();
  }

  }
}