using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class ConsolePrinter
    {
        public static void Printer(Recipe recipe)
        {
            Console.WriteLine($"Receta de {recipe.FinalProduct.Description}:"); // Aqui estamos imprimiendo en consola la receta a preparar
            foreach (Step step in recipe.Steps)                                 // Este foreach itera los pasos que dicta la receta y los imprime uno a uno
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El precio final: {RecipeCost.Cost(recipe)}");   // Por ultimo imprimimos el precio final.
        }
    }
}
