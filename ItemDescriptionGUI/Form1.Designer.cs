namespace ItemDescriptionGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlRW = new System.Windows.Forms.Panel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnAppendPack = new System.Windows.Forms.Button();
            this.btnAppendCan = new System.Windows.Forms.Button();
            this.btnAppendBottle = new System.Windows.Forms.Button();
            this.chkGoogleUPC = new System.Windows.Forms.CheckBox();
            this.chkAutoFormat = new System.Windows.Forms.CheckBox();
            this.btnWebSearch2 = new System.Windows.Forms.Button();
            this.btnWebSearch = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblDescSize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNewBrand = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblcsvIndex = new System.Windows.Forms.Label();
            this.pnlRO = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUPC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtSignDesc = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.numRowOffset = new System.Windows.Forms.NumericUpDown();
            this.btnBegin = new System.Windows.Forms.Button();
            this.rchBuffer = new System.Windows.Forms.RichTextBox();
            this.chkNoScrape = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCarryOver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.btnCarryOver2 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSaveTime = new System.Windows.Forms.Label();
            this.btnCarryOverBrand = new System.Windows.Forms.Button();
            this.pnlRW.SuspendLayout();
            this.pnlRO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRowOffset)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRW
            // 
            this.pnlRW.BackColor = System.Drawing.Color.LightGray;
            this.pnlRW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRW.Controls.Add(this.btnSkip);
            this.pnlRW.Controls.Add(this.btnAppendPack);
            this.pnlRW.Controls.Add(this.btnAppendCan);
            this.pnlRW.Controls.Add(this.btnAppendBottle);
            this.pnlRW.Controls.Add(this.chkGoogleUPC);
            this.pnlRW.Controls.Add(this.chkAutoFormat);
            this.pnlRW.Controls.Add(this.btnWebSearch2);
            this.pnlRW.Controls.Add(this.btnWebSearch);
            this.pnlRW.Controls.Add(this.btnNext);
            this.pnlRW.Controls.Add(this.lblDescSize);
            this.pnlRW.Controls.Add(this.label8);
            this.pnlRW.Controls.Add(this.txtNotes);
            this.pnlRW.Controls.Add(this.label7);
            this.pnlRW.Controls.Add(this.txtNewBrand);
            this.pnlRW.Controls.Add(this.label6);
            this.pnlRW.Controls.Add(this.txtNewDescription);
            this.pnlRW.Location = new System.Drawing.Point(378, 201);
            this.pnlRW.Name = "pnlRW";
            this.pnlRW.Size = new System.Drawing.Size(447, 242);
            this.pnlRW.TabIndex = 12;
            this.pnlRW.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnSkip
            // 
            this.btnSkip.Enabled = false;
            this.btnSkip.Location = new System.Drawing.Point(15, 199);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(126, 38);
            this.btnSkip.TabIndex = 15;
            this.btnSkip.Text = "&Skip Item";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnAppendPack
            // 
            this.btnAppendPack.Location = new System.Drawing.Point(79, 131);
            this.btnAppendPack.Name = "btnAppendPack";
            this.btnAppendPack.Size = new System.Drawing.Size(66, 22);
            this.btnAppendPack.TabIndex = 22;
            this.btnAppendPack.Text = "+\"&pack\"";
            this.btnAppendPack.UseVisualStyleBackColor = true;
            this.btnAppendPack.Click += new System.EventHandler(this.btnAppendPack_Click);
            // 
            // btnAppendCan
            // 
            this.btnAppendCan.Location = new System.Drawing.Point(223, 131);
            this.btnAppendCan.Name = "btnAppendCan";
            this.btnAppendCan.Size = new System.Drawing.Size(66, 22);
            this.btnAppendCan.TabIndex = 24;
            this.btnAppendCan.Text = "+\"&can\"";
            this.btnAppendCan.UseVisualStyleBackColor = true;
            this.btnAppendCan.Click += new System.EventHandler(this.btnAppendCan_Click);
            // 
            // btnAppendBottle
            // 
            this.btnAppendBottle.Location = new System.Drawing.Point(151, 131);
            this.btnAppendBottle.Name = "btnAppendBottle";
            this.btnAppendBottle.Size = new System.Drawing.Size(66, 22);
            this.btnAppendBottle.TabIndex = 23;
            this.btnAppendBottle.Text = "+\"&bottle\"";
            this.btnAppendBottle.UseVisualStyleBackColor = true;
            this.btnAppendBottle.Click += new System.EventHandler(this.btnAppendBottle_Click);
            // 
            // chkGoogleUPC
            // 
            this.chkGoogleUPC.AutoSize = true;
            this.chkGoogleUPC.Location = new System.Drawing.Point(327, 40);
            this.chkGoogleUPC.Name = "chkGoogleUPC";
            this.chkGoogleUPC.Size = new System.Drawing.Size(110, 17);
            this.chkGoogleUPC.TabIndex = 19;
            this.chkGoogleUPC.Text = "Auto-Google UPC";
            this.chkGoogleUPC.UseVisualStyleBackColor = true;
            // 
            // chkAutoFormat
            // 
            this.chkAutoFormat.AutoSize = true;
            this.chkAutoFormat.Checked = true;
            this.chkAutoFormat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoFormat.Location = new System.Drawing.Point(327, 17);
            this.chkAutoFormat.Name = "chkAutoFormat";
            this.chkAutoFormat.Size = new System.Drawing.Size(107, 17);
            this.chkAutoFormat.TabIndex = 15;
            this.chkAutoFormat.Text = "Auto-Format Text";
            this.chkAutoFormat.UseVisualStyleBackColor = true;
            // 
            // btnWebSearch2
            // 
            this.btnWebSearch2.Location = new System.Drawing.Point(325, 131);
            this.btnWebSearch2.Name = "btnWebSearch2";
            this.btnWebSearch2.Size = new System.Drawing.Size(112, 38);
            this.btnWebSearch2.TabIndex = 18;
            this.btnWebSearch2.Text = "Google &Description";
            this.btnWebSearch2.UseVisualStyleBackColor = true;
            this.btnWebSearch2.Click += new System.EventHandler(this.btnWebSearch2_Click);
            // 
            // btnWebSearch
            // 
            this.btnWebSearch.Location = new System.Drawing.Point(325, 87);
            this.btnWebSearch.Name = "btnWebSearch";
            this.btnWebSearch.Size = new System.Drawing.Size(112, 38);
            this.btnWebSearch.TabIndex = 17;
            this.btnWebSearch.Text = "&Google UPC";
            this.btnWebSearch.UseVisualStyleBackColor = true;
            this.btnWebSearch.Click += new System.EventHandler(this.btnWebSearch_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(163, 199);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(126, 38);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "&Next Item";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblDescSize
            // 
            this.lblDescSize.AutoSize = true;
            this.lblDescSize.BackColor = System.Drawing.Color.Transparent;
            this.lblDescSize.Location = new System.Drawing.Point(240, 73);
            this.lblDescSize.Name = "lblDescSize";
            this.lblDescSize.Size = new System.Drawing.Size(40, 13);
            this.lblDescSize.TabIndex = 7;
            this.lblDescSize.Text = "0 of 70";
            this.lblDescSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "(Internal) Item Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(12, 173);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(277, 20);
            this.txtNotes.TabIndex = 14;
            this.txtNotes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "New Brand ";
            // 
            // txtNewBrand
            // 
            this.txtNewBrand.Location = new System.Drawing.Point(12, 34);
            this.txtNewBrand.Name = "txtNewBrand";
            this.txtNewBrand.Size = new System.Drawing.Size(277, 20);
            this.txtNewBrand.TabIndex = 12;
            this.txtNewBrand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "New Description";
            // 
            // txtNewDescription
            // 
            this.txtNewDescription.Location = new System.Drawing.Point(12, 89);
            this.txtNewDescription.Multiline = true;
            this.txtNewDescription.Name = "txtNewDescription";
            this.txtNewDescription.Size = new System.Drawing.Size(277, 36);
            this.txtNewDescription.TabIndex = 13;
            this.txtNewDescription.TextChanged += new System.EventHandler(this.txtNewDescription_TextChanged);
            this.txtNewDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Internal Attributes";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblcsvIndex
            // 
            this.lblcsvIndex.AutoSize = true;
            this.lblcsvIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcsvIndex.Location = new System.Drawing.Point(19, 146);
            this.lblcsvIndex.Name = "lblcsvIndex";
            this.lblcsvIndex.Size = new System.Drawing.Size(214, 24);
            this.lblcsvIndex.TabIndex = 13;
            this.lblcsvIndex.Text = "Item #0 of 1000 - Row #2";
            // 
            // pnlRO
            // 
            this.pnlRO.BackColor = System.Drawing.Color.DarkGray;
            this.pnlRO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRO.Controls.Add(this.label11);
            this.pnlRO.Controls.Add(this.txtUPC);
            this.pnlRO.Controls.Add(this.label1);
            this.pnlRO.Controls.Add(this.label3);
            this.pnlRO.Controls.Add(this.txtBrand);
            this.pnlRO.Controls.Add(this.txtSignDesc);
            this.pnlRO.Controls.Add(this.txtDesc);
            this.pnlRO.Controls.Add(this.label2);
            this.pnlRO.Location = new System.Drawing.Point(20, 201);
            this.pnlRO.Name = "pnlRO";
            this.pnlRO.Size = new System.Drawing.Size(275, 242);
            this.pnlRO.TabIndex = 11;
            this.pnlRO.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "UPC";
            // 
            // txtUPC
            // 
            this.txtUPC.Location = new System.Drawing.Point(12, 200);
            this.txtUPC.Name = "txtUPC";
            this.txtUPC.ReadOnly = true;
            this.txtUPC.Size = new System.Drawing.Size(245, 20);
            this.txtUPC.TabIndex = 11;
            this.txtUPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Brand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sign or POS Description";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(12, 34);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.ReadOnly = true;
            this.txtBrand.Size = new System.Drawing.Size(245, 20);
            this.txtBrand.TabIndex = 8;
            this.txtBrand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // txtSignDesc
            // 
            this.txtSignDesc.Location = new System.Drawing.Point(12, 144);
            this.txtSignDesc.Name = "txtSignDesc";
            this.txtSignDesc.ReadOnly = true;
            this.txtSignDesc.Size = new System.Drawing.Size(245, 20);
            this.txtSignDesc.TabIndex = 10;
            this.txtSignDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(12, 89);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(245, 20);
            this.txtDesc.TabIndex = 9;
            this.txtDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Product Description";
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(23, 31);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(119, 30);
            this.btnInputFile.TabIndex = 1;
            this.btnInputFile.Text = "Choose Input File";
            this.btnInputFile.UseVisualStyleBackColor = true;
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(375, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(255, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "New Attributes (Leave Empty or Null For No Change)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(166, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Reading From:";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(169, 37);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(277, 20);
            this.txtInputFile.TabIndex = 2;
            this.txtInputFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(166, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(213, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Writing To: (This will overwrite existing data)";
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Location = new System.Drawing.Point(169, 94);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(277, 20);
            this.txtOutputFile.TabIndex = 4;
            this.txtOutputFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "CSV files | *.csv";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Location = new System.Drawing.Point(23, 84);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(119, 30);
            this.btnOutputFile.TabIndex = 3;
            this.btnOutputFile.Text = "Choose Output File";
            this.btnOutputFile.UseVisualStyleBackColor = true;
            this.btnOutputFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV files | *.csv";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(463, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Start at Row:";
            // 
            // numRowOffset
            // 
            this.numRowOffset.Location = new System.Drawing.Point(538, 24);
            this.numRowOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRowOffset.Name = "numRowOffset";
            this.numRowOffset.Size = new System.Drawing.Size(58, 20);
            this.numRowOffset.TabIndex = 5;
            // 
            // btnBegin
            // 
            this.btnBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBegin.Location = new System.Drawing.Point(466, 84);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(130, 30);
            this.btnBegin.TabIndex = 7;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // rchBuffer
            // 
            this.rchBuffer.Location = new System.Drawing.Point(614, 26);
            this.rchBuffer.Name = "rchBuffer";
            this.rchBuffer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rchBuffer.Size = new System.Drawing.Size(211, 88);
            this.rchBuffer.TabIndex = 25;
            this.rchBuffer.Text = "";
            this.rchBuffer.WordWrap = false;
            this.rchBuffer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectAllEnabler);
            // 
            // chkNoScrape
            // 
            this.chkNoScrape.AutoSize = true;
            this.chkNoScrape.Location = new System.Drawing.Point(466, 50);
            this.chkNoScrape.Name = "chkNoScrape";
            this.chkNoScrape.Size = new System.Drawing.Size(89, 17);
            this.chkNoScrape.TabIndex = 6;
            this.chkNoScrape.Text = "Offline Mode ";
            this.chkNoScrape.UseVisualStyleBackColor = true;
            this.chkNoScrape.CheckedChanged += new System.EventHandler(this.chkNoScrape_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(611, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Output Log:";
            // 
            // btnCarryOver
            // 
            this.btnCarryOver.Location = new System.Drawing.Point(301, 291);
            this.btnCarryOver.Name = "btnCarryOver";
            this.btnCarryOver.Size = new System.Drawing.Size(71, 24);
            this.btnCarryOver.TabIndex = 20;
            this.btnCarryOver.Text = "&a ->";
            this.btnCarryOver.UseVisualStyleBackColor = true;
            this.btnCarryOver.Click += new System.EventHandler(this.btnCarryOver_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(329, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Format: Attribute > Flavor > Product > Multipack > Container";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(70, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(309, 18);
            this.label10.TabIndex = 32;
            this.label10.Text = "ex: Low Sodium Cherry Vodka 4-Pack Bottles";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(378, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 36);
            this.panel1.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(703, 446);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 16);
            this.label17.TabIndex = 34;
            this.label17.Text = "Version: 6/12/2019";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCarryOver2
            // 
            this.btnCarryOver2.Location = new System.Drawing.Point(301, 321);
            this.btnCarryOver2.Name = "btnCarryOver2";
            this.btnCarryOver2.Size = new System.Drawing.Size(71, 24);
            this.btnCarryOver2.TabIndex = 21;
            this.btnCarryOver2.Text = "&z ->";
            this.btnCarryOver2.UseVisualStyleBackColor = true;
            this.btnCarryOver2.Click += new System.EventHandler(this.btnCarryOver2_Click);
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(1, 131);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(855, 2);
            this.label16.TabIndex = 36;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(20, 446);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 16);
            this.label18.TabIndex = 37;
            this.label18.Text = "Progress Saved:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaveTime
            // 
            this.lblSaveTime.AutoSize = true;
            this.lblSaveTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveTime.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblSaveTime.Location = new System.Drawing.Point(126, 446);
            this.lblSaveTime.Name = "lblSaveTime";
            this.lblSaveTime.Size = new System.Drawing.Size(59, 16);
            this.lblSaveTime.TabIndex = 38;
            this.lblSaveTime.Text = "12:00PM";
            this.lblSaveTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCarryOverBrand
            // 
            this.btnCarryOverBrand.Location = new System.Drawing.Point(301, 233);
            this.btnCarryOverBrand.Name = "btnCarryOverBrand";
            this.btnCarryOverBrand.Size = new System.Drawing.Size(71, 24);
            this.btnCarryOverBrand.TabIndex = 19;
            this.btnCarryOverBrand.Text = "&q ->";
            this.btnCarryOverBrand.UseVisualStyleBackColor = true;
            this.btnCarryOverBrand.Click += new System.EventHandler(this.btnCarryOverBrand_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(846, 476);
            this.Controls.Add(this.btnCarryOverBrand);
            this.Controls.Add(this.lblSaveTime);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnCarryOver2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCarryOver);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkNoScrape);
            this.Controls.Add(this.rchBuffer);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.numRowOffset);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnOutputFile);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnlRW);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblcsvIndex);
            this.Controls.Add(this.pnlRO);
            this.Controls.Add(this.btnInputFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Description GUI";
            this.pnlRW.ResumeLayout(false);
            this.pnlRW.PerformLayout();
            this.pnlRO.ResumeLayout(false);
            this.pnlRO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRowOffset)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlRW;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblcsvIndex;
        private System.Windows.Forms.Panel pnlRO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtSignDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNewBrand;
        private System.Windows.Forms.Label lblDescSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUPC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnOutputFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numRowOffset;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.RichTextBox rchBuffer;
        private System.Windows.Forms.CheckBox chkNoScrape;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCarryOver;
        private System.Windows.Forms.Button btnWebSearch;
        private System.Windows.Forms.Button btnWebSearch2;
        private System.Windows.Forms.CheckBox chkAutoFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkGoogleUPC;
        private System.Windows.Forms.Button btnCarryOver2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblSaveTime;
        private System.Windows.Forms.Button btnAppendCan;
        private System.Windows.Forms.Button btnAppendBottle;
        private System.Windows.Forms.Button btnAppendPack;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnCarryOverBrand;
    }
}

