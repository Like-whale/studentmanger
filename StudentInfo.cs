using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01
{
    class StudentInfo
    {
        private string xh;
        private string oldPass;
        private string newPass1;
        private string newPass2;

        public string XH
        {
            get
            {
                return xh;
            }
            set
            {
                xh = value;
            }
        }

        public string OldPass
        {
            get
            {
                return oldPass;
            }
            set
            {
                oldPass = value;
            }
        }

        public string NewPass1
        {
            get
            {
                return newPass1;
            }
            set
            {
                newPass1 = value;
            }
        }

        public string NewPass2
        {
            get
            {
                return newPass2;
            }
            set
            {
                newPass2 = value;
            }
        }

    }
}
