using System;
using System.Collections.Generic;

namespace oPlan_Repository;

public partial class Agenda
{
    public string Id { get; set; }

    public string UserId { get; set; }

    public string Description { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly DateUpdated { get; set; }

    public DateOnly DateDone { get; set; }

    public int TodoCount { get; set; }

    public virtual ICollection<Todo> Todos { get; } = new List<Todo>();

    public virtual User User { get; set; }
}
