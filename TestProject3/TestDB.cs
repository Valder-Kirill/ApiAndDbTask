using NUnit.Framework;
using System.Collections.Generic;

namespace DBAndAPIProject
{
    public class Tests
    {
        private DBUtils dBUtils;
        private List<�urrencyModel> �urrencyModels;
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
            �urrencyModels = apiUtils.GetListModels();
            dBUtils.InsertManyCurrenciesToNbrbTB(�urrencyModels);
        }
    }
}