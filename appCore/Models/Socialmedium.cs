﻿using System;
using System.Collections.Generic;

namespace appCore.Models;

public partial class Socialmedium
{
    public string Socialmediaid { get; set; } = null!;

    public string? Aplicacaoid { get; set; }

    public int? Socialmediatypeid { get; set; }

    public string? Socialmedialink { get; set; }
}
