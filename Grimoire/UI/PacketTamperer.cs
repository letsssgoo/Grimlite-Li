using DarkUI.Controls;
using DarkUI.Forms;
using Grimoire.Networking;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Grimoire.UI
{
    public class PacketTamperer : DarkForm
    {
        private IContainer components;

        private RichTextBox txtSend;

        private RichTextBox txtReceive;

        private DarkButton btnToServer;

        private DarkCheckBox chkFromClient;

        private DarkCheckBox chkFromServer;
        private SplitContainer splitContainer1;
        private DarkPanel panel1;
        private DarkPanel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private DarkTextBox tbFilter;
        private Label label1;
        private DarkButton btnClear;
        private DarkButton btnToClient;

        public static PacketTamperer Instance
        {
            get;
        } = new PacketTamperer();

        private PacketTamperer()
        {
            InitializeComponent();
        }

        private void PacketTamperer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void chkFromServer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFromServer.Checked)
            {
                Proxy.Instance.ReceivedFromServer += ReceivedFromServer;
            }
            else
            {
                Proxy.Instance.ReceivedFromServer -= ReceivedFromServer;
            }
        }

        private void chkFromClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFromClient.Checked)
            {
                Proxy.Instance.ReceivedFromClient += ReceivedFromClient;
            }
            else
            {
                Proxy.Instance.ReceivedFromClient -= ReceivedFromClient;
            }
        }

        private async void btnToClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSend.Text))
            {
                btnToClient.Enabled = false;
                await Proxy.Instance.SendToClient(txtSend.Text);
                btnToClient.Enabled = true;
            }
        }

        private async void btnToServer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSend.Text))
            {
                btnToServer.Enabled = false;
                await Proxy.Instance.SendToServer(txtSend.Text);
                btnToServer.Enabled = true;
            }
        }

        private void ReceivedFromClient(Networking.Message message)
        {
            string text = message.RawContent;
            if (text.Contains(tbFilter.Text))
            {
                this.txtSend.Invoke(new Action(delegate ()
                {
                    this.Append("From client: " + text);
                }));
            }
        }

        private void ReceivedFromServer(Networking.Message message)
        {
            string text = message.RawContent;
            if (text.Contains(tbFilter.Text))
            {
                this.txtSend.Invoke(new Action(delegate ()
                {
                    this.Append("From server: " + text);
                }));
            }
        }

        private void Append(string text)
        {
            txtReceive.AppendText(text + Environment.NewLine + Environment.NewLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.btnToServer = new DarkUI.Controls.DarkButton();
            this.chkFromClient = new DarkUI.Controls.DarkCheckBox();
            this.chkFromServer = new DarkUI.Controls.DarkCheckBox();
            this.btnToClient = new DarkUI.Controls.DarkButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new DarkUI.Controls.DarkPanel();
            this.panel2 = new DarkUI.Controls.DarkPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbFilter = new DarkUI.Controls.DarkTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new DarkUI.Controls.DarkButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSend.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtSend.Location = new System.Drawing.Point(0, 0);
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSend.Size = new System.Drawing.Size(540, 126);
            this.txtSend.TabIndex = 0;
            this.txtSend.Text = "";
            // 
            // txtReceive
            // 
            this.txtReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceive.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtReceive.Location = new System.Drawing.Point(0, 0);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(540, 274);
            this.txtReceive.TabIndex = 1;
            this.txtReceive.Text = "";
            // 
            // btnToServer
            // 
            this.btnToServer.Checked = false;
            this.btnToServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToServer.Location = new System.Drawing.Point(453, 3);
            this.btnToServer.Name = "btnToServer";
            this.btnToServer.Size = new System.Drawing.Size(84, 23);
            this.btnToServer.TabIndex = 3;
            this.btnToServer.Text = "Send to server";
            this.btnToServer.Click += new System.EventHandler(this.btnToServer_Click);
            // 
            // chkFromClient
            // 
            this.chkFromClient.AutoSize = true;
            this.chkFromClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFromClient.Location = new System.Drawing.Point(133, 3);
            this.chkFromClient.Name = "chkFromClient";
            this.chkFromClient.Size = new System.Drawing.Size(114, 23);
            this.chkFromClient.TabIndex = 4;
            this.chkFromClient.Text = "Capture from client";
            this.chkFromClient.CheckedChanged += new System.EventHandler(this.chkFromClient_CheckedChanged);
            // 
            // chkFromServer
            // 
            this.chkFromServer.AutoSize = true;
            this.chkFromServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFromServer.Location = new System.Drawing.Point(0, 0);
            this.chkFromServer.Name = "chkFromServer";
            this.chkFromServer.Size = new System.Drawing.Size(124, 23);
            this.chkFromServer.TabIndex = 5;
            this.chkFromServer.Text = "Capture from server";
            this.chkFromServer.CheckedChanged += new System.EventHandler(this.chkFromServer_CheckedChanged);
            // 
            // btnToClient
            // 
            this.btnToClient.Checked = false;
            this.btnToClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToClient.Location = new System.Drawing.Point(363, 3);
            this.btnToClient.Name = "btnToClient";
            this.btnToClient.Size = new System.Drawing.Size(84, 23);
            this.btnToClient.TabIndex = 6;
            this.btnToClient.Text = "Send to client";
            this.btnToClient.Click += new System.EventHandler(this.btnToClient_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSend);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtReceive);
            this.splitContainer1.Size = new System.Drawing.Size(540, 404);
            this.splitContainer1.SplitterDistance = 126;
            this.splitContainer1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkFromServer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 23);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(253, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(104, 23);
            this.panel2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.btnToClient, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnToServer, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkFromClient, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 29);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(88, 458);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(464, 20);
            this.tbFilter.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(16, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Filter by text";
            // 
            // btnClear
            // 
            this.btnClear.Checked = false;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // PacketTamperer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 492);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = global::Properties.Resources.GrimoireIcon;
            this.Name = "PacketTamperer";
            this.Text = "Packet Tamperer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PacketTamperer_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReceive.Text = "";
        }
    }
}