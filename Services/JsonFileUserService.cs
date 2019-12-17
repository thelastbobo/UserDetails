using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Json = System.Text.Json;
using System.Threading.Tasks;
using UserDetails.Models;

namespace UserDetails.Services
{
    public class JsonFileUserService
    {
        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json"); }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {

                return Json.JsonSerializer.Deserialize<User[]>(jsonFileReader.ReadToEnd(),
                    new Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public User GetUserById(long id)
        {
            var users = GetUsers();
            var query = users.First(x => x.Id == id);

            if (query != null)
            {
                return query;
            }
            else
            {
                throw new NullReferenceException("The user doesn't exist");
            }
        }

        public void UpdateUser(User user)
        {
            var users = GetUsers();

            var query = users.FirstOrDefault(x => x.Id == user.Id);

            if (query != null)
            {
                query.FirstName = user.FirstName;
                query.LastName = user.LastName;
                query.DateOfBirth = user.DateOfBirth;
                query.Username = user.Username;
            }
            else
            {
                var usersToAdd = users.ToList();
                usersToAdd.Add(user);
                users = usersToAdd.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                Json.JsonSerializer.Serialize<IEnumerable<User>>(
                    new Json.Utf8JsonWriter(outputStream, new Json.JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    users
                );
            };
        }
    }
}
