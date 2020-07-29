using NUnit.Framework;
using WedBanHang;
using WedBanHang.Models;
using System.Linq;

namespace Test_HoSo
{
    public class Tests_HoSo
    {
        [Test]
        public void Test_Lan1()
        {
            Muser user = new Muser();
            user.DienThoai = "rewtw";
            user.Email = "4134";
            Assert.True(!user.checkDoDaiSDT());
            Assert.True(!user.IsNumber(user.DienThoai));
            Assert.True(!user.isEmail());
        }
        [Test]
        public void Test_Lan2()
        {
            Muser user = new Muser();
            user.DienThoai = "aafwer";
            user.Email = "etye@tq";
            Assert.True(!user.checkDoDaiSDT());
            Assert.True(!user.IsNumber(user.DienThoai));
            Assert.True(!user.isEmail());
        }

        [Test]
        public void Test_Lan3()
        {
            Muser user = new Muser();
            user.DienThoai = "qrere";
            user.Email = "kiiuore";
            Assert.True(!user.checkDoDaiSDT());
            Assert.True(!user.IsNumber(user.DienThoai));
            Assert.True(!user.isEmail());
        }
        [Test]
        public void Test_Lan4()
        {
            Muser user = new Muser();
            user.DienThoai = "9084524542";
            user.Email = "uioqer@oit";
            Assert.True(user.checkDoDaiSDT());
            Assert.True(user.IsNumber(user.DienThoai));
            Assert.True(user.isEmail());
        }
        [Test]
        public void Test_Lan5()
        {
            Muser user = new Muser();
            user.DienThoai = "0302145623";
            user.Email = "tqqe@gmail.com";
            Assert.True(user.checkDoDaiSDT());
            Assert.True(user.IsNumber(user.DienThoai));
            Assert.True(user.isEmail());
        }
        [Test]
        public void Test_Lan6()
        {
            Muser user = new Muser();
            user.DienThoai = "0302145623";
            user.Email = "qrete";
            Assert.True(user.checkDoDaiSDT());
            Assert.True(!user.IsNumber(user.DienThoai));
            Assert.True(!user.isEmail());
        }
    }
}
