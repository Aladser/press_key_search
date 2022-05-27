namespace PressKeySearch
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.selectLabel = new System.Windows.Forms.Label();
            this.selectBox = new System.Windows.Forms.ComboBox();
            this.officeLabel = new System.Windows.Forms.Label();
            this.officeBox = new System.Windows.Forms.ComboBox();
            this.openButton = new System.Windows.Forms.Button();
            this.aboutImage = new System.Windows.Forms.PictureBox();
            this.infoField = new System.Windows.Forms.RichTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.aboutImage)).BeginInit();
            this.SuspendLayout();
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(358, 12);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(44, 13);
            this.selectLabel.TabIndex = 0;
            this.selectLabel.Text = "Кнопка";
            // 
            // selectBox
            // 
            this.selectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectBox.FormattingEnabled = true;
            this.selectBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.selectBox.Location = new System.Drawing.Point(408, 9);
            this.selectBox.Name = "selectBox";
            this.selectBox.Size = new System.Drawing.Size(121, 21);
            this.selectBox.TabIndex = 1;
            // 
            // officeLabel
            // 
            this.officeLabel.AutoSize = true;
            this.officeLabel.Location = new System.Drawing.Point(190, 12);
            this.officeLabel.Name = "officeLabel";
            this.officeLabel.Size = new System.Drawing.Size(35, 13);
            this.officeLabel.TabIndex = 2;
            this.officeLabel.Text = "Офис";
            // 
            // officeBox
            // 
            this.officeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.officeBox.FormattingEnabled = true;
            this.officeBox.Items.AddRange(new object[] {
            "Офис 1",
            "Офис 2",
            "Офис 3",
            "Белогорск",
            "Свободный",
            "Все офисы"});
            this.officeBox.Location = new System.Drawing.Point(231, 10);
            this.officeBox.Name = "officeBox";
            this.officeBox.Size = new System.Drawing.Size(121, 21);
            this.officeBox.TabIndex = 3;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(535, 9);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(126, 21);
            this.openButton.TabIndex = 4;
            this.openButton.Text = "Получить данные";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // aboutImage
            // 
            this.aboutImage.Image = ((System.Drawing.Image)(resources.GetObject("aboutImage.Image")));
            this.aboutImage.Location = new System.Drawing.Point(879, 8);
            this.aboutImage.Name = "aboutImage";
            this.aboutImage.Size = new System.Drawing.Size(20, 22);
            this.aboutImage.TabIndex = 5;
            this.aboutImage.TabStop = false;
            this.aboutImage.MouseHover += new System.EventHandler(this.aboutImage_MouseHover);
            // 
            // infoField
            // 
            this.infoField.Location = new System.Drawing.Point(13, 45);
            this.infoField.Name = "infoField";
            this.infoField.Size = new System.Drawing.Size(886, 365);
            this.infoField.TabIndex = 6;
            this.infoField.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 428);
            this.Controls.Add(this.infoField);
            this.Controls.Add(this.aboutImage);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.officeBox);
            this.Controls.Add(this.officeLabel);
            this.Controls.Add(this.selectBox);
            this.Controls.Add(this.selectLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Поиск вызовов кнопок";
            ((System.ComponentModel.ISupportInitialize)(this.aboutImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.ComboBox selectBox;
        private System.Windows.Forms.Label officeLabel;
        private System.Windows.Forms.ComboBox officeBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.PictureBox aboutImage;
        private System.Windows.Forms.RichTextBox infoField;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

