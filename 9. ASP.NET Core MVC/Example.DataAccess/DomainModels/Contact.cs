﻿namespace Example.DataAccess.DomainModels;

public class Contact : BaseEntity
{
    public string Name { get; set; }

    public string Phone { get; set; }
}