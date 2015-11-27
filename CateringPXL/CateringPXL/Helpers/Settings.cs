// Helpers/Settings.cs
using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;

namespace CateringPXL.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        // Campus Keuze
        private const string CampusKeuzeKey = "campus_keuze_key";
        private static readonly string CampusKeuzeDefault = string.Empty;
        // Menu
        public static DagMenu[] menu;
        // Eerste login
        private const string FirstLoginKey = "firstlogin_keuze_key";
        private static readonly string FirstLoginDefault = string.Empty;
        // DatumVandaag
        private const string DatumVandaagKey = "datum_keuze_key";
        private static readonly string DatumVandaagDefault = string.Empty;
        // DagMenuJson
        private const string DagMenuJsonKey = "dagmenujson_keuze_key";
        private static readonly string DagMenuJsonDefault = string.Empty;

        public static Splash splash;
        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static string CampusKeuze
        {
            get
            {
                return AppSettings.GetValueOrDefault(CampusKeuzeKey, CampusKeuzeDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(CampusKeuzeKey, value);
            }
        }
        public static string DatumVandaag
        {
            get
            {
                return AppSettings.GetValueOrDefault(DatumVandaagKey, DatumVandaagDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DatumVandaagKey, value);
            }
        }
        public static string DagMenuJson
        {
            get
            {
                return AppSettings.GetValueOrDefault(DagMenuJsonKey, DagMenuJsonDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DagMenuJsonKey, value);
            }
        }
        public static string FirstLogin
        {
            get
            {
                return AppSettings.GetValueOrDefault(FirstLoginKey, FirstLoginDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(FirstLoginKey, value);
            }
        }
    }

}