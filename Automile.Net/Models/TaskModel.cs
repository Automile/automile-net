using System;
using System.Collections.Generic;


namespace Automile.Net
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public int CreatedByContactId { get; set; }
        public string CreatedByContactName { get; set; }
        public int? TaskAcquiredByContactId { get; set; }
        public string TaskAcquiredByContactName { get; set; }

        public int? LastMessageSentByContactId { get; set; }
        public string LastMessageSentByContactName { get; set; }
        public string LastMessageShortText { get; set; }
        public DateTime? LastMessageDateUtc { get; set; }
        public bool? LastMessageIsRead { get; set; }
        public string CreatedByContactImageUrl { get; set; }
        public string TaskAcquiredByContactImageUrl { get; set; }
        public ApiTaskStatusType TaskStatusType { get; set; }
        public ApiTaskType TaskType { get; set; }
        public int UnreadTaskMessages { get; set; }
    }

    public class TaskDetailModel
    {
        public int TaskId { get; set; }
        public int CreatedByContactId { get; set; }
        public string CreatedByContactName { get; set; }
        public int? TaskAcquiredByContactId { get; set; }
        public string TaskAcquiredByContactName { get; set; }

        public List<TaskMessageModel> TaskMessages { get; set; }
    }

    public class TaskMessageModel
    {
        public int TaskMessageId { get; set; }
        public int SentByContactId { get; set; }
        public int ToContactId { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageSentAtUtc { get; set; }
        public string SentByContactName { get; set; }
        public string ToContactName { get; set; }
        public bool MessageIsRead { get; set; }        

        public PositionModel Position { get; set; }
    }

    public class PositionModel
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class TaskCreateModel
    {
        public ApiTaskType TaskType { get; set; }
        public int? ToContactId { get; set; }
        public string TaskMessageText { get; set; }
        public PositionModel Position { get; set; }
    }

    public class TaskMessageEditModel
    {
        public bool IsRead { get; set; }
    }

    public class TaskMessageCreateModel
    {
        public int TaskId { get; set; }
        public string MessageText { get; set; }
        public PositionModel Position { get; set; }
    }
}