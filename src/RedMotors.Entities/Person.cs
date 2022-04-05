using System;
using System.Linq;

namespace RedMotors.Entities;

public class Person
{
    public Guid Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Person()
    {
    }

}
