


using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {


    public void Dispose()
    {
      Item.ClearAll();
    }


    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      Item newItem = new Item("test");
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnDescription_String()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      string result = newItem.Description;
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "walk the dog";
      Item newItem = new Item(description);

      //Act
      string updatedDescription = "Do the dishes";
      newItem.Description = updatedDescription;
      string result = newItem.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      //Arrange
      List<Item> newList = new List<Item> {};

      //Act
      List<Item> result = Item.GetAll();

      foreach(Item i in result)
      {
        Console.WriteLine("GetAll empty: " + i.Description);
      }

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);
      List<Item> newList = new List<Item> {newItem1, newItem2};
      foreach(Item i in newList)
      {
        Console.WriteLine("Getall Items: " + i.Description);
      }

      //Act
      List<Item> result = Item.GetAll();

      foreach(Item i in result)
      {
        Console.WriteLine("Getall Items: " + i.Description);
      }
      foreach(Item i in newList)
      {
        Console.WriteLine("Getall Items: " + i.Description);
      }

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      //Act
      int result = newItem.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);

      //Act
      Item result = Item.Find(2);

      //Assert
      Assert.AreEqual(newItem2, result);
    }


  }
}
