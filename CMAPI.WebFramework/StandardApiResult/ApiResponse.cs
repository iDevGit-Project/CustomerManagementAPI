using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMAPI.WebFramework.StandardApiResult
{
    public class ApiResponse
    {
        public bool flag { get; set; }
        public string Message { get; set; }
        public ApiResultStatusCode StatusCode { get; set; }
    }

    public class ApiResponse<Date> : ApiResponse
    {
        public Date Data { get; set; }
    }


    public enum ApiResultStatusCode
    {
        [Display(Name = "دریافت اطلاعات از سرور با موفقیت انجام شد.")]
        Success = 200,
        [Display(Name = "دریافت اطلاعات از سرور با خطا مواجه شد.")]
        ServerError = 500,
        [Display(Name = "پارامترهای ارسالی از سمت سرور معتبر نمی باشد.")]
        BadRequest = 400,
        [Display(Name = "متأسفم. چنین اطلاعاتی از سمت سرور دریافت نشد.")]
        NotFound = 404,
        [Display(Name = "داده های ارسال شده به سمت سرور تکراری می باشد.")]
        DuplicateInformation = 550,
        [Display(Name = "خطای تاریخ")]
        DateTimeError = 515,
        [Display(Name = "متأسفم. پارامترهای دریافتی جهت نمایش لیست داده ها خالی است.")]
        ListEmpty = 590,
        [Display(Name = "متأسفم. اطلاعات چنین کاربری در سامانه موجود نمی باشد.")]
        UserMistake = 290
    }
}
