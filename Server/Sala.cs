using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPKS___Server

{
    public class Sala
    {
        //propriedades
        public string nome;
        public int numeroClientes;
        public int QuantosJogaram = 0;
        public int msg = 0;
        public int PontosJogador1 = 0;
        public int PontosJogador2 = 0;
        public string PosAtac;
        public string PosDefensor;
        public string Atac;
        public string Defensor;
        public string nickname1;
        public string nickname2;
        public int chat_alterado; // 2 -> atualizar em 2 pessoas, 1-> uma pessoa, 0-> nao atualizar chat


        //construtor
        public Sala(string Nome)
        {

            this.nome = Nome;
            this.numeroClientes = 1; // por defeito ja coloca um ao criar
            this.chat_alterado = 1; // para atualizar o chat da primeira vez

        }

        //metodo para adicionar um cliente
        public void adicionarCliente()
        {

            this.numeroClientes++;

        }
        public void adicionarPontos(string nickname)
        {
            if (nickname == nickname1)
            {
                PontosJogador1++;
            }
            else
            {
                PontosJogador2++;
            }
        }

        public void trocarFuncoes()
        {
            string novaAtac = Defensor;
            Defensor = Atac;
            Atac = novaAtac;
        }

    }
}
