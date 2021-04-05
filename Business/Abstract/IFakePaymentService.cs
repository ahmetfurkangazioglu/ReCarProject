using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface IFakePaymentService
    {
        IResult CheckCard(FakePayment fakePayment);
        IResult Update(FakePayment fakePayment);
    }
}
