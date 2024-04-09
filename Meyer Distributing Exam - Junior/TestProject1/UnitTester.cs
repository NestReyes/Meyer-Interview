using NUnit.Framework;
using InterviewTest;
using InterviewTest.Orders;
using InterviewTest.Products;
using InterviewTest.Returns;
using InterviewTest.Customers;
using System.Security.Cryptography;
using System.Linq;

namespace TestInterviewProject
{
    public class Tests
    {
        private static readonly OrderRepository orderRepo = new OrderRepository();
        private static readonly ReturnRepository returnRepo = new ReturnRepository();

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestCustomerOrdering()
        {
            ExampleCustomer1 John = new ExampleCustomer1(orderRepo, returnRepo);

            Order orderOne = new Order("TestOrderNumber2", John);
            orderOne.AddProduct(new SyntheticOil());
            orderOne.AddProduct(new SyntheticOil());
            orderOne.AddProduct(new SyntheticOil());

            //If adding nothing, ignore but do not crash.
            orderOne.AddProduct();

            John.CreateOrder(orderOne);

            //Confirms if the total sales from adding all three synthetic oils is equal to 75.
            Assert.AreEqual(John.GetTotalSales(), 75.0);

            Order orderTwo = new Order("TestOrderNumber1", John);
            orderTwo.AddProduct(new ReplacementBumper()); //155
            orderTwo.AddProduct(new BedLiner()); //150
            orderTwo.AddProduct(new SyntheticOil()); //25
            orderTwo.AddProduct(new SyntheticOil()); //25
            John.CreateOrder(orderTwo);

            //New total should be 355.0
            Assert.AreEqual(John.GetTotalSales(), 430.0);


        }

        [Test]
        public void TestCustomerReturning() 
        {
            ExampleCustomer2 Cust = new ExampleCustomer2(orderRepo, returnRepo);

            Order orderOne = new Order("TestOrderNumber2", Cust);
            orderOne.AddProduct(new SyntheticOil()); //25
            orderOne.AddProduct(new ReplacementBumper()); //155
            orderOne.AddProduct(new ReplacementBumper()); //155
            Cust.CreateOrder(orderOne);

            IReturn rga = new Return("TestReturn", orderOne);
            rga.AddProduct(orderOne.Products.First());
            Cust.CreateReturn(rga);

            //Confirms if the total returns are equal to 25.
            Assert.AreEqual(Cust.GetTotalReturns(), 25.0);

            //Confirms if the total profit is the cost of the two bumpers - the return of the oil.
            Assert.AreEqual(Cust.GetTotalProfit(), 310);

        }

    }
}