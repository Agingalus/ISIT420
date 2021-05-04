namespace Order500HW3
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
            this.employeeButton = new System.Windows.Forms.Button();
            this.storeSelect = new System.Windows.Forms.Button();
            this.employeeList = new System.Windows.Forms.ComboBox();
            this.storeList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // employeeButton
            // 
            this.employeeButton.Location = new System.Drawing.Point(133, 85);
            this.employeeButton.Name = "employeeButton";
            this.employeeButton.Size = new System.Drawing.Size(132, 23);
            this.employeeButton.TabIndex = 0;
            this.employeeButton.Text = "Select Employee";
            this.employeeButton.UseVisualStyleBackColor = true;
            this.employeeButton.Click += new System.EventHandler(this.employeeButton_Click);
            // 
            // storeSelect
            // 
            this.storeSelect.Location = new System.Drawing.Point(590, 104);
            this.storeSelect.Name = "storeSelect";
            this.storeSelect.Size = new System.Drawing.Size(75, 23);
            this.storeSelect.TabIndex = 1;
            this.storeSelect.Text = "Select Store";
            this.storeSelect.UseVisualStyleBackColor = true;
            this.storeSelect.Click += new System.EventHandler(this.storeSelect_Click);
            // 
            // employeeList
            // 
            this.employeeList.Location = new System.Drawing.Point(133, 147);
            this.employeeList.Name = "employeeList";
            this.employeeList.Size = new System.Drawing.Size(121, 21);
            this.employeeList.TabIndex = 4;
            this.employeeList.SelectedIndexChanged += new System.EventHandler(this.employeeList_SelectedIndexChanged);
            // 
            // storeList
            // 
            this.storeList.FormattingEnabled = true;
            this.storeList.Location = new System.Drawing.Point(616, 168);
            this.storeList.Name = "storeList";
            this.storeList.Size = new System.Drawing.Size(121, 21);
            this.storeList.TabIndex = 3;
            this.storeList.SelectedIndexChanged += new System.EventHandler(this.storeList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 540);
            this.Controls.Add(this.storeList);
            this.Controls.Add(this.employeeList);
            this.Controls.Add(this.storeSelect);
            this.Controls.Add(this.employeeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button employeeButton;
        private System.Windows.Forms.Button storeSelect;
        private System.Windows.Forms.ComboBox employeeList;
        private System.Windows.Forms.ComboBox storeList;
    }
}

