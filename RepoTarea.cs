using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class RepoTarea         //Clase que contiene los métodoso que crean, modifican, y muestran las tareas de la agenda
    {
        int IdTarea = 1;        //Variable ID para guardar el valor que determinar el ID de cada tarea nueva creada este valor se va incrementando cada nueva tarea 
        int res;        //Varible que guarda el resultado de los pequeños menus que se van desarrollando mas adelante, su valor se determina según el usuario
        List<Tarea> tareas = new List<Tarea>(); //Creación de la lista que contiene las tareas
        
        
        public void CrearTarea()        //Método que crea una tarea nueva pide los datos al usuario y determinar el estado por default como PENDIENTE
        {
            Console.Clear();
            Tarea tarea = new Tarea();

            Console.WriteLine("Crear nueva tarea");
            Console.WriteLine("Ingresar el encargado de la tarea");
            tarea.Encargado = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre de la tarea");
            tarea.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la descripción de la tarea");
            tarea.Descripcion = Console.ReadLine();
            Console.WriteLine("Ingresar fecha de inicio usando '/' y ':' para la hora");
            tarea.FechaInicio = Convert.ToDateTime(Console.ReadLine());
            tarea.Estado = "PENDIENTE";

            AddTarea(tarea);            //Llama a otro método AddTarea el cual agrega la tarea a la lista
                       
        }
        private void AddTarea(Tarea tarea)      //la tarea creada es agregada a la lista en este método
        {
            tarea.Id = IdTarea;         //y determina su ID mediante la variable antes mencionada, al terminar el recorrido en este método la variable incrementa en 1
            tareas.Add(tarea);
            IdTarea++;
            Console.WriteLine("TAREA AGREGADA CON EXITO ;)");       //Mensaje que notifica al usuario que una nueva tarea ah sido agregada
            Console.ReadKey();
        }


        public void ListaTareas()       //Método que muestra todas las tareas pero solo su ID y nombre
        {
            Console.Clear();
                      
            foreach (var item in tareas)
            {             
                Console.WriteLine(item.Id + " " + item.Nombre);               //Esto para que el usuario elija mediante el ID la tarea que quiere ver a detalle
            }

            MostrarTarea();     //Para esto, utilizo el método Mostrar Tarea 

            Console.WriteLine("PULSE CUALQUIER TECLA PARA CONTINUAR");
            Console.ReadKey();
            

        }
        private void MostrarTarea()  //En este método perteneciente al Método ListaTareas se muestran todos los datos de solo una tarea la cual es elegida por el usuario
        {
            
          
            Console.WriteLine("Elija el ID para ver más información de una tarea");
            res = Convert.ToInt32(Console.ReadLine());
            
            foreach (var item in tareas)
            {
                if(res == item.Id)
                {
                    Console.WriteLine("ID: {0}\nNombre: {1}\nEncargado: {2}\nDescripcion de la tarea: {3}\nFecha de inicio: {4}\nEstado: {5}", item.Id,item.Nombre,item.Encargado, item.Descripcion, item.FechaInicio, item.Estado);

                }
            }
            

        }

        public void ListaStatus()   //Este método muestra todas las tareas en orden de ESTADO siendo PENDIENTES, PROGRESO, COMPLETADAS respectivamente
        {
            Console.Clear();
            GetPendiente();         //Para esto utilizo 3 métodos extras para que sea legible y no ocurran problemas
            GetProgreso();
            GetCompletada();
            Console.WriteLine("PULSE CUALQUIER TECLA PARA CONTINUAR");      //Al mostrar todas las tareas el usuario puede regresar al menú presionando cualquier tecla
            Console.ReadLine();
        }

        private void GetCompletada()        //Método que muestra todas las tareas COMPLETADAS se ejecuta en el método ListaStatus
        {
            Console.WriteLine("\nTAREAS COMPLETADAS----------------------\n");
            foreach (var item in tareas)
            {              
                if (item.Estado == "COMPLETADA")        //Si la tarea cumple la condición se imprime en pantalla
                {                  
                    Console.WriteLine("ID: {0}\nNombre: {1}\nEncargado: {2}\nDescripcion de la tarea: {3}\nFecha de inicio: {4}\nEstado: {5}", item.Id, item.Nombre, item.Encargado, item.Descripcion, item.FechaInicio, item.Estado);

                }
            }
        }

        private void GetProgreso()      //Funciona de la misma forma que el anterior a diferencia de que muestra las tareas en PROGRESO
        {
            Console.WriteLine("\nTAREAS EN PROGRESO----------------------\n");
            foreach (var item in tareas)
            {             
                 if (item.Estado == "PROGRESO")
                {                 
                    Console.WriteLine("ID: {0}\nNombre: {1}\nEncargado: {2}\nDescripcion de la tarea: {3}\nFecha de inicio: {4}\nEstado: {5}", item.Id, item.Nombre, item.Encargado, item.Descripcion, item.FechaInicio, item.Estado);

                }
               
            }
        }

        private void GetPendiente()     //Muestra las tareas que estén PENDIENTES
        {
            Console.WriteLine("TAREAS PENDIENTES----------------------\n");
            foreach (var item in tareas)
            {
                if (item.Estado == "PENDIENTE")
                {
                    
                    Console.WriteLine("ID: {0}\nNombre: {1}\nEncargado: {2}\nDescripcion de la tarea: {3}\nFecha de inicio: {4}\nEstado: {5}", item.Id, item.Nombre, item.Encargado, item.Descripcion, item.FechaInicio, item.Estado);

                }
                
            }
        }

        public void CambiarEstado()     //Este método permite al usuario cambiar el ESTADO de una TAREA
        {
            Console.Clear();
          
            foreach (var item in tareas)
            {

            
                Console.WriteLine(item.Id + " " + item.Nombre);     //Muestra todas las tareas registradas solo el ID y el nombre 
                
               
            }

            Console.WriteLine("Elija el ID de la tarea a modificar");       //El usuario elige una tarea mediante el ID 
            res = Convert.ToInt32(Console.ReadLine());
            foreach(var item in tareas) {
                if (res == item.Id)
                {
                    Console.WriteLine("Elija el nuevo ESTADO de la tarea (Actualmente esta: {0}): ", item.Estado);      //Se muestra un menú para elegir el nuevo ESTADO de la tarea
                    Console.WriteLine("1.-PENDIENTE\n2.-PROGRESO\n3.-COMPLETADA");                              //De la misma forma se muestra al usuario el ESTADO en el que se encuentra
                    switch (Console.ReadLine())
                    {
                        case "1":
                            item.Estado = "PENDIENTE";      //Seún sea la elección se ejecuta un case y cambia el valor del ESTADO
                            break;
                        case "2":
                            item.Estado = "PROGRESO";
                            break;
                        case "3":
                            item.Estado = "COMPLETADA";
                            break;

                    }
                }
            }
        }
       
    }
}
