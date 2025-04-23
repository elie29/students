using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StudentManagement.Api.Models;

namespace StudentManagement.Api.Data
{
    public class DataSeeder
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<DataSeeder> _logger;

        public DataSeeder(StudentDbContext context, ILogger<DataSeeder> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedDataAsync()
        {
            try
            {
                // Only seed if the database is empty
                if (!_context.Students.Any())
                {
                    _logger.LogInformation("Database is empty. Seeding sample data...");
                    
                    // Seed with predefined students
                    await SeedStudentsAsync();
                    
                    _logger.LogInformation("Sample data seeding completed successfully.");
                }
                else
                {
                    _logger.LogInformation("Database already contains data. Skipping seed operation.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        private async Task SeedStudentsAsync()
        {
            // Create a list with predefined students with unique emails
            var students = GetPredefinedStudents();
            
            // Add the students to the context
            await _context.Students.AddRangeAsync(students);
            
            // Save changes to the database
            await _context.SaveChangesAsync();
            
            _logger.LogInformation($"Successfully seeded {students.Count} students into the database.");
        }

        private List<Student> GetPredefinedStudents()
        {
            return new List<Student>
            {
                new Student { FirstName = "Emma", LastName = "Johnson", Email = "emma.johnson@example.com", DateOfBirth = new DateTime(1998, 3, 12), Address = "123 Oak Street, Boston, MA" },
                new Student { FirstName = "Liam", LastName = "Smith", Email = "liam.smith@example.com", DateOfBirth = new DateTime(1997, 5, 24), Address = "456 Pine Avenue, New York, NY" },
                new Student { FirstName = "Olivia", LastName = "Williams", Email = "olivia.williams@example.com", DateOfBirth = new DateTime(1999, 11, 8), Address = "789 Maple Road, Chicago, IL" },
                new Student { FirstName = "Noah", LastName = "Brown", Email = "noah.brown@example.com", DateOfBirth = new DateTime(2000, 1, 15), Address = "321 Cedar Lane, San Francisco, CA" },
                new Student { FirstName = "Ava", LastName = "Jones", Email = "ava.jones@example.com", DateOfBirth = new DateTime(1996, 7, 30), Address = "654 Birch Street, Seattle, WA" },
                new Student { FirstName = "William", LastName = "Garcia", Email = "william.garcia@example.com", DateOfBirth = new DateTime(1998, 9, 18), Address = "987 Elm Road, Austin, TX" },
                new Student { FirstName = "Sophia", LastName = "Miller", Email = "sophia.miller@example.com", DateOfBirth = new DateTime(1997, 4, 22), Address = "159 Spruce Circle, Denver, CO" },
                new Student { FirstName = "James", LastName = "Davis", Email = "james.davis@example.com", DateOfBirth = new DateTime(1999, 6, 11), Address = "753 Willow Avenue, Portland, OR" },
                new Student { FirstName = "Isabella", LastName = "Rodriguez", Email = "isabella.rodriguez@example.com", DateOfBirth = new DateTime(2000, 2, 28), Address = "246 Redwood Lane, Miami, FL" },
                new Student { FirstName = "Benjamin", LastName = "Martinez", Email = "benjamin.martinez@example.com", DateOfBirth = new DateTime(1996, 12, 5), Address = "864 Aspen Drive, Phoenix, AZ" },
                new Student { FirstName = "Mia", LastName = "Hernandez", Email = "mia.hernandez@example.com", DateOfBirth = new DateTime(1998, 8, 17), Address = "975 Pine Street, Philadelphia, PA" },
                new Student { FirstName = "Mason", LastName = "Lopez", Email = "mason.lopez@example.com", DateOfBirth = new DateTime(1997, 10, 9), Address = "258 Oak Road, Detroit, MI" },
                new Student { FirstName = "Charlotte", LastName = "Gonzalez", Email = "charlotte.gonzalez@example.com", DateOfBirth = new DateTime(1999, 1, 20), Address = "369 Maple Lane, Atlanta, GA" },
                new Student { FirstName = "Elijah", LastName = "Wilson", Email = "elijah.wilson@example.com", DateOfBirth = new DateTime(2000, 4, 3), Address = "147 Cedar Avenue, Dallas, TX" },
                new Student { FirstName = "Amelia", LastName = "Anderson", Email = "amelia.anderson@example.com", DateOfBirth = new DateTime(1996, 5, 14), Address = "741 Birch Road, San Diego, CA" },
                new Student { FirstName = "Oliver", LastName = "Thomas", Email = "oliver.thomas@example.com", DateOfBirth = new DateTime(1998, 2, 25), Address = "852 Elm Circle, Houston, TX" },
                new Student { FirstName = "Evelyn", LastName = "Taylor", Email = "evelyn.taylor@example.com", DateOfBirth = new DateTime(1997, 12, 19), Address = "963 Spruce Drive, Minneapolis, MN" },
                new Student { FirstName = "Lucas", LastName = "Moore", Email = "lucas.moore@example.com", DateOfBirth = new DateTime(1999, 7, 7), Address = "159 Willow Street, St. Louis, MO" },
                new Student { FirstName = "Harper", LastName = "Jackson", Email = "harper.jackson@example.com", DateOfBirth = new DateTime(2000, 9, 29), Address = "357 Redwood Avenue, Nashville, TN" },
                new Student { FirstName = "Alexander", LastName = "Martin", Email = "alexander.martin@example.com", DateOfBirth = new DateTime(1996, 11, 11), Address = "864 Aspen Lane, Las Vegas, NV" },
                new Student { FirstName = "Abigail", LastName = "Lee", Email = "abigail.lee@example.com", DateOfBirth = new DateTime(1998, 6, 26), Address = "951 Pine Road, Charlotte, NC" },
                new Student { FirstName = "Ethan", LastName = "Perez", Email = "ethan.perez@example.com", DateOfBirth = new DateTime(1997, 3, 5), Address = "753 Oak Lane, Indianapolis, IN" },
                new Student { FirstName = "Elizabeth", LastName = "Thompson", Email = "elizabeth.thompson@example.com", DateOfBirth = new DateTime(1999, 4, 14), Address = "246 Maple Street, Columbus, OH" },
                new Student { FirstName = "Aiden", LastName = "White", Email = "aiden.white@example.com", DateOfBirth = new DateTime(2000, 8, 7), Address = "159 Cedar Road, New Orleans, LA" },
                new Student { FirstName = "Avery", LastName = "Harris", Email = "avery.harris@example.com", DateOfBirth = new DateTime(1996, 1, 23), Address = "357 Birch Avenue, Salt Lake City, UT" },
                new Student { FirstName = "Jacob", LastName = "Sanchez", Email = "jacob.sanchez@example.com", DateOfBirth = new DateTime(1998, 10, 10), Address = "852 Elm Lane, Kansas City, MO" },
                new Student { FirstName = "Ella", LastName = "Clark", Email = "ella.clark@example.com", DateOfBirth = new DateTime(1997, 6, 30), Address = "963 Spruce Circle, Sacramento, CA" },
                new Student { FirstName = "Michael", LastName = "Ramirez", Email = "michael.ramirez@example.com", DateOfBirth = new DateTime(1999, 9, 21), Address = "753 Willow Drive, Memphis, TN" },
                new Student { FirstName = "Scarlett", LastName = "Lewis", Email = "scarlett.lewis@example.com", DateOfBirth = new DateTime(2000, 12, 12), Address = "159 Redwood Road, Louisville, KY" },
                new Student { FirstName = "Daniel", LastName = "Robinson", Email = "daniel.robinson@example.com", DateOfBirth = new DateTime(1996, 4, 5), Address = "357 Aspen Avenue, Oklahoma City, OK" },
                new Student { FirstName = "Madison", LastName = "Walker", Email = "madison.walker@example.com", DateOfBirth = new DateTime(1998, 7, 28), Address = "852 Pine Lane, Baltimore, MD" },
                new Student { FirstName = "Henry", LastName = "Young", Email = "henry.young@example.com", DateOfBirth = new DateTime(1997, 2, 14), Address = "963 Oak Street, Albuquerque, NM" },
                new Student { FirstName = "Lily", LastName = "Allen", Email = "lily.allen@example.com", DateOfBirth = new DateTime(1999, 5, 5), Address = "753 Maple Road, Tucson, AZ" },
                new Student { FirstName = "Joseph", LastName = "King", Email = "joseph.king@example.com", DateOfBirth = new DateTime(2000, 3, 26), Address = "159 Cedar Lane, Fresno, CA" },
                new Student { FirstName = "Chloe", LastName = "Wright", Email = "chloe.wright@example.com", DateOfBirth = new DateTime(1996, 8, 16), Address = "357 Birch Circle, Omaha, NE" },
                new Student { FirstName = "Samuel", LastName = "Scott", Email = "samuel.scott@example.com", DateOfBirth = new DateTime(1998, 1, 7), Address = "852 Elm Drive, Raleigh, NC" },
                new Student { FirstName = "Zoe", LastName = "Torres", Email = "zoe.torres@example.com", DateOfBirth = new DateTime(1997, 11, 29), Address = "963 Spruce Lane, Cleveland, OH" },
                new Student { FirstName = "David", LastName = "Nguyen", Email = "david.nguyen@example.com", DateOfBirth = new DateTime(1999, 10, 18), Address = "753 Willow Road, Pittsburgh, PA" },
                new Student { FirstName = "Grace", LastName = "Hill", Email = "grace.hill@example.com", DateOfBirth = new DateTime(2000, 6, 9), Address = "159 Redwood Street, Orlando, FL" },
                new Student { FirstName = "Wyatt", LastName = "Flores", Email = "wyatt.flores@example.com", DateOfBirth = new DateTime(1996, 9, 30), Address = "357 Aspen Lane, Buffalo, NY" },
                new Student { FirstName = "Emily", LastName = "Green", Email = "emily.green@example.com", DateOfBirth = new DateTime(1998, 4, 11), Address = "852 Pine Circle, Richmond, VA" },
                new Student { FirstName = "Sebastian", LastName = "Adams", Email = "sebastian.adams@example.com", DateOfBirth = new DateTime(1997, 8, 22), Address = "963 Oak Avenue, Hartford, CT" },
                new Student { FirstName = "Sofia", LastName = "Nelson", Email = "sofia.nelson@example.com", DateOfBirth = new DateTime(1999, 2, 2), Address = "753 Maple Lane, Providence, RI" },
                new Student { FirstName = "Christopher", LastName = "Baker", Email = "christopher.baker@example.com", DateOfBirth = new DateTime(2000, 5, 15), Address = "159 Cedar Road, Cincinnati, OH" },
                new Student { FirstName = "Penelope", LastName = "Hall", Email = "penelope.hall@example.com", DateOfBirth = new DateTime(1996, 10, 24), Address = "357 Birch Drive, Milwaukee, WI" },
                new Student { FirstName = "Carter", LastName = "Rivera", Email = "carter.rivera@example.com", DateOfBirth = new DateTime(1998, 12, 31), Address = "852 Elm Street, Jacksonville, FL" },
                new Student { FirstName = "Layla", LastName = "Campbell", Email = "layla.campbell@example.com", DateOfBirth = new DateTime(1997, 7, 19), Address = "963 Spruce Avenue, Oakland, CA" },
                new Student { FirstName = "Andrew", LastName = "Mitchell", Email = "andrew.mitchell@example.com", DateOfBirth = new DateTime(1999, 3, 28), Address = "753 Willow Lane, Tampa, FL" },
                new Student { FirstName = "Riley", LastName = "Carter", Email = "riley.carter@example.com", DateOfBirth = new DateTime(2000, 11, 1), Address = "159 Redwood Circle, Honolulu, HI" },
                new Student { FirstName = "Jackson", LastName = "Roberts", Email = "jackson.roberts@example.com", DateOfBirth = new DateTime(1996, 3, 17), Address = "357 Aspen Street, Anchorage, AK" },
                new Student { FirstName = "Nora", LastName = "Gomez", Email = "nora.gomez@example.com", DateOfBirth = new DateTime(1998, 5, 8), Address = "852 Pine Avenue, Birmingham, AL" },
                new Student { FirstName = "Luke", LastName = "Phillips", Email = "luke.phillips@example.com", DateOfBirth = new DateTime(1997, 1, 27), Address = "963 Oak Lane, Charleston, SC" },
                new Student { FirstName = "Hannah", LastName = "Evans", Email = "hannah.evans@example.com", DateOfBirth = new DateTime(1999, 12, 9), Address = "753 Maple Circle, Savannah, GA" },
                new Student { FirstName = "Levi", LastName = "Turner", Email = "levi.turner@example.com", DateOfBirth = new DateTime(2000, 7, 21), Address = "159 Cedar Drive, Little Rock, AR" },
                new Student { FirstName = "Aria", LastName = "Diaz", Email = "aria.diaz@example.com", DateOfBirth = new DateTime(1996, 2, 4), Address = "357 Birch Road, Boise, ID" },
                new Student { FirstName = "Isaac", LastName = "Parker", Email = "isaac.parker@example.com", DateOfBirth = new DateTime(1998, 11, 15), Address = "852 Elm Lane, Des Moines, IA" },
                new Student { FirstName = "Victoria", LastName = "Cruz", Email = "victoria.cruz@example.com", DateOfBirth = new DateTime(1997, 9, 6), Address = "963 Spruce Street, Fargo, ND" },
                new Student { FirstName = "Julian", LastName = "Edwards", Email = "julian.edwards@example.com", DateOfBirth = new DateTime(1999, 8, 23), Address = "753 Willow Avenue, Manchester, NH" },
                new Student { FirstName = "Audrey", LastName = "Collins", Email = "audrey.collins@example.com", DateOfBirth = new DateTime(2000, 10, 4), Address = "159 Redwood Lane, Burlington, VT" },
                new Student { FirstName = "Gabriel", LastName = "Reyes", Email = "gabriel.reyes@example.com", DateOfBirth = new DateTime(1996, 6, 15), Address = "357 Aspen Circle, Wilmington, DE" },
                new Student { FirstName = "Natalie", LastName = "Stewart", Email = "natalie.stewart@example.com", DateOfBirth = new DateTime(1998, 3, 26), Address = "852 Pine Drive, Billings, MT" },
                new Student { FirstName = "Mateo", LastName = "Morris", Email = "mateo.morris@example.com", DateOfBirth = new DateTime(1997, 12, 7), Address = "963 Oak Road, Cheyenne, WY" },
                new Student { FirstName = "Camila", LastName = "Morales", Email = "camila.morales@example.com", DateOfBirth = new DateTime(1999, 11, 18), Address = "753 Maple Street, Jackson, MS" },
                new Student { FirstName = "Lincoln", LastName = "Murphy", Email = "lincoln.murphy@example.com", DateOfBirth = new DateTime(2000, 1, 29), Address = "159 Cedar Lane, Columbia, SC" },
                new Student { FirstName = "Eleanor", LastName = "Cook", Email = "eleanor.cook@example.com", DateOfBirth = new DateTime(1996, 5, 9), Address = "357 Birch Avenue, Augusta, ME" },
                new Student { FirstName = "Josiah", LastName = "Rogers", Email = "josiah.rogers@example.com", DateOfBirth = new DateTime(1998, 2, 20), Address = "852 Elm Circle, Juneau, AK" },
                new Student { FirstName = "Skylar", LastName = "Morgan", Email = "skylar.morgan@example.com", DateOfBirth = new DateTime(1997, 4, 1), Address = "963 Spruce Road, Montpelier, VT" },
                new Student { FirstName = "Anthony", LastName = "Peterson", Email = "anthony.peterson@example.com", DateOfBirth = new DateTime(1999, 6, 12), Address = "753 Willow Drive, Pierre, SD" },
                new Student { FirstName = "Lucy", LastName = "Cooper", Email = "lucy.cooper@example.com", DateOfBirth = new DateTime(2000, 9, 23), Address = "159 Redwood Avenue, Helena, MT" },
                new Student { FirstName = "Grayson", LastName = "Reed", Email = "grayson.reed@example.com", DateOfBirth = new DateTime(1996, 12, 2), Address = "357 Aspen Drive, Springfield, IL" },
                new Student { FirstName = "Stella", LastName = "Bailey", Email = "stella.bailey@example.com", DateOfBirth = new DateTime(1998, 8, 13), Address = "852 Pine Road, Albany, NY" },
                new Student { FirstName = "Dominic", LastName = "Bell", Email = "dominic.bell@example.com", DateOfBirth = new DateTime(1997, 10, 24), Address = "963 Oak Lane, Santa Fe, NM" },
                new Student { FirstName = "Leah", LastName = "Coleman", Email = "leah.coleman@example.com", DateOfBirth = new DateTime(1999, 1, 5), Address = "753 Maple Drive, Topeka, KS" },
                new Student { FirstName = "Jaxon", LastName = "Kelly", Email = "jaxon.kelly@example.com", DateOfBirth = new DateTime(2000, 5, 16), Address = "159 Cedar Circle, Carson City, NV" },
                new Student { FirstName = "Violet", LastName = "Howard", Email = "violet.howard@example.com", DateOfBirth = new DateTime(1996, 7, 27), Address = "357 Birch Lane, Concord, NH" },
                new Student { FirstName = "Ryan", LastName = "Ward", Email = "ryan.ward@example.com", DateOfBirth = new DateTime(1998, 9, 7), Address = "852 Elm Avenue, Dover, DE" },
                new Student { FirstName = "Hazel", LastName = "Cox", Email = "hazel.cox@example.com", DateOfBirth = new DateTime(1997, 5, 18), Address = "963 Spruce Drive, Nashville, TN" },
                new Student { FirstName = "Nathan", LastName = "Brooks", Email = "nathan.brooks@example.com", DateOfBirth = new DateTime(1999, 3, 29), Address = "753 Willow Circle, Salt Lake City, UT" },
                new Student { FirstName = "Aurora", LastName = "Richardson", Email = "aurora.richardson@example.com", DateOfBirth = new DateTime(2000, 11, 9), Address = "159 Redwood Road, Raleigh, NC" },
                new Student { FirstName = "Aaron", LastName = "Wood", Email = "aaron.wood@example.com", DateOfBirth = new DateTime(1996, 9, 20), Address = "357 Aspen Avenue, Seattle, WA" },
                new Student { FirstName = "Brooklyn", LastName = "Watson", Email = "brooklyn.watson@example.com", DateOfBirth = new DateTime(1998, 1, 1), Address = "852 Pine Lane, Boston, MA" },
                new Student { FirstName = "Thomas", LastName = "Brooks", Email = "thomas.brooks@example.com", DateOfBirth = new DateTime(1997, 2, 12), Address = "963 Oak Street, Austin, TX" },
                new Student { FirstName = "Bella", LastName = "Chavez", Email = "bella.chavez@example.com", DateOfBirth = new DateTime(1999, 4, 23), Address = "753 Maple Avenue, Chicago, IL" },
                new Student { FirstName = "John", LastName = "Gibson", Email = "john.gibson@example.com", DateOfBirth = new DateTime(2000, 6, 4), Address = "159 Cedar Road, Denver, CO" },
                new Student { FirstName = "Claire", LastName = "Bryant", Email = "claire.bryant@example.com", DateOfBirth = new DateTime(1996, 8, 15), Address = "357 Birch Drive, Miami, FL" },
                new Student { FirstName = "Asher", LastName = "Russell", Email = "asher.russell@example.com", DateOfBirth = new DateTime(1998, 10, 26), Address = "852 Elm Lane, Phoenix, AZ" },
                new Student { FirstName = "Mila", LastName = "Griffin", Email = "mila.griffin@example.com", DateOfBirth = new DateTime(1997, 7, 7), Address = "963 Spruce Street, Portland, OR" },
                new Student { FirstName = "Christian", LastName = "Price", Email = "christian.price@example.com", DateOfBirth = new DateTime(1999, 12, 18), Address = "753 Willow Road, Detroit, MI" },
                new Student { FirstName = "Savannah", LastName = "Hayes", Email = "savannah.hayes@example.com", DateOfBirth = new DateTime(2000, 2, 28), Address = "159 Redwood Lane, Atlanta, GA" },
                new Student { FirstName = "Theodore", LastName = "Myers", Email = "theodore.myers@example.com", DateOfBirth = new DateTime(1996, 4, 10), Address = "357 Aspen Circle, San Francisco, CA" },
                new Student { FirstName = "Aubrey", LastName = "Long", Email = "aubrey.long@example.com", DateOfBirth = new DateTime(1998, 6, 21), Address = "852 Pine Street, Las Vegas, NV" },
                new Student { FirstName = "Caleb", LastName = "Foster", Email = "caleb.foster@example.com", DateOfBirth = new DateTime(1997, 3, 2), Address = "963 Oak Road, Philadelphia, PA" },
                new Student { FirstName = "Genesis", LastName = "Sanders", Email = "genesis.sanders@example.com", DateOfBirth = new DateTime(1999, 5, 13), Address = "753 Maple Lane, New York, NY" },
                new Student { FirstName = "Owen", LastName = "Ross", Email = "owen.ross@example.com", DateOfBirth = new DateTime(2000, 8, 24), Address = "159 Cedar Avenue, Washington, DC" },
                new Student { FirstName = "Ellie", LastName = "Simmons", Email = "ellie.simmons@example.com", DateOfBirth = new DateTime(1996, 11, 4), Address = "357 Birch Road, Houston, TX" },
                new Student { FirstName = "Jack", LastName = "Powell", Email = "jack.powell@example.com", DateOfBirth = new DateTime(1998, 7, 15), Address = "852 Elm Avenue, Los Angeles, CA" },
                new Student { FirstName = "Ivy", LastName = "Sullivan", Email = "ivy.sullivan@example.com", DateOfBirth = new DateTime(1997, 12, 26), Address = "963 Spruce Circle, San Diego, CA" },
                new Student { FirstName = "Hudson", LastName = "Perry", Email = "hudson.perry@example.com", DateOfBirth = new DateTime(1999, 10, 5), Address = "741 Oak Drive, Minneapolis, MN" },
                new Student { FirstName = "Luna", LastName = "Fisher", Email = "luna.fisher@example.com", DateOfBirth = new DateTime(1998, 3, 8), Address = "325 Cedar Street, San Antonio, TX" },
                new Student { FirstName = "Jordan", LastName = "Barnes", Email = "jordan.barnes@example.com", DateOfBirth = new DateTime(1997, 6, 18), Address = "159 Maple Boulevard, Columbus, OH" }
            };
        }
    }
} 