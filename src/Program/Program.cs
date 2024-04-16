//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID
{
    public class Program                                                // Los patrones y principios que utilizamos fue el patron Expert y el principio SRP lo cual nos dice que cada clase debe tener una unica tarea general
                                                                        // y las tareas deben ser asignadas a las clases que contengan los datos suficientes para lograrlas
    {
        private static ArrayList productCatalog = new ArrayList();      // Creamos un arreglo que contenga el catalogo del producto

        private static ArrayList equipmentCatalog = new ArrayList();    // Creamos un arreglo que contenga el catalogo de las herramientas que necesitemos para nuestro producto
        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe(); //Aqui creamos nuestra receta
            recipe.FinalProduct = GetProduct("Café con leche");
            recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));
            ConsolePrinter.Printer(recipe); //Esta es nuestra nueva clase encargada de imprimir la receta con su correspondiente precio
        }

        private static void PopulateCatalogs() //Aqui detallamos los productos y herramientas que utilizaremos
        {
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }
        private static void AddProductToCatalog(string description, double unitCost) //Aqui agregamos los productos a nuestro arreglo de productos
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost) //Aqui agregamos las herramientas a nuestro arreglo de equipos
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        private static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        private static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
    }
}