﻿namespace GWebsite.AbpZeroTemplate.Core.Authorization
{
    /// <summary>
    /// Defines string constants for application's permission names.
    /// <see cref="GWebsiteAuthorizationProvider"/> for permission definitions.
    /// </summary>
    public static class GWebsitePermissions
    {
        public const string Pages = "Pages";
        public const string Pages_Administration_GWebsite = "Pages.Administration.GWebsite";

        public const string Pages_Administration_MenuClient = "Pages.Administration.MenuClient";
        public const string Pages_Administration_MenuClient_Create = "Pages.Administration.MenuClient.Create";
        public const string Pages_Administration_MenuClient_Edit = "Pages.Administration.MenuClient.Edit";
        public const string Pages_Administration_MenuClient_Delete = "Pages.Administration.MenuClient.Delete";

        public const string Pages_Administration_DemoModel = "Pages.Administration.DemoModel";
        public const string Pages_Administration_DemoModel_Create = "Pages.Administration.DemoModel.Create";
        public const string Pages_Administration_DemoModel_Edit = "Pages.Administration.DemoModel.Edit";
        public const string Pages_Administration_DemoModel_Delete = "Pages.Administration.DemoModel.Delete";

        public const string Pages_Administration_Customer = "Pages.Administration.Customer";
        public const string Pages_Administration_Customer_Create = "Pages.Administration.Customer.Create";
        public const string Pages_Administration_Customer_Edit = "Pages.Administration.Customer.Edit";
        public const string Pages_Administration_Customer_Delete = "Pages.Administration.Customer.Delete";

        public const string Pages_Administration_CustomUser = "Pages.Administration.CustomUser";
        public const string Pages_Administration_CustomUser_Create = "Pages.Administration.CustomUser.Create";
        public const string Pages_Administration_CustomUser_Edit = "Pages.Administration.CustomUser.Edit";
        public const string Pages_Administration_CustomUser_Delete = "Pages.Administration.CustomUser.Delete";
    }
}