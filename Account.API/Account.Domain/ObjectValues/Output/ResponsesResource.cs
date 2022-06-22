using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.Output
{
    public class ResponsesResource
    {
        public bool Error { get; set; } = false;
        public string ErrorCode { get; set; }
        public string MessageError { get; set; }
        public string Result { get; set; }
    }
}
