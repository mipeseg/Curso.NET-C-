/*
    Fuente: video108, video109, video110, video111, video112
    // TODO: Estamos al comienzo del video

    THREAD = HILO = FLUJO (PROGRAMACION MULTITAREA O CONCURRENTE)
    https://docs.microsoft.com/es-es/dotnet/api/system.threading.thread?view=net-6.0

        - aplicaciones monotarea (1 HILO)
            son aquellas donde el flujo de ejecucion del programa es secuencial, es decir,
            despues de una tarea se realiza otra. Son las que hemos visto hasta ahora.

        - aplicaciones multitarea ( MUCHOS HILOS)
            son aquellas donde hay N flujos de ejecucion en paralelo, es decir,
            se pueden ejecutar muchas tareas a la vez. Ej: Windows es multitarea

            Como funciona la multitarea? Una CPU monocore tiene que dividir su
            tiempo entre todos los hilos de forma secuencial. Lo hace tan rapido que parece 
            que lo haga en paralelo. En la CPU multicore si que se trabaja en paralelo realmente
        

                                         HILO PRINCIPAL (Main)
                Inicio Programa  ------------------------------------> Fin programa
                                              HILO
                                          ------------>   
                                   HILO            HILO        HILO
                                   ---->           ---->       ----> 
                                                   HILO
                                        ----------------------------->

            Es la CPU la que decide la prioridad que da a cada uno de los hilos. Por eso una misma
            app puede ejecutar en unas ocasiones unos hilos antes y en otras ocasiones despues. Ej:

                        EJECUCION 1                         EJECUCION 2

                    hilo2: que tal?                     Main Thread: Hola mundo
                    hilo3: Adios Mundo                  hilo2: que tal?
                    Main Thread: Hola mundo             hilo3: Adios Mundo
                    hilo3: Adios Mundo                  hilo3: Adios Mundo
                    Main Thread: Hola mundo             hilo2: que tal?
                    hilo2: que tal?                     Main Thread: Hola mundo
                    Main Thread: Hola mundo             hilo3: Adios Mundo
                    hilo2: que tal?                     hilo2: que tal?
                    hilo3: Adios Mundo                  Main Thread: Hola mundo
                    Main Thread: Hola mundo             Main Thread: Hola mundo
                    Main Thread: Hola mundo             Main Thread: Hola mundo

    SINCRONIZACION Y BLOQUEO DE THREADS

        - sincronizacion de Threads (es decidir el orden de ejecucion de los hilos) - Join()

            Por defecto la CPU, en funcion de su carga de trabajo, decide la prioridad que da a los hilos.
            Esto puede darnos igual o no, es decir, en ocasiones puede que necesitemos controlarlo nosotros.
            Ejemplo:

                        hilo2: que tal?
                        hilo2: que tal?
                        hilo2: que tal?
                        hilo3: Adios Mundo
                        hilo3: Adios Mundo
                        hilo3: Adios Mundo
                        Main Thread: Hola mundo
                        Main Thread: Hola mundo
                        Main Thread: Hola mundo
                        Main Thread: Hola mundo
                        Main Thread: Hola mundo

        - Bloqueo de Threads - lock(Object a){}

            Mientras que un Thread bloqueado este en ejecucion, no puede llegar otro a realizar su tarea. Ej:

            15 personas titulares (4 hilos) de una cuenta bancaria. No tendria sentido sincronizarlos, pero si 
            bloquearlos. Esto permite que un thread pueda controlar si hay saldo antes de sacar

    TAREAS COMPLETADAS (https://docs.microsoft.com/es-es/dotnet/api/system.threading.tasks.taskcompletionsource-1?view=net-6.0)    
                       using System.Threading.Tasks;

        Podemos detectar si un Thread se ha completado con la clase TaskCompletionSource<generico> y en funcion
        de ellos determinar que queremos que haga nuestro codigo

    THREADPOOL (https://docs.microsoft.com/es-es/dotnet/api/system.threading.threadpool?view=net-6.0) 

        Cuando tenemos pocas tareas, creamos un thread para cada una y a la marcha. Sin embargo cuando tenemos
        muchisimas tareas, no es operativo crear un thread por cada una. Un ThreadPool es un cjto reducido de
        threads que cuando terminen su tarea asignada se van a por otra (se reutilizan los threads)

                H1  H2  H3  H4                                  THREADPOOL
                T1  T2  T3  T4                                H1    H2    H3
                                                          T1 T2 T3 T4 T5 T6 T7 T8     

        Ventajas: Un ThreadPool usa menos recursos que un hilo por cada tarea
        Incovenientes: Un hilo por cada tarea es mas rapido que un threadPool
            

*/

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Video108
{
    class CuentaBancaria
    {
        public double Saldo { get; set; }
        private Object bloqueaEsteCodigo = new object(); 
       
        public void retirarEfectivo(double cant)
        {
            lock (bloqueaEsteCodigo)
            {
                if ((Saldo - cant) >= 0)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: Saldo: {Saldo}  Retirado: {cant} Saldo nuevo: {Saldo - cant}");
                    Saldo -= cant;
                }
                else 
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: Lo siento. El saldo es {Saldo}");
                }
            }

            //return Saldo;
        }

        public void vamosRetirarEfectivo()
        {
            Console.WriteLine($"Va a sacar dinero el {Thread.CurrentThread.Name}");   
            retirarEfectivo(500); // cada hilo retirara 500 euros
        }
    }

    public class Program
    {

        static Thread t, s;  // definimos dos objetos Thread o hilo

        static void MetodoSaludo()
        {
            Console.WriteLine($"{t.Name}: que tal?");
            //Thread.Sleep(1000);
            Console.WriteLine($"{t.Name}: que tal?");
            //Thread.Sleep(1000);
            Console.WriteLine($"{t.Name}: que tal?");
        }
        static void MetodoSaludo2()
        {
            Console.WriteLine($"{s.Name}: Adios Mundo");
            //Thread.Sleep(1000);
            Console.WriteLine($"{s.Name}: Adios Mundo");
            //Thread.Sleep(1000);
            Console.WriteLine($"{s.Name}: Adios Mundo");
        }

        static void ejecutarTarea(object o)
        {
            int numTarea = (int)o;
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ha comenzado la tarea {numTarea}");
            Thread.Sleep(500);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ha terminado la tarea {numTarea}");
        }

        static void Main(string[] args)  // Main Thread
        {
            // aplicacion monotarea. La hace tan rapida que parece que las 5 instrucciones
            // se han ejecutado a la vez. Pero en realidad ha sigo secuencialmente. La
            // secuencialidad se aprecia si pausamos el hilo de ejecucion entre instruccion
            // e instruccion 1 segundo

            /* La ejecucion secuencial tambien se aprecia si introducimos un punto de interrupcion
               e inciamos la ejecucion en modo depuracion (F5). El flujo de ejecucion se detiene en nuestro
               punto de interrupcion. Despues podremos ir ejecutando instruccion por instruccion con F11
               hasta llegar al final del programa. 
            
               NOTA: En Depurar/ventanas/subprocesos podemos ver los hilos de nuestra aplicacion. En este
               caso hay un subproceso con id=25535 y la flecha esta siempre sobre el.
            */

            Console.WriteLine("--EJECUCION DE THREADS ALEATORIAMENTE--");
            Console.WriteLine();

            t = new Thread(MetodoSaludo);  // acabamos de crear otro hilo llamado t que llama al MetodoSaludo2
            t.Name = "hilo2";  // nombre del hilo
            t.Start(); // iniciamos el hilo t

            s = new Thread(MetodoSaludo2);  // acabamos de crear otro hilo llamado s que llama al MetodoSaludo2
            s.Name = "hilo3";  // nombre del hilo
            s.Start(); // iniciamos el hilo s

            Console.WriteLine("Main Thread: Hola mundo");
            //Thread.Sleep(1000);
            Console.WriteLine("Main Thread: Hola mundo");
            //Thread.Sleep(1000);
            Console.WriteLine("Main Thread: Hola mundo");
            //Thread.Sleep(1000);
            Console.WriteLine("Main Thread: Hola mundo");
            //Thread.Sleep(1000);
            Console.WriteLine("Main Thread: Hola mundo");

            Console.WriteLine();
            Console.WriteLine("--EJECUCION DE THREADS SINCRONIZADOS--");
            Console.WriteLine();

            t = new Thread(MetodoSaludo);  // acabamos de crear otro hilo llamado t que llama al MetodoSaludo2
            t.Name = "hilo2";  // nombre del hilo
            t.Start(); // iniciamos el hilo t
            t.Join(); // sincronizar

            s = new Thread(MetodoSaludo2);  // acabamos de crear otro hilo llamado s que llama al MetodoSaludo2
            s.Name = "hilo3";  // nombre del hilo
            s.Start(); // iniciamos el hilo s
            s.Join(); // sincronizar

            Console.WriteLine("Main Thread: Hola mundo");
            //Thread.Sleep(1000);
            Console.WriteLine("Main Thread: Hola mundo");
            //Thread.Sleep(1000);
            Console.WriteLine("Main Thread: Hola mundo");
            //Thread.Sleep(1000);
            Console.WriteLine("Main Thread: Hola mundo");
            //Thread.Sleep(1000);
            Console.WriteLine("Main Thread: Hola mundo");

            Console.WriteLine();
            Console.WriteLine("--EJECUCION DE THREADS BLOQUEADOS--");
            Console.WriteLine();

            CuentaBancaria cuentaFamilia = new CuentaBancaria() { Saldo = 2000 };
            Thread[] hilosPersonas = new Thread[15];

            for(int i = 0; i<15; i++)
            {
                Thread k = new Thread(cuentaFamilia.vamosRetirarEfectivo);
                k.Name = "hilo" + i.ToString();
                hilosPersonas[i] = k;
            }

            for (int i = 0; i < 15; i++)
                hilosPersonas[i].Start();

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("-- ThHREADS COMPLETADOS --");
            Console.WriteLine();

            TaskCompletionSource<bool> tareaTerminada = new TaskCompletionSource<bool>();

            var hiloA = new Thread(() =>
            {
                for(int i = 0; i < 5; i++)
                {
                    Console.WriteLine("hilo A");
                    Thread.Sleep(500);
                }
                tareaTerminada.TrySetResult(true); // cuando el flujo llegue a esta instruccion se da por terminado hiloA
            });

            var hiloB = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("hilo B");
                    Thread.Sleep(500);
                }
                tareaTerminada.TrySetResult(true); // cuando el flujo llegue a esta instruccion se da por terminado hiloA
            });

            var hiloC = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("hilo C");
                    Thread.Sleep(500);
                }
            });

            /*hiloA.Start();
            var resultado = tareaTerminada.Task.Result;  // true si hiloA ha terminado
            hiloB.Start();
            hiloC.Start();*/

            hiloA.Start(); 
            hiloB.Start();
            var resultado = tareaTerminada.Task.Result;  // true si hiloA e hilo B ha terminado
            hiloC.Start();

            // THREADPOOL

            Console.WriteLine();
            Console.WriteLine("-- THREADPOOL --");
            Console.WriteLine();

            for (int i = 0; i < 100; i++)
            {
                /*Thread l = new Thread(ejectutarTarea);
                l.Start(); */
                ThreadPool.QueueUserWorkItem(ejecutarTarea, i);
            }

        }

       
    }
}


