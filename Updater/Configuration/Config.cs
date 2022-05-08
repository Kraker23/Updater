using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.Configuration
{
    public class Config
    {
        public int TipoUbicacion { get; set; }
        public string Version { get; set; }
        public int TipoActualizacion { get; set; }
        public int CopiaSeguridad { get; set; }       

        public bool ultimaVersion
        {
            get
            {
                if (string.IsNullOrEmpty(Version))
                {
                    return true;
                }
                else { return false; }
            }
        }
        public bool hacerCopiaSeguridad
        {
            get
            {
                if (CopiaSeguridad == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }

        public Ubicacion ubicacionArchivos
        {
            get
            {
                switch (TipoUbicacion)
                {
                    case 0: return Ubicacion.FileSystem;
                    case 1: return Ubicacion.Git;
                    case 2: return Ubicacion.FTP;
                    case 3: return Ubicacion.Nube;
                    default: return Ubicacion.FileSystem;
                }
            }
        }

        public Actualizacion tipoActualizacion
        {
            get
            {
                switch (TipoActualizacion)
                {
                    case 0: return Actualizacion.Cambios;
                    case 1: return Actualizacion.Full;
                    case 2: return Actualizacion.Reset;
                    default: return Actualizacion.Cambios;
                }
            }
        }


    }

    public enum Ubicacion
    {
        FileSystem = 0,
        Git = 1,
        FTP = 2,
        Nube = 3
    }

    public enum Actualizacion
    {
        Cambios = 0,
        Full = 1,
        Reset = 2
    }
}



