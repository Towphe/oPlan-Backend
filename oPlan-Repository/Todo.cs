using System;
using System.Collections.Generic;

namespace oPlan_Repository;

public partial class Todo
{
    public string Id { get; set; }

    public string UserId { get; set; }

    public string AgendaId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly DateUpdated { get; set; }

    public DateOnly DateDone { get; set; }

    public virtual Agenda Agenda { get; set; }

    public virtual User User { get; set; }
}
