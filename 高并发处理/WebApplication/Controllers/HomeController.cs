using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 抢单接口
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GrabSingle(User user)
        {
            //使用后台任务
            //BackgroundJob.Enqueue(() => MqPublish.AddQueue(user));
            MqPublish.AddQueue(user);
            return Json(new { Status = "OK" });
        }


        /// <summary>
        /// 获取数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCount()
        {
            try
            {
                return Json(new { Count = DapperHelper.Query() });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
