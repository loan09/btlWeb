using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebBanSach.Models
{
    [MetadataTypeAttribute(typeof(TAIKHOANADMINMetadata))]
    public partial class TK_KHACHHANG
    {
        internal sealed class TAIKHOANADMINMetadata
        {
            //public int ID_ADMIN { get; set; }
            //[Display(Name = "Số Điện Thoại")]
            //[Required(ErrorMessage = "Vui lòng nhập giá trị cho trường này")]
            //public string SDT_ADMIN { get; set; }
            //[Display(Name = "Mật Khẩu")]
            //public string MATKHAU { get; set; }

            public int ID_KHACHHANG { get; set; }
            [Display(Name = "Số Điện Thoại")]
            [Required(ErrorMessage = "Vui lòng nhập giá trị cho trường này")]
            public string SDT_KH { get; set; }
            [Display(Name = "Mật Khẩu")]
            public string MATKHAU_KH { get; set; }
        }
    }
}