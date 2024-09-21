using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GerenciadorContatosApp
{
    public class GerenciadorDeContatos
    {
        private List<Contato> contatos = new List<Contato>();
        private string caminhoArquivo = "contatos.txt";

        public GerenciadorDeContatos()
        {
            CarregarContatosDoArquivo();
        }

        public void AdicionarContato(Contato contato)
        {
            if (ValidarContato(contato))
            {
                contatos.Add(contato);
                SalvarContatosNoArquivo();
                Console.WriteLine("Contato adicionado com sucesso!");
            }
        }

        public void ListarContatos()
        {
            if (contatos.Count == 0)
            {
                Console.WriteLine("Nenhum contato encontrado.");
            }
            else
            {
                foreach (var contato in contatos)
                {
                    Console.WriteLine(contato.ToString());
                }
            }
        }

        public void RemoverContato(string nome)
        {
            Contato contatoRemover = contatos.Find(c => c.Nome == nome);
            if (contatoRemover != null)
            {
                contatos.Remove(contatoRemover);
                SalvarContatosNoArquivo();
                Console.WriteLine("Contato removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        public void BuscarContato(string nome)
        {
            var contatosEncontrados = contatos.Where(c => c.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
            if (contatosEncontrados.Count == 0)
            {
                Console.WriteLine("Nenhum contato encontrado com esse nome.");
            }
            else
            {
                foreach (var contato in contatosEncontrados)
                {
                    Console.WriteLine(contato.ToString());
                }
            }
        }

        private bool ValidarContato(Contato contato)
        {
            if (string.IsNullOrWhiteSpace(contato.Nome))
            {
                Console.WriteLine("Nome não pode ser vazio.");
                return false;
            }

            if (!contato.Email.Contains("@"))
            {
                Console.WriteLine("Email inválido.");
                return false;
            }

            if (!long.TryParse(contato.Telefone, out _))
            {
                Console.WriteLine("Telefone deve conter apenas números.");
                return false;
            }

            return true;
        }

        private void CarregarContatosDoArquivo()
        {
            if (File.Exists(caminhoArquivo))
            {
                var linhas = File.ReadAllLines(caminhoArquivo);
                foreach (var linha in linhas)
                {
                    var contato = Contato.FromCSV(linha);
                    contatos.Add(contato);
                }
            }
        }

        private void SalvarContatosNoArquivo()
        {
            var linhas = contatos.Select(c => c.ToCSV()).ToArray();
            File.WriteAllLines(caminhoArquivo, linhas);
        }
    }
}
