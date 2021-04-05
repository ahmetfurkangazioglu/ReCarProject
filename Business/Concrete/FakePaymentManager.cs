using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class FakePaymentManager : IFakePaymentService
    {
        IFakePaymentDal _fakePaymentDal;

        public FakePaymentManager(IFakePaymentDal fakePaymentDal)
        {
            _fakePaymentDal = fakePaymentDal;
        }

        public IResult CheckCard(FakePayment fakePayment)
        {
            IResult result = BusinessRules.Run(CheckCardInformation(fakePayment));
            if (result!=null)
            {
                return result;
            }
            return new SuccessResult("Kart bilgileri doğru, Ödeme işlemi yapılıyor");
        }

        public IResult Update(FakePayment fakePayment)
        {
            IResult result = BusinessRules.Run(CheckMoneyInCard(fakePayment));
            if (result!=null)
            {
                return result;
            }
            var result2 = _fakePaymentDal.Get(f => f.CardNumber == fakePayment.CardNumber);
           decimal amountPaye= result2.MoneyInCard - fakePayment.MoneyInCard;
            fakePayment.MoneyInCard = amountPaye;
            fakePayment.CardId = result2.CardId;
            fakePayment.NameOnCard = result2.NameOnCard;
            _fakePaymentDal.Update(fakePayment);
            return new SuccessResult("Ödeme Başarılı");
        }

        private IResult CheckCardInformation(FakePayment fakePayment)
        {
            var result = _fakePaymentDal.GetAll(f => f.CardNumber == fakePayment.CardNumber &&
            f.CardCvv == fakePayment.CardCvv && f.ExpirationDate == fakePayment.ExpirationDate).Any();
            if (!result)
            {
             return  new ErrorResult("Kart Bilgiler Hatalı");
            }
           return new SuccessResult();
        }

        private IResult CheckMoneyInCard(FakePayment fakePayment)
        {
            var result = _fakePaymentDal.GetAll(f => f.CardNumber == fakePayment.CardNumber && f.MoneyInCard >= fakePayment.MoneyInCard);
            if (result.Count>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Kartınızda Yeterli Miktarda Para Yok");
        }

    }
}
