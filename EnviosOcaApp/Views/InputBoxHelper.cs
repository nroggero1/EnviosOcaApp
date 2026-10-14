using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnviosOcaApp.Views
{
    public static class InputBoxHelper
    {
        public static string? Show(string prompt, string title, string defaultValue = "")
        {
            using var promptForm = new Form
            {
                Width = 460,
                Height = 210,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var lblText = new Label
            {
                Left = 25,
                Top = 20,
                Width = 395,
                Height = 60,
                Text = prompt,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(40, 40, 40)
            };

            var txtInput = new TextBox
            {
                Left = 25,
                Top = 85,
                Width = 395,
                Text = defaultValue,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                CharacterCasing = CharacterCasing.Upper
            };

            var btnOk = new Button
            {
                Text = "Aceptar",
                Left = 240,
                Width = 85,
                Top = 125,
                Height = 30,
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(167, 3, 85),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnOk.FlatAppearance.BorderSize = 0;

            var btnCancel = new Button
            {
                Text = "Cancelar",
                Left = 335,
                Width = 85,
                Top = 125,
                Height = 30,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(220, 220, 220),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            promptForm.Controls.Add(lblText);
            promptForm.Controls.Add(txtInput);
            promptForm.Controls.Add(btnOk);
            promptForm.Controls.Add(btnCancel);
            promptForm.AcceptButton = btnOk;
            promptForm.CancelButton = btnCancel;

            return promptForm.ShowDialog() == DialogResult.OK ? txtInput.Text.Trim() : null;
        }
    }
}
