﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDA.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("HRAT\\SQLEXPRESS")]
        public string DB_SERVER_NAME {
            get {
                return ((string)(this["DB_SERVER_NAME"]));
            }
            set {
                this["DB_SERVER_NAME"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MYP")]
        public string DB_NAME {
            get {
                return ((string)(this["DB_NAME"]));
            }
            set {
                this["DB_NAME"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SA")]
        public string DB_ID {
            get {
                return ((string)(this["DB_ID"]));
            }
            set {
                this["DB_ID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Myp53750804")]
        public string DB_PW {
            get {
                return ((string)(this["DB_PW"]));
            }
            set {
                this["DB_PW"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsOpenMypSetting {
            get {
                return ((bool)(this["IsOpenMypSetting"]));
            }
            set {
                this["IsOpenMypSetting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int DataUpdateTick {
            get {
                return ((int)(this["DataUpdateTick"]));
            }
            set {
                this["DataUpdateTick"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("05/20/2019 10:30:00")]
        public global::System.DateTime DataUpdateMorning {
            get {
                return ((global::System.DateTime)(this["DataUpdateMorning"]));
            }
            set {
                this["DataUpdateMorning"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("05/20/2019 19:30:00")]
        public global::System.DateTime DataUpdateAfternoon {
            get {
                return ((global::System.DateTime)(this["DataUpdateAfternoon"]));
            }
            set {
                this["DataUpdateAfternoon"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MonitorFingerPrint {
            get {
                return ((bool)(this["MonitorFingerPrint"]));
            }
            set {
                this["MonitorFingerPrint"] = value;
            }
        }
    }
}
