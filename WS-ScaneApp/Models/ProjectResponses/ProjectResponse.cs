namespace WS_ScaneApp.Models.ProjectResponses
{
    public class ProjectResponse
    {
        public int Success { get; set; } = 0;
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
