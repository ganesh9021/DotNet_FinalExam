using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ExamMVCApp.Models;

namespace ExamMVCApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Exam;Integrated Security=True";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectAllProducts";
            List<Product> list = new List<Product>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Product prod = new Product();
                    prod.ProductId = (int)dr["ProductId"];
                    prod.Rate = (decimal)dr["Rate"];
                    prod.CategoryName = dr["CategoryName"].ToString();
                    prod.Description = dr["Description"].ToString();
                    prod.ProductName = dr["ProductName"].ToString();
                    list.Add(prod);
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Exam;Integrated Security=True";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DetailsOfProduct";
            Product product = new Product();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                product.ProductName = dr["ProductName"].ToString();
                product.Rate = (decimal)dr["Rate"];
                product.Description = dr["Description"].ToString();
                product.CategoryName = dr["CategoryName"].ToString();
                dr.Close();
                conn.Close();
                return View(product);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
                return View();
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Exam;Integrated Security=True";
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AddNewProduct";
                cmd.Parameters.AddWithValue("ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Rate", product.Rate);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@CategoryName", product.CategoryName);
                cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Exam;Integrated Security=True";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "";
            Product product = new Product();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                product.ProductName = dr["ProductName"].ToString();
                product.Rate = (decimal)dr["Rate"];
                product.Description = dr["Description"].ToString();
                product.CategoryName = dr["CategoryName"].ToString();
                dr.Close();
                conn.Close();
                return View(product);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
                return View();
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public PartialViewResult Info()
        {
            return PartialView();
        }
    }
}
