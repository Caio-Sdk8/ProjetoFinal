using System;
using System.Collections.Generic;

namespace InstaDev.Models
{
    public class comentario
    {
        public string comment;

        public Usuario usuario;

        
        public List<comentario> lista = new List<comentario>();

        public const string PATH = "Database/comentarios.csv";
        public void cadastrar(){

        }

        public void excluir() {

        }

        public void like(){

        }
    }
}