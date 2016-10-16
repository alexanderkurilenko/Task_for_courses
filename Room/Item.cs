using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room
{
    class Item
    {
        #region Fields
        private string name;
        private int length;
        private int width;
        private int xc;
        private int yc;
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
        }
        public int Length
        {
            get { return this.length; }
        }
        public int Width
        {
            get { return this.width; }
        }
        public int Square
        {
            get { return this.length * this.width; }
        }
        public int Xc
        {
            get { return this.xc; }
        }
        public int Yc
        {
            get { return this.yc; }
        }
        #endregion

        public void replace(int new_X, int new_Y)
        {
            this.xc = new_X;
            this.yc = new_Y;
        }
        public Item(string _name, int _length, int _width, int _x, int _y)
        {
            this.name = _name;
            this.length = _length;
            this.width = _width;
            this.xc = _x;
            this.yc = _y;
        }
    }
}
