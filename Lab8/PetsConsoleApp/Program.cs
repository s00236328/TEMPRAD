using ModelsClass;
namespace PetsConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class SeedData
    {
        public static void Seed(Models context)
        {
            // Seed Veterinarians
            var veterinarians = new List<Veterinarian>
            {
                new Veterinarian { Name = "Dr. Emily Carter" },
                new Veterinarian { Name = "Dr. James Wilson" },
                new Veterinarian { Name = "Dr. Sophia Rivera" }
            };

            context.Veterinarians.AddRange(veterinarians);

            // Seed Owners
            var owners = new List<Owner>
            {
                new Owner { Name = "Alice Johnson", Veterinarian = veterinarians[0] },
                new Owner { Name = "Bob Smith", Veterinarian = veterinarians[1] },
                new Owner { Name = "Charlie Davis", Veterinarian = veterinarians[2] }
            };

            context.Owners.AddRange(owners);

            // Seed Pets
            var pets = new List<Pet>
            {
                new Pet { Name = "Bella", Owner = owners[0] },
                new Pet { Name = "Rocky", Owner = owners[1] },
                new Pet { Name = "Luna", Owner = owners[2] }
            };

            context.Pets.AddRange(pets);

            // Seed Toys
            var toys = new List<Toy>
            {
                new Toy { Name = "Rubber Ball" },
                new Toy { Name = "Squeaky Bone" },
                new Toy { Name = "Frisbee" }
            };

            context.Toys.AddRange(toys);

            // Seed PetToys (Many-to-Many relationship between Pets and Toys)
            var petToys = new List<PetToy>
            {
                new PetToy { Pet = pets[0], Toy = toys[0] }, // Bella has a Rubber Ball
                new PetToy { Pet = pets[1], Toy = toys[1] }, // Rocky has a Squeaky Bone
                new PetToy { Pet = pets[2], Toy = toys[2] }, // Luna has a Frisbee
                new PetToy { Pet = pets[0], Toy = toys[2] }, // Bella also has a Frisbee
                new PetToy { Pet = pets[1], Toy = toys[0] }  // Rocky also has a Rubber Ball
            };

            context.PetToys.AddRange(petToys);

            // Save all changes to the database
            context.SaveChanges();
        }
    }
}

