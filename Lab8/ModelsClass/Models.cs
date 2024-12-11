using System.Collections.Generic;
namespace ModelsClass
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int VeterinarianId { get; set; } // Foreign Key for One-to-One relationship
        public Veterinarian Veterinarian { get; set; } // Navigation property
        public List<Pet> Pets { get; set; } = new List<Pet>(); // Navigation property
    }

    // Pet class with Many-to-One relationship with Owner and Many-to-Many with Toy
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; } // Foreign Key
        public Owner Owner { get; set; } // Navigation property
        public List<PetToy> PetToys { get; set; } = new List<PetToy>(); // Navigation property
    }

    // Toy class with Many-to-Many relationship with Pet
    public class Toy
    {
        public int ToyId { get; set; }
        public string Name { get; set; }
        public List<PetToy> PetToys { get; set; } = new List<PetToy>(); // Navigation property
    }

    // Junction table for Many-to-Many relationship between Pet and Toy
    public class PetToy
    {
        public int PetId { get; set; } // Foreign Key
        public Pet Pet { get; set; } // Navigation property
        public int ToyId { get; set; } // Foreign Key
        public Toy Toy { get; set; } // Navigation property
    }

    // Veterinarian class with One-to-Many relationship with Owners
    public class Veterinarian
    {
        public int VeterinarianId { get; set; }
        public string Name { get; set; }
        public List<Owner> Owners { get; set; } = new List<Owner>(); // Navigation property
    }
}

