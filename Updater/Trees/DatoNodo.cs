using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.Trees
{
    public class DatoNodo
    {
        public int id { get; set; }
        public int? idPadre { get; set; }
        public string Nombre { get; set; }
        public int idADP { get; set; }
        public int Level { get; set; }
        public string nombreLevel { get; set; }
    }

    public class DatoArchivo
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Url { get; set; }
        public int Level { get; set; }
        public bool Archivo { get; set; }
        public string rutaBase { get; set; }
        public string rutaSinBase { get; set; }
        public bool SoloLectura { get; set; }

        public override string ToString()
        {
            string archivo = Archivo ? "1" : "0";
            string lectura = SoloLectura ? "1" : "0";
            return Nombre + "[" + Fecha.ToShortDateString() + "]" + "{" + archivo + "}" + "--->" + lectura;
            //return base.ToString(); 
        }
    }
}
