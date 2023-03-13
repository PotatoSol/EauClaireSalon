using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    public string Name { get; set; }
    public DateTime NextAppointment { get; set; }
    public Stylist PersonalStylist { get; set; }
    public int ClientId {get; set;}
    public int StylistId {get; set;}
  }
}