namespace ServidorMensajes01
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
            this.label1 = new System.Windows.Forms.Label();
            this.listanodos = new System.Windows.Forms.ListBox();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.txtmensaje = new System.Windows.Forms.TextBox();
            this.btnenviar = new System.Windows.Forms.Button();
            this.txtregistro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nodos conectados:";
            // 
            // listanodos
            // 
            this.listanodos.FormattingEnabled = true;
            this.listanodos.ItemHeight = 16;
            this.listanodos.Location = new System.Drawing.Point(12, 48);
            this.listanodos.Name = "listanodos";
            this.listanodos.Size = new System.Drawing.Size(182, 228);
            this.listanodos.TabIndex = 1;
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.Location = new System.Drawing.Point(233, 28);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(65, 17);
            this.lblmensaje.TabIndex = 2;
            this.lblmensaje.Text = "Mensaje:";
            // 
            // txtmensaje
            // 
            this.txtmensaje.Location = new System.Drawing.Point(236, 48);
            this.txtmensaje.Multiline = true;
            this.txtmensaje.Name = "txtmensaje";
            this.txtmensaje.Size = new System.Drawing.Size(393, 123);
            this.txtmensaje.TabIndex = 3;
            // 
            // btnenviar
            // 
            this.btnenviar.Location = new System.Drawing.Point(548, 187);
            this.btnenviar.Name = "btnenviar";
            this.btnenviar.Size = new System.Drawing.Size(75, 23);
            this.btnenviar.TabIndex = 4;
            this.btnenviar.Text = "Enviar";
            this.btnenviar.UseVisualStyleBackColor = true;
            this.btnenviar.Click += new System.EventHandler(this.btnenviar_Click);
            // 
            // txtregistro
            // 
            this.txtregistro.AcceptsReturn = true;
            this.txtregistro.AcceptsTab = true;
            this.txtregistro.Location = new System.Drawing.Point(236, 254);
            this.txtregistro.Multiline = true;
            this.txtregistro.Name = "txtregistro";
            this.txtregistro.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtregistro.Size = new System.Drawing.Size(393, 180);
            this.txtregistro.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 446);
            this.Controls.Add(this.txtregistro);
            this.Controls.Add(this.btnenviar);
            this.Controls.Add(this.txtmensaje);
            this.Controls.Add(this.lblmensaje);
            this.Controls.Add(this.listanodos);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listanodos;
        private System.Windows.Forms.Label lblmensaje;
        private System.Windows.Forms.TextBox txtmensaje;
        private System.Windows.Forms.Button btnenviar;
        private System.Windows.Forms.TextBox txtregistro;
    }
}

