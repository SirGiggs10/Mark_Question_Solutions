using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mark_Question5_Solution.Helpers
{
    public class Utils
    {
        public const int StatusCode_Success = 0;
        public const int StatusCode_ObjectNull = 1;
        public const int StatusCode_NameEmpty = 2;
        public const int StatusCode_NotFound = 3;
        public const int StatusCode_ObjectExists = 4;

        public const string StatusMessage_Success = "The operation was successful";
        public const string StatusMessage_ObjectNull = "The country object is null";
        public const string StatusMessage_NameEmpty = "The country name is empty";
        public const string StatusMessage_NotFound = "Country was not found";
        public const string StatusMessage_ObjectExists = "Country already exists";
    }
}
