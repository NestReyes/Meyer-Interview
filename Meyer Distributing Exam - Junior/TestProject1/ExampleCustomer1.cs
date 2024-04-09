using InterviewTest.Orders;
using InterviewTest.Returns;

namespace InterviewTest.Customers
{
    public class ExampleCustomer2 : CustomerBase
    {
        public ExampleCustomer2(OrderRepository orderRepo, ReturnRepository returnRepo)
            : base(orderRepo, returnRepo)
        {

        }

        public override string GetName()
        {
            return "Kirby";
        }
    }
}
