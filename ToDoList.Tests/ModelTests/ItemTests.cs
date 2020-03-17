using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Models;
using System;
using MySql.Data.MySqlClient;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {

    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      //Arrange
      List<Item> newList = new List<Item> { };
      //Act
      List<Item> result = Item.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      // Arrange, Act
      Item firstItem = new Item("Mow the lawn");
      Item secondItem = new Item("Mow the lawn");

      // Assert
      Assert.AreEqual(firstItem, secondItem);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      //Arrange
      Item testItem = new Item("Mow the lawn");

      //Act
      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item>{testItem};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      newItem1.Save(); // New code
      Item newItem2 = new Item(description02);
      newItem2.Save(); // New code
      List<Item> newList = new List<Item> { newItem1, newItem2 };

      //Act
      List<Item> result = Item.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    
    [TestMethod]
    public void Find_ReturnsCorrectItemFromDatabase_Item()
    {
      //Arrange
      Item newItem = new Item("Mow the lawn");
      newItem.Save();
      Item newItem2 = new Item("Wash dishes");
      newItem2.Save();

      //Act
      Item foundItem = Item.Find(newItem.Id);
      //Assert
      Assert.AreEqual(newItem, foundItem);
    }
  }
}