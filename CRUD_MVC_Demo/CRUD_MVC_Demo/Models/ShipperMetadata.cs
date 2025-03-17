using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC_Demo.Models
{
    public class ShipperMetadata
    {
        [Required(ErrorMessage = "公司名稱為必填")]
        [StringLength(50, ErrorMessage = "公司名稱最多50個字元")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "聯絡電話為必填")]
        [Phone(ErrorMessage = "請輸入有效的電話號碼")]
        [StringLength(24, ErrorMessage = "聯絡電話最多24個字元")]
        public string? Phone { get; set; }
    }

    [MetadataType(typeof(ShipperMetadata))]
    public partial class Shipper
    {
    }
}