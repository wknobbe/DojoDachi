using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoDachi.Models;

namespace DojoDachi.Controllers
{
    public class HomeController : Controller
    {
        public Dachi dachi = new Dachi();
        Random rand = new Random();
        public Dictionary<string, object> dict = new Dictionary<string, object>();
        public string message = "Welcome";
        [HttpGet("")]
        public IActionResult Index()
        {
            dict["Fullness"] = dachi.Fullness;
            dict["Happiness"] = dachi.Happiness;
            dict["Energy"] = dachi.Energy;
            dict["Meals"] = dachi.Meals;
            dict["message"] = (string)message;
            return View("Index", dict);
        }
        [HttpGet("feed")]
        public IActionResult Feed()
        {
            message = "";
            if (dachi.Meals > 0)
            {
                dachi.Meals--;
                int chance = rand.Next(4);
                int gain = rand.Next(5, 11);
                if (chance == 0)
                {
                    message += "DojoDachi did not want to eat!";
                }
                else
                {
                    message += "You feed your DojoDachi! Fullness: +";
                    string gainstring = gain.ToString();
                    message += gainstring;
                    message += ", Meals: -1";
                    dachi.Fullness += gain;
                    if (dachi.Winner() == true)
                    {
                        message = "You have won the game!";
                        dict["Fullness"] = dachi.Fullness;
                        dict["Happiness"] = dachi.Happiness;
                        dict["Energy"] = dachi.Energy;
                        dict["Meals"] = dachi.Meals;
                        dict["message"] = (string)message;
                        return View("Won", dict);
                    };
                }
            }
            else
            {
                message += "You do not have any meals to eat!";
            }
            dict["Fullness"] = dachi.Fullness;
            dict["Happiness"] = dachi.Happiness;
            dict["Energy"] = dachi.Energy;
            dict["Meals"] = dachi.Meals;
            dict["message"] = (string)message;
            return View("Index", dict);
        }
        [HttpGet("play")]
        public IActionResult Play()
        {
            message = "";
            dachi.Energy -= 5;
            if (dachi.Loser() == true)
            {
                message = "You have lost the game...";
                dict["Fullness"] = dachi.Fullness;
                dict["Happiness"] = dachi.Happiness;
                dict["Energy"] = dachi.Energy;
                dict["Meals"] = dachi.Meals;
                dict["message"] = (string)message;
                return View("Lost", dict);
            }
            else
            {
                int chance = rand.Next(4);
                int gain = rand.Next(5, 11);
                if (chance == 0)
                {
                    message += "DojoDachi did not want to play!";
                }
                else
                {
                    message += "You played with your DojoDachi! Happiness: +";
                    string gainstring = gain.ToString();
                    message += gainstring;
                    message += ", Energy: -5";
                    dachi.Happiness += gain;
                    if (dachi.Winner() == true)
                    {
                        message = "You have won the game!";
                        dict["Fullness"] = dachi.Fullness;
                        dict["Happiness"] = dachi.Happiness;
                        dict["Energy"] = dachi.Energy;
                        dict["Meals"] = dachi.Meals;
                        dict["message"] = (string)message;
                        return View("Won", dict);
                    };
                }
            }
            dict["Fullness"] = dachi.Fullness;
            dict["Happiness"] = dachi.Happiness;
            dict["Energy"] = dachi.Energy;
            dict["Meals"] = dachi.Meals;
            dict["message"] = (string)message;
            return View("Index", dict);
        }
        [HttpGet("work")]
        public IActionResult Work()
        {
            message = "";
            dachi.Energy -= 5;
            if (dachi.Loser() == true)
            {
                message = "You have lost the game...";
                dict["Fullness"] = dachi.Fullness;
                dict["Happiness"] = dachi.Happiness;
                dict["Energy"] = dachi.Energy;
                dict["Meals"] = dachi.Meals;
                dict["message"] = (string)message;
                return View("Lost", dict);
            }
            else
            {
                int gain = rand.Next(1, 4);
                message += "Your DojoDachi went to work! Meals: +";
                string gainstring = gain.ToString();
                message += gainstring;
                message += ", Energy: -5";
                dachi.Meals += gain;
            }
            dict["Fullness"] = dachi.Fullness;
            dict["Happiness"] = dachi.Happiness;
            dict["Energy"] = dachi.Energy;
            dict["Meals"] = dachi.Meals;
            dict["message"] = (string)message;
            return View("Index", dict);
        }
        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            message = "Your DojoDachi went to sleep. Energy: +15, Fullness: -5, Happiness: -5";
            dachi.Energy += 15;
            if (dachi.Winner() == true)
            {
                message = "You have won the game!";
                dict["Fullness"] = dachi.Fullness;
                dict["Happiness"] = dachi.Happiness;
                dict["Energy"] = dachi.Energy;
                dict["Meals"] = dachi.Meals;
                dict["message"] = (string)message;
                return View("Won", dict);
            }
            else
            {
                dachi.Fullness -= 5;
                dachi.Happiness -= 5;
                if (dachi.Loser() == true)
                {
                    message = "You have lost the game...";
                    dict["Fullness"] = dachi.Fullness;
                    dict["Happiness"] = dachi.Happiness;
                    dict["Energy"] = dachi.Energy;
                    dict["Meals"] = dachi.Meals;
                    dict["message"] = (string)message;
                    return View("Lost", dict);
                }
            }
            dict["Fullness"] = dachi.Fullness;
            dict["Happiness"] = dachi.Happiness;
            dict["Energy"] = dachi.Energy;
            dict["Meals"] = dachi.Meals;
            dict["message"] = (string)message;
            return View("Index", dict);
        }
        [HttpGet("reset")]
        public IActionResult Reset()
        {
            dachi.Fullness = 20;
            dachi.Happiness = 20;
            dachi.Energy = 50;
            dachi.Meals = 3;
            message = "Meet your new DojoDachi!";
            dict["Fullness"] = dachi.Fullness;
            dict["Happiness"] = dachi.Happiness;
            dict["Energy"] = dachi.Energy;
            dict["Meals"] = dachi.Meals;
            dict["message"] = (string)message;
            return View("Index", dict);
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
    }
}
