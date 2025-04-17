using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.database.models;

namespace WebApplication1.database
{
    public class dbContext
    {
        private const string pathName = "C:\\Users\\artur\\OneDrive\\Documentos\\APIs.net\\AspireApp1\\WebApplication1\\animais.txt";

        private readonly List<Animal> _animais = new();

        public dbContext()
        {
            string[] lines = File.ReadAllLines(pathName);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(';');

                Animal animal = new();
                animal.id = Convert.ToInt32(columns[0]);
                animal.name = columns[1];
                animal.classification = columns[2];
                animal.origem = columns[3];
                animal.reproduction = columns[4];
                animal.feeding = columns[5];

                _animais.Add(animal);
            }
        }
        public List<Animal> Animais => _animais;
    }
}
