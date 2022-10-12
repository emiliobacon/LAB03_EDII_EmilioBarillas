using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Laboratorio01.Data_Structure;
using Laboratorio01.Helpers;
using Laboratorio01.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Reflection;
using Laboratorio01.Cartas;

namespace Laboratorio01.Controllers
{
    public class ClientController : Controller
    {
        


        // GET: Client
        public ActionResult Index()
        {
            return View(Data.Instance.miArbolAvlId);
        }

        //Index donde se muestran los resultados de búsqueda

        public ActionResult searchId()
        {
            return View(new ClientModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult searchId(IFormCollection collection)
        {
            try
            {
                long parametro = (long.Parse(collection["Id"]));
                string contrasena = (collection["FullName"]);

                ViewData["DPI"] = parametro;

                //insertar carta 1
                if (LeerCartas.Leer(parametro, 1) != "error")
                {
                    string carta = LeerCartas.Leer(parametro, 1);

                    ViewData["Codificado_1"] = LZW.LZW.Desencolar(LZW.LZW.Codificar(carta));

                    ViewData["Decodificado_1"] = LZW.LZW.Decodificar(LZW.LZW.Codificar(carta));
                }
                //insertar carta 2
                if (LeerCartas.Leer(parametro, 2) != "error")
                {
                    string carta = LeerCartas.Leer(parametro, 2);

                    ViewData["Codificado_2"] = LZW.LZW.Desencolar(LZW.LZW.Codificar(carta));

                    ViewData["Decodificado_2"] = LZW.LZW.Decodificar(LZW.LZW.Codificar(carta));
                }
                //insertar carta 3
                if (LeerCartas.Leer(parametro, 3) != "error")
                {
                    string carta = LeerCartas.Leer(parametro, 3);

                    ViewData["Codificado_3"] = LZW.LZW.Desencolar(LZW.LZW.Codificar(carta));

                    ViewData["Decodificado_3"] = LZW.LZW.Decodificar(LZW.LZW.Codificar(carta));
                }
                //insertar carta 4
                if (LeerCartas.Leer(parametro, 4) != "error")
                {
                    string carta = LeerCartas.Leer(parametro, 4);

                    ViewData["Codificado_4"] = LZW.LZW.Desencolar(LZW.LZW.Codificar(carta));

                    ViewData["Decodificado_4"] = LZW.LZW.Decodificar(LZW.LZW.Codificar(carta));
                }

                //cifrado de conversaciones
                if (LeerConv.Leer(parametro, 1) != "error")
                {
                    string conv = LeerConv.Leer(parametro, 1);

                    ViewData["Codificado_11"] = Cipher.Transposition.Cifrar(conv, contrasena, '-');

                    ViewData["Decodificado_11"] = Cipher.Transposition.Decifrar(Cipher.Transposition.Cifrar(conv, contrasena, '-'), contrasena);
                }
                else
                {
                    return RedirectToAction(nameof(Error));
                }

                //insertar carta 2
                if (LeerConv.Leer(parametro, 2) != "error")
                {
                    string conv = LeerConv.Leer(parametro, 2);

                    ViewData["Codificado_22"] = Cipher.Transposition.Cifrar(conv, contrasena, '-');

                    ViewData["Decodificado_22"] = Cipher.Transposition.Decifrar(Cipher.Transposition.Cifrar(conv, contrasena, '-'), contrasena);
                }
                //insertar carta 3
                if (LeerConv.Leer(parametro, 3) != "error")
                {
                    string conv = LeerConv.Leer(parametro, 3);

                    ViewData["Codificado_33"] = Cipher.Transposition.Cifrar(conv, contrasena, '-');

                    ViewData["Decodificado_33"] = Cipher.Transposition.Decifrar(Cipher.Transposition.Cifrar(conv, contrasena, '-'), contrasena);
                }
                //insertar carta 4
                if (LeerConv.Leer(parametro, 4) != "error")
                {
                    string conv = LeerConv.Leer(parametro, 4);

                    ViewData["Codificado_44"] = Cipher.Transposition.Cifrar(conv, contrasena, '-');

                    ViewData["Decodificado_44"] = Cipher.Transposition.Decifrar(Cipher.Transposition.Cifrar(conv, contrasena, '-'), contrasena);
                }

                return View(Data.Instance.miArbolAvlId.Buscar(Comparison.Comparison.CompararID(parametro)));
            }
            catch 
            {
                return RedirectToAction(nameof(Error));
            }
        }

        //cartas
        public ActionResult searchLetter()
        {
            return View(new ClientModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult searchLetter(IFormCollection collection)
        {
            try
            {
                long parametro = (long.Parse(collection["Id"]));
                ViewData["DPI"] = parametro;
               

                //insertar carta 1
                if (LeerCartas.Leer(parametro, 1) != "error")
                {
                    string carta = LeerCartas.Leer(parametro, 1);

                    ViewData["Codificado_1"] = LZW.LZW.Desencolar(LZW.LZW.Codificar(carta));

                    ViewData["Decodificado_1"] = LZW.LZW.Decodificar(LZW.LZW.Codificar(carta));
                }
                else
                {
                    return RedirectToAction(nameof(Error));
                }

                //insertar carta 2
                if (LeerCartas.Leer(parametro, 2) != "error")
                {
                    string carta = LeerCartas.Leer(parametro, 2);

                    ViewData["Codificado_2"] = LZW.LZW.Desencolar(LZW.LZW.Codificar(carta));

                    ViewData["Decodificado_2"] = LZW.LZW.Decodificar(LZW.LZW.Codificar(carta));
                }
                //insertar carta 3
                if (LeerCartas.Leer(parametro, 3) != "error")
                {
                    string carta = LeerCartas.Leer(parametro, 3);

                    ViewData["Codificado_3"] = LZW.LZW.Desencolar(LZW.LZW.Codificar(carta));

                    ViewData["Decodificado_3"] = LZW.LZW.Decodificar(LZW.LZW.Codificar(carta));
                }
                //insertar carta 4
                if (LeerCartas.Leer(parametro, 4) != "error")
                {
                    string carta = LeerCartas.Leer(parametro, 4);

                    ViewData["Codificado_4"] = LZW.LZW.Desencolar(LZW.LZW.Codificar(carta));

                    ViewData["Decodificado_4"] = LZW.LZW.Decodificar(LZW.LZW.Codificar(carta));
                }

                



                return View();
            }
            catch
            {
                return RedirectToAction(nameof(Error));
            }
        }

        //cifrar conversaciones del "guasap"
        public ActionResult searchConv()
        {
            return View(new ClientModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult searchConv(IFormCollection collection)
        {
            try
            {
                long parametro = (long.Parse(collection["Id"]));
                string contrasena = (collection["FullName"]);

                ViewData["DPI"] = parametro;


                //insertar carta 1
                if (LeerConv.Leer(parametro, 1) != "error")
                {
                    string conv = LeerConv.Leer(parametro, 1);

                    ViewData["Codificado_1"] = Cipher.Transposition.Cifrar(conv, contrasena, '-');

                    ViewData["Decodificado_1"] = Cipher.Transposition.Decifrar(Cipher.Transposition.Cifrar(conv, contrasena, '-'), contrasena);
                }
                else
                {
                    return RedirectToAction(nameof(Error));
                }

                //insertar carta 2
                if (LeerConv.Leer(parametro, 2) != "error")
                {
                    string conv = LeerConv.Leer(parametro, 2);

                    ViewData["Codificado_2"] = Cipher.Transposition.Cifrar(conv, contrasena, '-');

                    ViewData["Decodificado_2"] = Cipher.Transposition.Decifrar(Cipher.Transposition.Cifrar(conv, contrasena, '-'), contrasena);
                }
                //insertar carta 3
                if (LeerConv.Leer(parametro, 3) != "error")
                {
                    string conv = LeerConv.Leer(parametro, 3);

                    ViewData["Codificado_3"] = Cipher.Transposition.Cifrar(conv, contrasena, '-');

                    ViewData["Decodificado_3"] = Cipher.Transposition.Decifrar(Cipher.Transposition.Cifrar(conv, contrasena, '-'), contrasena);
                }
                //insertar carta 4
                if (LeerConv.Leer(parametro, 4) != "error")
                {
                    string conv = LeerConv.Leer(parametro, 4);

                    ViewData["Codificado_4"] = Cipher.Transposition.Cifrar(conv, contrasena, '-');

                    ViewData["Decodificado_4"] = Cipher.Transposition.Decifrar(Cipher.Transposition.Cifrar(conv, contrasena, '-'), contrasena);
                }



                return View();
            }
            catch
            {
                return RedirectToAction(nameof(Error));
            }
        }



        //busqueda completa
        public ActionResult decoded()
        {
            return View(new ClientModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult decoded(IFormCollection collection)
        {
            try
            {
                long parametro = (int.Parse(collection["Id"]));


                return View(Data.Instance.miArbolAvlId.Buscar(Comparison.Comparison.CompararID(parametro)));
            }
            catch
            {
                return RedirectToAction(nameof(Error));
            }
        }

        public ActionResult CreateavlEmail()
        {
            return View(new ClientModel());
        }
        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateavlEmail(IFormCollection collection)
        {
            try
            {
                string valores = "";

                string parametro = (collection["FullName"]);

                ViewData["ResultadosBúsqueda"] = Data.Instance.miArbolAvlId.BuscarNombres2(Comparison.Comparison.CompararFullName(parametro), ref valores);

               
                return View();
            }
            catch
            {
                return RedirectToAction(nameof(Error));
            }
        }


        //busqueda por nombre

        public ActionResult Create3()
        {
            //formulario para búsqueda
            return View(new ClientModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create3(IFormCollection collection)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }

        //Mostrar error al cargar
        public ActionResult Error()
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ClientModel.SaveAVLMode(new ClientModel
                {
                    Id = long.Parse(collection["Id"]),
                    FullName = collection["FullName"],
                    Birthdate = collection["Birthdate"],
                    Address = collection["Address"],
                    Companies = collection["Companies"]
                    
                    
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Error));
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edicion()
        {
            return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edicion(IFormCollection collection)
        {
            long parametroId = (long.Parse(collection["Id"]));

            string addressModificar = collection["Address"];
            string birhtdateModificar = collection["Birthdate"];

            ClientModel clienteBuscar = new ClientModel();
            ClientModel clienteModificar = null;

            clienteBuscar.Id = parametroId;

            if (Data.Instance.miArbolAvlId.Buscar(clienteBuscar) != default)
            {
                clienteModificar = Data.Instance.miArbolAvlId.Buscar(clienteBuscar);
                clienteModificar.Address = addressModificar;
                clienteModificar.Birthdate = birhtdateModificar;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Error));
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            long parametroId = (long.Parse(collection["Id"]));
                ClientModel clienteEliminar = new ClientModel();
                clienteEliminar.Id = parametroId;

                if (Data.Instance.miArbolAvlId.Eliminar(clienteEliminar) != default)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Error));
                } 
        }


        //Cargar desde CSV 
        [HttpGet]
        public IActionResult Index(AVLtree<ClientModel> clients = null)
        {
            clients = clients == null ? new AVLtree<ClientModel>() : clients;
            return View(Data.Instance.miArbolAvlId);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            //cargar csv

            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }


            var clients = this.GetClientList(file.FileName);
            return Index(clients);
        }

        private AVLtree<ClientModel> GetClientList(string fileName)
        {
            AVLtree<ClientModel> client = new AVLtree<ClientModel>();

            //Leer CSV
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var clients = csv.GetRecord<ClientModel>();
                    Data.Instance.miArbolAvlId.Insert(clients);
                }
            }
            return client;

        }

    }
}
