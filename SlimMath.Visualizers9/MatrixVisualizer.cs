using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace SlimMath.Visualizers9 {
	class MatrixVisualizerForm : Form {
		private Label label1;
		private TextBox M11;
		private TextBox M21;
		private Label label2;
		private TextBox M31;
		private Label label3;
		private TextBox M41;
		private TextBox M42;
		private Label label5;
		private TextBox M32;
		private Label label6;
		private TextBox M22;
		private Label label7;
		private TextBox M12;
		private Label label8;
		private TextBox M43;
		private Label label9;
		private TextBox M33;
		private Label label10;
		private TextBox M23;
		private Label label11;
		private TextBox M13;
		private Label label12;
		private TextBox M44;
		private Label label13;
		private TextBox M34;
		private Label label14;
		private TextBox M24;
		private Label label15;
		private TextBox M14;
		private Label label16;
		private Button button1;
		private Label label4;

		public MatrixVisualizerForm() {
			InitializeComponent();
		}

		public MatrixVisualizerForm(Matrix matrix) {
			InitializeComponent();

			M11.Text = matrix.M11.ToString();
			M12.Text = matrix.M12.ToString();
			M13.Text = matrix.M13.ToString();
			M14.Text = matrix.M14.ToString();

			M21.Text = matrix.M21.ToString();
			M22.Text = matrix.M22.ToString();
			M23.Text = matrix.M23.ToString();
			M24.Text = matrix.M24.ToString();

			M31.Text = matrix.M31.ToString();
			M32.Text = matrix.M32.ToString();
			M33.Text = matrix.M33.ToString();
			M34.Text = matrix.M34.ToString();

			M41.Text = matrix.M41.ToString();
			M42.Text = matrix.M42.ToString();
			M43.Text = matrix.M43.ToString();
			M44.Text = matrix.M44.ToString();
		}

		public Matrix GetMatrix() {
			var matrix = new Matrix {
				M11 = float.Parse(M11.Text),
				M12 = float.Parse(M12.Text),
				M13 = float.Parse(M13.Text),
				M14 = float.Parse(M14.Text),
				M21 = float.Parse(M21.Text),
				M22 = float.Parse(M22.Text),
				M23 = float.Parse(M23.Text),
				M24 = float.Parse(M24.Text),
				M31 = float.Parse(M31.Text),
				M32 = float.Parse(M32.Text),
				M33 = float.Parse(M33.Text),
				M34 = float.Parse(M34.Text),
				M41 = float.Parse(M41.Text),
				M42 = float.Parse(M42.Text),
				M43 = float.Parse(M43.Text),
				M44 = float.Parse(M44.Text),
			};

			return matrix;
		}

		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.M11 = new System.Windows.Forms.TextBox();
			this.M21 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.M31 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.M41 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.M42 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.M32 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.M22 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.M12 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.M43 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.M33 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.M23 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.M13 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.M44 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.M34 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.M24 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.M14 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "M11";
			// 
			// M11
			// 
			this.M11.Location = new System.Drawing.Point(41, 12);
			this.M11.Name = "M11";
			this.M11.Size = new System.Drawing.Size(100, 20);
			this.M11.TabIndex = 1;
			// 
			// M21
			// 
			this.M21.Location = new System.Drawing.Point(41, 38);
			this.M21.Name = "M21";
			this.M21.Size = new System.Drawing.Size(100, 20);
			this.M21.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "M21";
			// 
			// M31
			// 
			this.M31.Location = new System.Drawing.Point(41, 64);
			this.M31.Name = "M31";
			this.M31.Size = new System.Drawing.Size(100, 20);
			this.M31.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "M31";
			// 
			// M41
			// 
			this.M41.Location = new System.Drawing.Point(41, 90);
			this.M41.Name = "M41";
			this.M41.Size = new System.Drawing.Size(100, 20);
			this.M41.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "M41";
			// 
			// M42
			// 
			this.M42.Location = new System.Drawing.Point(186, 90);
			this.M42.Name = "M42";
			this.M42.Size = new System.Drawing.Size(100, 20);
			this.M42.TabIndex = 15;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(152, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(28, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "M42";
			// 
			// M32
			// 
			this.M32.Location = new System.Drawing.Point(186, 64);
			this.M32.Name = "M32";
			this.M32.Size = new System.Drawing.Size(100, 20);
			this.M32.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(152, 67);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(28, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "M32";
			// 
			// M22
			// 
			this.M22.Location = new System.Drawing.Point(186, 38);
			this.M22.Name = "M22";
			this.M22.Size = new System.Drawing.Size(100, 20);
			this.M22.TabIndex = 11;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(152, 41);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(28, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "M22";
			// 
			// M12
			// 
			this.M12.Location = new System.Drawing.Point(186, 12);
			this.M12.Name = "M12";
			this.M12.Size = new System.Drawing.Size(100, 20);
			this.M12.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(152, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(28, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "M12";
			// 
			// M43
			// 
			this.M43.Location = new System.Drawing.Point(331, 90);
			this.M43.Name = "M43";
			this.M43.Size = new System.Drawing.Size(100, 20);
			this.M43.TabIndex = 23;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(297, 93);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(28, 13);
			this.label9.TabIndex = 22;
			this.label9.Text = "M43";
			// 
			// M33
			// 
			this.M33.Location = new System.Drawing.Point(331, 64);
			this.M33.Name = "M33";
			this.M33.Size = new System.Drawing.Size(100, 20);
			this.M33.TabIndex = 21;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(297, 67);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(28, 13);
			this.label10.TabIndex = 20;
			this.label10.Text = "M33";
			// 
			// M23
			// 
			this.M23.Location = new System.Drawing.Point(331, 38);
			this.M23.Name = "M23";
			this.M23.Size = new System.Drawing.Size(100, 20);
			this.M23.TabIndex = 19;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(297, 41);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(28, 13);
			this.label11.TabIndex = 18;
			this.label11.Text = "M23";
			// 
			// M13
			// 
			this.M13.Location = new System.Drawing.Point(331, 12);
			this.M13.Name = "M13";
			this.M13.Size = new System.Drawing.Size(100, 20);
			this.M13.TabIndex = 17;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(297, 15);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(28, 13);
			this.label12.TabIndex = 16;
			this.label12.Text = "M13";
			// 
			// M44
			// 
			this.M44.Location = new System.Drawing.Point(476, 90);
			this.M44.Name = "M44";
			this.M44.Size = new System.Drawing.Size(100, 20);
			this.M44.TabIndex = 31;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(442, 93);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(28, 13);
			this.label13.TabIndex = 30;
			this.label13.Text = "M44";
			// 
			// M34
			// 
			this.M34.Location = new System.Drawing.Point(476, 64);
			this.M34.Name = "M34";
			this.M34.Size = new System.Drawing.Size(100, 20);
			this.M34.TabIndex = 29;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(442, 67);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(28, 13);
			this.label14.TabIndex = 28;
			this.label14.Text = "M34";
			// 
			// M24
			// 
			this.M24.Location = new System.Drawing.Point(476, 38);
			this.M24.Name = "M24";
			this.M24.Size = new System.Drawing.Size(100, 20);
			this.M24.TabIndex = 27;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(442, 41);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(28, 13);
			this.label15.TabIndex = 26;
			this.label15.Text = "M24";
			// 
			// M14
			// 
			this.M14.Location = new System.Drawing.Point(476, 12);
			this.M14.Name = "M14";
			this.M14.Size = new System.Drawing.Size(100, 20);
			this.M14.TabIndex = 25;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(442, 15);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(28, 13);
			this.label16.TabIndex = 24;
			this.label16.Text = "M14";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(250, 116);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 32;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MatrixVisualizerForm
			// 
			this.ClientSize = new System.Drawing.Size(588, 142);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.M44);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.M34);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.M24);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.M14);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.M43);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.M33);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.M23);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.M13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.M42);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.M32);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.M22);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.M12);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.M41);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.M31);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.M21);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.M11);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MatrixVisualizerForm";
			this.Text = "Matrix";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void button1_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}
	}
	class MatrixVisualizer : DialogDebuggerVisualizer {
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider) {
			var matrix = (Matrix) objectProvider.GetObject();
			using (var form = new MatrixVisualizerForm(matrix)) {
				form.ShowDialog();
				try {
					matrix = form.GetMatrix();
					objectProvider.ReplaceObject(matrix);
				} catch {
				}
			}
		}
	}
}
