using System;
using System.Windows.Forms;

namespace MyMovieApp
{
    public partial class YearTextBox : TextBox
    {
        private const int FirstFilmDate = 1895;

        private ErrorProvider _errorProvider;
        internal bool IsValid
        {
            get
            {
                int parsed;
                if (!int.TryParse(Text, out parsed)) return false;
                return parsed >= FirstFilmDate && parsed <= DateTime.Now.Year;
            }
        }

        public YearTextBox()
        {
            KeyPress += (sender, args) =>
            {
                args.Handled = !char.IsDigit(args.KeyChar);
            };

            Validating += (sender, args) =>
            {
                _errorProvider.SetError(this,
                    IsValid ? "" : string.Format("year should be greater or equal than {0} and less or equal than {1}", FirstFilmDate, DateTime.Now.Year)); //TODO to resources
            };
        }

        internal void SetErrorProvider(ErrorProvider ep) { _errorProvider = ep; }
    }
}
