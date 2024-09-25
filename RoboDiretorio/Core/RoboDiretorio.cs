using System;
using System.IO;
using System.Runtime.InteropServices;
using RoboDiretorio.Servidor;

namespace RoboDiretorio
{
    public class RoboDiretorio
    {
        string origemDriver = string.Empty;
        string nomeDriver = string.Empty;
        string versao = string.Empty;
        string versaoCompleta = string.Empty;
        public RoboDiretorio()
        {
            ReceberDadosDriver();
            var uLinks = ServerLinks.LinksServidores();
            foreach(var lLinks in uLinks)
            {
                string destinoVersao = $@"{lLinks}\{versao}";
                string destinoVersaoTxt = $@"{destinoVersao}\{versaoCompleta}.txt";
                string destinoComVersaoDriver = $@"{lLinks}\{versao}\{nomeDriver}";
                string nomeDriverTxt = nomeDriver.Replace(".exe", "");

                try
                {
                    if (Directory.Exists(destinoVersao) == true)
                    {
                        if (File.Exists(destinoComVersaoDriver) == true)
                        {
                            File.Copy(origemDriver, destinoComVersaoDriver, true);                          
                            criartxt(destinoVersaoTxt, $"{nomeDriverTxt} {versaoCompleta}");
                        }
                        else
                        {
                            File.Copy(origemDriver, destinoComVersaoDriver);
                            criartxt(destinoVersaoTxt, $"{nomeDriverTxt} {versaoCompleta}");
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(destinoVersao);
                        File.Copy(origemDriver, destinoComVersaoDriver);
                        criartxt(destinoVersaoTxt, $"{nomeDriverTxt} {versaoCompleta}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao tentar extrair as versoes disponiveis (ChromeDrivers). Detalhe: " + ex.Message.ToString());
                }
            }
        }
        public void criartxt(string pathArquivo, string conteúdoArquivo)
        {
            File.WriteAllText(pathArquivo, conteúdoArquivo);
        }
        public void ReceberDadosDriver()
        {
            //Armazenar nome driver
            Console.Write("digite o nome do driver assim como está na sua máquina. ex: chromeDriver\n");
            nomeDriver = Console.ReadLine() + ".exe";

            //Armazenar caminho origem
            Console.Write("\nDigite o caminho de origem do driver\n");
            origemDriver = Console.ReadLine() + "\\" + nomeDriver;

            //Aramazena a versão do driver
            Console.Write("\ndigite a versão completa do driver ex:128.12.34.545\n");
            versaoCompleta = Console.ReadLine();
            string[] listaVersaoAtual = versaoCompleta.Split(new char[] { '.' });
            versao = listaVersaoAtual[0];
        }

    }
}