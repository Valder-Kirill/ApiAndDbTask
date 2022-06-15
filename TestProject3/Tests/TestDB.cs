using NUnit.Framework;
using System.Collections.Generic;

namespace DBAndAPIProject
{
    public class Tests
    {
        private DBUtils dBUtils;
        private List<ÑurrencyModel> ñurrencyModels;
        private APIUtils apiUtils;

        [SetUp]
        public void Setup()
        {
            apiUtils = new APIUtils();
            dBUtils = new DBUtils();
        }

        [Test]
        public void InformationOnAllCurrencies()
        {
            ñurrencyModels = apiUtils.GetListModels();
            dBUtils.InsertManyCurrenciesToNbrbTB(ñurrencyModels);
        }
    }
}