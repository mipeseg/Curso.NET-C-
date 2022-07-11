using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video063
{
    internal class Diccionario
    {
        public static void ejerciciosConDiccionarios()  // static hace que no sea necesario una instancia de Diccionario para llamar a este metodo
        {
            // creacion de un diccionario y adicion de objeto KeyValuePair<Tkey,TValue>

            Dictionary<string, string> miDicc = new Dictionary<string, string>();
            miDicc.Add("txt", "notepad.exe");
            miDicc.Add("bmp", "paint.exe");
            miDicc.Add("rtf", "wordpad.exe");

            Console.WriteLine("Los objetos del diccionario son: ");
            foreach (KeyValuePair<string, string> kvp in miDicc)
            {
                Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
            }

            // creacion de un diccionario y adicion de objeto KeyValuePair<Tkey,TValue>

            Dictionary<string, int> diccPersonas = new Dictionary<string, int>();
            diccPersonas.Add("Juan",25);    // 1. anadir con metodo Add
            diccPersonas.Add("Ana", 34);
            diccPersonas["Rosa"] = 9;       // 2. anadir por indexacion
            diccPersonas["Angel"] = 14;

            Console.WriteLine("El diccionario de personas es: ");  // mostramos el diccionario
            foreach (KeyValuePair<string, int> persona in diccPersonas)
            {
                Console.WriteLine($"Nombre = {persona.Key}, Edad = {persona.Value}");
            }

            // eliminacion de un objeto del diccionario

            Console.Write("Introduce el nombre de la persona a eliminar: ");
            string nombre = Console.ReadLine();
            if (diccPersonas.Remove(nombre))    // borramos un objeto del diccionario
            {
                Console.WriteLine($"{nombre} se ha eliminado del diccionario. Las personas del diccionario son: ");
                foreach (KeyValuePair<string, int> persona in diccPersonas)
                {
                    Console.WriteLine($"Nombre = {persona.Key}, Edad = {persona.Value}");
                }
            }
            else
                Console.WriteLine("La persona no existe");

            // Busqueda de una TKey y obtencion de su TValue

            Console.Write("Introduce el nombre de la persona: ");
            string nom = Console.ReadLine();
            int edad;
            if (diccPersonas.TryGetValue(nom, out edad))    // Obtiene el valor asociado a la clave especificada y lo almacena en edad
            {
                Console.WriteLine($"La edad de {nom} es {edad}");
            }
            else
                Console.WriteLine("La persona no existe");
        }
    }
}
