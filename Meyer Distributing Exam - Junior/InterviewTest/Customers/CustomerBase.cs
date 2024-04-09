using System;
using System.Collections.Generic;
using InterviewTest.Orders;
using InterviewTest.Returns;

namespace InterviewTest.Customers
{
    public abstract class CustomerBase : ICustomer
    {
        private readonly OrderRepository _orderRepository;
        private readonly ReturnRepository _returnRepository;

        protected CustomerBase(OrderRepository orderRepo, ReturnRepository returnRepo)
        {
            _orderRepository = orderRepo;
            _returnRepository = returnRepo;
        }

        public abstract string GetName();
        
        public void CreateOrder(IOrder order)
        {
            _orderRepository.Add(order);
        }

        public List<IOrder> GetOrders()
        {
            return _orderRepository.Get();
        }

        public void CreateReturn(IReturn rga)
        {
            _returnRepository.Add(rga);
        }

        public List<IReturn> GetReturns()
        {
            return _returnRepository.Get();
        }

        //Assuming GetTotalSales() returns the total number of sales completed by this specific customer.

        // Solution: Traverse through the order repository, find each order name for this customer, add the sale total of each order to a sum. Return sum.
        public float GetTotalSales()
        {
            float totalSales = 0;
            foreach(Order order in GetOrders())
            {
                // For each order, get the product list.
                List<OrderedProduct> productsInOrder = order.Products;

                // For each product, get the cost of the product, add it to the totalSales counter, return totalSales.
                foreach(OrderedProduct customerProduct in productsInOrder)
                {
                    //Console.WriteLine("Test: " + customerProduct.Product.GetSellingPrice());
                    totalSales += customerProduct.Product.GetSellingPrice();
                }
            }

        
            return totalSales;
        }

        // Assuming GetTotalReturns() returns the total number of returns completed by this specific customer.
        
        // Solution: Get the order repository for this customer
        public float GetTotalReturns()
        {
            float totalReturns = 0;
            foreach (Return returnOrder in GetReturns())
            {
                // For each order, get the product list.
                List<ReturnedProduct> returnsInOrder = returnOrder.ReturnedProducts;

                // For each product, get the cost of the product, add it to the totalSales counter, return totalSales.
                foreach (ReturnedProduct customerReturn in returnsInOrder)
                {
                    totalReturns += customerReturn.OrderProduct.Product.GetSellingPrice();
                }
            }

            return totalReturns;
        }

        // Assuming GetTotalProfit() returns the total number of profit (which should be the total sales - returns and the profit from the result).
        public float GetTotalProfit()
        {
            return GetTotalSales() - GetTotalReturns();
        }
    }
}
