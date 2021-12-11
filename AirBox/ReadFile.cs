using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using AirBox.Model;

namespace AirBox
{
    public class ReadFile
    {
        public List<Flight> GetFlights(string path)
        {
            var result = new List<Flight>();

            string str;
            using StreamReader f = new StreamReader(path);

            //// Пропустить строку с заданием.
            f.ReadLine();

            while ((str = f.ReadLine()) != null)
            {
                var strSplited = str.Split(" ");
                result.Add(new Flight
                {
                    Start = strSplited[1],
                    Finish = strSplited[2],
                    Weight = int.Parse(strSplited[3]),
                    Date = DateTime.Parse(strSplited[4])
                });
            }
            
            var flight = new Flight();

            return result;
        }
        
        public Cargo GetCargo(string path)
        {
            using StreamReader f = new StreamReader(path);
            var strSplited = f.ReadLine().Split(" ");
            
            var result = new Cargo
            {                    
                Start = strSplited[0],
                Finish = strSplited[1],
                Weight = int.Parse(strSplited[2]),
            };
            
            return result;
        }
    }
}