using System;
using System.Collections.Generic;

namespace DatabaseSchemaManager.Models1;

public partial class Log
{
    public int LogId { get; set; }

    public DateTime EventTime { get; set; }

    public string EventType { get; set; } = null!;

    public string Description { get; set; } = null!;
}
