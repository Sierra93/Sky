using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sky.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей описаний работ.
    /// </summary>
    [Table("PortfolioDetails")]
    public class PortfolioDetailsDto {
        [Key, Column("ID", TypeName = "int")]
        public int Id { get; set; }

        [Column("TITLE", TypeName = "nvarchar(100)")]
        public string Title { get; set; }   // Заголовок.

        [Column("IMAGE_PATH", TypeName = "nvarchar(500)")]
        public string Url { get; set; } // Путь к изображению.

        [Column("ID_GROUP", TypeName = "int")]
        public int GroupId { get; set; }    // Id группы, к которой относится работа.

        [Column("DETAILS_TASK", TypeName = "nvarchar(500)")]
        public string DetailsTask { get; set; } // Детальное описание работы.

        [Column("IS_CURRENT_FLAG", TypeName = "int")]
        public int IsCurrentFlag { get; set; }  // Актуальность.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public PortfolioDetailsDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
