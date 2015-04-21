namespace GraphicDesigner
{
    partial class STS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STS));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.line1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.line2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.line3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spline = new System.Windows.Forms.Button();
            this.bezier = new System.Windows.Forms.Button();
            this.brush = new System.Windows.Forms.Button();
            this.Rectangle = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.Point = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.ColorButton, "ColorButton");
            this.ColorButton.ForeColor = System.Drawing.Color.Black;
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.line1ToolStripMenuItem,
            this.line2ToolStripMenuItem,
            this.line3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // line1ToolStripMenuItem
            // 
            this.line1ToolStripMenuItem.Name = "line1ToolStripMenuItem";
            resources.ApplyResources(this.line1ToolStripMenuItem, "line1ToolStripMenuItem");
            this.line1ToolStripMenuItem.Click += new System.EventHandler(this.line1ToolStripMenuItem_Click_1);
            // 
            // line2ToolStripMenuItem
            // 
            this.line2ToolStripMenuItem.Name = "line2ToolStripMenuItem";
            resources.ApplyResources(this.line2ToolStripMenuItem, "line2ToolStripMenuItem");
            this.line2ToolStripMenuItem.Click += new System.EventHandler(this.line2ToolStripMenuItem_Click);
            // 
            // line3ToolStripMenuItem
            // 
            this.line3ToolStripMenuItem.Name = "line3ToolStripMenuItem";
            resources.ApplyResources(this.line3ToolStripMenuItem, "line3ToolStripMenuItem");
            this.line3ToolStripMenuItem.Click += new System.EventHandler(this.line3ToolStripMenuItem_Click);
            // 
            // spline
            // 
            this.spline.Image = global::GraphicDesigner.Properties.Resources.spline1;
            resources.ApplyResources(this.spline, "spline");
            this.spline.Name = "spline";
            this.spline.UseVisualStyleBackColor = true;
            this.spline.Click += new System.EventHandler(this.spline_Click);
            // 
            // bezier
            // 
            resources.ApplyResources(this.bezier, "bezier");
            this.bezier.Image = global::GraphicDesigner.Properties.Resources.bezier1;
            this.bezier.Name = "bezier";
            this.bezier.UseVisualStyleBackColor = true;
            this.bezier.Click += new System.EventHandler(this.bezier_Click);
            // 
            // brush
            // 
            resources.ApplyResources(this.brush, "brush");
            this.brush.ContextMenuStrip = this.contextMenuStrip1;
            this.brush.Name = "brush";
            this.brush.UseVisualStyleBackColor = true;
            this.brush.Click += new System.EventHandler(this.button1_Click);
            // 
            // Rectangle
            // 
            resources.ApplyResources(this.Rectangle, "Rectangle");
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click);
            // 
            // Line
            // 
            resources.ApplyResources(this.Line, "Line");
            this.Line.Cursor = System.Windows.Forms.Cursors.Default;
            this.Line.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Line.Name = "Line";
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Circle
            // 
            resources.ApplyResources(this.Circle, "Circle");
            this.Circle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Circle.Image = global::GraphicDesigner.Properties.Resources.circle;
            this.Circle.Name = "Circle";
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // Point
            // 
            this.Point.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Point, "Point");
            this.Point.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Point.Name = "Point";
            this.Point.UseVisualStyleBackColor = false;
            this.Point.Click += new System.EventHandler(this.Point_Click);
            // 
            // STS
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.spline);
            this.Controls.Add(this.bezier);
            this.Controls.Add(this.brush);
            this.Controls.Add(this.Rectangle);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Circle);
            this.Controls.Add(this.Point);
            this.Controls.Add(this.ColorButton);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "STS";
            this.Load += new System.EventHandler(this.STS_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button Point;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Button brush;
        private System.Windows.Forms.ToolStripMenuItem line1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem line2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem line3ToolStripMenuItem;
        private System.Windows.Forms.Button bezier;
        private System.Windows.Forms.Button spline;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;

     
       // private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
       // private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

