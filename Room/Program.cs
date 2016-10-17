﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room
{
    class Program
    {
        static void Main(string[] args)
        {
            Item sofa = new Item("SOFA", 1, 3, 0, 0);
            Item chair = new Item("CHAIR", 1, 1, 2, 2);
            chair.replace(3, 3);
            Room room = new Room(4, 4);
            room.Add(sofa);
            room.Add(chair);
            room.Show_plan();
            room.Replace(chair,2,3);
            room.Open_window();
            room.Light_on();
            room.Open_door();
            room.Remove(sofa);
            room.Show_plan();
            foreach (Item it in room.furniture)
            {
                it.Name = it.Name + it.Name.GetHashCode();
            }
          
            Console.ReadLine();
            
           }
             
        }
    }
