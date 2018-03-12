﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movies = new List<Movie>()
        {
            new Movie {Id = 1,Name = "Shrek" },
            new Movie {Id= 2, Name ="Wall-e" }
        };


        //movies
        public ActionResult Index()
        {
            return View(movies);

        }

        
    }
}