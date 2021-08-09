using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        public PersonaAdapter PersonaData { set; get; }

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public PersonaLogic(PersonaAdapter personaAdapter)
        {
            PersonaData = personaAdapter;
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public Persona GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }

        public void Save(Persona persona)
        {
            PersonaData.Save(persona);
        }
    }
}
