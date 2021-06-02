using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVCP.Models
{
    [Table("Dm_Xa")]
    public class Xa
    {
        [Key]
        [DisplayName("ID")]
        public int xaId { get; set; }

        [DisplayName("Huyện ID")]
        public int? huyenId { get; set; }

        [DisplayName("Mã Huyện")]
        public int maHuyen { get; set; }

        [DisplayName("Mã Xã")]
        public int maXa { get; set; }
        [DisplayName("Tên Xã")]
        public string tenXa { get; set; }


        [DisplayName("Phân Loại")]
        public int? phanLoai { get; set; }
        [DisplayName("Thứ Tự Sắp Xếp")]
        public int? thuTuSapXep { get; set; }
        //[DisplayName("U ID")]
        //public int? uid { get; set; }
        [DisplayName("O ID")]
        public int? oid { get; set; }

        [DisplayName("Người Sửa ID")]
        public int? nguoiSuaId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày Chỉnh Sửa")]
        public DateTime? ngayChinhSua { get; set; }
        [DisplayName("Trạng Thái")]
        public Boolean trangThai { get; set; }
        [DisplayName("Đơn Vị Chỉnh Sửa")]
        public int? donViChinhSua { get; set; }
        public object Huyen { get; internal set; }
    }
}

