using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

using PluginInterface;
using Aluminum.PluginCore2;

namespace DemoPlugin.Plugin
{
    public class DemoPlugin : IPlugin
    {
        public DemoPlugin()
        {

        }
        string _name = "Demo Plugin";
        string _author = "0xFireball";
        string _description = "Demo FireCryptEx Plugin";
        string _version = "1.0.0";

        public string Name
        {
            get { return _name; }
        }
        public string Author
        {
            get { return _author; }
        }
        public string Description
        {
            get { return _description; }
        }
        public string Version
        {
            get { return _version; }
        }
        IPluginHost _host = null;
        /// <summary>
        /// Host of the plugin.
        /// </summary>
        public IPluginHost Host
        {
            get { return _host; }
            set { _host = value; }
        }

        object _parentForm;

        public object HostObject
        {
            get { return _parentForm; }
            set { _parentForm = value; }
        }

        private object GetObjectFromHostWindow(string memberName)
        {
            var mainWinType = _parentForm.GetType();

            var objMem = mainWinType.GetMember(memberName,
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance)[0];
            var objF = ((FieldInfo)objMem);
            var objV = objF.GetValue(_parentForm);
            return objV;
        }

        public void InvokePlugin()
        {
            MessageBox.Show("Demo Plugin has been invoked.");
            //Add any code you want to be called when the plugin is invoked
            //This will be triggered when the plugin menu item is clicked.
        }

        public void Initialize()
        {

            //This is the first Function called by the host...
            //Put anything needed to start with here first
        }

        public void Dispose()
        {
            //Put any cleanup code in here for when the program is stopped
        }
    }
}
