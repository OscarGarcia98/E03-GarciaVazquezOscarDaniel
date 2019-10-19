using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Tarea
    {

        public int Id { get; set; }     //El atributo Id se determina mediante un contandor a la hora de crear una tarea nueva
        public string Nombre { get; set; }      //
        public string Descripcion { get; set; }     //Estos atributos los ingresa el usuario
        public string Encargado { get; set; }  //
        public DateTime FechaInicio { get; set; }  //
        public string Estado { get; set; }          //El atributo Estado se determina por default como PENDIENTE hasta que se realice el cambio por el usuario 

        
       

    }
}
