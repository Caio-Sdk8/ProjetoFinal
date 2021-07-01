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

        
        public List<comentario> lista = new List<comentario>();

        public const string CAMINHO = "Database/comentarios.csv";

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