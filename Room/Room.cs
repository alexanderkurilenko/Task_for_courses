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
        private PlanInConsole plan;
        public  List<Item> furniture=new List<Item>();
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
            this.plan = new PlanInConsole(this.length, this.width);
            
        }
        public Room(int _length, int _width, bool _door, bool _window, bool _light)
        {
            this.length = _length;
            this.width = _width;
            this.light_is_on = _light;
            this.window_is_open =_window;
            this.door_is_open = _door;
            this.plan = new PlanInConsole(this.length, this.width);

        }
        #endregion
  
        public void Open_door()
        {
            door_is_open = true;
            plan.ReplaceSymbol(1, 0, '/');
        }
        public void Close_door()
        {
            door_is_open = false;
            plan.ReplaceSymbol(1, 0, '|');
        }
        public void Open_window()
        {
            window_is_open = true;
            plan.ReplaceSymbol(this.length, this.width + 2, '/');
            plan.ReplaceSymbol(1, this.width + 2, '/');        
        }
        public void Close_window()
        {
            window_is_open = true;
            plan.ReplaceSymbol(this.length, this.width + 2, '|');
            plan.ReplaceSymbol(1, this.width + 2, '|');
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
                plan.Add(_item.Yc, _item.Xc, _item.Length, _item.Width);
                furniture.Add(_item);
            }
        }
        public void Remove(Item _item)
        {
            plan.Remove(_item.Yc, _item.Xc, _item.Length, _item.Width);
            this.furniture.Remove(_item);
        }
       
        public void Replace(Item _item, int newy, int newx)
        {
            try
            {
                Remove(_item);
                _item.replace(newy, newx);
                Add(_item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Space is not free");

            }

        }
       
        public void Show_plan()
        {
            plan.ShowPlan();
        }
    }
}
