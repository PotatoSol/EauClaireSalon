using System.Collections.Generic;
using System;
using EauClaireSalon.Models;

namespace EauClaireSalon.Models
{
  public class Stylist
  {
    public string Name { get; set; }
    public DateOnly HireDate { get; set; }
    public string Speciality { get; set; }
    public int Id {get;}
    public List<Client> ClientList { get; set;}
    private static List<Stylist> _instances = new List<Stylist> { };

    public Stylist(string name, DateOnly hireDate) 
    {
      Name = name;
      HireDate = hireDate;
      VendorsOrders = new List<Order>();
      _instances.Add(this);
      Id = _instances.Count;
    }

    public void AddOrder(Order newOrder){
      VendorsOrders.Add(newOrder);
    }

    public void RemoveOrder(Order removeOrder){
      VendorsOrders.Remove(removeOrder);
    }

    public List<Order> GetAllOrders(){
      return VendorsOrders;
    }

    public static List<Vendor> GetAll(){
      return _instances;
    }

    public static Vendor Find(int searchId){
      return _instances[searchId - 1];
    }
  }
}