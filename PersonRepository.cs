using JMacasS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JMacasS5
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init() {
            if (conn is not null)

                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
            }
        public PersonRepository(string dbPath) { 
        _dbPath = dbPath;
        }
        public void AddNewPerson(string Name) {
            int result = 0;
            try {
                Init();
                if (string.IsNullOrEmpty(Name)) 
                    throw new Exception("Nombre es requerido");
                    Persona perosn = new() { Name =Name };
                    result = conn.Insert(perosn);
                    StatusMessage = string.Format("Se ingreso una persona ",result, Name);
                                  
               
            }
            catch(Exception ex)
             {
                StatusMessage = string.Format("Error no se inserto la persona",Name,ex.Message);
            }

        }

        public List<Persona> getAllPeople() {
            try
            { 
                Init();
                return conn.Table<Persona>().ToList();
            } catch(Exception ex) {
                StatusMessage = string.Format("Error al listar", ex.Message);
            }
            return new List<Persona>();
        }
        public void UpdatePerson(Persona person)
        {
         
            try
            {
                Init();
                
                 conn.Update(person);
                StatusMessage = string.Format("Se Actualizo la perosna con ID {0} y nombre{1}", person.Id, person.Name);


            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al actulizar persona con ID {0}:{1} ", person.Id, ex.Message);
            }

        }
public void DeletePerson(int id ) {
            try
            {
                Init();
                conn.Delete<Persona>(id);
                StatusMessage = string.Format("Se eliminó la persona con ID {0}", id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al eliminar la persona con ID {0}: {1}", id, ex.Message);
            }

        }

    } }
