using System;
using System.Collections.Generic;

namespace appCore.Models;

public partial class Tipocotacao
{
    public string Tipocotacaoid { get; set; } = null!;

    public string? Nome { get; set; }

    public string? Descricao { get; set; }
}
