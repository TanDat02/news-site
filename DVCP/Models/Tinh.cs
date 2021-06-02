using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVCP.Models
{
    [Table("Dm_Tinh")]
    public class Tinh
    {
        [Key]
        public int tinhId { get; set; }


        [DisplayName("Mã Tỉnh")]
        public int maTinh { get; set; }

        [DisplayName("Tên Tỉnh")]
        public string tenTinh { get; set; }
        [DisplayName("Phân Loại")]
        public int phanLoai { get; set; }
        [DisplayName("Thứ Tự Sắp Xếp")]
        public int thuTuSapXep { get; set; }

        [DisplayName("Dân Số")]
        public int danSo { get; set; }
        [DisplayName("Diện Tích")]
        public int dienTich { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Chỉnh Sửa")]
        public DateTime? ngayChinhSua { get; set; }

    }
}

