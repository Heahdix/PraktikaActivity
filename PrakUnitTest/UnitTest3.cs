﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PraktikaActivity;
using System;

namespace PrakUnitTest
{
    [TestClass]
    public class PasswordValidateTest
    {
        [TestMethod]
        public void PassTest0()
        {
            string pass = "qwertyQWERTY";
            int actual = 0;

            int extended = RgistrationOfJuryModerator.ValidatePassword(pass);
            Assert.AreEqual(extended, actual);
        }
        [TestMethod]
        public void PassTest1()
        {
            string pass = "QWERTY1";
            int actual = 1;
            int extended = RgistrationOfJuryModerator.ValidatePassword(pass);
            Assert.AreEqual(extended, actual);
        }
        [TestMethod]
        public void PassTest2()
        {
            string pass = "qwerty1";
            int actual = 2;
            int extended = RgistrationOfJuryModerator.ValidatePassword(pass);
            Assert.AreEqual(extended, actual);
        }
        [TestMethod]
        public void PassTest3()
        {
            string pass = "QWERTYqwerty1";
            int actual = 3;
            int extended = RgistrationOfJuryModerator.ValidatePassword(pass);
            Assert.AreEqual(extended, actual);

        }
        [TestMethod]
        public void PassTest4()
        {
            string pass = "Qq1^";
            int actual = 4;
            int extended = RgistrationOfJuryModerator.ValidatePassword(pass);
            Assert.AreEqual(extended, actual);
        }
        [TestMethod]
        public void PassTest5()
        {
            string pass = "QWEasd123!@#";
            int actual = 5;
            int extended = RgistrationOfJuryModerator.ValidatePassword(pass);
            Assert.AreEqual(extended, actual);
        }
    }
}
