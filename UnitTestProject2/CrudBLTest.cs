using CrudBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CrudBL;
namespace UnitTestProject2
{
    
    
    /// <summary>
    ///This is a test class for CrudBLTest and is intended
    ///to contain all CrudBLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CrudBLTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ShowAll
        ///</summary>
        [TestMethod()]
        public void ShowAllTest()
        {
            CrudBL.CrudBL target = new CrudBL.CrudBL(); // TODO: Initialize to an appropriate value
            SearchResults expected = null; // TODO: Initialize to an appropriate value
            SearchResults actual;
            actual = target.ShowAll();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Search
        ///</summary>
        [TestMethod()]
        public void SearchTest()
        {
            CrudBL.CrudBL target = new CrudBL.CrudBL(); // TODO: Initialize to an appropriate value
            string invoiceNum = string.Empty; // TODO: Initialize to an appropriate value
            SearchResults expected = null; // TODO: Initialize to an appropriate value
            SearchResults actual;
            actual = target.Search(invoiceNum);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            CrudBL.CrudBL target = new CrudBL.CrudBL(); // TODO: Initialize to an appropriate value
            string Number = string.Empty; // TODO: Initialize to an appropriate value
            string concept = string.Empty; // TODO: Initialize to an appropriate value
            string description = string.Empty; // TODO: Initialize to an appropriate value
            string total = string.Empty; // TODO: Initialize to an appropriate value
            string dateI = string.Empty; // TODO: Initialize to an appropriate value
            string dateF = string.Empty; // TODO: Initialize to an appropriate value
            IUDResults expected = null; // TODO: Initialize to an appropriate value
            IUDResults actual;
            actual = target.Insert(Number, concept, description, total, dateI, dateF);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InsertPost
        ///</summary>
        [TestMethod()]
        public void InsertPostTest()
        {
            CrudBL.CrudBL target = new CrudBL.CrudBL(); // TODO: Initialize to an appropriate value
            string request = string.Empty; // TODO: Initialize to an appropriate value
            IUDResults expected = null; // TODO: Initialize to an appropriate value
            IUDResults actual;
            actual = target.InsertPost(request);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            CrudBL.CrudBL target = new CrudBL.CrudBL(); // TODO: Initialize to an appropriate value
            string idInvoice = string.Empty; // TODO: Initialize to an appropriate value
            IUDResults expected = null; // TODO: Initialize to an appropriate value
            IUDResults actual;
            actual = target.Delete(idInvoice);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
