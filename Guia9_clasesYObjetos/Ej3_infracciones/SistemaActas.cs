using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3_infracciones
{
    class SistemaActas
    {
        #region nomenclador de infracciones
        int CODIGO_1_INFRACCION = 1;
        string DESC_1_INFRACCION = "Sin luces bajas, ley 25….";
        int UD_1_INFRACCION = 25;
        //
        int CODIGO_2_INFRACCION = 2;
        string DESC_2_INFRACCION = "alta de Matafuego, ley 2…";
        int UD_2_INFRACCION = 30;
        #endregion

        #region atributos generales de sistema
        double montoBase;

        public double Recaudacion { get; private set; }

        /*
        double recaudacion;
        public double Recaudacion
        {
            get {
                    ...
                return recaudacion;
            }
            set
            {
                recaudacion = value;
            }
        }
        */

        /*
        double recaudacion;
        public double GetRecaudacion()
        {
            return recaudacion;
        }
        public void SetRecaudacion(double Value)
        {
            recaudacion = Value;
        }
        */
        #endregion

        #region atributos por cada acta
        int dni;
        string nombre;
        public double totalAPagar;
        #endregion

        #region atributos por cada infraccion
        int codigoInfraccion;
        string descInfraccion;
        double montoInfraccion;
        #endregion

        #region método del sistema
        public void IniciarSistema(double montoBase)
        {
            this.montoBase = montoBase;
            this.Recaudacion = 0;
        }
        #endregion

        #region métodos por acta
        public void IniciarActa(int dni, string nombre)
        {
            this.dni = dni;
            this.nombre = nombre;
            totalAPagar = 0;
        }

        public double RegistrarInfraccion(int codigo)
        {
            switch (codigo)
            {
                case 1:
                    {
                        montoInfraccion = UD_1_INFRACCION * montoBase;
                    }
                    break;
                case 2:
                    {
                        montoInfraccion = UD_2_INFRACCION * montoBase;
                    }
                    break;
            }
            totalAPagar += montoInfraccion;
            return montoInfraccion;
        }

        public void FinalizarActa(bool pagaEnElLugar)
        {
            Recaudacion += totalAPagar;
        }
        #endregion

    }
}
