﻿using System;
using System.Collections.Generic;

namespace appCore.Models;

public partial class Opcao
{
    public string Opcaoid { get; set; } = null!;

    public Guid Atributoid { get; set; }

    public int Qtd { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public int? Estoque { get; set; }
}
