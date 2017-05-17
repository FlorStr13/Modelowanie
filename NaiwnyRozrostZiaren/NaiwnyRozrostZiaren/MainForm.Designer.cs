namespace NaiwnyRozrostZiaren
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.start_stop = new System.Windows.Forms.Button();
            this.losowoButton = new System.Windows.Forms.Button();
            this.LosowoRButton = new System.Windows.Forms.Button();
            this.rownoButton = new System.Windows.Forms.Button();
            this.iloscText = new System.Windows.Forms.TextBox();
            this.promienText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wielkoscText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.stworzButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // start_stop
            // 
            this.start_stop.Location = new System.Drawing.Point(506, 439);
            this.start_stop.Name = "start_stop";
            this.start_stop.Size = new System.Drawing.Size(170, 55);
            this.start_stop.TabIndex = 1;
            this.start_stop.Text = "Start";
            this.start_stop.UseVisualStyleBackColor = true;
            this.start_stop.Click += new System.EventHandler(this.start_stop_Click);
            // 
            // losowoButton
            // 
            this.losowoButton.Location = new System.Drawing.Point(506, 141);
            this.losowoButton.Name = "losowoButton";
            this.losowoButton.Size = new System.Drawing.Size(85, 45);
            this.losowoButton.TabIndex = 2;
            this.losowoButton.Text = "Losowo";
            this.losowoButton.UseVisualStyleBackColor = true;
            this.losowoButton.Click += new System.EventHandler(this.losowoButton_Click);
            // 
            // LosowoRButton
            // 
            this.LosowoRButton.Location = new System.Drawing.Point(506, 192);
            this.LosowoRButton.Name = "LosowoRButton";
            this.LosowoRButton.Size = new System.Drawing.Size(85, 45);
            this.LosowoRButton.TabIndex = 3;
            this.LosowoRButton.Text = "Losowo z promieniem";
            this.LosowoRButton.UseVisualStyleBackColor = true;
            this.LosowoRButton.Click += new System.EventHandler(this.LosowoRButton_Click);
            // 
            // rownoButton
            // 
            this.rownoButton.Location = new System.Drawing.Point(591, 141);
            this.rownoButton.Name = "rownoButton";
            this.rownoButton.Size = new System.Drawing.Size(85, 45);
            this.rownoButton.TabIndex = 4;
            this.rownoButton.Text = "Równomiernie";
            this.rownoButton.UseVisualStyleBackColor = true;
            this.rownoButton.Click += new System.EventHandler(this.RownoButton_Click);
            // 
            // iloscText
            // 
            this.iloscText.Location = new System.Drawing.Point(591, 116);
            this.iloscText.Name = "iloscText";
            this.iloscText.Size = new System.Drawing.Size(85, 20);
            this.iloscText.TabIndex = 5;
            // 
            // promienText
            // 
            this.promienText.Location = new System.Drawing.Point(591, 217);
            this.promienText.Name = "promienText";
            this.promienText.Size = new System.Drawing.Size(85, 20);
            this.promienText.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(503, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ilosc ziaren:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(597, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Promień:";
            // 
            // wielkoscText
            // 
            this.wielkoscText.Location = new System.Drawing.Point(630, 12);
            this.wielkoscText.Name = "wielkoscText";
            this.wielkoscText.Size = new System.Drawing.Size(46, 20);
            this.wielkoscText.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(508, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Wielkość planszy:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sasiedstwo Von Neumann",
            "Sasiedstwo Moore",
            "Sasiedstwo Heksagonal lewe",
            "Sasiedstwo Heksagonal prawe",
            "Sasiedstwo Heksagonal losowe",
            "Sasiedstwo Pentagonal losowe"});
            this.comboBox1.Location = new System.Drawing.Point(506, 89);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.Text = "Sasiedstwo Von Neumann";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(506, 243);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(173, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Periodyczne warunki brzegowe";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // stworzButton
            // 
            this.stworzButton.Location = new System.Drawing.Point(506, 38);
            this.stworzButton.Name = "stworzButton";
            this.stworzButton.Size = new System.Drawing.Size(170, 45);
            this.stworzButton.TabIndex = 13;
            this.stworzButton.Text = "Stwórz";
            this.stworzButton.UseVisualStyleBackColor = true;
            this.stworzButton.Click += new System.EventHandler(this.stworzButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(684, 504);
            this.Controls.Add(this.stworzButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wielkoscText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.promienText);
            this.Controls.Add(this.iloscText);
            this.Controls.Add(this.rownoButton);
            this.Controls.Add(this.LosowoRButton);
            this.Controls.Add(this.losowoButton);
            this.Controls.Add(this.start_stop);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(700, 543);
            this.MinimumSize = new System.Drawing.Size(700, 543);
            this.Name = "MainForm";
            this.Text = "Naiwyny rozrost ziaren";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button start_stop;
        private System.Windows.Forms.Button losowoButton;
        private System.Windows.Forms.Button LosowoRButton;
        private System.Windows.Forms.Button rownoButton;
        private System.Windows.Forms.TextBox iloscText;
        private System.Windows.Forms.TextBox promienText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wielkoscText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button stworzButton;
    }
}

