using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostOffice.Models;
using System.Collections.Generic;
using System;

namespace PostOffice.Tests
{
  [TestClass]
  public class ParcelTest : IDisposable
  {

    public void Dispose()
    {
      Parcel.ClearAll();//comment out to see console output -> WTF
    }

    [TestMethod]
    public void SimpleParcelConstructor_CreatesInstanceOfParcel_Parcel()
    {
      //Arrange Act
      Parcel newParcel = new Parcel();
      //Assert
      Assert.AreEqual(typeof(Parcel), newParcel.GetType());
    }

    [TestMethod]
    public void ParcelConstructor_CreatesInstanceOfParcel_Parcel()
    {
      //Arrange Act
      Parcel newParcel = new Parcel("new", 1, 2, 3);
      //Assert
      Assert.AreEqual(typeof(Parcel), newParcel.GetType());
    }

    [TestMethod]
    public void ParcelGetters_ReturnsCorrectInstanceMemberValues_StringInt()
    {
      //Arrange
      Parcel newParcel = new Parcel("ready", 4, 5, 6);
      //Act
      string description = newParcel.Description;
      int height = newParcel.Height;
      int width = newParcel.Width;
      int weight = newParcel.Weight;
      //Assert
      Assert.AreEqual(description, "ready");
      Assert.AreEqual(height, 4);
      Assert.AreEqual(width, 5);
      Assert.AreEqual(weight, 6);
    }

    [TestMethod]
    public void ParcelSetters_ReturnsCorrectInstanceMemeberValuesAfterSetters_StringInt()
    {
      //Arrange
      Parcel newParcel = new Parcel();
      //Act
      newParcel.Description = "newReady";
      newParcel.Height = 7;
      newParcel.Width = 8;
      newParcel.Weight = 9;
      //Assert
      Assert.AreEqual(newParcel.Description, "newReady");
      Assert.AreEqual(newParcel.Height, 7);
      Assert.AreEqual(newParcel.Width, 8);
      Assert.AreEqual(newParcel.Weight, 9);
    }

    [TestMethod]
    public void GetVolume_ReturnsVolumeBasedOnHeightWidth_Int()
    {
      //Arrange Act -> constructor calls GetVolume
      Parcel newParcel = new Parcel("ready", 4, 5, 6);
      //Act
      Assert.AreEqual(newParcel.Volume, 100);
    }

    [TestMethod]
    public void GetCostToShip_CalculatesCostOfShipmentBasedOnVolWeightCost_Decimal()
    {
      //Arrange Act -> constructor calls GetVolume, GetCostToShip
      Parcel newParcel = new Parcel("ready", 4, 5, 6);
      //Assert
      Assert.AreEqual(newParcel.CostToShip, 150);
    }

    [TestMethod]
    public void SetId_ReturnsSequentialID_Int()
    {
      //Arrange Act
      Parcel p1 = new Parcel();
      Parcel p2 = new Parcel();
      Parcel p3 = new Parcel();
      Parcel p4 = new Parcel();

      //Assert
      Assert.AreEqual(p1.Id, 1);
      Assert.AreEqual(p2.Id, 2);
      Assert.AreEqual(p3.Id, 3);
      Assert.AreEqual(p4.Id, 4);
    }

    [TestMethod]
    public void Inventory_StaticKeepsTrackOfAllParcelInstances_Parcels()
    {
      //Arrange
      Parcel nP1 = new Parcel("new1", 1, 2, 3);
      Parcel nP2 = new Parcel("new2", 4, 5, 6);
      Parcel nP3 = new Parcel("new3", 4, 5, 6);
      Parcel nP4 = new Parcel("new4", 4, 5, 6);

      List<Parcel> newList = new List<Parcel> {nP1, nP2, nP3, nP4};

      //Act
      List<Parcel> result = Parcel.Inventory();
      foreach(Parcel p in newList)
      {
        Console.Write(p.Id + " " + p.Description);
      }
      Console.WriteLine();

      foreach(Parcel p in result)
      {
        Console.Write(p.Id + " " + p.Description);
      }
      Console.WriteLine();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

      [TestMethod]
      public void Find_ReturnsParcelSpecifiedById_Parcel()
      {
        //Arrange
        Parcel nP1 = new Parcel("new1", 1, 2, 3);
        Parcel nP2 = new Parcel("new2", 4, 5, 6);
        Parcel nP3 = new Parcel("new3", 4, 5, 6);
        Parcel nP4 = new Parcel("new4", 4, 5, 6);

        //Act
        Parcel foundParcel = Parcel.Find(3);

        //Assert
        Assert.AreEqual(foundParcel.Height, nP2.Height);
      }




  }
}
