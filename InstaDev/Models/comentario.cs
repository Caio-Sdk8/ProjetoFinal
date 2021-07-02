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

        public string IdComentario { get; set; }


        
        public List<comentario> lista = new List<comentario>();

        public const string CAMINHO = "Database/comentarios.csv";


        public void CriarId(comentario c)
        {
            Random randonzin = new Random(3000);

            bool validando = false;

            do
            {
                c.IdComentario = $"#BR{randonzin.Next()}";

                List<string> linhas = lertodaslinhasCSV(CAMINHO);
                string validar = linhas.Find(x => x.Split(";")[0] == IdComentario);

                if (validar != null)
                {
                    c.IdComentario = $"#BR{randonzin.Next()}";
                }else{
                    validando = false;
                }

            } while (validando);
        }


        public comentario(){
            criarpastaearquivo(CAMINHO);
        }

        private string Preparar(comentario c){
            return $"{c.IdComentario};{c.usuario};{c.comment}";
        }
        public void cadastrar(comentario c){
            //salvar o que foi escrito
            string[] armazenar = {Preparar(c)}; 
            File.AppendAllLines(CAMINHO, armazenar);
        }

        public void listas() {

            string[] armazenamento = File.ReadAllLines(CAMINHO);

            foreach (var item in armazenamento)
            {
                comentario b = new comentario();
                //b = objeto para a lista
                b.IdComentario = armazenamento[0];
                b.usuario.nome = armazenamento[1];
                b.comment = armazenamento[2];

                lista.Add(b);
            }
        }

        public void Deletar(string id)
        {
            //excluir comentario
            List<string> linhas = lertodaslinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == IdComentario.ToString());
            reescreverCSV(CAMINHO, linhas);
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