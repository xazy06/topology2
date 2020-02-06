using Designer.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Cors;

namespace Topology
{
    [Route("api/")]
    public class MainController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null;
        }

        [EnableCors("MyPolicy")]
        [HttpPost("SaveModel")]
        public IActionResult SaveModel([FromBody] Model Model)
        {
            try
            {
                if (String.IsNullOrEmpty(Model.Uuid))
                    Model.Uuid = Guid.NewGuid().ToString();
                String FileName = Path.Combine(Program.HomeDir, Model.Uuid + ".json");

                String Json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);

                System.IO.File.WriteAllText(FileName, Json);

                return Ok(Model.Uuid);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [EnableCors("MyPolicy")]
        [HttpGet("LoadModel")]
        public IActionResult LoadModel([FromQuery] String uuid)
        {
            try
            {
                if (String.IsNullOrEmpty(uuid))
                    return NotFound("Model UUID is empty");

                String FileName = Path.Combine(Program.HomeDir, uuid + ".json");

                if (!System.IO.File.Exists(FileName))
                    return NotFound("File not found " + FileName);

                String Json = System.IO.File.ReadAllText(FileName);

                Model Model = (Model)Newtonsoft.Json.JsonConvert.DeserializeObject(Json, typeof(Model));


                return Ok(Model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [EnableCors("MyPolicy")]
        [HttpGet("GetPalette")]
        public IActionResult GetPalette()
         
        {
           List<Component> result = new List<Component>()
           {

             new Component()
             {
                DisplayName = "Ворота",
                ClassName = "Gate",
                GroupName = "Склад",
                Frame = new Frame(0, 0, 300, 3000),
                Graphics = new Shape[] { new Rectangle(0, 0, 300, 3000) },
                DefaultSize = new Frame(0, 0, 300, 3000),
                MinSize = new Frame(0, 0, 100, 2000),
                MaxSize = new Frame(0, 0, 1000, 6000),
                DefaultText = "Ворота",
                Properties = new ObjectProp[]
                  {
                      new ObjectProp("Номер ворот", "Nr", "Общее", "String", new ExternalMethod("", ""), new ExternalMethod("", "")),
                      new ObjectProp("Штрихкод", "Barcode", "Общее", "String", new ExternalMethod("", ""), new ExternalMethod("", ""))},
                OnDblClick = new ExternalMethod("", ""),
                OnChange = new ExternalMethod("", ""),
             },

             new Component()
             {
                DisplayName = "Стеллаж",
                ClassName = "Rack",
                GroupName = "Склад",
                Frame = new Frame(0, 0, 300, 3000),
                Graphics = new Shape[] { new Rectangle(0, 0, 1000, 2708) },
                DefaultSize = new Frame(0, 0, 1000, 2708),
                MinSize = new Frame(0, 0, 1000, 2708),
                MaxSize = new Frame(0, 0, 1000, 2708),
                DefaultText = "Стеллаж",
                Properties = new ObjectProp[]
                  {
                      new ObjectProp("Номер", "Nr", "Общее", "String", new ExternalMethod("", ""), new ExternalMethod("", "")),
                      new ObjectProp("Штрихкод", "Barcode", "Общее", "String", new ExternalMethod("", ""), new ExternalMethod("", ""))},
                OnDblClick = new ExternalMethod("", ""),
                OnChange = new ExternalMethod("", ""),
             }
           };

            return Ok(result);
        }


        [HttpPost]
        public string Post([FromBody]string value)
        {
            return "OK";
        }


    }
}

