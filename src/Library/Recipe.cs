//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe                             // El error que existia en esta clase era que se encargaba de almacenar los pasos y tambien de imprimirlos en pantalla
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }
        public ArrayList Steps                      // Agregamos este ArrayList Steps para que se use de manera publica y las otras clases puedan acceder a el sin modificar su contenido.
        {
            get { return steps; }
        }
    }
}