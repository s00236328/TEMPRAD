using Microsoft.Extensions.Options;
using ModelsClass;
using System.Reflection.Metadata;

namespace PetsConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Petsdb())
            {
                SeedData.Seed(context);

                // Query 1: Get Pets Owned by a Specific Owner
                var ownerName = "Bob Tuah";
                var petsByOwner = context.Pets
                    .Where(p => p.Owner.Name == ownerName)
                    .Select(p => new { p.Name })
                    .ToList();

                Console.WriteLine("Pets owned by " + ownerName + ":");
                foreach (var pet in petsByOwner)
                {
                    Console.WriteLine($"Pet Name: {pet.Name}");
                }

                // Query 2: Get Toys Owned by a Specific Pet
                var petName = "Bella";
                var toysByPet = context.PetToys
                    .Where(pt => pt.Pet.Name == petName)
                    .Select(pt => new { pt.Toy.Name })
                    .ToList();

                Console.WriteLine("Toys owned by " + petName + ":");
                foreach (var toy in toysByPet)
                {
                    Console.WriteLine($"Toy Name: {toy.Name}");
                }

                // Query 3: Count the Number of Pets Each Owner Has
                var petsCountByOwner = context.Owners
                    .Select(o => new
                    {
                        o.Name,
                        PetCount = o.Pets.Count
                    })
                    .ToList();

                Console.WriteLine("Number of pets each owner has:");
                foreach (var owner in petsCountByOwner)
                {
                    Console.WriteLine($"Owner: {owner.Name}, Pets: {owner.PetCount}");
                }

                // Query 4: Find Veterinarians with Multiple Owners
                var veterinariansWithMultipleOwners = context.Veterinarians
                    .Where(v => v.Owners.Count > 1)
                    .Select(v => new { v.Name, OwnerCount = v.Owners.Count })
                    .ToList();

                Console.WriteLine("Veterinarians with multiple owners:");
                foreach (var vet in veterinariansWithMultipleOwners)
                {
                    Console.WriteLine($"Veterinarian: {vet.Name}, Owners: {vet.OwnerCount}");
                }

                // Query 5: Get Pets and Their Toys
                var petsWithToys = context.Pets
                    .Select(p => new
                    {
                        PetName = p.Name,
                        Toys = p.PetToys.Select(pt => pt.Toy.Name).ToList()
                    })
                    .ToList();

                Console.WriteLine("Pets and their toys:");
                foreach (var pet in petsWithToys)
                {
                    Console.WriteLine($"Pet: {pet.PetName}, Toys: {string.Join(", ", pet.Toys)}");
                }
            }
        }

        public class SeedData
        {
            public static void Seed(Petsdb context)
            {
                if (context.Pets.Any())
                {
                    return;
                }

                // Seed Veterinarians
                var veterinarians = new List<Veterinarian>
                {
                    new Veterinarian { Name = "Martin" },
                    new Veterinarian { Name = "Fred" },
                    new Veterinarian { Name = "Bigger Flopper" }
                };

                context.Veterinarians.AddRange(veterinarians);

                // Seed Owners
                var owners = new List<Owner>
                {
                    new Owner { Name = "Jorking Johnson", Veterinarian = veterinarians[0] },
                    new Owner { Name = "Bob Tuah", Veterinarian = veterinarians[1] },
                    new Owner { Name = "Charlie France", Veterinarian = veterinarians[2] }
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
}