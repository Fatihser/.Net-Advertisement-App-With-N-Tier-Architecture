using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Common
{
    public interface IResponse<T>:IResponse
    {
        T Data { get; set; }
        List<CustomValidationError> ValidationErrors { get; set; }
    }
}
