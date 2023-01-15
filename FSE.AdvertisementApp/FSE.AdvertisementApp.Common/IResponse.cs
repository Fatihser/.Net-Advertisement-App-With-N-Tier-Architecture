using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Common
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}
