using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace ASPNETCOREFORM.Models {

    public class FormControl
    {
        public int FormControlId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
    /*
        Create a class that represents the form designed in React.
        You must find the name attribute and see what the Name it has assigned to that Form Control.

        Example:
        If the form control is: <FormControl type="number" name="quantity" placeholder="Quantity" />
        --Then the class must contain the name of quantity as:
        public int Quantity {get; set;}

        Notice, that the type is number. 
            number is int
            text is string
     */



    public class InventoryContext : DbContext
    {
        public DbSet<FormControl> Inventories { get; set; }
        /*
        You must assign:
        public DbSet<NameOfClassGoesHere> Inventories {get;set;}
        Change NameOfClass to the class you have created.
         */



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Inventory.db");
        }

    }


}