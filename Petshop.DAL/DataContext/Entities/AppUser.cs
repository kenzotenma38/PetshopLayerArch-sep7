﻿using Microsoft.AspNetCore.Identity;

namespace Petshop.DAL.DataContext.Entities;

public class AppUser : IdentityUser
{
    public string? FullName {  get; set; }

    public string? ProfileImageName {  get; set; }

    public ICollection<Review> Reviews { get; set; } = [];
}
