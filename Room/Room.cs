using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room
{
    class Room:Operations
    { 
       #region Fields
        private bool light_is_on;
        private bool door_is_open;
        private bool window_is_open;
        private int length;
        private int width;
        private int free_space;
        public  List<Item> furniture=new List<Item>();
        private char[,] plan;
       #endregion
       #region Properties
        public bool Light
        {
            get { return this.light_is_on; }
            set { this.light_is_on = value; }

        }
        public bool Door
        {
            get { return this.door_is_open; }
            set { this.door_is_open = value; }
        }
        public int Length
        {
            get { return this.length; }
        }
        public int Width
        {
            get { return this.width; }
        }
        public bool Window
        {
            get { return this.window_is_open; }
            set { this.window_is_open = value; }
        }
        public int Square
        {
            get { return this.length * this.width; }
        }
        #endregion
       #region Ctors
        public Room(int _length, int _width)
        {
            this.length = _length;
            this.width = _width;
            this.light_is_on=false;
            this.window_is_open=false;
            this.door_is_open=false;
            this.plan = new char[this.length + 3, this.width + 3];
            Make_plan();
        }
        public Room(int _length, int _width, bool _door, bool _window, bool _light)
        {
            this.length = _length;
            this.width = _width;
            this.light_is_on = _light;
            this.window_is_open =_window;
            this.door_is_open = _door;
            Make_plan();
        }
        #endregion
  
        public void Open_door()
        {
            door_is_open = true;
            plan[1,0]='/';
        }
        public void Close_door()
        {
            door_is_open = false;
            plan[1, 0] = '|';
        }
        public void Open_window()
        {
            window_is_open = true;
            plan[this.length,this.width+2]='/';
            plan[1, this.width + 2] = '/';

        }
        public void Close_window()
        {
            window_is_open = true;
            plan[this.length, this.width + 2] = '|';
            plan[1, this.width + 2] = '|';

        }
        public void Light_on()
        {
            light_is_on = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void Light_off()
        {
            light_is_on = false;
            Console.ResetColor();
        }
    
        public void Add(Item _item)
        {
            this.free_space = this.width * this.length - _item.Square;
            if (this.free_space <= 0)
            {
                Exception ex = new Exception();
                ex.Data.Add("NotEnoughOfFreeSpace", DateTime.Now);
                throw ex;
            }
            else
            {
                for (int i = _item.Yc + 1; i <= _item.Yc + _item.Length; i++)
                {
                    for (int j = _item.Xc + 1; j <= _item.Xc + _item.Width; j++)
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
                furniture.Add(_item);
            }
        }
        public void Remove(Item _item)
        {
            for (int i = _item.Yc + 1; i <= _item.Yc + _item.Length; i++)
            {
                for (int j = _item.Xc + 1; j <= _item.Xc + _item.Width; j++)
                {
                    plan[i, j] = ' ';
                }
            }
            this.furniture.Remove(_item);
        }
        public void Make_plan()
        {
            for (int j = 0; j < this.width + 3;j++ )
            {
                plan[0, j] = '-';
                plan[ this.length + 2,j] = '-';
            }
            for(int i=0;i<this.length+3;i++){
                plan[i,0] = '|';
                plan[i,this.width + 2] = '|';
            }
            for (int i = 1; i < this.length + 2; i++)
            {
                for (int j = 1; j < this.width + 2; j++)
                {
                    plan[i,j] = ' ';
                }

            }
          
        }
        public void Show_plan()
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
    }
}
