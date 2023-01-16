using System;
using System.Collections.Generic;

namespace oPlan_Repository;

public partial class User
{
    public string Id { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    public DateOnly DateCreated { get; set; }

    public virtual ICollection<Agenda> Agenda { get; } = new List<Agenda>();

    public virtual ICollection<Todo> Todos { get; } = new List<Todo>();
}
