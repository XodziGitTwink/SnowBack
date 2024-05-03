using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JTask
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int Task { get; set; } // ссылка на задание в справочнике

    public string? Description { get; set; }

    public int? Element { get; set; } // ссылка на элемент инфраструктуры

    public int Executor { get; set; } // ссылка на исполнителя

    public DateTime Dateon { get; set; }

    public DateTime Dateoff { get; set; }

    public string Emergency { get; set; } = null!; // приоритет

    public int Creator { get; set; }

    public virtual DStaff ExecutorNavigation { get; set; } = null!;
}

// 