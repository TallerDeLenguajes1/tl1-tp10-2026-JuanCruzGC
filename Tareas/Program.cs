// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using Tareas;
using System.Linq;
HttpClient cliente=new HttpClient();

HttpResponseMessage respuesta=await cliente.GetAsync(@"https://jsonplaceholder.typicode.com/todos/");
respuesta.EnsureSuccessStatusCode();

string responseBody=await respuesta.Content.ReadAsStringAsync();
List<Tarea> ?listaTareas=JsonSerializer.Deserialize<List<Tarea>>(responseBody);
Console.WriteLine("----------Tareas----------");
// foreach(Tarea miTar in listaTareas)
// {
//     Console.WriteLine($"--Titulo:{miTar.title}");
//     Console.WriteLine($"Completada:{miTar.completed}");
// }

List<Tarea> tareasPorEstado=listaTareas.OrderBy(t => t.completed).ToList();

var opciones = new JsonSerializerOptions { WriteIndented = true };  //Para que el json este identado y sea legible
string jsonString=JsonSerializer.Serialize(tareasPorEstado,opciones);
await File.WriteAllTextAsync("tareas.json",jsonString);