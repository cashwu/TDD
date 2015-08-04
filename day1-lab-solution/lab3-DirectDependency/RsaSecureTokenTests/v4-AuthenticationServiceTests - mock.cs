using Microsoft.VisualStudio.TestTools.UnitTesting;

//using Rhino.Mocks;
using NSubstitute;

namespace RsaSecureToken.Tests
{
    [TestClass()]
    public class AuthenticationServiceTests
    {
        [TestMethod()]
        public void IsValidTest_只有驗證Authentication合法或非法()
        {
            //arrange
            //IProfile profile = MockRepository.GenerateStub<IProfile>();
            //profile.Stub(x => x.GetPassword("Joey")).Return("91");

            IProfile profile = Substitute.For<IProfile>();
            profile.GetPassword("Joey").Returns("91");

            //IToken token = MockRepository.GenerateStub<IToken>();
            //token.Stub(x => x.GetRandom("Joey")).Return("abc");
            IToken token = Substitute.For<IToken>();
            token.GetRandom("Joey").Returns("abc");

            //ILog log = MockRepository.GenerateStub<ILog>();
            ILog log = Substitute.For<ILog>();

            AuthenticationService target = new AuthenticationService(profile, token, log);
            string account = "Joey";
            string password = "wrong password";
            // 正確的 password 應為 "91abc"

            //act
            bool actual;
            actual = target.IsValid(account, password);

            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsValidTest_如何驗證當非法登入時有正確紀錄log()
        {
            //arrange
            // step 1: 建立 mock object

            #region rhino.mocks

            //IProfile profile = MockRepository.GenerateStub<IProfile>();
            //profile.Stub(x => x.GetPassword("Joey")).Return("91");

            #endregion rhino.mocks

            IProfile profile = Substitute.For<IProfile>();
            profile.GetPassword("").ReturnsForAnyArgs("91"); // 不管GetPassword()傳入任何參數，都要回傳 "91"

            #region rhino.mocks

            //IToken token = MockRepository.GenerateStub<IToken>();
            //token.Stub(x => x.GetRandom("Joey")).Return("abc");

            #endregion rhino.mocks

            IToken token = Substitute.For<IToken>();
            token.GetRandom("").ReturnsForAnyArgs("abc"); // 不管GetRandom()傳入任何參數，都要回傳 "91"

            #region rhino.mocks

            //var mock = new MockRepository();
            //ILog log = mock.StrictMock<ILog>();

            //// step 2: 建立預期腳本
            //using (mock.Record())
            //{
            //    var expected = "account:Joey try to login failed";
            //    log.Save(expected);
            //}

            #endregion rhino.mocks

            // NSub 的 mock 比 Rhino.Mocks 漂亮太多的地方
            ILog log = Substitute.For<ILog>();

            var target = new AuthenticationService(profile, token, log);

            string account = "Joey";
            string password = "wrong password";

            //act
            var neverMindActual = target.IsValid(account, password);

            #region rhino.mocks

            //// step 3: 實際驗證
            //using (mock.Playback())
            //{
            //    var actual = target.IsValid(account, password);
            //}

            #endregion rhino.mocks

            //assert
            //log.Received(1).Save("account:Joey try to login failed"); //Received(1) 可以簡化成 Received()
            log.Received(1).Save(Arg.Is<string>(x => x.Contains("login failed") && x.Contains("Joey")));
            
            //log.ReceivedWithAnyArgs().Save(""); //不管參數內容的驗證
        }
    }
}