namespace MyMovieApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridTitleLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.movieNameTextBox = new System.Windows.Forms.TextBox();
            this.movieDirectorNameTextBox = new System.Windows.Forms.TextBox();
            this.movieCountryTextBox = new System.Windows.Forms.TextBox();
            this.movieNameLabel = new System.Windows.Forms.Label();
            this.movieDirectorLabel = new System.Windows.Forms.Label();
            this.movieYearLabel = new System.Windows.Forms.Label();
            this.movieActorsLabel = new System.Windows.Forms.Label();
            this.movieCountryLabel = new System.Windows.Forms.Label();
            this.movieAddButton = new System.Windows.Forms.Button();
            this.movieChangeButton = new System.Windows.Forms.Button();
            this.movieDeleteButton = new System.Windows.Forms.Button();
            this.movieActorsListBox = new System.Windows.Forms.ListBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findMovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviePictureBox = new System.Windows.Forms.PictureBox();
            this.movieEditPanel = new System.Windows.Forms.Panel();
            this.movieActorsGroupBox = new System.Windows.Forms.GroupBox();
            this.addActorNameTextBox = new System.Windows.Forms.TextBox();
            this.addActorButton = new System.Windows.Forms.Button();
            this.deleteActorButton = new System.Windows.Forms.Button();
            this.movieYearTextBox = new MyMovieApp.YearTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moviePictureBox)).BeginInit();
            this.movieEditPanel.SuspendLayout();
            this.movieActorsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridTitleLabel
            // 
            this.gridTitleLabel.AutoSize = true;
            this.gridTitleLabel.Location = new System.Drawing.Point(12, 45);
            this.gridTitleLabel.Name = "gridTitleLabel";
            this.gridTitleLabel.Size = new System.Drawing.Size(37, 13);
            this.gridTitleLabel.TabIndex = 0;
            this.gridTitleLabel.Text = "Status";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 61);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(37, 329);
            this.dataGridView.TabIndex = 1;
            // 
            // movieNameTextBox
            // 
            this.movieNameTextBox.Location = new System.Drawing.Point(505, 32);
            this.movieNameTextBox.Name = "movieNameTextBox";
            this.movieNameTextBox.Size = new System.Drawing.Size(148, 20);
            this.movieNameTextBox.TabIndex = 2;
            // 
            // movieDirectorNameTextBox
            // 
            this.movieDirectorNameTextBox.Location = new System.Drawing.Point(505, 58);
            this.movieDirectorNameTextBox.Name = "movieDirectorNameTextBox";
            this.movieDirectorNameTextBox.Size = new System.Drawing.Size(148, 20);
            this.movieDirectorNameTextBox.TabIndex = 3;
            // 
            // movieCountryTextBox
            // 
            this.movieCountryTextBox.Location = new System.Drawing.Point(505, 110);
            this.movieCountryTextBox.Name = "movieCountryTextBox";
            this.movieCountryTextBox.Size = new System.Drawing.Size(148, 20);
            this.movieCountryTextBox.TabIndex = 5;
            // 
            // movieNameLabel
            // 
            this.movieNameLabel.AutoSize = true;
            this.movieNameLabel.Location = new System.Drawing.Point(456, 35);
            this.movieNameLabel.Name = "movieNameLabel";
            this.movieNameLabel.Size = new System.Drawing.Size(35, 13);
            this.movieNameLabel.TabIndex = 6;
            this.movieNameLabel.Text = "Name";
            // 
            // movieDirectorLabel
            // 
            this.movieDirectorLabel.AutoSize = true;
            this.movieDirectorLabel.Location = new System.Drawing.Point(456, 61);
            this.movieDirectorLabel.Name = "movieDirectorLabel";
            this.movieDirectorLabel.Size = new System.Drawing.Size(44, 13);
            this.movieDirectorLabel.TabIndex = 7;
            this.movieDirectorLabel.Text = "Director";
            // 
            // movieYearLabel
            // 
            this.movieYearLabel.AutoSize = true;
            this.movieYearLabel.Location = new System.Drawing.Point(456, 87);
            this.movieYearLabel.Name = "movieYearLabel";
            this.movieYearLabel.Size = new System.Drawing.Size(29, 13);
            this.movieYearLabel.TabIndex = 8;
            this.movieYearLabel.Text = "Year";
            // 
            // movieActorsLabel
            // 
            this.movieActorsLabel.AutoSize = true;
            this.movieActorsLabel.Location = new System.Drawing.Point(288, 58);
            this.movieActorsLabel.Name = "movieActorsLabel";
            this.movieActorsLabel.Size = new System.Drawing.Size(37, 13);
            this.movieActorsLabel.TabIndex = 9;
            this.movieActorsLabel.Text = "Actors";
            // 
            // movieCountryLabel
            // 
            this.movieCountryLabel.AutoSize = true;
            this.movieCountryLabel.Location = new System.Drawing.Point(456, 113);
            this.movieCountryLabel.Name = "movieCountryLabel";
            this.movieCountryLabel.Size = new System.Drawing.Size(43, 13);
            this.movieCountryLabel.TabIndex = 10;
            this.movieCountryLabel.Text = "Country";
            // 
            // movieAddButton
            // 
            this.movieAddButton.Location = new System.Drawing.Point(291, 216);
            this.movieAddButton.Name = "movieAddButton";
            this.movieAddButton.Size = new System.Drawing.Size(75, 23);
            this.movieAddButton.TabIndex = 11;
            this.movieAddButton.Text = "Add";
            this.movieAddButton.UseVisualStyleBackColor = true;
            this.movieAddButton.Click += new System.EventHandler(this.OnMovieAddClick);
            // 
            // movieChangeButton
            // 
            this.movieChangeButton.Location = new System.Drawing.Point(291, 254);
            this.movieChangeButton.Name = "movieChangeButton";
            this.movieChangeButton.Size = new System.Drawing.Size(75, 23);
            this.movieChangeButton.TabIndex = 12;
            this.movieChangeButton.Text = "Change";
            this.movieChangeButton.UseVisualStyleBackColor = true;
            this.movieChangeButton.Click += new System.EventHandler(this.OnMovieChangeButtonClick);
            // 
            // movieDeleteButton
            // 
            this.movieDeleteButton.Location = new System.Drawing.Point(291, 283);
            this.movieDeleteButton.Name = "movieDeleteButton";
            this.movieDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.movieDeleteButton.TabIndex = 13;
            this.movieDeleteButton.Text = "Delete";
            this.movieDeleteButton.UseVisualStyleBackColor = true;
            this.movieDeleteButton.Click += new System.EventHandler(this.OnMovieDeleteButtonClick);
            // 
            // movieActorsListBox
            // 
            this.movieActorsListBox.FormattingEnabled = true;
            this.movieActorsListBox.Location = new System.Drawing.Point(6, 19);
            this.movieActorsListBox.Name = "movieActorsListBox";
            this.movieActorsListBox.Size = new System.Drawing.Size(207, 95);
            this.movieActorsListBox.TabIndex = 15;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(723, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBDToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openBDToolStripMenuItem
            // 
            this.openBDToolStripMenuItem.Name = "openBDToolStripMenuItem";
            this.openBDToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openBDToolStripMenuItem.Text = "Open BD";
            this.openBDToolStripMenuItem.Click += new System.EventHandler(this.OnOpenBdToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMovieToolStripMenuItem,
            this.deleteMovieToolStripMenuItem,
            this.findMovieToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.searchToolStripMenuItem.Text = "Edit";
            // 
            // editMovieToolStripMenuItem
            // 
            this.editMovieToolStripMenuItem.Name = "editMovieToolStripMenuItem";
            this.editMovieToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.editMovieToolStripMenuItem.Text = "Edit movie";
            this.editMovieToolStripMenuItem.Click += new System.EventHandler(this.OnEditMovieToolStripMenuItemClick);
            // 
            // deleteMovieToolStripMenuItem
            // 
            this.deleteMovieToolStripMenuItem.Name = "deleteMovieToolStripMenuItem";
            this.deleteMovieToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteMovieToolStripMenuItem.Text = "Delete movie";
            // 
            // findMovieToolStripMenuItem
            // 
            this.findMovieToolStripMenuItem.Name = "findMovieToolStripMenuItem";
            this.findMovieToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.findMovieToolStripMenuItem.Text = "Find movie";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // moviePictureBox
            // 
            this.moviePictureBox.Location = new System.Drawing.Point(3, 3);
            this.moviePictureBox.Name = "moviePictureBox";
            this.moviePictureBox.Size = new System.Drawing.Size(241, 313);
            this.moviePictureBox.TabIndex = 18;
            this.moviePictureBox.TabStop = false;
            // 
            // movieEditPanel
            // 
            this.movieEditPanel.Controls.Add(this.movieActorsGroupBox);
            this.movieEditPanel.Controls.Add(this.movieAddButton);
            this.movieEditPanel.Controls.Add(this.movieYearTextBox);
            this.movieEditPanel.Controls.Add(this.movieNameLabel);
            this.movieEditPanel.Controls.Add(this.movieDirectorLabel);
            this.movieEditPanel.Controls.Add(this.movieNameTextBox);
            this.movieEditPanel.Controls.Add(this.movieYearLabel);
            this.movieEditPanel.Controls.Add(this.moviePictureBox);
            this.movieEditPanel.Controls.Add(this.movieDirectorNameTextBox);
            this.movieEditPanel.Controls.Add(this.movieChangeButton);
            this.movieEditPanel.Controls.Add(this.movieDeleteButton);
            this.movieEditPanel.Controls.Add(this.movieCountryLabel);
            this.movieEditPanel.Controls.Add(this.movieActorsLabel);
            this.movieEditPanel.Controls.Add(this.movieCountryTextBox);
            this.movieEditPanel.Location = new System.Drawing.Point(55, 61);
            this.movieEditPanel.Name = "movieEditPanel";
            this.movieEditPanel.Size = new System.Drawing.Size(656, 329);
            this.movieEditPanel.TabIndex = 19;
            // 
            // movieActorsGroupBox
            // 
            this.movieActorsGroupBox.Controls.Add(this.addActorNameTextBox);
            this.movieActorsGroupBox.Controls.Add(this.addActorButton);
            this.movieActorsGroupBox.Controls.Add(this.deleteActorButton);
            this.movieActorsGroupBox.Controls.Add(this.movieActorsListBox);
            this.movieActorsGroupBox.Location = new System.Drawing.Point(434, 138);
            this.movieActorsGroupBox.Name = "movieActorsGroupBox";
            this.movieActorsGroupBox.Size = new System.Drawing.Size(219, 181);
            this.movieActorsGroupBox.TabIndex = 19;
            this.movieActorsGroupBox.TabStop = false;
            this.movieActorsGroupBox.Text = "Actors";
            // 
            // addActorNameTextBox
            // 
            this.addActorNameTextBox.Location = new System.Drawing.Point(6, 122);
            this.addActorNameTextBox.Name = "addActorNameTextBox";
            this.addActorNameTextBox.Size = new System.Drawing.Size(126, 20);
            this.addActorNameTextBox.TabIndex = 18;
            // 
            // addActorButton
            // 
            this.addActorButton.Location = new System.Drawing.Point(138, 120);
            this.addActorButton.Name = "addActorButton";
            this.addActorButton.Size = new System.Drawing.Size(75, 23);
            this.addActorButton.TabIndex = 17;
            this.addActorButton.Text = "Add Actor";
            this.addActorButton.UseVisualStyleBackColor = true;
            this.addActorButton.Click += new System.EventHandler(this.OnAddActorButtonClick);
            // 
            // deleteActorButton
            // 
            this.deleteActorButton.Location = new System.Drawing.Point(138, 152);
            this.deleteActorButton.Name = "deleteActorButton";
            this.deleteActorButton.Size = new System.Drawing.Size(75, 23);
            this.deleteActorButton.TabIndex = 16;
            this.deleteActorButton.Text = "Delete Actor";
            this.deleteActorButton.UseVisualStyleBackColor = true;
            this.deleteActorButton.Click += new System.EventHandler(this.OnDeleteActorButtonClick);
            // 
            // movieYearTextBox
            // 
            this.movieYearTextBox.Location = new System.Drawing.Point(505, 84);
            this.movieYearTextBox.Name = "movieYearTextBox";
            this.movieYearTextBox.Size = new System.Drawing.Size(148, 20);
            this.movieYearTextBox.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 402);
            this.Controls.Add(this.movieEditPanel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.gridTitleLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moviePictureBox)).EndInit();
            this.movieEditPanel.ResumeLayout(false);
            this.movieEditPanel.PerformLayout();
            this.movieActorsGroupBox.ResumeLayout(false);
            this.movieActorsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gridTitleLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox movieNameTextBox;
        private System.Windows.Forms.TextBox movieDirectorNameTextBox;
        private System.Windows.Forms.TextBox movieCountryTextBox;
        private System.Windows.Forms.Label movieNameLabel;
        private System.Windows.Forms.Label movieDirectorLabel;
        private System.Windows.Forms.Label movieYearLabel;
        private System.Windows.Forms.Label movieActorsLabel;
        private System.Windows.Forms.Label movieCountryLabel;
        private System.Windows.Forms.Button movieAddButton;
        private System.Windows.Forms.Button movieChangeButton;
        private System.Windows.Forms.Button movieDeleteButton;
        private System.Windows.Forms.ListBox movieActorsListBox;
        private YearTextBox movieYearTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox moviePictureBox;
        private System.Windows.Forms.ToolStripMenuItem openBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMovieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMovieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findMovieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel movieEditPanel;
        private System.Windows.Forms.GroupBox movieActorsGroupBox;
        private System.Windows.Forms.Button deleteActorButton;
        private System.Windows.Forms.Button addActorButton;
        private System.Windows.Forms.TextBox addActorNameTextBox;
    }
}

