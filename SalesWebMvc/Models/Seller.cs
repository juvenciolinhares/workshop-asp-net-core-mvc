﻿using System;
using System.Linq;
using System.Collections.Generic;
namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }//implementar department em seller
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); //associação de salesrecord com sales

        //construtor vazio por conta do framework
        public Seller()
        {

        }

        //construtor com argumentos, mas sem coleções(essas informações vao aparecer no bd)
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }


        //metodos p add e remover uma venda
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //operação que retorna o total de vendas
        public double totalSales(DateTime initial, DateTime final)
        {
            /*implementar utilizando o link]
             * 1°: exporta link;
             * 2° chama colecão Sales(lista de vendas associada ao vendedor)
             * 3° filtra(WHERE) a lista p obter uma nova lista contendo apenas as vendas no intervalo dado no argumento
             * 4° calcular a soma das vendas(amount)
             */
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }
    }
}
