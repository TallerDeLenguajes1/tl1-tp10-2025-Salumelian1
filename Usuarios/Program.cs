using System.Threading.Tasks;
using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using Usuarios;
using System.Text.Json;


public class Program
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string url = "https://jsonplaceholder.typicode.com/users";
        HttpResponseMessage response = await client.GetAsync(url);
        string ResposeBody = await response.Content.ReadAsStringAsync();
        List<Usuario> ListUsu = JsonSerializer.Deserialize<List<Usuario>>(ResposeBody)!;
        var PrimerosCinco = ListUsu.Take(5);
        foreach (var usuario in PrimerosCinco)
        {
            Console.WriteLine($"Nombre: {usuario.name} | Email: {usuario.email}| Adrees: {usuario.address}");
        }
    }
}