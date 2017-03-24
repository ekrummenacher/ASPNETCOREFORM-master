using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCOREFORM.Models;
using Newtonsoft.Json;

namespace ASPNETCOREFORM.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        /*
        
        Instructions:
        Anywhere in the code containing [MyNameClass], change it
        to the name of the class you have defined in your Model.cs file.
         */

        // GET api/values
        [HttpGet]
        public List<FormControl> Get()
        {
            var data = new List<FormControl>();
            using (var db = new InventoryContext())
            {
                data = db.Inventories.ToList();
            }

            return data;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<FormControl> Get(int id)
        {
            var data = new List<FormControl>();
            using (var db = new InventoryContext())
            {
                data = db.Inventories.Where(x => x.FormControlId == id).ToList();
            }

            return data;

        }


        // POST api/values
        [HttpPost]
        public string Post([FromBody] FormControl value)
        {

            // Console.WriteLine(data.id);

            using (var db = new InventoryContext())
            {

                /*
                 The code will try and run, If it fails then we get an error.
                 Once we get an error, we'll send it back to the React. 
                 */
                try
                {
                    if (value.FormControlId < 1)
                    {
                        db.Inventories.Add(value);
                        db.SaveChanges();
                    }
                    else
                    {

                        var record = db.Inventories.Where(x => x.FormControlId == value.FormControlId).FirstOrDefault();


                        record.Name = value.Name;
                        record.Description = value.Description;
                        record.Quantity = value.Quantity;
                        record.Price = value.Price;

                        db.Inventories.Update(record);
                        db.SaveChanges();

                    }
                }
                catch (Exception error)
                {
                    return error.ToString();
                }

            }
            /*
               Make sure to create a new instance of 
               inventoryContext. You may refer to your notes or gitbook.
               https://cn1109.gitbooks.io/saintermediate/content/dotnet-core-entityframework.html

               Look under the section: Updating the Values Controller to use Entity Framework
            */

            return "DONE!";
        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            using (var db = new InventoryContext())
            {
                var inventoryItem = db.Inventories.Where(x => x.FormControlId == id);

                if (inventoryItem.Count() > 0)
                {

                    var inventoryItemRecord = inventoryItem.FirstOrDefault();
                    db.Remove(inventoryItemRecord);
                    db.SaveChanges();

                    return "DONE!";

                }
                else
                {
                    return "No Record Found";
                }
            }
        }
    }


}

