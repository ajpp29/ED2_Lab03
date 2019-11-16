using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaboratorioAPIs.Repository;

namespace LaboratorioAPIs.Controllers
{
    public class JWTController : Controller
    {
       
        [HttpGet]
        public ActionResult IndexJWT(string TOKEN)
        {
            if (TOKEN!= null)
            {
                if (TOKEN.Contains("$token$"))
                {
                    ViewBag.Token = TOKEN.Substring(0,TOKEN.Length-7);
                }
                else
                {
                    ViewBag.EstatusDeSubida = TOKEN;
                }
            }
            
            
            return View();
        }  

        [HttpPost]
        public ActionResult IndexJWT(IFormFile Archivo, string Key)
        {
                if (Archivo.FileName.Contains(".json"))
                {
                    if (Key.Length >= 16)
                    {
                        LJWT logicaJWT = new LJWT();
                        var token = logicaJWT.GenerarJWT(Archivo, Key).Result;
                        return IndexJWT(token + "$token$");
                    }
                    else
                    {
                        return IndexJWT("Key Mínima 16 caracteres");
                    }
                    
                }
                else
                {
                    return IndexJWT("Formato inválido");  
                }
        }
     }  
        


    }