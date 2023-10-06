using System;
using System.Collections;
using System.Collections.Generic;

namespace appCore.Models;

public partial class Formulario
{
    public string Formularioid { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Valor { get; set; }

    public BitArray? Ativo { get; set; }

    public DateTime? Datainclusao { get; set; }

    public string? Areaid { get; set; }
}
