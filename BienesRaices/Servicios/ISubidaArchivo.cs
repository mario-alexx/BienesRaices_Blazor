using Microsoft.AspNetCore.Components.Forms;

namespace BienesRaices.Servicios
{
    public interface ISubidaArchivo
    {
        // Permite seleccionar el archivo en el form y subirlo
        Task<string> SubirArchivo(IBrowserFile archivo);
        bool BorrarArchivo(string nombreArchivo);
    }
}
