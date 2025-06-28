using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Collections.Generic;
using Tareas;
using System.Text.Json;

public class Program
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string url = "https://jsonplaceholder.typicode.com/todos/";
        HttpResponseMessage response = await client.GetAsync(url);
        string ResposeBody = await response.Content.ReadAsStringAsync();
        List<Tarea> listTarea = JsonSerializer.Deserialize<List<Tarea>>(ResposeBody)!;
        List<Tarea> TareasC = new List<Tarea>();
        foreach (var Tarea in listTarea)
        {
            Console.WriteLine($"Título: {Tarea.title} | Completada: {Tarea.completed}");
            if (Tarea.completed)
            {
                TareasC.Add(Tarea);
            }
        }
        string JsonCompletas = JsonSerializer.Serialize(TareasC,new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("completadas.json", JsonCompletas);
    }
}