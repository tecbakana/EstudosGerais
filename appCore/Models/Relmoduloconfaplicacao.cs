﻿using System;
using System.Collections.Generic;

namespace appCore.Models;

public partial class Relmoduloconfaplicacao
{
    public string Relacaoid { get; set; } = null!;

    public string Moduloconfid { get; set; } = null!;

    public string Aplicacaoid { get; set; } = null!;

    public DateTime Datainclusao { get; set; }

    public DateTime Datafinalizacao { get; set; }
}
