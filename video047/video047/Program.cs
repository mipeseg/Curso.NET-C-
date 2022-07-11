/*
    Fuente: video47
    // TODO: Estamos empezando el video
    
    EJERCICIO DE REPASO

    a) Crear 3 clases: Avion, Vehiculo y Coche
    b) Crear una jerarquia de clases o herencia
    c) Metodos comunes a las 3 clases: arrancarMotor y pararMotor
    d) Metodo virtual: Conducir

        un Avion ES SIEMPRE UN Vehiculo ?   SI
        un Avion ES SIEMPRE UN Coche ?      NO
        un Vehiculo ES SIEMPRE UN Avion ?   NO
        un Vehiculo ES SIEMPRE UN Coche ?   NO
        un Coche ES SIEMPRE UN Avion ?      NO
        un Coche ES SIEMPRE UN Vehiculo ?   SI

        La jeraquia deberia ser:
                    Vehiculo
                        Avion   Coche

 */


using System;

namespace video047 
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehiculo[] vehics = new Vehiculo[3];

            vehics[0] = new Coche("2345JLT");
            vehics[1] = new Avion("2345AKL");
            vehics[2] = new Coche("6766TTP");

            foreach (Vehiculo v in vehics) 
            {
                Console.WriteLine($"Info del vehiculo: {v.getInfo()}");
            }

            vehics[0].arrancarMotor("rrrrr");
            vehics[0].conducir();
            vehics[0].pararMotor("brum brum");

            vehics[1].arrancarMotor("gggggg");
            vehics[1].conducir();
            vehics[1].pararMotor("tumtumtum");

            vehics[2].arrancarMotor("ttttt");
            vehics[2].conducir();
            vehics[2].pararMotor("niuniuniu");

            Coche miCoche = new Coche("1234TTT");
            Console.WriteLine($"Info del vehiculo: {miCoche.getInfo()}");
            miCoche.arrancarMotor("rrrrr");
            miCoche.acelerar();
            miCoche.conducir();
            miCoche.frenar();
            miCoche.pararMotor("brum brum");

            Avion miAvion = new Avion("6767BCD");
            Console.WriteLine($"Info del vehiculo: {miAvion.getInfo()}");
            miAvion.arrancarMotor("rrrrr");
            miAvion.despegar();
            miAvion.conducir();
            miAvion.aterrizar();
            miAvion.pararMotor("brum brum");

            Console.WriteLine();

            // Ejemplo de poliformismo (cambio de forma en tiempo de ejecucion)

            Vehiculo miVehiculo = miCoche;  // Se puede hacer gracias al principio ES-UN
            miVehiculo.conducir(); // polimorfismo. miVehiculo se comporta como un Coche
            miVehiculo = miAvion;
            miVehiculo.conducir(); // polimorfismo. miVehiculo se comporta como un Avion
        }
    }
}

