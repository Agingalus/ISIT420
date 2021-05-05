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
            this.label1 = new System.Windows.Forms.Label();
            this.markUps = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // employeeButton
            // 
            this.employeeButton.Location = new System.Drawing.Point(376, 413);
            this.employeeButton.Margin = new System.Windows.Forms.Padding(4);
            this.employeeButton.Name = "employeeButton";
            this.employeeButton.Size = new System.Drawing.Size(176, 28);
            this.employeeButton.TabIndex = 0;
            this.employeeButton.Text = "Select Employee";
            this.employeeButton.UseVisualStyleBackColor = true;
            this.employeeButton.Click += new System.EventHandler(this.employeeButton_Click);
            // 
            // storeSelect
            // 
            this.storeSelect.Location = new System.Drawing.Point(1027, 113);
            this.storeSelect.Margin = new System.Windows.Forms.Padding(4);
            this.storeSelect.Name = "storeSelect";
            this.storeSelect.Size = new System.Drawing.Size(100, 28);
            this.storeSelect.TabIndex = 1;
            this.storeSelect.Text = "Select Store";
            this.storeSelect.UseVisualStyleBackColor = true;
            this.storeSelect.Click += new System.EventHandler(this.storeSelect_Click);
            // 
            // employeeList
            // 
            this.employeeList.Location = new System.Drawing.Point(105, 413);
            this.employeeList.Margin = new System.Windows.Forms.Padding(4);
            this.employeeList.Name = "employeeList";
            this.employeeList.Size = new System.Drawing.Size(160, 24);
            this.employeeList.TabIndex = 4;
            // 
            // storeList
            // 
            this.storeList.FormattingEnabled = true;
            this.storeList.Location = new System.Drawing.Point(778, 113);
            this.storeList.Margin = new System.Windows.Forms.Padding(4);
            this.storeList.Name = "storeList";
            this.storeList.Size = new System.Drawing.Size(160, 24);
            this.storeList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 58);
            this.label1.TabIndex = 5;
            this.label1.Text = "Which Stores are selling CDs for better markups? (price more than $13)\r\nHere are " +
    "the total number of sales per store of CD\'s sold at more than $13";
            // 
            // markUps
            // 
            this.markUps.Location = new System.Drawing.Point(105, 113);
            this.markUps.Name = "markUps";
            this.markUps.Size = new System.Drawing.Size(107, 40);
            this.markUps.TabIndex = 6;
            this.markUps.Text = "Get Markups\r\n";
            this.markUps.UseVisualStyleBackColor = true;
            this.markUps.Click += new System.EventHandler(this.markUps_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(517, 96);
            this.label2.TabIndex = 7;
            this.label2.Text = "I want to check on the performance of an employee.\r\nWill show the total amount so" +
    "ld for a salesperson for the entire year";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(773, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(423, 44);
            this.label3.TabIndex = 8;
            this.label3.Text = "I want to see the performance of my stores";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 665);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.markUps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.storeList);
            this.Controls.Add(this.employeeList);
            this.Controls.Add(this.storeSelect);
            this.Controls.Add(this.employeeButton);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button markUps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

