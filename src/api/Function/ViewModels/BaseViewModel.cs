using System;
using System.Collections.Generic;
using System.Text;

namespace Function.ViewModels
{
    public class BaseViewModel
    {
        public string ApiVersion
        {
            get
            {
                return Environment.GetEnvironmentVariable("ApiVersion");
            }
        }
    }
}
