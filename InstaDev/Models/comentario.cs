using System;
using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class comentario : BaseInstadev
    {
        public string comment;

        public Usuario usuario;

        public int like;

        public string IdPost { get; set; }


        
        public List<comentario> lista = new List<comentario>();

        public const string CAMINHO = "Database/comentarios.csv";


        public void CriarId(comentario c)
        {
            Random randonzin = new Random(3000);

            bool validando = false;

            do
            {
                c.IdPost = $"#BR{randonzin.Next()}";

                List<string> linhas = lertodaslinhasCSV(CAMINHO);
                string validar = linhas.Find(x => x.Split(";")[0] == IdPost);

                if (validar != null)
                {
                    c.IdPost = $"#BR{randonzin.Next()}";
                }else{
                    validando = false;
                }

            } while (validando);
        }


        public comentario(){
            criarpastaearquivo(CAMINHO);
        }

        private string Preparar(comentario c){
            return $"{c.usuario};{c.comment}";
        }
        public void cadastrar(comentario c){
            //salvar o que foi escrito
            string[] armazenar = {Preparar(c)}; 
            File.AppendAllLines(CAMINHO, armazenar);
        }

        public void excluir(comentario c) {
            //excluir o comentario
        }

        public void darlike(comentario c){
            //dar like no comentario
            c.like = c.like + 1;
        }

        public void alterar(comentario c) {
            //editar o comentario
        }
    }
}