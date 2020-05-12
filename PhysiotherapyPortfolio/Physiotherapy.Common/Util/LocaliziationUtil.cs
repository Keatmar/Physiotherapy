using System.Collections.Generic;
using System.Globalization;
using System.Linq;



namespace Physiotherapy.Common
{
    public class LocalizationUtil
    {
        //........................................................................
        public static string DefaultCulture;
        public static string DefaultCultureBasic = null;
        static public Dictionary<string, string> CulturesDict = new Dictionary<string, string>()
                                { { "el-GR", "Ελληνικά" }, { "en-US", "English" } };
  
        public const string GreekCulture = "el-GR";
        public const string EnglCulture = "en-GB";
        //........................................................................

        public static string DefaultCountry;
        static public Dictionary<string, string> CountriesDict;

        static public string[] GreekCountries = new string[] { "GR", "CY" }; // Greece , Cyprus
        static public string[] GreekCultures = new string[] { "el-GR", "el-CY" }; // Greece , Cyprus
        public const string GreekCountry = "GR";
        public const string EnglCountry = "GB";
        //........................................................................
        public static string DefaultCurrencySymbolCode;
        public static string DefaultCurrencySymbol;
        static public Dictionary<string, string> CurrenciesDict;

        public static void Init(string defaultCulture,
                                string defaultCountry,
                                string defaultCurrencySymbolCode,
                                string defaultCurrencySymbol)
        {
            DefaultCulture = defaultCulture;
            DefaultCountry = defaultCountry;
            DefaultCurrencySymbolCode = defaultCurrencySymbolCode;
            DefaultCurrencySymbol = defaultCurrencySymbol;

            DefaultCultureBasic = GetCultureBasic(DefaultCulture);
            CountriesDict = GetCountriesDict();
            CurrenciesDict = GetCurrenciesDict();

            CultureInfo cid = CultureInfo.GetCultureInfo(defaultCulture);
            CultureInfo.DefaultThreadCurrentCulture = cid;
            CultureInfo.DefaultThreadCurrentUICulture = cid;
        }

        private static Dictionary<string, string> GetCountriesDict()
        {
            Dictionary<string, string> countriesDict = new Dictionary<string, string>();
            try
            {
                Dictionary<string, string> cultureDict = new Dictionary<string, string>();

                //create an array of CultureInfo to hold all the cultures found, these include the users local cluture, and all the
                //cultures installed with the .Net Framework
                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

                foreach (CultureInfo culture in cultures)
                {
                    //pass the current culture's Locale ID (http://msdn.microsoft.com/en-us/library/0h88fahh.aspx)
                    //to the RegionInfo contructor to gain access to the information for that culture
                    RegionInfo region = new RegionInfo(culture.LCID);

                    //make sure out generic list doesnt already
                    //contain this country
                    if (!(cultureDict.Keys.Contains(region.TwoLetterISORegionName)) && !(culture.Name.EndsWith("GB") && culture.Name != "en-GB"))
                        //not there so add the EnglishName (http://msdn.microsoft.com/en-us/library/system.globalization.regioninfo.englishname.aspx)
                        //value to our generic list
                        cultureDict.Add(region.TwoLetterISORegionName, region.EnglishName + " - " + region.NativeName);
                }
                //Προσθήκη Κύπρου (.ΝΕΤ δεν έχει κολτούρα για κύπρο διότι η μιση είναι τούρκικη και η άλλη ελληνικη)!!!			
                cultureDict.Add("CY", "Cyprus - Κύπρος");
                cultureDict.Add("MH", "Marshall Islands - Marshall Islands");

                IEnumerable<KeyValuePair<string, string>> sortedDict = from entry in cultureDict orderby entry.Value ascending select entry;

                foreach (KeyValuePair<string, string> item in sortedDict)
                    countriesDict.Add(item.Key, item.Value);

            }
            catch //(Exception)
            {

            }
            return countriesDict;
        }

        private static Dictionary<string, string> GetCurrenciesDict()
        {
            Dictionary<string, string> currencyDict = new Dictionary<string, string>();

            try
            {
                Dictionary<string, string> cultureDict = new Dictionary<string, string>();

                //create an array of CultureInfo to hold all the cultures found, these include the users local cluture, and all the
                //cultures installed with the .Net Framework
                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

                foreach (CultureInfo culture in cultures)
                {
                    //pass the current culture's Locale ID (http://msdn.microsoft.com/en-us/library/0h88fahh.aspx)
                    //to the RegionInfo contructor to gain access to the information for that culture
                    RegionInfo region = new RegionInfo(culture.LCID);

                    //make sure out generic list doesnt already
                    //contain this country
                    if (region != null && region.ISOCurrencySymbol != null && !cultureDict.ContainsKey(region.ISOCurrencySymbol))
                        cultureDict.Add(region.ISOCurrencySymbol, string.Format("{0} ({1})", region.CurrencyEnglishName, region.CurrencySymbol));
                }

                IEnumerable<KeyValuePair<string, string>> sortedDict = from entry in cultureDict orderby entry.Value ascending select entry;

                foreach (KeyValuePair<string, string> item in sortedDict)
                    currencyDict.Add(item.Key, item.Value);
            }
            catch //Exception)
            {

            }
            return currencyDict;
        }

        static public string GetCountryNameByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                code = DefaultCountry;

            return CountriesDict[code];
        }

        static public string GetCurrencySymbolNameByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                code = DefaultCurrencySymbolCode;

            return CurrenciesDict[code];

        }

        static public string GetCurrencySymbolByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                code = DefaultCurrencySymbolCode;

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                //pass the current culture's Locale ID (http://msdn.microsoft.com/en-us/library/0h88fahh.aspx)
                //to the RegionInfo contructor to gain access to the information for that culture
                RegionInfo region = new RegionInfo(culture.LCID);

                //make sure out generic list doesnt already
                //contain this country
                if (region != null && region.ISOCurrencySymbol != null && region.ISOCurrencySymbol == code)
                    return region.CurrencySymbol;
            }
            return DefaultCurrencySymbol;
        }

        static public bool IsGreekCountryCode(string countryCode)
        {
            return GreekCountries.Contains(countryCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        static public string CountryCode4Specialities(string cultureCode, string countryCode)
        {
            if (countryCode != null)
            {
                if (GreekCountries.Contains(countryCode))
                    return LocalizationUtil.GreekCountry;
                else
                    return LocalizationUtil.EnglCountry;
            }
            else
            {
                cultureCode = CheckCulture(cultureCode);

                if (cultureCode == LocalizationUtil.EnglCulture)
                    return LocalizationUtil.EnglCountry;
                else
                    return LocalizationUtil.GreekCountry;
            }
        }

        public static string CheckCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country) || !CountriesDict.Keys.Contains(country))
                return DefaultCountry;
            else
                return country;
        }

        //..............................................................................
        //   Cultures
        //..............................................................................
        public static string CheckCulture(string culture)
        {
            if (string.IsNullOrWhiteSpace(culture) || !CulturesDict.Keys.Contains(culture))
                return DefaultCulture;
            else
                return culture.Substring(0,2);
        }

        public static string CultureFileExtension(string culture)
        {
            culture = LocalizationUtil.CheckCulture(culture);
            if (culture == LocalizationUtil.GreekCulture)
                culture = "";
            else
                culture = "-" + culture;

            return culture;
        }

        /// <summary>
        /// All interface languages
        /// </summary>
        /// <param name="culture"></param>
        static public string SetCurrentCulture(string culture)
        {
            culture = CheckCulture(culture);

            CultureInfo cid = CultureInfo.GetCultureInfo(culture);
            CultureInfo.DefaultThreadCurrentCulture = cid;
            CultureInfo.DefaultThreadCurrentUICulture = cid;
            return culture;
        }

        static public string GetCultureName(string culture)
        {
            if (string.IsNullOrEmpty(culture))
                culture = DefaultCulture;
            return CulturesDict[culture];
        }

        static public string GetCultureFlag(string culture)
        {
            if (string.IsNullOrEmpty(culture))
                culture = DefaultCulture;
            return string.Format("/Files/Language/{0}.gif", culture);
        }

        static public string GetCultureByCountryCode(string code)
        {
            if (code == "CY")
                return GreekCulture;
            else
            {
                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (CultureInfo culture in cultures)
                {
                    RegionInfo region = new RegionInfo(culture.LCID);
                    if (region.TwoLetterISORegionName == code)
                        return culture.Name;
                }
                return DefaultCulture;
            }
        }

        /// <summary>
        /// Read first part only, like:  "en", "es", "el"
        /// </summary>
        static public string GetCultureBasic(string culture)
        {
            if (string.IsNullOrEmpty(culture))
                return "";
            else
                return culture.Substring(0, 2);
        }

        //static public string FormatPhoneNumber(string phone, string countryCode)
        //{
        //    try
        //    {
        //        PhoneNumber number = PhoneNumberUtil.Instance.Parse(phone, countryCode);
        //        if (number.IsValidNumber)
        //            phone = number.Format(PhoneNumberUtil.PhoneNumberFormat.E164);
        //        else
        //            phone = "";
        //    }
        //    catch // (Exception ex)
        //    {
        //        phone = "";
        //    }
        //    return phone;
        //}
    }
}
