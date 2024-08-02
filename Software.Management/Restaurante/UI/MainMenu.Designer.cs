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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(45, 95);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(288, 65);
            button1.TabIndex = 0;
            button1.Text = "Cadastrar Produto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(45, 201);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(288, 65);
            button2.TabIndex = 1;
            button2.Text = "Gerenciar Usuarios";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnTableManager
            // 
            btnTableManager.Location = new Point(45, 315);
            btnTableManager.Margin = new Padding(3, 4, 3, 4);
            btnTableManager.Name = "btnTableManager";
            btnTableManager.Size = new Size(288, 65);
            btnTableManager.TabIndex = 2;
            btnTableManager.Text = "Gerenciar Mesas";
            btnTableManager.UseVisualStyleBackColor = true;
            btnTableManager.Click += btnTableManager_Click;
            // 
            // button4
            // 
            button4.Location = new Point(45, 420);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(288, 65);
            button4.TabIndex = 3;
            button4.Text = "Descontos";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 16);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 5;
            label1.Text = "Voltar";
            label1.Click += label1_Click;
            // 
            // btnVendaPanel
            // 
            btnVendaPanel.Location = new Point(563, 95);
            btnVendaPanel.Margin = new Padding(3, 4, 3, 4);
            btnVendaPanel.Name = "btnVendaPanel";
            btnVendaPanel.Size = new Size(288, 65);
            btnVendaPanel.TabIndex = 6;
            btnVendaPanel.Text = "Painel de Vendas";
            btnVendaPanel.UseVisualStyleBackColor = true;
            btnVendaPanel.Click += btnVendaPanel_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnVendaPanel);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(btnTableManager);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
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
    }
}