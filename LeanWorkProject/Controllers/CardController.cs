using System;
using LeanWorkProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeanWorkProject.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Valid(Card card)
        {
            if(ModelState.IsValid)
            {
                card.Validate();
                return Ok(card);
            }

            return BadRequest();
        }
    }
}