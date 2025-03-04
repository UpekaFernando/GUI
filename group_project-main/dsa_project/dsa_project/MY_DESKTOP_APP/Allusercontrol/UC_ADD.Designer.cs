namespace MY_DESKTOP_APP.Allusercontrol
{
    partial class UC_ADD
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txttype = new ComboBox();
            txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            AddItem = new Guna.UI2.WinForms.Guna2Button();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            label5 = new Label();
            txtname = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(320, 12);
            label1.Name = "label1";
            label1.Size = new Size(176, 31);
            label1.TabIndex = 0;
            label1.Text = "ADD TO STOCK";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.OrangeRed;
            label2.Location = new Point(173, 69);
            label2.Name = "label2";
            label2.Size = new Size(57, 28);
            label2.TabIndex = 1;
            label2.Text = "Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.OrangeRed;
            label3.Location = new Point(173, 164);
            label3.Name = "label3";
            label3.Size = new Size(95, 28);
            label3.TabIndex = 2;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.OrangeRed;
            label4.Location = new Point(173, 338);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 3;
            label4.Text = "Price";
            // 
            // txttype
            // 
            txttype.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txttype.ForeColor = SystemColors.ActiveCaptionText;
            txttype.FormattingEnabled = true;
            txttype.Items.AddRange(new object[] { "Toyota", "Nissan", "Mitsubishi" });
            txttype.Location = new Point(173, 115);
            txttype.Name = "txttype";
            txttype.Size = new Size(386, 36);
            txttype.TabIndex = 4;
            txttype.SelectedIndexChanged += txttype_SelectedIndexChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.BackColor = Color.Black;
            txtQuantity.BorderColor = Color.Black;
            txtQuantity.BorderThickness = 2;
            txtQuantity.CustomizableEdges = customizableEdges1;
            txtQuantity.DefaultText = "";
            txtQuantity.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtQuantity.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtQuantity.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtQuantity.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtQuantity.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuantity.ForeColor = SystemColors.ActiveCaptionText;
            txtQuantity.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtQuantity.Location = new Point(173, 207);
            txtQuantity.Margin = new Padding(4, 6, 4, 6);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.PasswordChar = '\0';
            txtQuantity.PlaceholderText = "";
            txtQuantity.SelectedText = "";
            txtQuantity.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtQuantity.Size = new Size(531, 36);
            txtQuantity.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            txtQuantity.TabIndex = 5;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.Black;
            txtPrice.BorderColor = Color.Black;
            txtPrice.BorderThickness = 2;
            txtPrice.CustomizableEdges = customizableEdges3;
            txtPrice.DefaultText = "";
            txtPrice.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPrice.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPrice.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPrice.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPrice.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.ForeColor = SystemColors.ActiveCaptionText;
            txtPrice.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPrice.Location = new Point(173, 372);
            txtPrice.Margin = new Padding(4, 6, 4, 6);
            txtPrice.Name = "txtPrice";
            txtPrice.PasswordChar = '\0';
            txtPrice.PlaceholderText = "";
            txtPrice.SelectedText = "";
            txtPrice.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPrice.Size = new Size(531, 40);
            txtPrice.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            txtPrice.TabIndex = 6;
            // 
            // AddItem
            // 
            AddItem.BorderRadius = 20;
            AddItem.CustomizableEdges = customizableEdges5;
            AddItem.DisabledState.BorderColor = Color.DarkGray;
            AddItem.DisabledState.CustomBorderColor = Color.DarkGray;
            AddItem.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddItem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddItem.FillColor = Color.Coral;
            AddItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddItem.ForeColor = Color.Firebrick;
            AddItem.Location = new Point(290, 437);
            AddItem.Name = "AddItem";
            AddItem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            AddItem.Size = new Size(196, 56);
            AddItem.TabIndex = 7;
            AddItem.Text = "ADD";
            AddItem.Click += AddItem_Click;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 30;
            guna2Elipse1.TargetControl = this;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.OrangeRed;
            label5.Location = new Point(173, 259);
            label5.Name = "label5";
            label5.Size = new Size(68, 28);
            label5.TabIndex = 8;
            label5.Text = "Brand";
            // 
            // txtname
            // 
            txtname.BackColor = Color.Black;
            txtname.BorderColor = Color.Black;
            txtname.BorderThickness = 2;
            txtname.CustomizableEdges = customizableEdges7;
            txtname.DefaultText = "";
            txtname.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtname.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtname.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtname.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtname.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtname.ForeColor = SystemColors.ActiveCaptionText;
            txtname.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtname.Location = new Point(173, 293);
            txtname.Margin = new Padding(4, 6, 4, 6);
            txtname.Name = "txtname";
            txtname.PasswordChar = '\0';
            txtname.PlaceholderText = "";
            txtname.SelectedText = "";
            txtname.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtname.Size = new Size(531, 40);
            txtname.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            txtname.TabIndex = 9;
            // 
            // UC_ADD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(txtname);
            Controls.Add(label5);
            Controls.Add(AddItem);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(txttype);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UC_ADD";
            Size = new Size(781, 514);
            Leave += UC_ADD_Leave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox txttype;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantity;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private Guna.UI2.WinForms.Guna2Button AddItem;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox txtname;
        private Label label5;
    }
}
