﻿namespace Hospital.Models;
public class TestPrice
{
    public Guid Id { get; set; }
    public string TestCode { get; set; }
    public decimal Price { get; set; }
    public Lab Lab { get; set; }
    public Bill Bill { get; set; }
}
