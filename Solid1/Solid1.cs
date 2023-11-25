using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid1
{
    //Порушено принцип єдиного обов'язку (The Single Responsibility Principle) - клас має три різні обов'язки.
    //Методи класу повинні бути пов'язані однією спільною метою. 
    class Item
    {

    }

    class Order
    {
        private List<Item> itemList;
        internal List<Item> ItemList
        {
            get
            {
                return itemList;
            }

            set
            {
                itemList = value;
            }
        }
    }

    class OrderRepository
    {
        public void Load(int orderId) {/*...*/}
        public void Save(Order order) {/*...*/}
        public void Update(int orderId) {/*...*/}
        public void Delete(int orderId) {/*...*/}
    }

    class ManageOrder
    {
        public void CalculateTotalSum(Order order) {/*...*/}
        public void GetItems(Order order) {/*...*/}
        public void GetItemCount(Order order) {/*...*/}
        public void AddItem(Item item, int orderId) {/*...*/}
        public void DeleteItem(Item item, int orderId) {/*...*/}
    }

    class PrintManager
    {
        public void PrintOrder(Order order) {/*...*/}
        public void ShowOrder(int orderId) {/*...*/}
    }

    class Program
    {
        static void Main()
        {
        }
    }
}
