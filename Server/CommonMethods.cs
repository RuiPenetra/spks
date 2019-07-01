using System;
using System.IO;

namespace SPKS___Server
{
    class CommonMethods
    {
        public static readonly string ProjectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        public static readonly string SolutionPath = Directory.GetParent(ProjectPath).FullName;

        public static string Sala(string sala)
        {
            return SolutionPath + "/Salas/" + sala + "_log.txt";
        }



        public void Teste_Encriptarcoisas() {
        }



    }
}
