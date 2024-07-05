using Newtonsoft.Json;

namespace OnlineStore.Interface.WebApi.Services
{
    internal class ErrorDetails
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
