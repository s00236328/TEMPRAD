using System.Collections.Generic;
namespace ModelsClass
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int VeterinarianId { get; set; } // Fk  
        public Veterinarian Veterinarian { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>(); 
    }

    // Pet with Many-to-One Owner Many-to-Many with Toy
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; } // Fk
        public Owner Owner { get; set; } 
        public List<PetToy> PetToys { get; set; } = new List<PetToy>(); 
    }

    // Toy Many-to-Many with Pet
    public class Toy
    {
        public int ToyId { get; set; }
        public string Name { get; set; }
        public List<PetToy> PetToys { get; set; } = new List<PetToy>(); 
    }

    // join table for Many-to-Many relation Pet and Toy
    public class PetToy
    {
        public int PetId { get; set; } // Fk
        public Pet Pet { get; set; } 
        public int ToyId { get; set; } // Fk
        public Toy Toy { get; set; } 
    }

    // Veterinarian class with One-to-Many relationship with Owners
    public class Veterinarian
    {
        public int VeterinarianId { get; set; }
        public string Name { get; set; }
        public List<Owner> Owners { get; set; } = new List<Owner>(); 
    }
}

