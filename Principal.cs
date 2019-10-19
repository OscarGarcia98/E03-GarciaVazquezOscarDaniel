using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Principal
    {
        RepoTarea repo = new RepoTarea();       //Se instancia un objeto de la clase RepoTarea que es de donde vienen todos los métodos con los que interactua el menú
        public Principal()          //El constructor de la clase principal ejecuta el menu principal y un saludo que se muestra la primera vez que aparece el menu
        {
            
            Saludo();
            MenuPrincipal();
        }

        private void MenuPrincipal()            //Método principal que contiene todas las opciones con las que el usuario puede interactuar mediante la consola 
        {
            
            Console.WriteLine("Menú Principal\nElija una opción\n" +
                "1.-Crear Tarea\n" +
                "2.-Lista de Tareas\n" +
                "3.-Tareas por Estado\n" +
                "4.-Cambiar Estado de tarea.");
            switch (Console.ReadLine())     //Según sea la respuesta del usuario se ejecutará un case con su respectico método
            {
                case "1":
                    Console.WriteLine("Crear una nueva tarea\n");       
                    repo.CrearTarea();      //Método que crea una nueva tarea con los datos que el usuario ingrese
                    
                    break;
                case "2":
                    Console.WriteLine("Lista de todas las tareas creadas\n");     //En el case 2 utilice los dos metodos Lista de tareas y el de mostrar tareas...
                    repo.ListaTareas();                                         //...Utilizando la lista de todas las tareas registradas como un menú donde el usuario... 
                    break;                                                      //...Puede elegir el ID de la tarea deseada para ver los detalles 
                case "3":
                    Console.WriteLine("Tareas en orden de ESTADO\n");  //Muestra todas las tareas creadas y las muestra divididas según sea su ESTADO 
                    repo.ListaStatus(); 
                    break;
                case "4":
                    Console.WriteLine("Cambio de Estado\n");        //Permite al usuario cambiar el ESTADO de la tarea que el elija mediante el ID de la misma 
                    repo.CambiarEstado();
                    break;
            }
            Console.Clear();        //Al terminar el case se vuelve a ejecutar el menú para que no se cierre el programa y se limpia la consola para no tener tanto texto
            MenuPrincipal();
        }

        private void Saludo()       //Método saludo que muestra una bienvenida al usuario cuando corre la applicacion 
        {
            Console.WriteLine("!BIENVENIDO!\nTASK AGENDA");
          
        }
       
    }
}
