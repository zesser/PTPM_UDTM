using NUnit.Framework;
using WedBanHang;
using WedBanHang.Models;
using System.Linq;

namespace Test_TaiKhoan
{
    public class Tests
    {
        [Test]
        public void Test_TK1()
        {
            Muser kh = new Muser();
            kh.mUsername = "nnhoang";
            kh.mPassword = "ngochoang";
            Assert.True(kh.CheckDoDaiUserName());
            Assert.True(kh.CheckDoDaiPassword());
        }
        [Test]
        public void Test_TK2()
        {
            Muser kh = new Muser();
            kh.mUsername = "nnho";
            kh.mPassword = "ngochoang";
            Assert.True(!kh.CheckDoDaiUserName());
            Assert.True(kh.CheckDoDaiPassword());
        }

        [Test]
        public void Test_TK3()
        {
            Muser kh = new Muser();
            kh.mUsername = "nnhoangvcgghdgh";
            kh.mPassword = "ngochoang";
            Assert.True(!kh.CheckDoDaiUserName());
            Assert.True(kh.CheckDoDaiPassword());
        }
        [Test]
        public void Test_TK4()
        {
            Muser kh = new Muser();
            kh.mUsername = "nnhoang";
            kh.mPassword = "ngochoangadfadfad";
            Assert.True(kh.CheckDoDaiUserName());
            Assert.True(!kh.CheckDoDaiPassword());
        }
        [Test]
        public void Test_TK5()
        {
            Muser kh = new Muser();
            kh.mUsername = "nnhoang";
            kh.mPassword = "ngochoa32";
            Assert.True(kh.CheckDoDaiUserName());
            Assert.True(kh.CheckDoDaiPassword());
        }
        [Test]
        public void Test_TK6()
        {
            Muser kh = new Muser();
            kh.mUsername = "nnhoang";
            kh.mPassword = "ngocho";
            Assert.True(kh.CheckDoDaiUserName());
            Assert.True(!kh.CheckDoDaiPassword());
        }
    }
}