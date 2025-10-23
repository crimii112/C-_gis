namespace Gis
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelGis = new System.Windows.Forms.Panel();
            this.tableLayoutPanelDetail = new System.Windows.Forms.TableLayoutPanel();
            this.tblDetail = new System.Windows.Forms.TableLayoutPanel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.22314F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.77686F));
            this.tableLayoutPanel1.Controls.Add(this.panelGis, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelDetail, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(847, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelGis
            // 
            this.panelGis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGis.Location = new System.Drawing.Point(114, 3);
            this.panelGis.Name = "panelGis";
            this.panelGis.Size = new System.Drawing.Size(730, 444);
            this.panelGis.TabIndex = 0;
            // 
            // tableLayoutPanelDetail
            // 
            this.tableLayoutPanelDetail.ColumnCount = 1;
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDetail.Controls.Add(this.tblDetail, 0, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.lblDetailTitle, 0, 0);
            this.tableLayoutPanelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDetail.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelDetail.Name = "tableLayoutPanelDetail";
            this.tableLayoutPanelDetail.RowCount = 2;
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.954955F));
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.04504F));
            this.tableLayoutPanelDetail.Size = new System.Drawing.Size(105, 444);
            this.tableLayoutPanelDetail.TabIndex = 1;
            // 
            // tblDetail
            // 
            this.tblDetail.AutoSize = true;
            this.tblDetail.BackColor = System.Drawing.SystemColors.Info;
            this.tblDetail.ColumnCount = 2;
            this.tblDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblDetail.Location = new System.Drawing.Point(3, 25);
            this.tblDetail.Name = "tblDetail";
            this.tblDetail.RowCount = 2;
            this.tblDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblDetail.Size = new System.Drawing.Size(99, 0);
            this.tblDetail.TabIndex = 0;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.BackColor = System.Drawing.SystemColors.Info;
            this.lblDetailTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDetailTitle.Location = new System.Drawing.Point(3, 0);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(99, 22);
            this.lblDetailTitle.TabIndex = 1;
            this.lblDetailTitle.Text = "클릭한 위치 정보";
            this.lblDetailTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelDetail.ResumeLayout(false);
            this.tableLayoutPanelDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelGis;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDetail;
        private System.Windows.Forms.TableLayoutPanel tblDetail;
        private System.Windows.Forms.Label lblDetailTitle;
    }
}

