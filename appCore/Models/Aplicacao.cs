﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace appCore.Models;

public partial class Aplicacao
{
    public string? Nome { get; set; }

    public string? Url { get; set; }

    public DateTime? Datainicio { get; set; }

    public DateTime? Datafinal { get; set; }

    public string? Idusuarioinicio { get; set; }

    public string? Idusuariofim { get; set; }

    public string? Pagsegurotoken { get; set; }

    public string? Layoutchoose { get; set; }

    public int? Posicao { get; set; }

    public string? Mailuser { get; set; }

    public string? Mailpassword { get; set; }

    public string? Mailserver { get; set; }

    public int? Mailport { get; set; }

    public short? Issecure { get; set; }

    public string? Pagefacebook { get; set; }

    public string? Pagelinkedin { get; set; }

    public string? Pageinstagram { get; set; }

    public string? Pagetwitter { get; set; }

    public string? Pagepinterest { get; set; }

    public string? Pageflicker { get; set; }

    public byte[]? Lotipo { get; set; }

    public string? Ogleadsense { get; set; }

    public BitArray? Isactivea { get; set; }

    public string? Header { get; set; }

    /// <summary>
    /// Id unico da aplicacao
    /// </summary>
    public Guid Aplicacaoid { get; set; }

    public bool? Isactive { get; set; }
}
