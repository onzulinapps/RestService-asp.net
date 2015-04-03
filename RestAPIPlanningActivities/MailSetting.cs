using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Configuration;

namespace RestAPIPlanningActivities
{
    public class MailSetting
    {
        private void ProtegerMailSettings()
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SmtpSection configSection = config.GetSection("system.net/mailSettings/smtp") as SmtpSection;

            if (!configSection.SectionInformation.IsProtected)
            {
                //configSection.SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
                configSection.SectionInformation.ProtectSection("MailProtectedProvider");

                config.Save();
            }

        }

        private void DesprotegerMailSettings()
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SmtpSection configSection = config.GetSection("system.net/mailSettings/smtp") as SmtpSection;

            if (configSection.SectionInformation.IsProtected)
            {
                configSection.SectionInformation.UnprotectSection();
                config.Save();
            }

        }
    }
}