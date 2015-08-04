using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandlerLib
{
    public class XmasMessageHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            //var month = DateTime.Today.Month;
            //var day = DateTime.Today.Day;
            var now = (DateTime)this.MockNow;
            var month = now.Month;
            var day = now.Day;

            var isDay24Or25 = day == 24 || day == 25;

            var isXmax = month == 12 && isDay24Or25;

            if (!isXmax)
            {
                // 回傳BadRequset
                var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();

                var response = request.CreateResponse(HttpStatusCode.BadRequest);
                taskCompletionSource.SetResult(response);

                return taskCompletionSource.Task;
            }
            else
            {
                // 正常通過
                return base.SendAsync(request, cancellationToken);
            }
        }

        private DateTime? _mockNow;

        public DateTime? MockNow
        {
            get
            {
                if (this._mockNow == null)
                {
                    return DateTime.Now;
                }
                else
                {
                    return this._mockNow;
                }

            }
            set
            {
                this._mockNow = value;
            }
        }
    }
}