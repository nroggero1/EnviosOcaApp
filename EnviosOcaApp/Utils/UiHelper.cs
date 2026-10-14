using System;
using System.Windows.Forms;

namespace EnviosOcaApp.Utils
{
    public static class UiHelper
    {
        /// <summary>
        /// Configura recursivamente todos los TextBox contenidos en el control para forzar CharacterCasing.Upper,
        /// y se suscribe a ControlAdded para que cualquier control hijo agregado dinámicamente también lo cumpla.
        /// </summary>
        public static void ForzarMayusculasEnControles(Control? parent)
        {
            if (parent == null) return;

            AplicarMayusculasRecursivo(parent);

            parent.ControlAdded += Parent_ControlAdded;
        }

        private static void Parent_ControlAdded(object? sender, ControlEventArgs e)
        {
            if (e.Control != null)
            {
                ForzarMayusculasEnControles(e.Control);
            }
        }

        private static void AplicarMayusculasRecursivo(Control ctrl)
        {
            if (ctrl is TextBox tb)
            {
                tb.CharacterCasing = CharacterCasing.Upper;
            }

            foreach (Control child in ctrl.Controls)
            {
                AplicarMayusculasRecursivo(child);
            }
        }
    }
}
