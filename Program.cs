using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPorTurnos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool jugarDeNuevo = true;

            while (jugarDeNuevo)
            {
                Jugador jugador = crearJugador();
                List<Enemigo> enemigos = crearEnemigos();

                int turno = 1;
                Random random = new Random();

                while (true)
                {
                    Console.WriteLine($"Turno {turno}");
                    Console.WriteLine($"Tu vida: {jugador.vida}");

                    List<int> enemigosVivos = new List<int>();
                    for (int i = 0; i < enemigos.Count; i++)
                    {
                        if (enemigos[i].estaVivo())
                        {
                            enemigosVivos.Add(i);
                        }
                    }

                    if (enemigosVivos.Count == 0)
                    {
                        Console.WriteLine("¡Has vencido a todos los enemigos! ¡Victoria!");
                        break;
                    }

                    Console.WriteLine("Enemigos vivos:");
                    foreach (int ene in enemigosVivos)
                    {
                        Console.WriteLine($"{ene}. Enemigo {ene + 1} - Vida: {enemigos[ene].vida}");
                    }
                    int objetivo;
                    while (true)
                    {
                        Console.Write("¿A quién quieres atacar?: ");
                        if (int.TryParse(Console.ReadLine(), out objetivo) && enemigosVivos.Contains(objetivo))
                        {
                            enemigos[objetivo].recibirDanio(jugador.causarDanio());
                            Console.WriteLine($"Atacaste al Enemigo {objetivo + 1} causando {jugador.causarDanio()} de daño.");

                            if (!enemigos[objetivo].estaVivo())
                            {
                                Console.WriteLine($"¡Enemigo {objetivo + 1} derrotado!");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Número inválido (duh) . Intenta de nuevo :v.");
                        }
                    }
                    // Ataque enemigo
                    List<Enemigo> enemigosVivosList = enemigos.FindAll(e => e.estaVivo());
                    if (enemigosVivosList.Count > 0)
                    {
                        Enemigo atacante = enemigosVivosList[random.Next(enemigosVivosList.Count)];
                        int danioRecibido = atacante.causarDanio();
                        jugador.recibirDanio(danioRecibido);
                        Console.WriteLine($"Un enemigo te atacó causando {danioRecibido} de daño. Tu vida ahora es {jugador.vida}.");

                        if (jugador.vida <= 0)
                        {
                            Console.WriteLine("¡Has sido derrotado :( ! Fin del juego (eres muy malo :v).");
                            break;
                        }
                    }

                    turno++;
                }

                Console.WriteLine("¿Quieres intentarlo otra vez? (s/n): ");
                string respuesta = Console.ReadLine().ToLower();
                jugarDeNuevo = (respuesta == "s");
            }

            Console.WriteLine("Gracias por jugar. Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        static Jugador crearJugador()
        {
            int vida;
            int danio;

            while (true)
            {
                Console.WriteLine("Ponte la vida del quieras (1-100): ");
                if (int.TryParse(Console.ReadLine(), out vida) && vida > 0 && vida <= 100)
                {
                    break;
                }
                Console.WriteLine("Número equivocado. Debe estar entre 1 y 100.");
            }

            while (true)
            {
                Console.WriteLine("Introduce tu daño (1-100): ");
                if (int.TryParse(Console.ReadLine(), out danio) && danio > 0 && danio <= 100)
                {
                    break;
                }
                Console.WriteLine("Número equivocado. Debe estar entre 1 y 100.");
            }

            return new Jugador(vida, danio);
        }

        static List<Enemigo> crearEnemigos()
        {
            List<Enemigo> enemigos = new List<Enemigo>();
            int cantidad;

            while (true)
            {
                Console.WriteLine("¿Cuántos enemigos podrás vencer? ");
                if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0)
                {
                    break;
                }
                Console.WriteLine("Cantidad inválida. Intenta nuevamente.");
            }

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Enemigo {i + 1}:");

                int vida;
                while (true)
                {
                    Console.WriteLine("  Vida del enemigo (1-100): ");
                    if (int.TryParse(Console.ReadLine(), out vida) && vida > 0 && vida <= 100)
                    {
                        break;
                    }
                    Console.WriteLine("  Número equivocado. Debe estar entre 1 y 100.");
                }

                int daño;
                while (true)
                {
                    Console.WriteLine("  Daño del enemigo (1-100): ");
                    if (int.TryParse(Console.ReadLine(), out daño) && daño > 0 && daño <= 100)
                    {
                        break;
                    }
                    Console.WriteLine("  Número equivocado. Debe estar entre 1 y 100.");
                }

                enemigos.Add(new Enemigo(vida, daño));
            }

            return enemigos;
        }
     
    }
 
}

      


