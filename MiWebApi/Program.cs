// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using Show;

string ?seguirBuscando;
do
{
    Console.WriteLine("INGRESE EL NOMBRE DE UNA SERIO O PELICULA");
    string busq=Console.ReadLine();
    string url=@"http://www.omdbapi.com";
    busq=busq.Replace(' ','+');
    string urlCompleta=@$"{url}/?t={busq}&apikey=cfb34f66";

    HttpClient cliente=new HttpClient();
    HttpResponseMessage respuesta=await cliente.GetAsync(urlCompleta);
    respuesta.EnsureSuccessStatusCode();

    string responseBody=await respuesta.Content.ReadAsStringAsync();
    show miBusqueda=JsonSerializer.Deserialize<show>(responseBody);

    Console.WriteLine("-----RESULTADO-----");
    Console.WriteLine($"TITULO: {miBusqueda.titulo}");
    Console.WriteLine($"ANIOS DE EMISION: {miBusqueda.anio}");
    Console.WriteLine($"LANZAMIENTO: {miBusqueda.lanzamiento}");
    Console.WriteLine($"GENERO: {miBusqueda.genero}");
    Console.WriteLine($"TIPO: {miBusqueda.tipo}");
    Console.WriteLine("¿DESEA HACER OTRA BUSQUEDA?    1:SI");
    seguirBuscando=Console.ReadLine();
}while(seguirBuscando.Equals("1"));
