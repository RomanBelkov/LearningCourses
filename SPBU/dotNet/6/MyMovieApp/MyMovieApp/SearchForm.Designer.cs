namespace MyMovieApp
{
    partial class SearchForm
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
            this.searchModeGroupBox = new System.Windows.Forms.GroupBox();
            this.regExSearchModeRadioButton = new System.Windows.Forms.RadioButton();
            this.valueSearchModeRadioButton = new System.Windows.Forms.RadioButton();
            this.searchMovieNameTextBox = new System.Windows.Forms.TextBox();
            this.searchMovieCountryTextBox = new System.Windows.Forms.TextBox();
            this.searchMovieActorTextBox = new System.Windows.Forms.TextBox();
            this.searchMovieYearTextBox = new MyMovieApp.YearTextBox();
            this.searchMovieNameLabel = new System.Windows.Forms.Label();
            this.searchMovieYearLabel = new System.Windows.Forms.Label();
            this.searchMovieCountryLabel = new System.Windows.Forms.Label();
            this.searchMovieActorLabel = new System.Windows.Forms.Label();
            this.searchMovieDirectorTextBox = new System.Windows.Forms.TextBox();
            this.searchMovieDirectorLabel = new System.Windows.Forms.Label();
            this.searchSearchButton = new System.Windows.Forms.Button();
            this.searchClearButton = new System.Windows.Forms.Button();
            this.searchErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.searchModeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // searchModeGroupBox
            // 
            this.searchModeGroupBox.Controls.Add(this.regExSearchModeRadioButton);
            this.searchModeGroupBox.Controls.Add(this.valueSearchModeRadioButton);
            this.searchModeGroupBox.Enabled = false;
            this.searchModeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.searchModeGroupBox.Name = "searchModeGroupBox";
            this.searchModeGroupBox.Size = new System.Drawing.Size(242, 68);
            this.searchModeGroupBox.TabIndex = 0;
            this.searchModeGroupBox.TabStop = false;
            this.searchModeGroupBox.Text = "Search mode";
            // 
            // regExSearchModeRadioButton
            // 
            this.regExSearchModeRadioButton.AutoSize = true;
            this.regExSearchModeRadioButton.Location = new System.Drawing.Point(6, 42);
            this.regExSearchModeRadioButton.Name = "regExSearchModeRadioButton";
            this.regExSearchModeRadioButton.Size = new System.Drawing.Size(57, 17);
            this.regExSearchModeRadioButton.TabIndex = 1;
            this.regExSearchModeRadioButton.TabStop = true;
            this.regExSearchModeRadioButton.Text = "RegEx";
            this.regExSearchModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // valueSearchModeRadioButton
            // 
            this.valueSearchModeRadioButton.AutoSize = true;
            this.valueSearchModeRadioButton.Location = new System.Drawing.Point(6, 19);
            this.valueSearchModeRadioButton.Name = "valueSearchModeRadioButton";
            this.valueSearchModeRadioButton.Size = new System.Drawing.Size(52, 17);
            this.valueSearchModeRadioButton.TabIndex = 0;
            this.valueSearchModeRadioButton.TabStop = true;
            this.valueSearchModeRadioButton.Text = "Value";
            this.valueSearchModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // searchMovieNameTextBox
            // 
            this.searchMovieNameTextBox.Location = new System.Drawing.Point(12, 103);
            this.searchMovieNameTextBox.Name = "searchMovieNameTextBox";
            this.searchMovieNameTextBox.Size = new System.Drawing.Size(242, 20);
            this.searchMovieNameTextBox.TabIndex = 1;
            this.searchMovieNameTextBox.TextChanged += new System.EventHandler(this.OnSearchTextBoxTextChanged);
            // 
            // searchMovieCountryTextBox
            // 
            this.searchMovieCountryTextBox.Location = new System.Drawing.Point(12, 181);
            this.searchMovieCountryTextBox.Name = "searchMovieCountryTextBox";
            this.searchMovieCountryTextBox.Size = new System.Drawing.Size(242, 20);
            this.searchMovieCountryTextBox.TabIndex = 2;
            this.searchMovieCountryTextBox.TextChanged += new System.EventHandler(this.OnSearchTextBoxTextChanged);
            // 
            // searchMovieActorTextBox
            // 
            this.searchMovieActorTextBox.Location = new System.Drawing.Point(12, 220);
            this.searchMovieActorTextBox.Name = "searchMovieActorTextBox";
            this.searchMovieActorTextBox.Size = new System.Drawing.Size(242, 20);
            this.searchMovieActorTextBox.TabIndex = 4;
            this.searchMovieActorTextBox.TextChanged += new System.EventHandler(this.OnSearchTextBoxTextChanged);
            // 
            // searchMovieYearTextBox
            // 
            this.searchMovieYearTextBox.Location = new System.Drawing.Point(12, 142);
            this.searchMovieYearTextBox.Name = "searchMovieYearTextBox";
            this.searchMovieYearTextBox.Size = new System.Drawing.Size(242, 20);
            this.searchMovieYearTextBox.TabIndex = 5;
            this.searchMovieYearTextBox.TextChanged += new System.EventHandler(this.OnSearchTextBoxTextChanged);
            // 
            // searchMovieNameLabel
            // 
            this.searchMovieNameLabel.AutoSize = true;
            this.searchMovieNameLabel.Location = new System.Drawing.Point(9, 87);
            this.searchMovieNameLabel.Name = "searchMovieNameLabel";
            this.searchMovieNameLabel.Size = new System.Drawing.Size(67, 13);
            this.searchMovieNameLabel.TabIndex = 6;
            this.searchMovieNameLabel.Text = "Movie Name";
            // 
            // searchMovieYearLabel
            // 
            this.searchMovieYearLabel.AutoSize = true;
            this.searchMovieYearLabel.Location = new System.Drawing.Point(9, 126);
            this.searchMovieYearLabel.Name = "searchMovieYearLabel";
            this.searchMovieYearLabel.Size = new System.Drawing.Size(29, 13);
            this.searchMovieYearLabel.TabIndex = 7;
            this.searchMovieYearLabel.Text = "Year";
            // 
            // searchMovieCountryLabel
            // 
            this.searchMovieCountryLabel.AutoSize = true;
            this.searchMovieCountryLabel.Location = new System.Drawing.Point(9, 165);
            this.searchMovieCountryLabel.Name = "searchMovieCountryLabel";
            this.searchMovieCountryLabel.Size = new System.Drawing.Size(43, 13);
            this.searchMovieCountryLabel.TabIndex = 8;
            this.searchMovieCountryLabel.Text = "Country";
            // 
            // searchMovieActorLabel
            // 
            this.searchMovieActorLabel.AutoSize = true;
            this.searchMovieActorLabel.Location = new System.Drawing.Point(9, 204);
            this.searchMovieActorLabel.Name = "searchMovieActorLabel";
            this.searchMovieActorLabel.Size = new System.Drawing.Size(32, 13);
            this.searchMovieActorLabel.TabIndex = 9;
            this.searchMovieActorLabel.Text = "Actor";
            // 
            // searchMovieDirectorTextBox
            // 
            this.searchMovieDirectorTextBox.Location = new System.Drawing.Point(12, 259);
            this.searchMovieDirectorTextBox.Name = "searchMovieDirectorTextBox";
            this.searchMovieDirectorTextBox.Size = new System.Drawing.Size(242, 20);
            this.searchMovieDirectorTextBox.TabIndex = 10;
            this.searchMovieDirectorTextBox.TextChanged += new System.EventHandler(this.OnSearchTextBoxTextChanged);
            // 
            // searchMovieDirectorLabel
            // 
            this.searchMovieDirectorLabel.AutoSize = true;
            this.searchMovieDirectorLabel.Location = new System.Drawing.Point(9, 243);
            this.searchMovieDirectorLabel.Name = "searchMovieDirectorLabel";
            this.searchMovieDirectorLabel.Size = new System.Drawing.Size(44, 13);
            this.searchMovieDirectorLabel.TabIndex = 11;
            this.searchMovieDirectorLabel.Text = "Director";
            // 
            // searchSearchButton
            // 
            this.searchSearchButton.Location = new System.Drawing.Point(98, 291);
            this.searchSearchButton.Name = "searchSearchButton";
            this.searchSearchButton.Size = new System.Drawing.Size(75, 23);
            this.searchSearchButton.TabIndex = 12;
            this.searchSearchButton.Text = "Search";
            this.searchSearchButton.UseVisualStyleBackColor = true;
            this.searchSearchButton.Click += new System.EventHandler(this.OnSearchSearchClick);
            // 
            // searchClearButton
            // 
            this.searchClearButton.Location = new System.Drawing.Point(179, 291);
            this.searchClearButton.Name = "searchClearButton";
            this.searchClearButton.Size = new System.Drawing.Size(75, 23);
            this.searchClearButton.TabIndex = 13;
            this.searchClearButton.Text = "Clear";
            this.searchClearButton.UseVisualStyleBackColor = true;
            this.searchClearButton.Click += new System.EventHandler(this.OnSearchClearClick);
            // 
            // searchErrorProvider
            // 
            this.searchErrorProvider.ContainerControl = this;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 326);
            this.Controls.Add(this.searchClearButton);
            this.Controls.Add(this.searchSearchButton);
            this.Controls.Add(this.searchMovieDirectorLabel);
            this.Controls.Add(this.searchMovieDirectorTextBox);
            this.Controls.Add(this.searchMovieActorLabel);
            this.Controls.Add(this.searchMovieCountryLabel);
            this.Controls.Add(this.searchMovieYearLabel);
            this.Controls.Add(this.searchMovieNameLabel);
            this.Controls.Add(this.searchMovieYearTextBox);
            this.Controls.Add(this.searchMovieActorTextBox);
            this.Controls.Add(this.searchMovieCountryTextBox);
            this.Controls.Add(this.searchMovieNameTextBox);
            this.Controls.Add(this.searchModeGroupBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnSearchKeyUp);
            this.searchModeGroupBox.ResumeLayout(false);
            this.searchModeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox searchModeGroupBox;
        private System.Windows.Forms.RadioButton regExSearchModeRadioButton;
        private System.Windows.Forms.RadioButton valueSearchModeRadioButton;
        private System.Windows.Forms.TextBox searchMovieNameTextBox;
        private System.Windows.Forms.TextBox searchMovieCountryTextBox;
        private System.Windows.Forms.TextBox searchMovieActorTextBox;
        private YearTextBox searchMovieYearTextBox;
        private System.Windows.Forms.Label searchMovieNameLabel;
        private System.Windows.Forms.Label searchMovieYearLabel;
        private System.Windows.Forms.Label searchMovieCountryLabel;
        private System.Windows.Forms.Label searchMovieActorLabel;
        private System.Windows.Forms.TextBox searchMovieDirectorTextBox;
        private System.Windows.Forms.Label searchMovieDirectorLabel;
        private System.Windows.Forms.Button searchSearchButton;
        private System.Windows.Forms.Button searchClearButton;
        private System.Windows.Forms.ErrorProvider searchErrorProvider;
    }
}