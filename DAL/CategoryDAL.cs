﻿using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        BartersDBContext bartersDBContext = new BartersDBContext();


        public List<Category> GetAllCategories()
        {
            //select * from Users; 
            try
            {
                var Categories = bartersDBContext.Categories.ToList();
                return Categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Category GetCategoryById(int id)
        {
            //select * from Users; 
            try
            {
                Category category = bartersDBContext.Categories.SingleOrDefault(x => x.Id == id);
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateCategory(int id, Category category)
        {
            try
            {
                Category currentCategoryToUpdate = bartersDBContext.Categories.SingleOrDefault(x => x.Id == id);
                bartersDBContext.Entry(currentCategoryToUpdate).CurrentValues.SetValues(category);
                bartersDBContext.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool AddCategory(Category category)
        {
            try
            {

                bartersDBContext.Categories.Add(category);
                bartersDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool DeleteCategory(int id)
        {
            Category category = bartersDBContext.Categories.SingleOrDefault(x => x.Id == id);
            bartersDBContext.Categories.Remove(category);
            bartersDBContext.SaveChanges();
            return true;

        }
        public List<Category> GetCategoriesByUserId(int id)
        {
            var categories = bartersDBContext.CategoryUsers
                     .Where(x => x.UserId == id)
                     .Select(u=>u.Categoty)
                     .ToList();
            return categories;
        }


    }
}
