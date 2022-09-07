using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    class InventoryTest
    {
        Inventory tInventory;
        int InventoryMax;

        [SetUp]
        public void SetUp()
        {
            InventoryMax = 5;
			tInventory = new Inventory(InventoryMax);
        }
		[Test]
		public void TakeItemTrue()
		{
			Item TestItem = new Item("fork", 1, ItemGroup.Key);
			tInventory.AddItem(TestItem);
			tInventory.TakeItem(TestItem);
			Assert.AreEqual(tInventory.AvailableSlots, InventoryMax);
		}

		[Test]
		public void TakeItemFalse()
		{
			Item TestItem = new Item("fork", 1, ItemGroup.Key);
			tInventory.AddItem(TestItem);
			tInventory.TakeItem(TestItem);
			Assert.IsNull(TestItem);
			Assert.AreEqual(tInventory.AvailableSlots, InventoryMax - 1);
		}

		[Test]
		public void AddItemTrue()
		{
			Item TestItem = new Item("fork", 1, ItemGroup.Key);
			tInventory.AddItem(TestItem);
			Assert.AreEqual(tInventory.AvailableSlots, InventoryMax - 1);
			Assert.AreEqual(tInventory.ListAllItems()[0], TestItem);
		}

		[Test]
		public void ResetItemTrue()
		{
			tInventory.AddItem(new Item("fork", 1, ItemGroup.Key));
			tInventory.AddItem(new Item("Death Killer 10000000", 1, ItemGroup.Equipment));
			tInventory.Reset();
			Assert.AreEqual(tInventory.AvailableSlots, InventoryMax);
			Assert.IsEmpty(tInventory.ListAllItems());
		}

	}
}