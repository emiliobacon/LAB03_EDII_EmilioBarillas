
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio01.Cipher
{
    public class Transposition
    {
        public static int[] Indexs(string llave)
        {
            int longitudLlave = llave.Length;
            int[] indexs = new int[longitudLlave];
            List<KeyValuePair<int, char>> llaveOrdenada = new List<KeyValuePair<int, char>>();
            int i;

            for (i = 0; i < longitudLlave; ++i)
            {
                llaveOrdenada.Add(new KeyValuePair<int, char>(i, llave[i]));
            }

            llaveOrdenada.Sort
            (
                delegate (KeyValuePair<int, char> par1, KeyValuePair<int, char> par2)
                {
                    return par1.Value.CompareTo(par2.Value);
                }
            );

            for (i = 0; i < longitudLlave; ++i)
            {
                indexs[llaveOrdenada[i].Key] = i;
            }

            return indexs;
        }

        public static string Cifrar(string entrada, string llave, char espacio)
        {
            entrada = (entrada.Length % llave.Length == 0) ? entrada : entrada.PadRight(entrada.Length - (entrada.Length % llave.Length) + llave.Length, espacio);
            StringBuilder salida = new StringBuilder();

            int caracteres_total = entrada.Length;
            int columnasTotales = llave.Length;
            int totalFilas = (int)Math.Ceiling((double)caracteres_total / columnasTotales);

            char[,] caracteresFila = new char[totalFilas, columnasTotales];
            char[,] caracteresColumna = new char[columnasTotales, totalFilas];
            char[,] caracteresColumnaOrdenados = new char[columnasTotales, totalFilas];

            int filaActual;
            int columnaActual;
            int i;
            int j;
            int[] indexsCambio = Indexs(llave);

            for (i = 0; i < caracteres_total; i++)
            {
                filaActual = i / columnasTotales;
                columnaActual = i % columnasTotales;
                caracteresFila[filaActual, columnaActual] = entrada[i];
            }

            for (i = 0; i < totalFilas; ++i)
            {
                for (j = 0; j < columnasTotales; ++j)
                {
                    caracteresColumna[j, i] = caracteresFila[i, j];
                }
            }

            for (i = 0; i < columnasTotales; ++i)
            {
                for (j = 0; j < totalFilas; ++j)
                {
                    caracteresColumnaOrdenados[indexsCambio[i], j] = caracteresColumna[i, j];
                }
            }

            for (i = 0; i < caracteres_total; ++i)
            {
                filaActual = i / totalFilas;
                columnaActual = i % totalFilas;
                salida.Append(caracteresColumnaOrdenados[filaActual, columnaActual]);
            }

            return salida.ToString();
        }

        public static string Decifrar(string entrada, string llave)
        {
            StringBuilder salida = new StringBuilder();

            int caracteresTotal = entrada.Length;
            int columnasTotales = (int)Math.Ceiling((double)caracteresTotal / llave.Length);
            int filasTotales = llave.Length;

            char[,] caracteresFila = new char[filasTotales, columnasTotales];
            char[,] caracteresColumna = new char[columnasTotales, filasTotales];
            char[,] caracteresColumnaDesordenados = new char[columnasTotales, filasTotales];

            int filaActual;
            int columnaActual;
            int i;
            int j;
            int[] indexsCambio = Indexs(llave);

            for (i = 0; i < caracteresTotal; i++)
            {
                filaActual = i / columnasTotales;
                columnaActual = i % columnasTotales;
                caracteresFila[filaActual, columnaActual] = entrada[i];
            }

            for (i = 0; i < filasTotales; i++)
            {
                for (j = 0; j < columnasTotales; j++)
                {
                    caracteresColumna[j, i] = caracteresFila[i, j];
                }
            }

            for (i = 0; i < columnasTotales; i++)
            {
                for (j = 0; j < filasTotales; j++)
                {
                    caracteresColumnaDesordenados[i, j] = caracteresColumna[i, indexsCambio[j]];
                }
            }

            for (i = 0; i < caracteresTotal; i++)
            {
                filaActual = i / filasTotales;
                columnaActual = i % filasTotales;
                salida.Append(caracteresColumnaDesordenados[filaActual, columnaActual]);
            }

            return salida.ToString();
        }
    }
}

