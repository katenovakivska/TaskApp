namespace Application.Queries.SharedTaskLists
{
    public class GetAccessByTaskListIdAndUserIdQuery
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
    }
}
