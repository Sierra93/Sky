using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sky.Models {
    /// <summary>
    /// Класс сопоставляется в таблицей услуг.
    /// </summary>
    [Table("OrdersDetails")]
    public class OrderDetailDto {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("order_name")]
        public string OrderName { get; set; }   // Наименование услуги.

        [Column("order_details")]
        public string OrderDetails { get; set; }    // Детальное описание услуги.

        public List<MultepleContextTable> MultepleContextTables { get; set; }

        public OrderDetailDto() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
