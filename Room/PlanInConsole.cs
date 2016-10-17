using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room
{
    class PlanInConsole
    {
        #region Fields
        private int length;
        private int width;
        private char[,] plan;
        #endregion
        public PlanInConsole(int _length, int _width)
        {
            this.length = _length;
            this.width = _width;
            plan = new char[this.length+3, this.width+3];
            for (int j = 0; j < this.width + 3; j++)
            {
                plan[0, j] = '-';
                plan[this.length + 2, j] = '-';
            }
            for (int i = 0; i < this.length + 3; i++)
            {
                plan[i, 0] = '|';
                plan[i, this.width + 2] = '|';
            }
            for (int i = 1; i < this.length + 2; i++)
            {
                for (int j = 1; j < this.width + 2; j++)
                {
                    plan[i, j] = ' ';
                }

            }

        }
        public void Add(int y, int x,int length,int width)
        {
            for (int i = y+ 1; i <= y + length; i++)
            {
                for (int j = x + 1; j <= x +width; j++)
                {
                    if (plan[i, j] == ' ')
                    {
                        plan[i, j] = '*';
                    }
                    else
                    {
                        Exception ex = new Exception();
                        ex.Data.Add("This space is full", DateTime.Now);
                        throw ex;
                    }
                }
            }
        }
        public void Remove(int y, int x, int length, int width)
        {
            for (int i = y + 1; i <= y + length; i++)
            {
                for (int j = x + 1; j <= x + width; j++)
                {
                    plan[i, j] = ' ';
                }
            }
        }
        public void ShowPlan()
        {
            for (int i = 0; i < this.length + 3; i++)
            {
                for (int j = 0; j < this.width + 3; j++)
                {
                    Console.Write(plan[i, j]);
                }
                Console.WriteLine();

            }
        }
        public void ReplaceSymbol(int y, int x, char symb)
        {
            plan[y, x] = symb;
        }

    }
}
