using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jovo
{
    public partial class formChangelog : Form
    {
        Dictionary<string, Color> TagColours = new Dictionary<string, Color>();
        List<Changelog> changelog;

        public formChangelog(List<Changelog> _changelog, Point pos, string ModuleName)
        {
            changelog = _changelog;
            InitializeComponent();

            this.Location = pos;

            if (changelog != null)
            {
                lblMainTitle.Text = "Changelog - " + ModuleName;

                TagColours.Add("initialrelease", Color.FromArgb(134, 95, 197));
                TagColours.Add("initial", Color.FromArgb(134, 95, 197));

                TagColours.Add("maycontainbugs", Color.FromArgb(192, 57, 43));
                TagColours.Add("containsbugs", Color.FromArgb(192, 57, 43));
                TagColours.Add("bugs", Color.FromArgb(192, 57, 43));

                TagColours.Add("stable", Color.FromArgb(30, 130, 76));
                TagColours.Add("stablebuild", Color.FromArgb(30, 130, 76));

                TagColours.Add("bugfix", Color.FromArgb(219, 10, 91));
                TagColours.Add("fix", Color.FromArgb(219, 10, 91));

                TagColours.Add("cuttingedge", Color.FromArgb(211, 84, 0));
                TagColours.Add("devbuild", Color.FromArgb(211, 84, 0));
                TagColours.Add("dev", Color.FromArgb(211, 84, 0));

                TagColours.Add("default", Color.FromArgb(30, 139, 195));

                GenerateVersionInfo(GenerateHeaders());
            }
            else
            {
                pnlError.Visible = true;
            }
        }

        private string GenerateHeaders()
        {
            List<Changelog> versionSorted = changelog.OrderByDescending(c => (c.Version)).Take(10).ToList();

            string versiontoreturn = "";
            int x = 5;
            bool first = true;
            foreach (Changelog change in versionSorted)
            {
                if (first)
                    versiontoreturn = change.Version;

                string headerText = change.Version;
                Label header = new Label();
                header.Name = "lbl" + headerText.Replace(" ", String.Empty);
                header.Text = headerText;
                header.AutoSize = true;
                header.ForeColor = Color.FromArgb(30, 30, 30);
                header.BackColor = Color.Transparent;
                header.MouseEnter += label_MouseEnter;
                header.MouseLeave += label_MouseLeave;
                header.Click += label_Click;
                header.Tag = change.Version;
                header.TextAlign = ContentAlignment.MiddleLeft;
                header.Location = new Point(x, 70);
                header.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
                this.Controls.Add(header);

                Panel under = new Panel();
                under.Name = "pnlHead" + headerText.Replace(" ", String.Empty);
                under.Size = new Size(header.Size.Width, 3);
                under.Location = new Point(x, 95);
                under.BackColor = Color.FromArgb(51, 153, 255);
                under.Visible = first;
                this.Controls.Add(under);
                x += header.Size.Width + 5;
                first = false;
            }

            return versiontoreturn;
        }

        private void GenerateVersionInfo(string version)
        {
            int r = 100;
            int g = 100;
            int b = 100;

            pnlVersion.Controls.Clear();

            Changelog change = changelog.Find(c => c.Version == version);

            Label title = new Label();
            title.Name = "lblVersionTitle";
            title.Text = "v" + change.Version + " - " + change.Title;
            title.ForeColor = Color.FromArgb(r, g, b);
            title.BackColor = Color.Transparent;
            title.TextAlign = ContentAlignment.TopLeft;
            title.Location = new Point(10, 1);
            title.Size = new Size(570, 29);
            title.Font = new Font("Segoe UI", 16F, FontStyle.Regular);
            pnlVersion.Controls.Add(title);

            Label desc = new Label();
            desc.Name = "lblVersionDesc";
            desc.Text = change.Description;
            desc.ForeColor = Color.FromArgb(r, g, b);
            desc.BackColor = Color.Transparent;
            desc.TextAlign = ContentAlignment.TopLeft;
            desc.Location = new Point(10, 31);
            desc.Size = new Size(568, 26);
            desc.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular);
            pnlVersion.Controls.Add(desc);

            Label author = new Label();
            author.Name = "lblVersionAuthor";
            author.Text = "Author: " + change.Author;
            author.ForeColor = Color.FromArgb(r, g, b);
            author.BackColor = Color.Transparent;
            author.TextAlign = ContentAlignment.TopLeft;
            author.Location = new Point(10, 75);
            author.Size = new Size(181, 13);
            author.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular);
            pnlVersion.Controls.Add(author);

            Label date = new Label();
            date.Name = "lblVersionDate";
            date.Text = "Version Date: " + change.VersionDate;
            date.ForeColor = Color.FromArgb(r, g, b);
            date.BackColor = Color.Transparent;
            date.TextAlign = ContentAlignment.TopLeft;
            date.Location = new Point(300, 75);
            date.Size = new Size(181, 13);
            date.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular);
            pnlVersion.Controls.Add(date);

            Point prevLoc = new Point(10, 62);
            int count = 0;
            foreach (string tag in change.Tags.Split(','))
            {
                Label lbl = new Label();
                lbl.Name = "lblTag" + count;
                lbl.Text = tag;
                lbl.ForeColor = Color.White;
                lbl.BackColor = FindTagColour(tag.Replace(" ", "").ToLower());
                lbl.TextAlign = ContentAlignment.TopLeft;
                lbl.Location = prevLoc;
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
                pnlVersion.Controls.Add(lbl);

                prevLoc = new Point(lbl.Location.X + lbl.Size.Width + 5, lbl.Location.Y);

                count++;
            }

            GenerateChangelog(change);
        }

        private void GenerateChangelog(Changelog change)
        {
            pnlChangelog.Controls.Clear();

            int count = 0;
            int left = 10;
            int top = 4;

            string[] options = { "added", "changed", "deprecated", "removed", "fixed", "security", "misc" };
            foreach (string option in options)
            {
                bool first = true;
                foreach (ChangelogChange part in change.Changes.FindAll(c => c.Type.ToLower() == option.ToLower()))
                {
                    if (first)
                    {
                        top += 10;

                        Label title = new Label();
                        title.Name = "lblSectionTitle" + count;
                        title.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(option);
                        title.ForeColor = Color.FromArgb(69, 69, 69);
                        title.BackColor = Color.Transparent;
                        title.TextAlign = ContentAlignment.TopLeft;
                        title.Location = new Point(left, top);
                        title.Size = new Size(550, 25);
                        title.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
                        pnlChangelog.Controls.Add(title);

                        top += 25;
                        first = false;
                    }

                    Label desc = new Label();
                    desc.Name = "lblChangeTitle" + count;
                    desc.Text = "  ● " + part.Title;
                    desc.ForeColor = Color.FromArgb(69, 69, 69);
                    desc.BackColor = Color.Transparent;
                    desc.TextAlign = ContentAlignment.TopLeft;
                    desc.Location = new Point(left, top);
                    desc.Size = new Size(560, 26);
                    desc.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    pnlChangelog.Controls.Add(desc);

                    top += 26;

                    count++;
                }
            }
        }

        private Color FindTagColour(string tag)
        {
            if (TagColours.ContainsKey(tag))
                return TagColours[tag];
            else
                return TagColours["default"];
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            GenerateVersionInfo((string)lbl.Tag);

            string pnlName = "pnlHead" + lbl.Name.Substring(3, lbl.Name.Length - 3);
            foreach (Control cntrl in this.Controls)
            {
                if (cntrl.Name.Contains("pnlHead"))
                {
                    Panel pnl = (Panel)cntrl;
                    if (pnl.Name == pnlName)
                    {
                        pnl.Visible = true;
                    }
                    else
                        pnl.Visible = false;
                }
            }
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(51, 153, 255);
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.FromArgb(30, 30, 30);
        }

        private void btnFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
