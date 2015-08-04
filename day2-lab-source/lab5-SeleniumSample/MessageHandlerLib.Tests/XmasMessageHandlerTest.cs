using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageHandlerLib.Tests
{
    [TestClass]
    public class XmasMessageHandlerTest
    {
        [TestMethod]
        public void Test_不是聖誕節的時候_應回傳BadRequest()
        {
            // arrange 

            // Step1: 初始化 fakeInnerHandler, 拿來接在欲測試的 messageHandler 後面
            // 預計的回傳值可以隨便自訂
            //var fakeInnerHandler = new FakeInnerHandler
            //{
            //    Message = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            //    {
            //        Content = new StringContent("Fake inner handler response")
            //    }
            //};

            // Step2: 初始化測試目標，並將 fakeInnerHandler assign 給 InnerHandler 的 property
            //var target = new XmasMessageHandler() { InnerHandler = fakeInnerHandler };

            // Step3: MessageHandler 的單元測試，需要透過HttpMessageInvoker來模擬 client 端送 request 進來
            //HttpMessageInvoker client = new HttpMessageInvoker(target);

            //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/Fake");
            //httpRequestMessage.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            // act
            // Step4: 呼叫HttpMessageInvoker的 SendAsync ，就會先呼叫 target, 
            // 當正常執行時，會先呼叫 target 的 SendAsync(), 穿過 target 後，再呼叫 InnerHandler 的 SendAsync()
            //var actual = client.SendAsync(httpRequestMessage, new CancellationToken()).Result;

            // assert
            // Step5: 驗證回傳的 StatusCode 是否為 BadRequest
            //Assert.AreEqual(HttpStatusCode.BadRequest, actual.StatusCode);

            Assert.Inconclusive();
        }

        [TestMethod]
        public void Test_聖誕節的時候_才可以正常呼叫()
        {
            // Question: 怎麼模擬今天是聖誕節？

            // arrange 

            // Step1: 初始化 fakeInnerHandler, 拿來接在欲測試的 messageHandler 後面
            // 預計的回傳值可以隨便自訂

            // Step2: 初始化測試目標，並將 fakeInnerHandler assign 給 InnerHandler 的 property
            

            // Step3: MessageHandler 的單元測試，需要透過HttpMessageInvoker來模擬 client 端送 request 進來
            
            
            // act
            // Step4: 呼叫HttpMessageInvoker的 SendAsync ，就會先呼叫 target, 
            
            
            // assert
            // Step5: 驗證回傳的 StatusCode 是否為 OK
            

            // Step6: 驗證回傳的訊息內容，是否為 fakeInnerHandler 的 Message 內容
            
            Assert.Inconclusive();
        }
    }

    // FakeInnerHandler 是用來模擬 Controller 或是下一個 MessageHandler 回傳值的 stub object
    //internal class FakeInnerHandler : DelegatingHandler
    //{
    //    internal HttpResponseMessage Message { get; set; }

    //    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //    {
    //        if (Message == null)
    //        {
    //            return base.SendAsync(request, cancellationToken);
    //        }
    //        return Task.Factory.StartNew(() => Message);
    //    }
    //}
}
