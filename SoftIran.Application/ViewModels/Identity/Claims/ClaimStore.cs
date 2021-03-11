using System.Collections.Generic;
using System.Security.Claims;

namespace SoftIran.Application.ViewModels.Identity.Claims
{
    public class ClaimStore
    {
        public static ClaimModel FullAccess = new ClaimModel
        {
            Name = "FullAccess",
            DisplayName = "دسترسی کامل",
            Description = "دسترسی کامل، دسترسی به حذف و افزودن کاربر، اعطای دسترسی به کاربراان"
        };

        public static ClaimModel MiddleAccess = new ClaimModel
        {
            Name = "ExternalFullAccess",
            DisplayName = "برون سازمانی",
            Description = "دسترسی کامل برون سازمانی، دیدن نامه های وارده و صادره، ایجاد مخاطب برون سازمانی"
        };

        public static ClaimModel BaseAccess = new ClaimModel
        {
            Name = "BaseAccess",
            DisplayName = "دسترسی پایه",
            Description = "دسترسی های پایه مانند دسترسی به مدیریت فایل، پروفایل کاربری و کارتابل درون سازمانی"
        };

        public static List<ClaimModel> AllClaimsTypes()
        {
            return new List<ClaimModel>
            {
                FullAccess, MiddleAccess , BaseAccess
            };
        }

        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim(FullAccess.Name, true.ToString()),
            new Claim(MiddleAccess.Name, true.ToString()),
            new Claim(BaseAccess.Name, true.ToString()),
        };
    }
}