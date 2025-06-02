namespace Application.Queries.TaskLists
{
    public class GetTaskListByIdAndUserIdQuery
    {
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }
    }
}
