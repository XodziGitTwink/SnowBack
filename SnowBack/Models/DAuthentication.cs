using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DAuthentication
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
