using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Product238.Models
{
    public class Product
    {
        int id;
        string pName;
        string pType;
        double pPrice;
        string imgCover;

        //Propeties
        [Required(ErrorMessage = "ID không được trống")]
        [Display(Name = "ID")]
        public int Id { get => id; set => id = value; }
        // Kiểm tra ràng buộc cho tiêu đề : không trống và dài <= 250
        [Required(ErrorMessage = "Tên sản phẩm không được trống")]
        [StringLength(250, ErrorMessage = "Tên sản phẩm không quá 250 ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string PName { get => pName; set => pName = value;}
        [Required(ErrorMessage = "Thể loại không được trống")]
        [Display(Name = "Thể loại")]
        public string PType { get => pType; set => pType = value;}

        [Required(ErrorMessage = "Giá bán phải lớn hơn 0")]
        [Display(Name = "Giá bán")]
        public double PPrice { get => pPrice; set => pPrice = value;}
        [Display(Name = "Hình ảnh")]
        public string ImgCover { get => imgCover; set => imgCover = value;}    

        //Constructors
        public Product() { }
        public Product(int id, string pName, string pType, double pPrice, string imgCover)
        {
            this.id = id;
            this.pName = pName;
            this.pType = pType;
            this.pPrice = pPrice;
            this.imgCover = imgCover;
        }
    }
}