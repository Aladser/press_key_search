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
            this.selectQualityElement = new System.Windows.Forms.ComboBox();
            this.officeLabel = new System.Windows.Forms.Label();
            this.officeBox = new System.Windows.Forms.ComboBox();
            this.openButton = new System.Windows.Forms.Button();
            this.aboutImage = new System.Windows.Forms.PictureBox();
            this.infoField = new System.Windows.Forms.RichTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.selectedUnitsComboBox = new System.Windows.Forms.ComboBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.windowLabel = new System.Windows.Forms.Label();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.progressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.aboutImage)).BeginInit();
            this.SuspendLayout();
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(206, 17);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(44, 13);
            this.selectLabel.TabIndex = 0;
            this.selectLabel.Text = "Кнопка";
            // 
            // selectQualityElement
            // 
            this.selectQualityElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectQualityElement.FormattingEnabled = true;
            this.selectQualityElement.Items.AddRange(new object[] {
            "зеленая",
            "серая",
            "красная"});
            this.selectQualityElement.Location = new System.Drawing.Point(256, 14);
            this.selectQualityElement.Name = "selectQualityElement";
            this.selectQualityElement.Size = new System.Drawing.Size(121, 21);
            this.selectQualityElement.TabIndex = 1;
            // 
            // officeLabel
            // 
            this.officeLabel.AutoSize = true;
            this.officeLabel.Location = new System.Drawing.Point(38, 17);
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
            "Все офисы",
            "Офис 1",
            "Офис 2",
            "Офис 3",
            "Белогорск",
            "Свободный",
            "Тында"});
            this.officeBox.Location = new System.Drawing.Point(79, 14);
            this.officeBox.Name = "officeBox";
            this.officeBox.Size = new System.Drawing.Size(121, 21);
            this.officeBox.TabIndex = 3;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(383, 14);
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
            this.aboutImage.Location = new System.Drawing.Point(879, 13);
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
            // selectedUnitsComboBox
            // 
            this.selectedUnitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedUnitsComboBox.FormattingEnabled = true;
            this.selectedUnitsComboBox.Items.AddRange(new object[] {
            "Все"});
            this.selectedUnitsComboBox.Location = new System.Drawing.Point(611, 14);
            this.selectedUnitsComboBox.Name = "selectedUnitsComboBox";
            this.selectedUnitsComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectedUnitsComboBox.TabIndex = 7;
            this.selectedUnitsComboBox.SelectedValueChanged += new System.EventHandler(this.selectedUnitsComboBox_SelectedValueChanged);
            // 
            // filterButton
            // 
            this.filterButton.Enabled = false;
            this.filterButton.Location = new System.Drawing.Point(738, 14);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 21);
            this.filterButton.TabIndex = 8;
            this.filterButton.Text = "Фильтр";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // windowLabel
            // 
            this.windowLabel.Location = new System.Drawing.Point(567, 17);
            this.windowLabel.Name = "windowLabel";
            this.windowLabel.Size = new System.Drawing.Size(38, 18);
            this.windowLabel.TabIndex = 9;
            this.windowLabel.Text = "Окна";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(829, 17);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(16, 13);
            this.progressLabel.TabIndex = 10;
            this.progressLabel.Text = "   ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 428);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.windowLabel);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.selectedUnitsComboBox);
            this.Controls.Add(this.infoField);
            this.Controls.Add(this.aboutImage);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.officeBox);
            this.Controls.Add(this.officeLabel);
            this.Controls.Add(this.selectQualityElement);
            this.Controls.Add(this.selectLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Поиск нажатий кнопок 1.12";
            ((System.ComponentModel.ISupportInitialize)(this.aboutImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.ComboBox selectQualityElement;
        private System.Windows.Forms.Label officeLabel;
        private System.Windows.Forms.ComboBox officeBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.PictureBox aboutImage;
        private System.Windows.Forms.RichTextBox infoField;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox selectedUnitsComboBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Label windowLabel;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.Label progressLabel;
    }
}

