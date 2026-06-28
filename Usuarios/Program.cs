// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Usuarios;
HttpClient cliente=new HttpClient();

HttpResponseMessage respuesta=await cliente.GetAsync(@"https://jsonplaceholder.typicode.com/users/");
respuesta.EnsureSuccessStatusCode();

string responseBody=await respuesta.Content.ReadAsStringAsync();
List<Usuario> ?misUsuarios=JsonSerializer.Deserialize<List<Usuario>>(responseBody);

Console.WriteLine("----------5 Primeros usuarios----------\n");
for(int i = 0; i < 5; i++)
{
    Console.WriteLine($"---NOMBRE: {misUsuarios[i].name}");
    Console.WriteLine($"Correo Electronico: {misUsuarios[i].email}");
    Console.WriteLine($"DOMICILIO");
    Console.WriteLine($"Calle: {misUsuarios[i].address.street}");
    Console.WriteLine($"Piso: {misUsuarios[i].address.suite}");
    Console.WriteLine($"Ciudad: {misUsuarios[i].address.city}");
    Console.WriteLine($"ZipCode: {misUsuarios[i].address.zipcode}");
    Console.WriteLine($"COORDENADAS");
    Console.WriteLine($"Latitud: {misUsuarios[i].address.geo.lat}");
    Console.WriteLine($"Longitud: {misUsuarios[i].address.geo.lng}\n");
}

var opciones = new JsonSerializerOptions { WriteIndented = true };
string jsonString=JsonSerializer.Serialize(misUsuarios,opciones);
await File.WriteAllTextAsync("misUsuarios.json",jsonString);