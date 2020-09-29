using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sky.Models {
    /// <summary>
    /// Класс сопоставляется с таблицей заявок.
    /// </summary>
    [Table("REQUEST")]
    public class RequestDto {
        [Key, Column("ID")]
        public int Id { get; set; }

        [Column("CLIENT_NAME", TypeName = "nvarchar(100)")]
        public string Name { get; set; }    // Имя клиента.

        [Column("EMAIL_OR_NUMBER", TypeName = "nvarchar(200)")]
        public string EmailOrNumber { get; set; } // Телеон или email клиента.

        [Column("COMMENT_REQUEST", TypeName = "nvarchar(max)")]
        public string Comment { get; set; } // Комментарий к заявке.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public RequestDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
