namespace Restaurante.UI
{
    partial class MainMenu
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            button1 = new Button();
            button2 = new Button();
            btnTableManager = new Button();
            button4 = new Button();
            label1 = new Label();
            btnVendaPanel = new Button();
            button3 = new Button();
            lblName = new Label();
            pbStoreLogo = new PictureBox();
            pictureBox2 = new PictureBox();
            imageList1 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)pbStoreLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(79, 174);
            button1.Name = "button1";
            button1.Size = new Size(252, 49);
            button1.TabIndex = 0;
            button1.Text = "Gerenciar Produtos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(79, 254);
            button2.Name = "button2";
            button2.Size = new Size(252, 49);
            button2.TabIndex = 1;
            button2.Text = "Gerenciar Usuarios";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnTableManager
            // 
            btnTableManager.Location = new Point(79, 328);
            btnTableManager.Name = "btnTableManager";
            btnTableManager.Size = new Size(252, 49);
            btnTableManager.TabIndex = 2;
            btnTableManager.Text = "Gerenciar Mesas";
            btnTableManager.UseVisualStyleBackColor = true;
            btnTableManager.Click += btnTableManager_Click;
            // 
            // button4
            // 
            button4.Location = new Point(419, 254);
            button4.Name = "button4";
            button4.Size = new Size(252, 49);
            button4.TabIndex = 3;
            button4.Text = "Descontos";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 5;
            label1.Text = "Voltar";
            label1.Click += label1_Click;
            // 
            // btnVendaPanel
            // 
            btnVendaPanel.Location = new Point(419, 174);
            btnVendaPanel.Name = "btnVendaPanel";
            btnVendaPanel.Size = new Size(252, 49);
            btnVendaPanel.TabIndex = 6;
            btnVendaPanel.Text = "Painel de Vendas";
            btnVendaPanel.UseVisualStyleBackColor = true;
            btnVendaPanel.Click += btnVendaPanel_Click;
            // 
            // button3
            // 
            button3.Location = new Point(419, 328);
            button3.Name = "button3";
            button3.Size = new Size(252, 49);
            button3.TabIndex = 7;
            button3.Text = "Feedbacks";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 20F);
            lblName.Location = new Point(240, 115);
            lblName.Name = "lblName";
            lblName.Size = new Size(282, 37);
            lblName.TabIndex = 8;
            lblName.Text = "MEAT BURGER'N BEER";
            // 
            // pbStoreLogo
            // 
            pbStoreLogo.Location = new Point(326, 21);
            pbStoreLogo.Name = "pbStoreLogo";
            pbStoreLogo.Size = new Size(101, 91);
            pbStoreLogo.TabIndex = 9;
            pbStoreLogo.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo;
            pictureBox2.Location = new Point(12, 393);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(76, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "clickandeat.png");
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(771, 466);
            Controls.Add(pictureBox2);
            Controls.Add(pbStoreLogo);
            Controls.Add(lblName);
            Controls.Add(button3);
            Controls.Add(btnVendaPanel);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(btnTableManager);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainMenu";
            Text = "Menu Principal";
            Load += MainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)pbStoreLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button btnTableManager;
        private Button button4;
        private Panel panel1;
        private Label label1;
        private Button btnVendaPanel;
        private Button button3;
        private Label lblName;
        private PictureBox pbStoreLogo;
        private PictureBox pictureBox2;
        private ImageList imageList1;
    }
}