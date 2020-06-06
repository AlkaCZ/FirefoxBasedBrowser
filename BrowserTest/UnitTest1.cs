using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gecko;
using Gecko.Events;
using Browser_Glora_1._0;
using System.Windows.Input;


namespace UnitTest1
{      
    
    [TestClass]
    public class UnitTest1
    {
        IsLoaded l;
        TextChanger tTest;



        public UnitTest1()
        {
            l = new IsLoaded();
            Xpcom.Initialize("Firefox");
            tTest = new TextChanger();
        }

        [TestMethod]
        public void SerchBar_Is_Null()
        {
          //Arrange
           string s = null;
            //Act
            bool result = l.SearchTestIsNull(s);
           //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void SearchBar_Is_Full()
        {
            //Arrange
            string s = "side.com";
            //Act
            bool result = tTest.FullSearchBar(s);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Ulr_Has_Changed()
        {
            //Arrange
            string s = "side.com";
            //Act
            string changed = tTest.TextChange(s);
            //Assert
            Assert.AreNotSame(changed,s);
        }
    }
}
