using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuoc
{
    /*{
    "accountNo": 113366668888,
    "accountName": "QUY VAC XIN PHONG CHONG COVID",
    "acqId": 970415,
    "amount": 79000,
    "addInfo": "Ung Ho Quy Vac Xin",
    "format": "text",
    "template": "compact"
    }*/
    public class ApiRequest
    {
        public string accountNo { get; set; } // Số tài khoản (dạng chuỗi)
        public string accountName { get; set; }
        public int acqId { get; set; }
        public int amount { get; set; }
        public string addInfo { get; set; }
        public string format { get; set; }
        public string template { get; set; }
    }
    /*
     {
        "code": "00",
        "desc": "Gen VietQR successful!",
        "data": {
        "acpId": 970415,
        "accountName": "QUY VAC XIN PHONG CHONG COVID 19",
        "qrCode": "00020101021238560010A0000007270126000697041501121133666688880208QRIBFTTA53037045405790005802VN62220818Ung Ho Quy Vac Xin63043ACF",
        "qrDataURL": "data:image/png;base64,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"
       }
    }
     */
    public class Data
    {
        public int acpId { get; set; }
        public string accountName { get; set; }
        public string qrCode { get; set; }
        public string qrDataURL { get; set; }
    }

    public class ApiResponse
    {
        public string code { get; set; }
        public string desc { get; set; }
        public Data data { get; set; }
    }
}
