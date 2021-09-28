using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.IU.SettingClass
{
    public class ReadBaseUrlSettings
    {

        #region Dependency Description

        private readonly IOptions<BaseUrlSettings> baseUrlSettings;

        public ReadBaseUrlSettings(


            IOptions<BaseUrlSettings> _baseUrlSettings

        )
        {

            baseUrlSettings = _baseUrlSettings;
        }

        #endregion
        public String ApiUrl
        {
            get
            {
                string apiiUrl = baseUrlSettings.Value.ApiUrl;

                var response = String.IsNullOrEmpty(ApiUrl) ? "https://localhost:44303/api/" : apiiUrl;
                return response;
            }

        }
        



    }
}
