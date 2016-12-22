using System;
using System.Windows.Forms;
using MyMovieApp.Models;

namespace MyMovieApp
{
    public partial class SearchForm : Form
    {
        internal delegate void UserInputEvent(string name, int year, string director, string actor);
        internal delegate void SearchEvent();
        internal delegate void ClearEvent();

        internal event UserInputEvent UserInput;
        internal event SearchEvent Search;
        internal event ClearEvent Clear;

        internal SearchForm(Search search)
        {
            InitializeComponent();
            searchMovieYearTextBox.SetErrorProvider(searchErrorProvider);
            search.StateChanged += UpdateFromModel;
        }

        private void UpdateFromModel(Search search)
        {
            if (searchMovieNameTextBox.Text != search.Name)
            {
                searchMovieNameTextBox.Text = search.Name;
            }
            if (searchMovieCountryTextBox.Text != search.Country)
            {
                searchMovieCountryTextBox.Text = search.Country;
            }
            if (searchMovieDirectorTextBox.Text != search.Director)
            {
                searchMovieDirectorTextBox.Text = search.Director;
            }
            if (searchMovieActorTextBox.Text != search.Actor)
            {
                searchMovieActorTextBox.Text = search.Actor;
            }
        }

        private void OnSearchClearClick(object sender, EventArgs e)
        {
            Clear?.Invoke();
        }

        private void OnSearchSearchClick(object sender, EventArgs e)
        {
            Search?.Invoke();
        }

        private void OnSearchTextBoxTextChanged(object sender, EventArgs e)
        {
            CheckUserInput();
        }

        private void CheckUserInput()
        {
            UserInput?.Invoke(searchMovieNameTextBox.Text,
                searchMovieYearTextBox.IsValid ? int.Parse(searchMovieYearTextBox.Text) : 0,
                searchMovieDirectorTextBox.Text, "");
        }

        private void OnSearchKeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.Enter) == Keys.Enter)
            {
                Search?.Invoke();
            }
        }
    }
}
