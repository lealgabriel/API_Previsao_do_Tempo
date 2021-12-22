﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeather_Desafio.Data
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Temp { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public DateTime DateTime {get; set;}

        public Cidade()
        {

        }
        public Cidade(int id, string nome, double temp, double tempMax, double tempMin, DateTime dateTime)
        {
            Id = id;
            Nome = nome;
            Temp = temp;
            TempMax = tempMax;
            TempMin = tempMin;
            DateTime = dateTime;
        }
    }
}