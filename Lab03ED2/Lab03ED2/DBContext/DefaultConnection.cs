using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03ED2.DBContext
{
    public class DefaultConnection
    {
        private static volatile DefaultConnection Instance;
        private static object syncRoot = new Object();

        public List<Models.Pizza> Listadopizzas = new List<Models.Pizza>();

        private static int getId { get; set; }

        public int obtenerId()
        {
            var id = getId;
            getId++;
            return id;
        }

        public static DefaultConnection getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new DefaultConnection();
                        }
                    }
                }
                return Instance;
            }
        }
    }
}
