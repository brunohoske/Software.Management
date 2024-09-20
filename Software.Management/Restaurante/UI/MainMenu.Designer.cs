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
            button1 = new Button();
            button2 = new Button();
            btnTableManager = new Button();
            button4 = new Button();
            label1 = new Label();
            btnVendaPanel = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(39, 71);
            button1.Name = "button1";
            button1.Size = new Size(252, 49);
            button1.TabIndex = 0;
            button1.Text = "Gerenciar Produtos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(39, 151);
            button2.Name = "button2";
            button2.Size = new Size(252, 49);
            button2.TabIndex = 1;
            button2.Text = "Gerenciar Usuarios";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnTableManager
            // 
            btnTableManager.Location = new Point(39, 236);
            btnTableManager.Name = "btnTableManager";
            btnTableManager.Size = new Size(252, 49);
            btnTableManager.TabIndex = 2;
            btnTableManager.Text = "Gerenciar Mesas";
            btnTableManager.UseVisualStyleBackColor = true;
            btnTableManager.Click += btnTableManager_Click;
            // 
            // button4
            // 
            button4.Location = new Point(39, 315);
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
            btnVendaPanel.Location = new Point(493, 71);
            btnVendaPanel.Name = "btnVendaPanel";
            btnVendaPanel.Size = new Size(252, 49);
            btnVendaPanel.TabIndex = 6;
            btnVendaPanel.Text = "Painel de Vendas";
            btnVendaPanel.UseVisualStyleBackColor = true;
            btnVendaPanel.Click += btnVendaPanel_Click;
            // 
            // button3
            // 
            button3.Location = new Point(493, 151);
            button3.Name = "button3";
            button3.Size = new Size(252, 49);
            button3.TabIndex = 7;
            button3.Text = "Feedbacks";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(btnVendaPanel);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(btnTableManager);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainMenu";
            Text = "Tela Gestão";
            Load += MainMenu_Load;
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
    }
}