﻿namespace Application.Queries.TaskLists
{
    public class GetAllTaskListsByUserIdQuery
    {
        public Guid UserId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
