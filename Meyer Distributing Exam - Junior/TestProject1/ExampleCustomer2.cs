using InterviewTest.Orders;
using InterviewTest.Returns;

namespace InterviewTest.Customers
{
    public class ExampleCustomer1 : CustomerBase
    {
        public ExampleCustomer1(OrderRepository orderRepo, ReturnRepository returnRepo)
            : base(orderRepo, returnRepo)
        {

        }

        public override string GetName()
        {
            return "John J.";
        }
    }
}
