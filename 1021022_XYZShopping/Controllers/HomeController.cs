using _1021022_XYZShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1021022_XYZShopping.Controllers
{
    
        public class HomeController : Controller
        {
            // GET: Home
            public ActionResult Index()
            {
                return View();
            }
            public ActionResult Display()
            {
                return View();
            }

            public ActionResult Menu()
            {
                return View();
            }

            public ActionResult Login()
            {
                if ((string)Session["USERNAME"] == null)
                {
                    return View();
                }
                else
                {
                    ShoppingCartModel model = new ShoppingCartModel();
                    model.Email_Id = (string)Session["USERNAME"];
                    return View("Success", model);
                }

            }
            public ActionResult Success()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Login(ShoppingCartModel cartModel)
            {
                string UserID = cartModel.checkUser(cartModel.Email_Id, cartModel.password);
                if (!(UserID == null))
                {
                    Session["USERNAME"] = cartModel.Email_Id;
                    Session["USERID"] = UserID;
                    return View("Success", cartModel);
                }
                return View();
            }
            public ActionResult MyProfile(ShoppingCartModel model)
            {
                List<ProfileDataModel> prof = model.getCustomerDetails((string)Session["USERID"]);
                if (!prof.Any())
                {
                    ViewBag.Message = "Please Login to see your Profile";
                }
                return View(prof);
            }

            public ActionResult OrderDetails()
            {
                if ((string)Session["USERNAME"] == null)
                {
                    ViewBag.Message = "Please Login to access your Details!!!";
                }


                return View();
            }
            [HttpPost]
            public JsonResult OrderDetails(ShoppingCartModel model)
            {
                try
                {
                    if (Session["USERNAME"].ToString() == null)
                    {
                        return null;
                    }
                    else
                    {
                        List<OrderDetailsModel> orderDetails = model.getOrderDetails();
                        return Json(new { Result = "OK", Records = orderDetails }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "OK", Message = ex.Message });
                }
            }
            public ActionResult Products()
            {
                return View();
            }
            [HttpPost]
            public JsonResult Products(ShoppingCartModel model)
            {
                try
                {

                    List<ProductsModel> products = model.getProducts();
                    return Json(new { Result = "OK", Records = products }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    return Json(new { Result = "OK", Message = ex.Message });
                }
            }
            public ActionResult Feedback()
            {
                if ((string)Session["USERNAME"] == null)
                {
                    ViewBag.Message = "Please Login to send feedback!";
                }
                return View();
            }
            [HttpPost]
            public ActionResult Feedback(ShoppingCartModel model)
            {
                if (!((string)Session["USERNAME"] == null))
                {
                    if (model.updateFeedback((string)Session["USERID"], model.feedback))
                    {
                        ModelState.Clear();
                        ViewBag.Message = "FeedBack Received! Thank You for your time!! :)";
                    }
                }
                else
                {
                    ViewBag.Message = "Please login to send feedback!!";
                }
                return View();
            }
        }
    }
