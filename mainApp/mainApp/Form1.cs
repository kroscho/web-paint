using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using PluginInterface;

namespace mainApp
{
    public partial class MainForm : Form, IMainApp
    {
        private readonly Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        public MainForm()
        {
            InitializeComponent();
            FindPlugins();
            CreatePluginsMenu();
        }

        public Bitmap Image
        {
            get => (Bitmap)pcBox.Image;

            set => pcBox.Image = value;
        }
        //Метод FindPlugins с помощью рефлексии находит плагины в папке с приложением и загружает их сборки. 
        void FindPlugins()
        {
            // папка с плагинами
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;

            // dll-файлы в этой папке
            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);

                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("PluginInterface.IPlugin");

                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];
            plugin.Transform(this);
        }

        private void CreatePluginsMenu()
        {
            var item = new ToolStripMenuItem("Плагины");

            foreach (var name in plugins.Keys)
            {
                var pluginItem = new ToolStripMenuItem(name, null, OnPluginClick);
                item.DropDownItems.Add(pluginItem);
                filterMenu.DropDownItems.Add(item);
            }
        }
    }
}
