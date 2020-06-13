using System;

namespace Lab_1
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.RichTextBox output_field;
        private System.Windows.Forms.TextBox search_file_field;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox choose_folder_field;
        private System.Windows.Forms.FolderBrowserDialog choose_folder;
        private System.Windows.Forms.Button choose_folder_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox files_list;
        private System.Windows.Forms.Button open_file_button;
        private System.Windows.Forms.Label file_label;
        private System.Windows.Forms.Label folder_label;
        private System.Windows.Forms.Label files_label;
    }
}