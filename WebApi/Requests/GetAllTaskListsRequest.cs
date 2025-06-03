namespace WebApi.Requests
{
    public class GetAllTaskListsRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
