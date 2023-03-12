using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Models
{
  public class Stylist
  {
    public string Name { get; set; }
    public DateOnly HireDate { get; set; }
    public string Speciality { get; set; }
    public int StylistId {get;}
    public List<Client> ClientList { get; set;}

  }
}
