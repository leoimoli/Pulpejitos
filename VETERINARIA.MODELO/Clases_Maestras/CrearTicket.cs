using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace VETERINARIA.MODELO.Clases_Maestras
{
    public class CrearTicket
    {
        string ticket = "";
        string parte1, parte2;
        string impresora = "POS58 Printer";
        //string impresora = "POS80 Pro";
        //string impresora = WebConfigurationManager.AppSettings["ImpresoraTKT"].ToString(); // nombre exacto de la impresora como esta en el panel de control
        //ticket.PrintTicket("EPSON TM-T88III Receipt");
        int max, cort;
        public void LineasGuion()
        {
            ticket = "--------------------------------\n";   // agrega lineas separadoras -
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }

        public void Encabezado(string numero, bool esFactura)
        {
            if (esFactura)
            {
                TextoCentro("NIKODEM VALERIA ALEJANDRA");
                TextoIzquierda("C.U.I.T Nro: 27-22975207-9");
                TextoIzquierda("INGRESOS BRUTOS: 27-22975207-9");
                TextoIzquierda("25 DE MAYO 555");
                TextoIzquierda("GUALEGUAYCHU, ENTRE RIOS");
                TextoIzquierda("INICIO DE ACTIVIDADES:01-09-2019");
                TextoIzquierda("IVA RESP. INSCRIPTO");
                LineasGuion();
                TextoIzquierda("TIQUE FACTURA B");
                TextoIzquierda("Nro.:0003-" + numero);
            }
            else
            {
                TextoIzquierda("Venta Nro.:" + numero);
            }
            TextoIzquierda("FECHA:" + DateTime.Now.ToShortDateString() + "  HORA:" + DateTime.Now.ToString("HH:mm:ss"));
            LineasGuion();
            TextoIzquierda("A CONSUMIDOR FINAL");
            LineasGuion();
            TextoIzquierda("Cant. x P. Unit. (%IVA)");
            TextoIzquierda("Descripcion      [%BI]   Importe");
            LineasGuion();
            //RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }

        public void TextoIzquierda(string par1)                          // agrega texto a la izquierda
        {
            max = par1.Length;
            if (max > 32)                                 // **********
            {
                cort = max - 32;
                parte1 = par1.Remove(32, cort);        // si es mayor que 40 caracteres, lo corta
            }
            else { parte1 = par1; }                      // **********
            ticket = parte1 + "\n";
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoDerecha(string par1)
        {
            ticket = "";
            max = par1.Length;
            if (max > 32)                                 // **********
            {
                cort = max - 32;
                parte1 = par1.Remove(32, cort);           // si es mayor que 40 caracteres, lo corta
            }
            else { parte1 = par1; }                      // **********
            max = 40 - par1.Length;                     // obtiene la cantidad de espacios para llegar a 40
            for (int i = 0; i < max; i++)
            {
                ticket += " ";                          // agrega espacios para alinear a la derecha
            }
            ticket += parte1 + "\n";                    //Agrega el texto
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoCentro(string par1)
        {
            ticket = "";
            max = par1.Length;
            if (max > 32)                                 // **********
            {
                cort = max - 32;
                parte1 = par1.Remove(32, cort);          // si es mayor que 40 caracteres, lo corta
            }
            else { parte1 = par1; }                      // **********
            max = (int)(32 - parte1.Length) / 2;         // saca la cantidad de espacios libres y divide entre dos
            for (int i = 0; i < max; i++)                // **********
            {
                ticket += " ";                           // Agrega espacios antes del texto a centrar
            }                                            // **********
            ticket += parte1 + "\n";
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoExtremos(string par1, string par2)
        {
            max = par1.Length;
            if (max > 18)                                 // **********
            {
                cort = max - 18;
                parte1 = par1.Remove(18, cort);          // si par1 es mayor que 18 lo corta
            }
            else { parte1 = par1; }                      // **********
            ticket = parte1;                             // agrega el primer parametro
            max = par2.Length;
            if (max > 18)                                 // **********
            {
                cort = max - 18;
                parte2 = par2.Remove(18, cort);          // si par2 es mayor que 18 lo corta
            }
            else { parte2 = par2; }
            max = 40 - (parte1.Length + parte2.Length);
            for (int i = 0; i < max; i++)                 // **********
            {
                ticket += " ";                            // Agrega espacios para poner par2 al final
            }                                             // **********
            ticket += parte2 + "\n";                     // agrega el segundo parametro al final
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void AgregaTotales(double total, string cae, string fechaVtoCae)
        {
            TextoIzquierda("                        ---------");
            TextoIzquierda(("TOTAL").PadRight((32 - string.Format("{0:N2}", total).Length), ' ') + string.Format("{0:N2}", total));
            TextoIzquierda("".PadRight(32, ' '));
            TextoIzquierda("Gracias por su compra!!!".PadRight(32, ' '));
            if (cae != null)
            {
                TextoIzquierda("CAE:" + cae);
                TextoIzquierda("FECHA VTO. CAE:" + fechaVtoCae);
            }
            TextoIzquierda("".PadRight(32, ' '));
            TextoIzquierda("".PadRight(32, ' '));

        }

        public void AgregarDescuentos(string descripcion, object p1, double precio, object p2)
        {
            //TextoIzquierda(cant.ToString() + " x " + string.Format("{0:N2}", precio) + "(21.00)".PadLeft(19 - (cant.ToString().Length + string.Format("{0:N2}", precio).Length), ' '));
            max = descripcion.Length;
            while (max > 23)
            {
                cort = max - 23;
                parte1 = descripcion.Remove(23, cort);
                TextoIzquierda(parte1);
                descripcion = descripcion.Remove(0, 23);
                max = descripcion.Length;
            }
            TextoIzquierda(descripcion.PadRight((32 - string.Format("{0:N2}", precio).Length), ' ') + string.Format("{0:N2}", precio));
        }

        public void AgregaArticulo(string descripcion, int cant, double precio, double total)
        {
            TextoIzquierda(cant.ToString() + " x " + string.Format("{0:N2}", precio) + "(21.00)".PadLeft(19 - (cant.ToString().Length + string.Format("{0:N2}", total).Length), ' '));
            max = descripcion.Length;
            while (max > 23)
            {
                cort = max - 23;
                parte1 = descripcion.Remove(23, cort);
                TextoIzquierda(parte1);
                descripcion = descripcion.Remove(0, 23);
                max = descripcion.Length;
            }
            TextoIzquierda(descripcion.PadRight((32 - string.Format("{0:N2}", total).Length), ' ') + string.Format("{0:N2}", total));
        }
    }

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}
