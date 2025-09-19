using System;

namespace Petshop.DAL.DataContext.Entities;

public class HeaderInfo : TimeStample
{
    public string LogoPath { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;
}


