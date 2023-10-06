using System;
using System.Collections.Generic;

namespace appCore.Models;

public partial class Unidade
{
    public Guid Unidadeid { get; set; }

    public string? Nome { get; set; }

    public string? Sigla { get; set; }
}
