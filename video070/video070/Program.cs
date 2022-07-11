/*
    Fuente: video70, video71
    // TODO: estamos al principio del video

    EXPRESIONES REGULARES  https://docs.microsoft.com/es-es/dotnet/standard/base-types/regular-expression-language-quick-reference

        Una expresion regular es una cadena de caracteres que funciona como un patron de busqueda.
        Se utilizan para buscar otras cadenas de caracteres que cumplan el patron. 
        Los usos mas comunes de la expresiones regulares son: 

            - validacion de datos en formularios (ej: comprobar q el mail introducido es vaida)
            - hacer busquedas en ficheros externos
            - hacer busquedas en BBDD
            - comprobacion de errores en los datos de entrada del usuario
            - ...

        Para trabajar con expresiones regulares deberemos utilizar tb:
    
            - Clases (https://docs.microsoft.com/es-es/dotnet/api/system.text.regularexpressions.regex?view=net-6.0)
                Regex, Match, MatchCollection, GroupCollection
            - Metodos
                Matches
            - Propiedades
                Groups

    CONSTRUCCION DE EXPRESIONES REGULARES

       Documentacion oficial ->  https://docs.microsoft.com/es-es/dotnet/standard/base-types/regular-expression-language-quick-reference
       Construcor online de ER -> https://regex-generator.olafneumann.org/

           MANEJO DE CARACTERES              ER              CADENA            COINCIDENCIAS
            [grupo_caracteres]              [ae]	         "gray"                "a" 
                                                             "lAne"                "A","e"
            [^grupo_caracteres]             [^aei]           "reign"	           "r", "g", "n"
            [inicio - fin]                  [A-Z]            "AB123"               "A", "B"
                   .                         a.e             "nave"                "ave"
                                                             "water"               "ate"
            \p{Nombre}                      \p{Lu}           "City Lights"         "C", "L"
                                            \p{IsCyrillic}   "ДЖem"                "Д", "Ж" 
            \d                              \d               "4 = IV"              "4"
            \D                              \D               "4 = IV"              " ", "=", " ", "I", "V"
            \w (alfanumerico)               \w               "ID A1.3"             "I", "D", "A", "1", "3"
            \W (no alfanumerico)            \W               "ID A1.3"             " ", "."
            \s (spacebar)                   \w\s             "ID A1.3"             "D "
            \S (no spacebar)                \s\S             "int __ctr"           " _" 


           DELIMITADORES                     ER              CADENA                    COINCIDENCIAS
           ^ (principio cadena)            ^\d{3}           "901-333-"                 "901"
           $ (final cadena)                -\d{3}$          "-901-333"                 "-333"                                                 
           \A (principio cadena)           \A\d{3}          "901-333-"                 "901"
           \Z (final cadena)               -\d{3}\Z         "-901-333"                 "-333"
           \z (final cadena)               -\d{3}\z         "-901-333"                 "-333"
           \G (coincidencia anterior)      \G\(\d\)         "(1)(3)(5)[7](9)"          "(1)", "(3)", "(5)"
           \b                              \b\w+\s\w+\b     "them theme them them"     "them theme", "them them"
           \B                              \Bend\w*\b       "end sends endure lender"  "ends", "ender"

           AGRUPAMIENTOS                     ER              CADENA                    COINCIDENCIAS
           (Subexpresión)                    (\w)\1          "deep"                    "ee"
           ...

           CUANTIFICADORES                   ER              CADENA                        COINCIDENCIAS
           * (elemento anterior 0 o mas)     a.*c            "abcbc"                         "abcbc"
           + (elemento anterior 1 o mas)     be+             "been"                          "bee"
                                                             "bent beeem b"                  "be", "beee"
           ? (elemento anterior 0 o 1)       rai?            "rainrata"                      "rai", "ra"
           {N} (repite anterior n veces}     ,\d{3}          "1,043.6"                       ",043"
                                                             "9,876,543,210"                 ",876", ",543", ",210"
           {N,} (repite anterior >=n veces}  \d{2,}          "166 29 1930 1 123456"          "166", "29", "1930", "123456"
           {N,M} (repite anterior >=n y <m}  \d{3,5}         "193024 5 85-899.a1111 123456"  "19302", "899", "1111", "12345"

    USO DE BUSQUEDA RAPIDA (CTRL=F) 

        La ventana de busqueda rapida de Visual Studio puede trabajar con ER. Para ello la abrimos
        con CTRL+F y si pulsamos ALT+E activamos el uso de ER. Asi podremos escribir ER y
        se nos marcaran los caracteres encontrados en nuestro codigo que cumplan el patron

        Ej) \d -> esta ER acepta cadenas que tengan al menos 1 digito   
                  "Ana Maria" no cumple el patron. "6023" y "el perro 1" lo cumplen
        Ej)  \d{3} -> esta ER acepta toda cadena que tenga al menos un grupo de 3 digitos seguidos
             "15" no cumple la ER. "3456" cumple la ER. "456 y ""123-4-23" cumplen la ER

        OJO: Ninguna ER es infalible. Tiene un % de aciertos pero tb pueden fallar.
    
*/

// espacios de nombre nativos a utilizar 

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace video070
{
    class Program
    {
        static void Main(string[] args)
        {
            // Buscamos si hay una J en una cadena

            string cadena = "Mi abcbc nombre es Juan Jose y mis tlfos son (+34)963-603-218 (+44)123-456-789 y mi C.P 46015. Mi web es http://www.yo.es y mi mail yo@hotmail.com";
            //string patron = @"[J]";   // busca grupos de caracteres [] que tenga una J  NOTA: @ evita errores cuando en la ER pongamos \
            //string patron = @"(Juan)";   // busca grupos de caracteres [] que tenga una J  NOTA: @ evita errores cuando en la ER pongamos \
            //string patron = @"\d";    // busca digitos  NOTA: @ evita errores cuando en la ER pongamos \
            //string patron = @"\d{3}";   // busca grupos de, al menos, 3 digitos  NOTA: @ evita errores cuando en la ER pongamos \
            //string patron = @"\(\+34\)\d{3}-\d{3}-\d{3}";   // busca un numero de telefono con ese patron  NOTA: @ evita errores cuando en la ER pongamos \
            //string patron = @"\+34";    // prefijos de Espana
            //string patron = @"\+34|\+44";    // prefijos de Espana o Reino Unido
            //string patron = @"http(s)?://(www.)?yo.es";    // ? indica que (s) o (www.) pueden estar una o ninguna vez
            string patron = @"[\w-]+@([\w-]+\.)+[\w-]+"; // valida mail
            


            Regex re1 = new Regex(patron); // Creamos un objeto Regex que contiene el patron o expresion regular
            MatchCollection mc1 = re1.Matches(cadena);   // buscamos coincidencias en cadena usando el patron y las vamos almacenando en la coleccion de coincidencias mc1

            if (mc1.Count > 0)
            {
                Console.Write($"Se ha encontrado {mc1.Count} coincidencias: ");
                foreach (Match coincidencia in mc1)
                {
                    Console.Write($"{coincidencia}, ");   
                }
            }
            else Console.WriteLine("No se ha encontrado coincidencias");

            Console.WriteLine();

            // validacion de email usando la clase MailAddress
            
            try
            {
                MailAddress miMail = new MailAddress("mipeseg@gmail.com", "Miguel Perez");
                Console.WriteLine("El mail es correcto");
                Console.WriteLine($"mail: {miMail.Address}");
                Console.WriteLine($"nombre: {miMail.DisplayName}");
                Console.WriteLine("El mail es correcto");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
