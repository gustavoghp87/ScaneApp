namespace WS_ScaneApp.Models.ProjectResponses
{
    public class ClientResponse
    {
        public int Success { get; set; } = 0;
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
