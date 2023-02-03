using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RieltorClient.Componens
{
   internal class Navigation
    {
        public static MainWindow main;
        public static List<Nav> navs = new List<Nav>();

        public static void Update(Nav nav) 
        {
            navs.Add(nav);
            Update(nav);
        }
        public static void Nextpage(Nav nav) 
        {
            main.MyFrame.Navigate(nav.page);
        
        }
    }
    class Nav 
    {
        public Page page;
        public Nav(Page page) 
        {

            this.page = page;

        }
    }
}
