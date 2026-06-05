using Mahla_Blog.CoreLayer.DTOs.Categories;
using Mahla_Blog.CoreLayer.Mappers;
using Mahla_Blog.CoreLayer.Utilities;
using Mahla_Blog_DataLayer.Context;
using Mahla_Blog_DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;


namespace Mahla_Blog.CoreLayer.Services.Categories
{
    public class CategoryServise : ICategoryService
    {
        readonly BlogContext _context;
        public CategoryServise(BlogContext context)
        {
            _context = context;
        }

        public bool IsExists(string slug)
        {
            var result = _context.Categories.Any(s => s.Slug == slug);
            if (!result)
                return true;
            return false;
        }

        OperationResult ICategoryService.CreateCategory(CreateCategoryDto command)
        {
            var category = new Category()
            {
                Title = command.Title,
                Slug = command.Slug,
                MetaDescription = command.MetaDescription,
                MetaTag = command.MetaTag,
                ParentId = command.ParentId,
                IsDeleted = false

            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return OperationResult.Success();

        }

        OperationResult ICategoryService.EditCategory(EditCategoryDto command)
        {
            var Categury = _context.Categories.FirstOrDefault(c => c.Id == command.Id);
            if (Categury == null)
                return OperationResult.NotFound();
            Categury.Id = command.Id;
            Categury.Slug = command.Slug.ToSlug();
            Categury.Title = command.Title;
            Categury.MetaDescription = command.MetaDescription;
            Categury.MetaTag = command.MetaTag;

            _context.SaveChanges();
            return OperationResult.Success();
        }

        List<CategoriesDto> ICategoryService.GetAllCategories()
        {
            return _context.Categories.Select(Category => Mapper.MapperCategury(Category)).ToList();
        }

        CategoriesDto ICategoryService.GetCategoryBy(int id)
        {
            var category = _context.Categories.FirstOrDefault(Category => Category.Id == id);
            if (category == null)
                return null;
            return Mapper.MapperCategury(category);
        }



        CategoriesDto ICategoryService.GetCategoryBy(string slug)
        {
            var category = _context.Categories.FirstOrDefault(Category => Category.Slug == slug);
            if (category == null)
                return null;
            return Mapper.MapperCategury(category);
        }
    }
}
