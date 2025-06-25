namespace _25_06_2025_p32_bx
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxQuery = new TextBox();
            buttonSearch = new Button();
            checkedListBoxSearchEngines = new CheckedListBox();
            radioButtonTextSearch = new RadioButton();
            radioButtonImageSearch = new RadioButton();
            tabControlResults = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabControlResults.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxQuery
            // 
            textBoxQuery.Location = new Point(135, 8);
            textBoxQuery.Name = "textBoxQuery";
            textBoxQuery.Size = new Size(653, 23);
            textBoxQuery.TabIndex = 0;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(12, 7);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(117, 23);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxSearchEngines
            // 
            checkedListBoxSearchEngines.FormattingEnabled = true;
            checkedListBoxSearchEngines.Items.AddRange(new object[] { "Google", "Bing", "DuckDuckGo" });
            checkedListBoxSearchEngines.Location = new Point(12, 37);
            checkedListBoxSearchEngines.Name = "checkedListBoxSearchEngines";
            checkedListBoxSearchEngines.Size = new Size(120, 94);
            checkedListBoxSearchEngines.TabIndex = 2;
            // 
            // radioButtonTextSearch
            // 
            radioButtonTextSearch.AutoSize = true;
            radioButtonTextSearch.Location = new Point(12, 137);
            radioButtonTextSearch.Name = "radioButtonTextSearch";
            radioButtonTextSearch.Size = new Size(81, 19);
            radioButtonTextSearch.TabIndex = 3;
            radioButtonTextSearch.TabStop = true;
            radioButtonTextSearch.Text = "TextSearch";
            radioButtonTextSearch.UseVisualStyleBackColor = true;
            // 
            // radioButtonImageSearch
            // 
            radioButtonImageSearch.AutoSize = true;
            radioButtonImageSearch.Location = new Point(12, 162);
            radioButtonImageSearch.Name = "radioButtonImageSearch";
            radioButtonImageSearch.Size = new Size(93, 19);
            radioButtonImageSearch.TabIndex = 4;
            radioButtonImageSearch.TabStop = true;
            radioButtonImageSearch.Text = "ImageSearch";
            radioButtonImageSearch.UseVisualStyleBackColor = true;
            // 
            // tabControlResults
            // 
            tabControlResults.Controls.Add(tabPage1);
            tabControlResults.Controls.Add(tabPage2);
            tabControlResults.Location = new Point(224, 37);
            tabControlResults.Name = "tabControlResults";
            tabControlResults.SelectedIndex = 0;
            tabControlResults.Size = new Size(564, 369);
            tabControlResults.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(556, 341);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(192, 72);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlResults);
            Controls.Add(radioButtonImageSearch);
            Controls.Add(radioButtonTextSearch);
            Controls.Add(checkedListBoxSearchEngines);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxQuery);
            Name = "Form1";
            Text = "Form1";
            tabControlResults.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxQuery;
        private Button buttonSearch;
        private CheckedListBox checkedListBoxSearchEngines;
        private RadioButton radioButtonTextSearch;
        private RadioButton radioButtonImageSearch;
        private TabControl tabControlResults;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
