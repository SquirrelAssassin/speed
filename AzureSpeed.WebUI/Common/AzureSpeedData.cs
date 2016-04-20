namespace AzureSpeed.WebUI
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Hosting;
    using System.Web.Script.Serialization;

    public static class AzureSpeedData
    {
        private static IEnumerable<AzureSpeedStorageAccount> accounts;

        private static Dictionary<string, string> regionNames;

        public static IEnumerable<AzureSpeedStorageAccount> Accounts
        {
            get
            {
                if (accounts == null)
                {
                    var serializer = new JavaScriptSerializer();
                    string filePath = Path.Combine(HostingEnvironment.MapPath("~/App_Data/"), "setting.json");

                    var text = File.ReadAllText(filePath);
                    var setting = serializer.Deserialize<Setting>(text);
                    accounts = setting.Accounts;
                }

                return accounts;
            }
        }

        public static Dictionary<string, string> RegionNames
        {
            get
            {
                if (regionNames == null)
                {
                    // The list is from ip file xml file.
                    // Needs to be update when new data center opens.
                    regionNames = new Dictionary<string, string>();

                    // Azure
                    regionNames.Add("europewest", "Azure - West Europe");
                    regionNames.Add("useast", "Azure - East US");
                    regionNames.Add("useast2", "Azure - East US 2");
                    regionNames.Add("uswest", "Azure - West US");
                    regionNames.Add("usnorth", "Azure - North Central US");
                    regionNames.Add("europenorth", "Azure - North Europe");
                    regionNames.Add("uscentral", "Azure - Central US");
                    regionNames.Add("asiaeast", "Azure - East Asia");
                    regionNames.Add("asiasoutheast", "Azure - Southeast Asia");
                    regionNames.Add("ussouth", "Azure - SouthCentral US");
                    regionNames.Add("japanwest", "Azure - Japan West");
                    regionNames.Add("japaneast", "Azure - Japan East");
                    regionNames.Add("brazilsouth", "Azure - Brazil South");
                    regionNames.Add("australiaeast", "Azure - Australia East");
                    regionNames.Add("australiasoutheast", "Azure - Australia Southeast");
                    regionNames.Add("chinanorth", "Azure - China North");
                    regionNames.Add("chinaeast", "Azure - China East");
                    regionNames.Add("indiacentral", "Azure - India Central");
                    regionNames.Add("indiawest", "Azure - India West");
                    regionNames.Add("indiasouth", "Azure - India South");

                }
                return regionNames;
            }
        }
    }
}