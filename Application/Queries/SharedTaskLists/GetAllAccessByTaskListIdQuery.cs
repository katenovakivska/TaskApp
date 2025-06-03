namespace Application.Queries.SharedTaskLists
{
    public class GetAllAccessByTaskListIdQuery
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
    }
}
