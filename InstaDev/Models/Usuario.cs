using System;
using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class Usuario : BaseInstaDev
    {
        public string IdUsuario;
        public string Nome { get; set; }
        public string Username { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string ImagemUsuario {get; set;}

        private const string CAMINHO = "Database/jogador.csv";
        private string preparar(Usuario u){
            return $"{u.IdUsuario};{u.Nome};{u.Username};{u.email};{u.senha};{ImagemUsuario}";
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

                user.IdUsuario = linha[0];
                user.Nome = linha[1];
                user.Username = linha[2];
                user.email = linha[2];
                user.senha = linha[3];
                user.ImagemUsuario = linha[4];
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
        public void deletar(string id)
        {
            List<string> linhas = lertodaslinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            reescreverCSV(CAMINHO, linhas);
        } 

        public void CriarId(Usuario u)
        {
            Random randonzin = new Random(3000);

            bool validando = false;

            do
            {
                u.IdUsuario = $"#BR{randonzin.Next()}";

                List<string> linhas = lertodaslinhasCSV(CAMINHO);
                string validar = linhas.Find(x => x.Split(";")[0] == u.IdUsuario);

                if (validar != null)
                {
                    u.IdUsuario = $"#BR{randonzin.Next()}";
                }else{
                    validando = false;
                }

            } while (validando);
        }
    }
}