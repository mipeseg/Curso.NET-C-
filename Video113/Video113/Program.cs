/*

    Fuente: video113, video114, video115, video116, video117
    // TODOS: Estamos al comienzo del video

    TASK https://docs.microsoft.com/es-es/dotnet/api/system.threading.tasks.task?view=net-6.0

        Una Task es parecido a un ThreadPool. Se usan para optimizar los recursos ya que
        dependiendo de los nucleos de la CPU el sistema ira mas o menos sobrecargado.
        Los Task se usan en programacion asincrona

                                           TASK

                              HILO1  HILO2  HILO3  HILO4  HILO5

                                      TAREA  TAREA  TAREA

        Si ejecutamos solo la tarea t1 la salida es:

            La iteracion 0 corresponde al Thread 8
            La iteracion 1 corresponde al Thread 8
            La iteracion 2 corresponde al Thread 8
            ....
            La iteracion 18 corresponde al Thread 8
            La iteracion 19 corresponde al Thread 8
            
        Si ejecutamos t1 y t2 a la vez:

            La iteracion 0 corresponde al Thread 5
            La iteracion 0 corresponde al Thread 9
            La iteracion 1 corresponde al Thread 9
            La iteracion 1 corresponde al Thread 5
            La iteracion 2 corresponde al Thread 5
            La iteracion 2 corresponde al Thread 9
            ....
            La iteracion 17 corresponde al Thread 9
            La iteracion 17 corresponde al Thread 5
            La iteracion 18 corresponde al Thread 5
            La iteracion 18 corresponde al Thread 9
            La iteracion 19 corresponde al Thread 5
            La iteracion 19 corresponde al Thread 9

        Si ejecutamos t1, t2 y t3 a la vez:

            La iteracion 0 corresponde al Thread 8
            La iteracion 0 corresponde al Thread 10 desde el Main
            La iteracion 0 corresponde al Thread 5
            ...
            La iteracion 19 corresponde al Thread 8
            La iteracion 19 corresponde al Thread 10 desde el Main
            La iteracion 19 corresponde al Thread 5

    TASK CONSECUTIVAS O SECUENCIALES

        Por defecto cuando lanzamos varias Task se ejecutan en paralelo. Lo que queremos conseguir es que
        se ejecuten una detras de otra:

                        Task1  ----------------->  
                        Task2  ----------------->                Task1     Task2        Task3
                        Task3  ----------------->                --------->------------>----------->

        Vemos que en este caso solo hay un Thread 5. Primero realiza la t4 y despues EjecutarOtraTarea

        t4: La iteracion 0 corresponde al Thread 5 desde el Main
        t4: La iteracion 1 corresponde al Thread 5 desde el Main
        ...
        t4: La iteracion 18 corresponde al Thread 5 desde el Main
        t4: La iteracion 19 corresponde al Thread 5 desde el Main
        La iteracion 0 corresponde al Thread 5
        La iteracion 1 corresponde al Thread 5
        La iteracion 2 corresponde al Thread 5
        La iteracion 3 corresponde al Thread 5
        ......
        La iteracion 17 corresponde al Thread 5
        La iteracion 18 corresponde al Thread 5
        La iteracion 19 corresponde al Thread 5

    PRIORIDAD ENTRE TAREAS

        - WaitAll(t1, t2, ..., tN); -> espera a que terminen todas las tareas
        - WaitAny(t1, t2, ..., tN); -> espera a que termine algunas tarea
        - t1.Wait(); -> espera a que termine la tarea t1

        Cuando tenemos varias tareas y queremos dar preferencia a unas sobre otras usando los siguientes
        metodos de la clase Task:

        Ej) en el primer ejemplo no hay ninguna Task en ejecutarTodasTareas(). Por eso los metodos se ejecutan 
            en orden secuencial

                static void ejecutarTodasTareas()
                {
                    ejecutarTarea();ejecutarTarea2();ejecutarTarea3();
                }

                tarea1: La iteracion 0 corresponde al Thread 1
                ....
                tarea1: La iteracion 19 corresponde al Thread 1
                tarea2: La iteracion 0 corresponde al Thread 1
                .....
                tarea2: La iteracion 19 corresponde al Thread 1
                tarea3: La iteracion 0 corresponde al Thread 1
                .....
                tarea3: La iteracion 19 corresponde al Thread 1

        Ej)  Vamos a crear tres Task en el ejemplo anterior. Ahora sera la CPU la que organice automaticamente
             la prioridad entre ellas:

                static void ejecutarTodasTareas()
                {
                    Task.Run(() => { ejecutarTarea(); });
                    Task.Run(() => { ejecutarTarea2(); });
                    Task.Run(() => { ejecutarTarea3(); });
                }

                    tarea2: La iteracion 0 corresponde al Thread 8
                    tarea3: La iteracion 0 corresponde al Thread 11
                    ....
                    tarea1: La iteracion 0 corresponde al Thread 5
                    ...
                    tarea3: La iteracion 19 corresponde al Thread 11
                    tarea2: La iteracion 19 corresponde al Thread 8
                    ...
                    tarea1: La iteracion 19 corresponde al Thread 5

        Ej) Vamos a dar esta prioridad: tarea1 y tarea2 paralelas. La tarea3 empieza cuando terminen tarea1 y
            tarea2

                    static void ejecutarTodasTareas()
                    {
                        Task tarea1 = Task.Run(() => { ejecutarTarea(); });
                        Task tarea2 = Task.Run(() => { ejecutarTarea2(); });

                        Task.WaitAll(tarea1, tarea2);  // esperar a que acaben las dos

                        Task tarea3 = Task.Run(() => { ejecutarTarea3(); });
                    }

                    tarea2: La iteracion 0 corresponde al Thread 5
                    ...
                    tarea1: La iteracion 0 corresponde al Thread 8
                    ...
                    tarea2: La iteracion 19 corresponde al Thread 5
                    ...
                    tarea1: La iteracion 19 corresponde al Thread 8
                    tarea3: La iteracion 0 corresponde al Thread 8
                    ...
                    tarea3: La iteracion 19 corresponde al Thread 8
        
       Ej) Vamos a dar esta prioridad: tarea1 y tarea2 paralelas. La tarea3 empieza cuando termine tarea1 o
            tarea2

                    static void ejecutarTodasTareas()
                    {
                        Task tarea1 = Task.Run(() => { ejecutarTarea(); });
                        Task tarea2 = Task.Run(() => { ejecutarTarea2(); });

                        Task.WaitAny(tarea1, tarea2);  // esperar a que acabe cualquiera

                        Task tarea3 = Task.Run(() => { ejecutarTarea3(); });
                    }

                    tarea2: La iteracion 0 corresponde al Thread 5
                    ...
                    tarea1: La iteracion 0 corresponde al Thread 8
                    ...
                    tarea2: La iteracion 19 corresponde al Thread 5
                    tarea3: La iteracion 0 corresponde al Thread 5
                    ...
                    tarea3: La iteracion 19 corresponde al Thread 5
                    ...
                    tarea1: La iteracion 19 corresponde al Thread 8


        Ej) Vamos a dar esta prioridad: tarea1 debe terminar para que empiecen tarea2 y tarea3 paralelas

                    static void ejecutarTodasTareas()
                    {
                        Task tarea1 = Task.Run(() => { ejecutarTarea(); });
                        tarea1.Wait();  // esperar a que acabe la tarea1
                        Task tarea2 = Task.Run(() => { ejecutarTarea2(); });
                        Task tarea3 = Task.Run(() => { ejecutarTarea3(); });
                    }

                            tarea1: La iteracion 0 corresponde al Thread 8
                            ...
                            tarea1: La iteracion 19 corresponde al Thread 8
                            tarea2: La iteracion 0 corresponde al Thread 8
                            tarea3: La iteracion 0 corresponde al Thread 5
                            ...
                            tarea3: La iteracion 19 corresponde al Thread 5
                            tarea2: La iteracion 19 corresponde al Thread 8

        Ej) Vamos a dar esta prioridad secuencial: tarea1 debe terminar para que empiece tarea2.
                                                   tarea2 debe terminar para que empiece tarea3

                    static void ejecutarTodasTareas()
                    {
                        Task tarea1 = Task.Run(() => { ejecutarTarea(); });
                        tarea1.Wait();  // esperar a que acabe la tarea1
                        Task tarea2 = Task.Run(() => { ejecutarTarea2(); });
                        tarea2.Wait();  // esperar a que acabe la tarea2
                        Task tarea3 = Task.Run(() => { ejecutarTarea3(); });
                    }

                        tarea1: La iteracion 0 corresponde al Thread 5
                        ...
                        tarea1: La iteracion 19 corresponde al Thread 5
                        tarea2: La iteracion 0 corresponde al Thread 5
                        ...
                        tarea2: La iteracion 19 corresponde al Thread 5
                        tarea3: La iteracion 0 corresponde al Thread 5
                        ...
                        tarea3: La iteracion 19 corresponde al Thread 5

    LA CLASE Parallel (https://docs.microsoft.com/es-es/dotnet/api/system.threading.tasks.parallel?view=net-6.0)
                      espacio de nombres: System.Threading.Tasks
        
        En ejemplo anteriores hemos creado varias tareas que llamaban al mismo metodo de forma concurrente o paralela. Pero y
        si tenemos un numero considerable de tareas?. No seria eficiente. Aqui es donde entra Parallel
    
        Ej) Un hilo llamando a un metodo ejecutarTareaParalela()

                static void ejecutarTareaParalela(int dato)
                {
                    if((acumulador%2) == 0)
                    {
                        acumulador += dato; Thread.Sleep(100);
                    }
                    else
                    {
                        acumulador -= dato; Thread.Sleep(100);
                    }
                }

                for(int i = 0; i < 20 ; i++)
                {
                    ejecutarTareaParalela(i);
                    Console.WriteLine($"acumulador = {acumulador} | Tarea realizada por Thread " +
                                      $"{Thread.CurrentThread.ManagedThreadId}");
                }

                acumulador = 0 | Tarea realizada por Thread 1
                acumulador = 1 | Tarea realizada por Thread 1
                acumulador = -1 | Tarea realizada por Thread 1
                acumulador = -4 | Tarea realizada por Thread 1
                ...
                acumulador = 17 | Tarea realizada por Thread 1
                acumulador = -1 | Tarea realizada por Thread 1
                acumulador = -20 | Tarea realizada por Thread 1

         Ej) varios Threads llaman de forma paralela a ejecutarTareaParalela(). En lugar de crear
             varias Task como hemos hecho en ejercicios anteriores, usamos parallel

                   // static void ejecutarTareaParalelas()
                   // {
                   //     Task tarea1 = Task.Run(() => { ejecutarTarea(); });
                   //     Task tarea2 = Task.Run(() => { ejecutarTarea2(); });  
                   //     Task tarea3 = Task.Run(() => { ejecutarTarea3(); });
                   // }

                    static void ejecutarTareaParalela(int dato)
                    {
                        Console.WriteLine($"acumulador = {acumulador} | Tarea realizada por Thread " +
                                              $"{Thread.CurrentThread.ManagedThreadId}");

                        if ((acumulador%2) == 0)
                        {
                            acumulador += dato;
                            Thread.Sleep(100);
                        }
                        else
                        {
                            acumulador -= dato;
                            Thread.Sleep(100);
                        }
                    }

                    Parallel.For(0,20,ejecutarTareaParalela);

    CANCELAR TAREAS

        En ocasiones se esta ejecutando una tarea y hay que cancelarla. Como se hace? 
        Generando un token de cancelacion cuando halla que cancelarla. Trabajaremos con dos clases:

                Token de cancelacion ---> clase CancellationTokenSource (https://docs.microsoft.com/es-es/dotnet/api/system.threading.cancellationtokensource?view=net-6.0)
                                          Espacio de nombres: System.Threading
                                     |--> estructura CancellationToken (https://docs.microsoft.com/es-es/dotnet/api/system.threading.cancellationtoken?view=net-6.0)
                                          Espacio de nombres: System.Threading

        Ej) Partimos de esto:

                static void tareaN()
                {
                    for(int i = 0; i < 20; i++)
                    {
                        acumulador++;
                        Thread.Sleep(200);
                        Console.WriteLine($"acumulador = {acumulador} | Tarea realizada por Thread " +
                                          $"{Thread.CurrentThread.ManagedThreadId}");
                    }
                }

                Task tarea = Task.Run(() => tareaN());

                acumulador = 1 | Tarea realizada por Thread 5
                acumulador = 2 | Tarea realizada por Thread 5
                acumulador = 3 | Tarea realizada por Thread 5
                .....
                acumulador = 19 | Tarea realizada por Thread 5
                acumulador = 20 | Tarea realizada por Thread 5

        Ej) Cuando acumulador > 100 debe terminar la tarea

                static void tareaN(CancellationToken ct)
                {
                    for(int i = 0; i < 20; i++)
                    {
                        acumulador++;
                        Thread.Sleep(200);
                        Console.WriteLine($"acumulador = {acumulador} | Tarea realizada por Thread " +
                                          $"{Thread.CurrentThread.ManagedThreadId}");
                        if (ct.IsCancellationRequested)
                        {
                            // aqui va el codigo para revertir todo lo que ha hecho la tarea
                            acumulador = 0;  // volvemos al estado inicial del acumulador

                            // termina el metodo tareaN
                            return; 
                        }       
                    }
                }

                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken cancelToken = tokenSource.Token; // este es el cancellation token

                Task tarea = Task.Run(() => tareaN(cancelToken));  // esta tarea incrementa acumulador en 1
                for (int i = 0; i < 20; i++) // desde el MainThread se incrementa acumulador en 30
                {
                    acumulador += 30;
                    Thread.Sleep(200);
                    if(acumulador>100)
                    {
                        tokenSource.Cancel();  // cancela la tarea N cuando acumulador > 100
                        break; // rompe el bucle for y termina el mainThread
                    }
                   
                }

                acumulador = 31 | Tarea realizada por Thread 5
                acumulador = 92 | Tarea realizada por Thread 5
                acumulador = 123 | Tarea realizada por Thread 5
                acumulador = 124 | Tarea realizada por Thread 5

*/

using System;

namespace Video113
{
   
    public class Program
    {
        private static int acumulador = 0;

        static void ejecutarTarea()
        {
            for(int i = 0; i < 20; i++)
            {
                int miThread = Thread.CurrentThread.ManagedThreadId;  // creamos un Thread y obtenemos su Id
                Thread.Sleep(500);
                Console.WriteLine($"tarea1: La iteracion {i} corresponde al Thread {miThread}");   
            }
        }

        static void ejecutarTarea2()
        {
            for (int i = 0; i < 20; i++)
            {
                int miThread = Thread.CurrentThread.ManagedThreadId;  // creamos un Thread y obtenemos su Id
                Thread.Sleep(200);
                Console.WriteLine($"tarea2: La iteracion {i} corresponde al Thread {miThread}");
            }
        }

        static void ejecutarTarea3()
        {
            for (int i = 0; i < 20; i++)
            {
                int miThread = Thread.CurrentThread.ManagedThreadId;  // creamos un Thread y obtenemos su Id
                Thread.Sleep(200);
                Console.WriteLine($"tarea3: La iteracion {i} corresponde al Thread {miThread}");
            }
        }

        static void ejecutarOtraTarea(Task o)
        {
            for (int i = 0; i < 20; i++)
            {
                int miThread = Thread.CurrentThread.ManagedThreadId;  // creamos un Thread y obtenemos su Id
                Thread.Sleep(500);
                Console.WriteLine($"tarea otra: La iteracion {i} corresponde al Thread {miThread}");
            }
        }

        static void ejecutarTodasTareas()
        {
            Task tarea1 = Task.Run(() => { ejecutarTarea(); });
            tarea1.Wait();  // esperar a que acabe la tarea1
            Task tarea2 = Task.Run(() => { ejecutarTarea2(); });
            tarea2.Wait();  // esperar a que acabe la tarea2
            Task tarea3 = Task.Run(() => { ejecutarTarea3(); });
        }

        static void ejecutarTareaParalela(int dato)
        {
            Console.WriteLine($"acumulador = {acumulador} | Tarea realizada por Thread " +
                                  $"{Thread.CurrentThread.ManagedThreadId}");
            if ((acumulador%2) == 0)
            {
                acumulador += dato;
                Thread.Sleep(100);
            }
            else
            {
                acumulador -= dato;
                Thread.Sleep(100);
            }
        }

        static void tareaN(CancellationToken ct)
        {
            for(int i = 0; i < 20; i++)
            {
                acumulador++;
                Thread.Sleep(200);
                Console.WriteLine($"acumulador = {acumulador} | Tarea realizada por Thread " +
                                  $"{Thread.CurrentThread.ManagedThreadId}");
                if (ct.IsCancellationRequested)
                {
                    // aqui va el codigo para revertir todo lo que ha hecho la tarea
                    acumulador = 0;  // volvemos al estado inicial del acumulador

                    // termina el metodo tareaN
                    return; 
                }       
            }
        }

        static void Main(string[] args)
        {

            // PRIMERA TAREA

            Task t1 = new Task(ejecutarTarea);
            //t1.Start();

            // SEGUNDA TAREA

            Task t2 = new Task(ejecutarTarea);
            //t2.Start();

            // TERCERA TAREA

            Task t3 = new Task(() => 
            {
                for(int i=0; i<20; i++)
                {
                    int miThread = Thread.CurrentThread.ManagedThreadId;  // creamos un Thread y obtenemos su Id
                    Thread.Sleep(200);
                    Console.WriteLine($"La iteracion {i} corresponde al Thread {miThread} desde el Main");
                }
            });
            //t3.Start();

            // TAREAS SECUENCIALES

            Task t4 = new Task(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    int miThread = Thread.CurrentThread.ManagedThreadId;  // creamos un Thread y obtenemos su Id
                    Thread.Sleep(200);
                    Console.WriteLine($"t4: La iteracion {i} corresponde al Thread {miThread} desde el Main");
                }
            });
            //t4.ContinueWith(ejecutarOtraTarea);  // cuando termine t4 se llama a ejecutarOtraTarea
            //t4.Start();

            // PRIORIDAD DE TAREAS


            //ejecutarTodasTareas();


            // CLASE PARALLEL

            /*
            for(int i = 0; i < 20 ; i++)
            {
                ejecutarTareaParalela(i);
                Console.WriteLine($"acumulador = {acumulador} | Tarea realizada por Thread " +
                                  $"{Thread.CurrentThread.ManagedThreadId}");
            }*/

            // Parallel.For(0, 20, ejecutarTareaParalela);  // primera forma

            /*
            Parallel.For(0, 20, dato => {   // segunda forma

                Console.WriteLine($"acumulador = {acumulador} | Tarea realizada por Thread " +
                                  $"{Thread.CurrentThread.ManagedThreadId}");
                if ((acumulador % 2) == 0)
                {
                    acumulador += dato;
                    Thread.Sleep(100);
                }
                else
                {
                    acumulador -= dato;
                    Thread.Sleep(100);
                }

            });  */

            // CANCELAR TAREA

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = tokenSource.Token; // este es el cancellation token

            Task tarea = Task.Run(() => tareaN(cancelToken));  // esta tarea incrementa acumulador en 1
            for (int i = 0; i < 20; i++) // desde el MainThread se incrementa acumulador en 30
            {
                acumulador += 30;
                Thread.Sleep(200);
                if(acumulador>100)
                {
                    tokenSource.Cancel();  // cancela la tarea N cuando acumulador > 100
                    break; // rompe el bucle for y termina el mainThread
                }
                   
            }

            Thread.Sleep(1000);
            Console.WriteLine($"El valor de acumulador vuelve a ser el inicial = {acumulador}");



            Console.ReadLine();

        }
    }
}