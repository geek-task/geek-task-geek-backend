using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.OutModels
{
    public class UserOut
    {
        public int id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }

        public UserOut(int id,string FirstName,string LastName)
        {
            this.id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public UserOut()
        {

        }
    }
}
