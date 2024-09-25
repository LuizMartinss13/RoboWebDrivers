using System;
using System.Collections.Generic;
using System.Linq;

namespace Servidores
{
    public class ServersLinks
    {
        public static List<String> LinksServidores()
        {

            //criando a lista string dos servidores
            List<String> Links = new List<String>();

            Console.Write("\nDigite os links/servidores e separe por virgulas\n");
            string[] listaServidores = Console.ReadLine().Split(new char[] { ',' });

            foreach (string servidor in listaServidores)
            {
                Links.Add(servidor.Trim());
            }

            Console.WriteLine(Links);
            return Links;
        }
    }
    
}
