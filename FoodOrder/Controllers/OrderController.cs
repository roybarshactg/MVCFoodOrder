using DataAcceessLibrary.BussinessLogic;
using FoodOrder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Create()
        {
            try
            {
                var food = FoodClass.LoadFood();

                OrderModel model = new OrderModel();

                food.ForEach(x =>
                {
                    model.foodItem.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.FoodName });
                });

                return View(model);
            }
            catch (Exception) 
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderModel model)
        {
            if (ModelState.IsValid) 
            {
                var food = FoodClass.LoadFood();

                model.Total = model.Quantity * food.Where(x => x.Id == model.FoodId).First().FoodPrice;

               int id = OrderClass.InsertOrder(model.PersonName, model.PersonAddress, model.FoodId,
                    model.Quantity, model.Total);

                return RedirectToAction("Details", new { id });
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            try
            {
                var data = OrderClass.LoadOrder();

                var val = data.Where(x => x.Id == id).FirstOrDefault();

                OrderModel order = new OrderModel
                {
                    Id = val.Id,
                    PersonName = val.PersonName,
                    PersonAddress = val.PersonAddress,
                    FoodId = val.FoodId,
                    Quantity = val.Quantity,
                    Total = val.Total
                };
                return View(order);
            }
            catch(Exception) 
            {
                return View();
            }
        }

        public IActionResult Edit(int id) 
        {
            try
            {
                var data = OrderClass.LoadOrder();

                var val = data.Where(x => x.Id == id).FirstOrDefault();

                OrderModel order = new OrderModel
                {
                    Id = val.Id,
                    PersonName = val.PersonName,
                    PersonAddress = val.PersonAddress,
                    FoodId = val.FoodId,
                    Quantity = val.Quantity,
                    Total = val.Total
                };

                return View(order);
            }
            catch (Exception) 
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderModel model)
        {
            var food = FoodClass.LoadFood();

            model.Total = model.Quantity * food.Where(x => x.Id == model.FoodId).First().FoodPrice;

            OrderClass.UpdateOrder(model.Id,
                                   model.PersonName,
                                   model.PersonAddress,
                                   model.FoodId,
                                   model.Quantity,
                                   model.Total);

            return RedirectToAction("Details", new { model.Id });
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var data = OrderClass.LoadOrder();

                var val = data.Where(x => x.Id == id).FirstOrDefault();

                OrderModel order = new OrderModel
                {
                    Id = val.Id,
                    PersonName = val.PersonName,
                    PersonAddress = val.PersonAddress,
                    FoodId = val.FoodId,
                    Quantity = val.Quantity,
                    Total = val.Total
                };

                return View(order);
            }
            catch (Exception) 
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrderModel model)
        {
            OrderClass.DeleteOrder(model.Id);

            return RedirectToAction("Create");
        }

        public IActionResult Display()
        {
            try
            {
                var data = FoodClass.LoadFood();

                List<FoodModel> food = new List<FoodModel>();

                foreach (var row in data)
                {
                    food.Add(new FoodModel
                    {
                        Id = row.Id,
                        FoodName = row.FoodName,
                        FoodPrice = row.FoodPrice
                    });
                }

                return View(food);
            }
            catch (Exception) 
            {
                return View();
            }
        }
    }
}
