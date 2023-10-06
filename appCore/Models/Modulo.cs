using System;
using System.Collections.Generic;

namespace appCore.Models;

public partial class Modulo
{
    public string? Nome { get; set; }

    public string? Url { get; set; }

    public int? Posicao { get; set; }

    public Guid? Moduloid { get; set; }
}
