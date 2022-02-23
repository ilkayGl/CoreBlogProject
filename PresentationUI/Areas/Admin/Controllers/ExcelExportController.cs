using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExcelExportController : Controller
    {

        /////////////// Blog ////////////////////

        [AllowAnonymous]
        public IActionResult ExportDynamicExelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Başlığı";
                worksheet.Cell(1, 2).Value = "Blog Yazarı";
                worksheet.Cell(1, 3).Value = "Blog Kategorisi";
                worksheet.Cell(1, 4).Value = "Blog Oluşturulma Tarihi";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogName;
                    worksheet.Cell(BlogRowCount, 2).Value = item.Writer;
                    worksheet.Cell(BlogRowCount, 3).Value = item.Category;
                    worksheet.Cell(BlogRowCount, 4).Value = item.BlogDate;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "WorkSheet.xlsx");
                }
            }
        }

        [AllowAnonymous]
        public List<BlogExcelDTO> BlogTitleList()
        {
            List<BlogExcelDTO> bm = new();
            using (var c = new Context())
            {
                bm = c.Blogs.Include(x => x.Writer).Include(y => y.Category).OrderByDescending(d => d.BlogCreateDate).Select(x => new BlogExcelDTO
                {
                    BlogName = x.BlogTitle,
                    Writer = x.Writer.WriterName,
                    Category = x.Category.CategoryName,
                    BlogDate = x.BlogCreateDate
                }).ToList();
            }
            return bm;
        }


        /////////////// Comment ////////////////////


        [AllowAnonymous]
        public IActionResult ExportDynamicExelCommentBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Yorumlar Listesi");
                worksheet.Cell(1, 1).Value = "Yorum Atan Kullanıcı";
                worksheet.Cell(1, 2).Value = "Yorum Tarihi";
                worksheet.Cell(1, 3).Value = "Blog Adı";
                worksheet.Cell(1, 4).Value = "Yorum İçeriği";

                int CommentRowCount = 2;
                foreach (var item in CommentBlogList())
                {
                    worksheet.Cell(CommentRowCount, 1).Value = item.CommentUser;
                    worksheet.Cell(CommentRowCount, 2).Value = item.CommentDate;
                    worksheet.Cell(CommentRowCount, 3).Value = item.BlogName;
                    worksheet.Cell(CommentRowCount, 4).Value = item.CommentContent;
                    CommentRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "WorkSheet.xlsx");
                }
            }
        }

        [AllowAnonymous]
        public List<CommentExcelDTO> CommentBlogList()
        {
            List<CommentExcelDTO> cm = new();
            using (var c = new Context())
            {
                cm = c.Comments.Include(x => x.Blog).OrderByDescending(d => d.CommentDate).Select(x => new CommentExcelDTO
                {
                    CommentUser = x.CommentUserName,
                    CommentDate = x.CommentDate,
                    BlogName = x.Blog.BlogTitle,
                    CommentContent = x.CommentContent,

                }).ToList();
            }
            return cm;
        }
    }
}
