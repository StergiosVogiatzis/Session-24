using System;
using System.Linq;

namespace RedMotors.Entities;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Person()
    {
        Id = Guid.NewGuid();
    }

}
