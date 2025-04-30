using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPorTurnos
{
    internal class Jugador
    {
        public int vida;
        public int danio;

        public Jugador(int vida, int danio)
        {
            this.vida = vida;
            this.danio = danio;
        }

        public void recibirDanio(int danio)
        {
            vida -= danio;
            if (vida < 0)
                vida = 0;
        }

        public int causarDanio()
        {
            return danio;
        }
        //public int Vida() => vida;
        //public int Danio() => danio;

    }
}
