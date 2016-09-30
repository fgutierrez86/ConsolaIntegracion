using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using Microsoft.Win32.SafeHandles;

namespace Datos
{
    public class MovimientoEstoquePadraoERPIn_v1_Contexto
    {
        public static void Enviar()
        {
            var movimiento = new MovimentacaoEstoquePadraoERPIn_v1();
            movimiento.CodigoEstoque = "50161872";
            movimiento.CodigoMaterialSKU = "7899563242421";
            movimiento.Observacao = "Movimiento de prueba";
            movimiento.Quantidade = 100;
            movimiento.TipoMovimento = "E";

            var aMovimientos = new ArrayOfMovimentacaoEstoquePadraoERPIn_v1().Estoque;
            aMovimientos = new MovimentacaoEstoquePadraoERPIn_v1[1];
            aMovimientos[0] = movimiento;
            //aMovimientos.Estoque[0] = movimiento;
            FileStream fileStream = new FileStream(@"C:\Compartida\MySoapFile.dat", FileMode.Create );

            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(fileStream, aMovimientos );
            //aMovimientos.Estoque[0] = movimiento;
            //XmlSerializer xml = new XmlSerializer(typeof(ArrayOfMovimentacaoEstoquePadraoERPIn_v1));
            //return xml;

        }
    }
}
