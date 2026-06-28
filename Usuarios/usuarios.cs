namespace Usuarios;
using direccion;
using company;
using System.Security.AccessControl;
using System.Threading.Channels;
using System.Text.Json.Serialization;

public class Usuario
{
    public int ?id{get; set;}
    public string ?name{get; set;}
    public string ?username{get; set;}
    public string ?email{get; set;}
    public Address ?address{get; set;}
    public string ?phone{get; set;}
    public string ?website{get; set;}
    public Company ?company{get; set;}
}
