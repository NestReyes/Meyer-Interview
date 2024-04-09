using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Returns
{
    public class ReturnRepository
    {
        private List<IReturn> returns;
        public ReturnRepository()
        {
            returns = new List<IReturn>();
        }

        public void Add(IReturn newReturn)
        {
            returns.Add(newReturn);
        }

        public void Remove(IReturn removedReturn)
        {
            returns = returns.Where(o => !string.Equals(removedReturn.ReturnNumber, o.ReturnNumber)).ToList();
        }
        
        // Added a function to clear out the List<IReturn> returns of any contents.
        public void Clear()
        {
            returns.Clear();
        }

        public List<IReturn> Get()
        {
            return returns;
        }
    }
}
