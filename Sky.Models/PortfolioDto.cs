using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sky.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей Портфолио.
    /// </summary>
    [Table("Portfolio")]
    public class PortfolioDto {
        [Key, Column("ID", TypeName = "int")]
        public int Id { get; set; }

        [Column("TITLE", TypeName = "nvarchar(100)")]
        public string Title { get; set; }   // Наименование работы.

        [Column("IMAGE_PATH", TypeName = "nvarchar(500)")]
        public string Url { get; set; }   // Путь к изображению в папке. 

        [Column("COMMENT_TASK", TypeName = "nvarchar(500)")]
        public string CommentTask { get; set; } // Краткое описание работы.

        [Column("COMMENT_DETAILS", TypeName = "nvarchar(500)")]
        public string CommentDetails { get; set; }  // Подробное описание работы.

        [Column("ID_GROUP", TypeName = "int")]
        public int? GroupId { get; set; }    // Номер категории.

        [Column("CATEGORY_PROJECT", TypeName = "nvarchar(500)")]
        public string Category { get; set; }    // Категория работы.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public PortfolioDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}