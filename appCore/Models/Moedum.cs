using System;
using System.Collections.Generic;

namespace appCore.Models;

public partial class Moedum
{
    public string Moedaid { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Sigla { get; set; }
}
