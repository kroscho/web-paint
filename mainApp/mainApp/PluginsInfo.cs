using System;
using System.Collections.Generic;
using PluginInterface;
using System.Windows.Forms;

namespace mainApp
{
    public partial class PluginsInfo : Form
    {
        public PluginsInfo(Dictionary<string, IPlugin> plugins, List<Type> types)
        {
            InitializeComponent();
            listView.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Author", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Version", -2, HorizontalAlignment.Left);

            int i = 0;
            foreach (KeyValuePair<string, IPlugin> plug in plugins)
            {
                object[] attrs = types[i].GetCustomAttributes(false);
                i++;

                ListViewItem lvi = new ListViewItem(new[] { plug.Key, plug.Value.Author, $"{((VersionAttribute)attrs[0]).Major}.{((VersionAttribute)attrs[0]).Minor}" });
                listView.Items.Add(lvi);
            }
        }
    }
}
