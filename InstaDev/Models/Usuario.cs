using System;
using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class Usuario : BaseInstadev
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string email { get; set; }
        private string senha { get; set; }
        private const string CAMINHO = "Database/jogador.csv";
        private string preparar(Usuario u){
            return $"{u.IdUsuario};{u.Nome};{u.email};{u.senha}";
        }
        public Usuario(){
            criarpastaearquivo(CAMINHO);
        }

        public void criar(Usuario u)
        {
            string[] linhas = {preparar(u)};
            File.AppendAllLines(CAMINHO, linhas);
        }
        public List<Usuario> lertodos()
        {
            List<Usuario> users = new List<Usuario>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Usuario user = new Usuario();

                user.IdUsuario = Int32.Parse(linha[0]);
                user.Nome = linha[1];
                user.email = linha[2];
                user.senha = linha[3];
                users.Add(user);
            }
            return users;
        }

         public void alterar(Usuario u)
        {
            List<string> linhas = lertodaslinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == u.IdUsuario.ToString());
            linhas.Add(preparar(u));
            reescreverCSV(CAMINHO, linhas);
        }
        public void deletar(int id)
        {
            List<string> linhas = lertodaslinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            reescreverCSV(CAMINHO, linhas);
        } 
    }
}