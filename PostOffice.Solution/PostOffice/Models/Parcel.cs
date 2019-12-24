using System;
using System.Collections.Generic;


namespace PostOffice.Models
{
  public class Parcel
  {
    private static List<Parcel> _inventory = new List<Parcel> {};
    private static int _inventoryIndex = 0;

    public string Description {get; set;}
    public int Height {get; set;}
    public int Width {get; set;}
    public int Weight {get; set;}
    public int Id {get; set;}
    public int Volume {get; set;}
    public decimal CostToShip {get; set;}
    public const decimal COST_TO_SHIP = 0.25M;

    public Parcel()
    {
      AddToInventory(this);
      SetId();
    }

    public Parcel(string description, int height, int width, int weight) : this()
    {
      Description = description;
      Height = height;
      Width = width;
      Weight = weight;


      GetVolume();
      GetCostToShip();
    }

    private void GetVolume()
    {
      Volume = Height * Width * Width  ;
    }

    private void GetCostToShip()
    {
      CostToShip = Volume * Weight * COST_TO_SHIP;
    }

    private void SetId()
    {
      Id = _inventoryIndex;
    }

    private void AddToInventory(Parcel nParcel)
    {
      _inventory.Add(nParcel);
      _inventoryIndex++;
    }

    public static List<Parcel> Inventory()
    {
      return _inventory;
    }

    public static void ClearAll()
    {
      _inventory.Clear();
      _inventoryIndex = 0;
    }

    public static Parcel Find(int id)
    {
      return _inventory[id - 1];
    }

  }
}
