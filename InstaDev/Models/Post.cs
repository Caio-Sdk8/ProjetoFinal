using System;
using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class Post : BaseInstadev
    {
        public string Local { get; set; }

        public string IdPost { get; set; }

        public Usuario UsuarioPost;

        public string Descrição { get; set; }

        public string ImagemPost { get; set; }

        private const string CAMINHO = "Database/postagem.csv";

        public Post()
        {
            criarpastaearquivo(CAMINHO);
        }

        private string Preparar(Post p)
        {
            return $"{p.IdPost};{p.Local};{p.UsuarioPost};{p.Descrição};{p.ImagemPost}";
        }

        public void Alterar(Post p)
        {
            List<string> linhas = lertodaslinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == p.IdPost.ToString());
            linhas.Add(Preparar(p));
            reescreverCSV(CAMINHO, linhas);
        }

        public void Criar(Post p)
        {
            string[] linha = { Preparar(p) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void CriarId(Post p)
        {
            Random randonzin = new Random(3000);

            bool validando = false;

            do
            {
                p.IdPost = $"#BR{randonzin.Next()}";

                List<string> linhas = lertodaslinhasCSV(CAMINHO);
                string validar = linhas.Find(x => x.Split(";")[0] == IdPost);

                if (validar != null)
                {
                    p.IdPost = $"#BR{randonzin.Next()}";
                }else{
                    validando = false;
                }

            } while (validando);
        }

        public void Deletar(string id)
        {
            List<string> linhas = lertodaslinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            reescreverCSV(CAMINHO, linhas);
        }

        public List<Post> LerTodas()
        {
            List<Post> LerEquipes = new List<Post>();

            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Post post = new Post();

                post.IdPost = linha[0];
                post.Local = linha[1];
                //post.UsuarioPost = linha[2];
                post.Descrição = linha[3];
                post.ImagemPost = linha[4];


                LerEquipes.Add(post);
            }
            return LerEquipes;
        }

    }
}