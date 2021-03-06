﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        private LoginContext _context;
        public HomeController(LoginContext context){
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Login")]
        public IActionResult Login()
        {
            List<Users> AllUsers = _context.Users.ToList();
            return View("Login");
        }
        [HttpPost("Create")]
        public IActionResult Create(Users user){
            if(ModelState.IsValid){
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                user.Password = Hasher.HashPassword(user, user.Password);
                Users TempUser = new Users
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    ConfirmPassword = "This Is Not the Pass Word",
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };
                _context.Add(TempUser);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost("GetUser")]
        public IActionResult GetUser(Users log)
        {
            //grab user with email
            Users loginUser = _context.Users.SingleOrDefault(user => user.Email == log.Email);
            if(loginUser != null)
            {
                //compare passwords
                var Hasher = new PasswordHasher<Users>();
                var result = Hasher.VerifyHashedPassword(log, loginUser.Password, log.Password);
                if(result > 0)
                {
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }
        [HttpGet("Dashboard")]
        public IActionResult Dashboard(){
            return View("Dashboard");
        }

        
    }
}
