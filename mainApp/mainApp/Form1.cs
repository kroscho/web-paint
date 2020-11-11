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
       
        List<Type> types = new List<Type>();

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
                    //Сборку для проверки на наличие плагина загружаем методом LoadFile и в цикле проходим по всем типам, определенным в сборке.
                    Assembly assembly = Assembly.LoadFile(file);

                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("PluginInterface.IPlugin");
                        
                        //Если тип содержит интерфейс IPlugin
                        if (iface != null)
                        {
                            types.Add(type);
                            //создаем экземпляр типа
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
            foreach (var item in plugins)
            {
                var it = filterMenu.DropDownItems.Add(item.Key);
                it.Click += OnPluginClick;
            }
        }
        
        private void filterMenu_Click(object sender, EventArgs e)
        {

        }

        private void pluginsInfoMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PluginsInfo plugForm = new PluginsInfo(plugins, types);

            plugForm.ShowDialog(this);
        }
    }
}
