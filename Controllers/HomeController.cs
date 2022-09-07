using CrudCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using CrudCore.Myclass;
using System.Data;


namespace CrudCore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

       // public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private ConeccionDB coneccionDB= new ConeccionDB();
        public IActionResult Index()
        {
            if (ChkLogin() == true)
            {
                return View();  
            }
            else
            {
                return View("Login");
            }
                
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login() 
        {
            return View();
        }
        public IActionResult InsertInfouserView()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            DataTable dt = coneccionDB.GetData($"SELECT U.codigo_usuario, U.descripcion_usuario, U.estado_usuario, C.codigo_clave, C.codigo_usr , C.descripcion_clave, C.estado_clave " +
                $"FROM empreadmin.usr_usuario U " +
                $"INNER JOIN empreadmin.usr_clave C " +
                $"ON C.codigo_usr = U.codigo_usuario " +
                $"WHERE  U.descripcion_usuario = '{username}';");
       // DataTable dt = coneccionDB.GetData($"SELECT * FROM Tbl_Usuarios WHERE username = '{username}';");
            if (dt.Rows.Count > 0)
            {
                //if (dt.Rows[0]["password"].ToString()==EncodeString.MD5HashCrytography(password))
                if (dt.Rows[0]["descripcion_clave"].ToString() == EncodeString.MD5HashCrytography(password))
                {
                   
                    HttpContext.Session.SetString("Login", "1");
                    return View("Index");
                }
            }



            return View();
         
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ChkLogin()
        {
            bool result = false;    

            if (HttpContext.Session.GetString("Login") !=null )
                {
                if (HttpContext.Session.GetString("Login") == "1")
                    {
                        result = true;  
                    }
                }
            return result;
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult UserView() 
        {
            DataTable dt = coneccionDB.GetData($"SELECT * FROM empreadmin.tbl_usuarios;");
            
            return View(dt);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usr_id"></param>
        /// <returns></returns>
        public IActionResult UserSearch(string usr_id)
        {
            DataTable dt = coneccionDB.GetData($"SELECT * FROM empreadmin.tbl_usuarios WHERE user_id ='{usr_id}';");

            return View(dt);

        }
    }
}