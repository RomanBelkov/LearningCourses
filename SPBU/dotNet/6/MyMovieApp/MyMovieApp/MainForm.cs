using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MyMovieApp.Helpers;
using MyMovieApp.Models;

namespace MyMovieApp
{
    internal sealed partial class MainForm : Form
    {
        internal delegate void RepopulateDatabaseEvent();
        internal delegate void EditFilmEvent(List<Movie> selectedMovies);
        internal delegate void DeleteFilmEvent(List<Movie> selectedMovies);
        internal delegate void FindFilmEvent();
        internal delegate void GoBackEvent();
        internal delegate void AboutOpenEvent();
        internal delegate void DeleteActorEvent(int position);
        internal delegate void SaveMovieEvent();
        internal delegate void AddMovieActorEvent(string name);

        internal event RepopulateDatabaseEvent RepopulateDatabase;
        internal event EditFilmEvent EditFilm;
        internal event DeleteFilmEvent DeleteFilm;
        internal event FindFilmEvent FindFilm;
        internal event GoBackEvent GoBack;
        internal event AboutOpenEvent AboutOpen;
        internal event DeleteActorEvent DeleteActor;
        internal event SaveMovieEvent SaveMovie;
        internal event AddMovieActorEvent AddMovieActor;

        private MoviesEditor _moviesEditor;

        internal ToolStripMenuItem ExitMenuItem => exitToolStripMenuItem;
        internal ToolStripMenuItem FindMovieMenuItem => findMovieToolStripMenuItem;

        internal MainForm(MoviesGrid moviesGrid)
        {
            InitializeComponent();

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //DESIGNER SHIT

            var imageColumn = new DataGridViewImageColumn();
            var nameColumn = new DataGridViewTextBoxColumn();
            var yearColumn = new DataGridViewTextBoxColumn();

            dataGridView.Columns.Add(imageColumn);
            dataGridView.Columns.Add(nameColumn);
            dataGridView.Columns.Add(yearColumn);

            imageColumn.Resizable = DataGridViewTriState.False;
            nameColumn.Resizable = DataGridViewTriState.False;
            yearColumn.Resizable = DataGridViewTriState.False;

            imageColumn.ReadOnly = true;
            nameColumn.ReadOnly = true;
            yearColumn.ReadOnly = true;

            //DESIGNER SHIT

            movieYearTextBox.SetErrorProvider(errorProvider);

            //editMovieFormHelpProvider.SetShowHelp(editFormNameText, true);
            //editMovieFormHelpProvider.SetHelpString(editFormNameText, "Название фильма");

            moviesGrid.StateChanged += UpdateGridView;
            UpdateGridView(moviesGrid);
            ShowMovieGrid();

            OnMainFormResize(this, null);
        }

        internal void SetGridTitle(string title) { gridTitleLabel.Text = title; }
        internal void SetGridStatus(bool enabled) { dataGridView.Enabled = enabled; }

        private void UpdateGridView(MoviesGrid moviesGrid)
        {
            const int moviesRowHeight = 200;
            DataGridViewRow currentRow = null;
            var cells = new List<DataGridViewImageCell>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var dataGridViewImageCell = row.Cells[0] as DataGridViewImageCell;
                (dataGridViewImageCell?.Value as Image)?.Dispose();
            }
            dataGridView.Rows.Clear();

            moviesGrid.Movies.ForEach(movie =>
            {
                currentRow = new DataGridViewRow
                {
                    Height = moviesRowHeight,
                    Tag = movie
                };

                var imageCell = new DataGridViewImageCell();
                var nameCell = new DataGridViewTextBoxCell { Value = movie.Name };
                var yearCell = new DataGridViewTextBoxCell { Value = movie.Year };

                cells.Add(imageCell);

                currentRow.Cells.Add(imageCell);
                currentRow.Cells.Add(nameCell);
                currentRow.Cells.Add(yearCell);

                dataGridView.Rows.Add(currentRow);
                currentRow = null;
            });

            if (currentRow != null)
            {
                dataGridView.Rows.Add(currentRow);
            }

            for (var i = 0; i < cells.Count; i++)
            {
                var image = ImagesHelper.FromFile(moviesGrid.Movies[i].ImageUrl);
                cells[i].Value = image;
            }
        }

        private void UpdateEditForm(MoviesEditor moviesEditor)
        {
            movieNameTextBox.Text = moviesEditor.Name;
            movieYearTextBox.Text = moviesEditor.Year.ToString();
            movieDirectorNameTextBox.Text = moviesEditor.Director.Name;

            moviePictureBox.Image = ImagesHelper.FromFile(moviesEditor.Image);
            movieActorsListBox.Items.Clear();
            movieActorsListBox.Items.AddRange(moviesEditor.Actors.Select(actor => actor.Name).ToArray());
        }

        internal void ShowMovieGrid()
        {
            movieEditPanel.Hide();
            dataGridView.Left = 0;
            dataGridView.Width = ClientSize.Width;
            dataGridView.Show();
            gridTitleLabel.Show();
        }

        internal void ShowMovieEditForm(MoviesEditor moviesEditor)
        {
            _moviesEditor = moviesEditor;

            dataGridView.Hide();
            gridTitleLabel.Hide();
            movieEditPanel.Left = 0;
            movieEditPanel.Width = ClientSize.Width;
            movieEditPanel.Show();

            moviesEditor.StateChanged += UpdateEditForm;

            UpdateEditForm(moviesEditor);
        }

        internal void UpdateMoviesEditorState(MoviesEditor moviesEditor, out string directorName, List<string> actorNames)
        {
            moviesEditor.Name = movieNameTextBox.Text;
            moviesEditor.Year = int.Parse(movieYearTextBox.Text);
            directorName = movieDirectorNameTextBox.Text;
            actorNames.AddRange(
                from object t 
                in movieActorsListBox.Items
                select t.ToString());
        }

        internal void SetControlsState(bool enabled)
        {
            foreach (Control c in Controls) { c.Enabled = enabled; }
        }

        private List<Movie> GetSelectedMovies()
        {
            return dataGridView.SelectedRows.OfType<DataGridViewRow>().Select(movieRow => movieRow.Tag as Movie).ToList();
        }

        private void OnMovieDeleteButtonClick(object sender, EventArgs e)
        {
            DeleteFilm?.Invoke(GetSelectedMovies());
        }

        private void OnMovieChangeButtonClick(object sender, EventArgs e)
        {
            EditFilm?.Invoke(GetSelectedMovies());
        }

        private void OnMovieAddClick(object sender, EventArgs e)
        {
            var selectFile = new OpenFileDialog();
            var result = selectFile.ShowDialog();

            if (result.HasFlag(DialogResult.Cancel)) return;
            var file = selectFile.FileName;
            moviePictureBox.Image = Image.FromFile(file);

            _moviesEditor.Image = file;
        }

        private void OnOpenBdToolStripMenuItemClick(object sender, EventArgs e)
        {
            RepopulateDatabase?.Invoke();
        }

        private void OnEditMovieToolStripMenuItemClick(object sender, EventArgs e)
        {
            EditFilm?.Invoke(GetSelectedMovies());
        }

        private void OnAddActorButtonClick(object sender, EventArgs e)
        {
            AddMovieActor?.Invoke(addActorNameTextBox.Text);
        }

        private void OnDeleteActorButtonClick(object sender, EventArgs e)
        {
            DeleteActor?.Invoke(movieActorsListBox.SelectedIndex);
        }

        private void OnMainFormResize(object sender, EventArgs e)
        {
            var gridWidth = dataGridView.Width - dataGridView.RowHeadersWidth * 2;
            dataGridView.Columns[0].Width = gridWidth / 3;
            dataGridView.Columns[1].Width = gridWidth / 3;
            dataGridView.Columns[2].Width = gridWidth / 3;
        }
    }
}
