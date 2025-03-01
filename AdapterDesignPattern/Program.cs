﻿using System;

namespace AdapterDesignPattern

    {
        public class Program
        {
            public static void Main(string[] args)
            {

                Compound unknown = new Compound();
                unknown.Display();

        

                Compound water = new RichCompound("Water");
                water.Display();

                Compound benzene = new RichCompound("Benzene");
                benzene.Display();

                Compound ethanol = new RichCompound("Ethanol");
                ethanol.Display();

     

                Console.ReadKey();
            }
        }

         public class Compound
        {
            protected float boilingPoint;
            protected float meltingPoint;
            protected double molecularWeight;
            protected string molecularFormula;

            public virtual void Display()
            {
                Console.WriteLine("\nCompound: Unknown ------ ");
            }
        }

        public class RichCompound : Compound
        {
            private string chemical;
            private ChemicalDatabank bank;

            public RichCompound(string chemical)
            {
                this.chemical = chemical;
            }

            public override void Display()
            {
           
                bank = new ChemicalDatabank();

                boilingPoint = bank.GetCriticalPoint(chemical, "B");
                meltingPoint = bank.GetCriticalPoint(chemical, "M");
                molecularWeight = bank.GetMolecularWeight(chemical);
                molecularFormula = bank.GetMolecularStructure(chemical);

                Console.WriteLine("\nCompound: {0} ------ ", chemical);
                Console.WriteLine(" Formula: {0}", molecularFormula);
                Console.WriteLine(" Weight : {0}", molecularWeight);
                Console.WriteLine(" Melting Pt: {0}", meltingPoint);
                Console.WriteLine(" Boiling Pt: {0}", boilingPoint);
            }
        }

        public class ChemicalDatabank
        {


            public float GetCriticalPoint(string compound, string point)
            {
            
                if (point == "M")
                {
                    switch (compound.ToLower())
                    {
                        case "water": return 0.0f;
                        case "benzene": return 5.5f;
                        case "ethanol": return -114.1f;
                        default: return 0f;
                    }
                }

          

                else
                {
                    switch (compound.ToLower())
                    {
                        case "water": return 100.0f;
                        case "benzene": return 80.1f;
                        case "ethanol": return 78.3f;
                        default: return 0f;
                    }
                }
            }

            public string GetMolecularStructure(string compound)
            {
                switch (compound.ToLower())
                {
                    case "water": return "H20";
                    case "benzene": return "C6H6";
                    case "ethanol": return "C2H5OH";
                    default: return "";
                }
            }

            public double GetMolecularWeight(string compound)
            {
                switch (compound.ToLower())
                {
                    case "water": return 18.015;
                    case "benzene": return 78.1134;
                    case "ethanol": return 46.0688;
                    default: return 0d;
                }
            }
        }
    }

