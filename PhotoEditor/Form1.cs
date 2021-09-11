using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PhotoEditor
{
    public partial class mainForm : Form
    {
        private int customSize = 5;
        private int drawingCode = 0;
        private int addPhotoSize = 0;
        private bool drawnImage = false, keyDPressed = false, added = false;
        private string imageFileName = null, addImageFileName = null;
        private Color backColor, marginColor, drawColor;
        private Bitmap actualImage = null;
        private Point addPhotoLocation;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            BackColor = backColor;

            Rectangle rectangle = new Rectangle(50, 75, ClientSize.Width - 100, ClientSize.Height - 150);
            e.Graphics.FillRectangle(new SolidBrush(marginColor), rectangle);
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            Refresh();
            if (drawnImage)
            {
                DrawImage(imageFileName);
            }

            Rectangle rectangle = new Rectangle(50, 75, ClientSize.Width - 100, ClientSize.Height - 150);
            if (rectangle.Height > 0 && rectangle.Width > 0)
                if (actualImage == null) actualImage = new Bitmap(rectangle.Width, rectangle.Height);
                else actualImage = new Bitmap(actualImage, rectangle.Width, rectangle.Height);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
            drawingCode = 0;
            actualImage = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Title = "Open file";
            openDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openDialog.FileName = "";
            openDialog.CheckFileExists = true;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openDialog.FileName;
                DrawImage(fileName);
            }
        }

        private void DrawImage(string fileName)
        {
            imageFileName = fileName;
            drawnImage = true;
            Image image = Image.FromFile(fileName);
            Rectangle rectangle = new Rectangle(50, 75, ClientSize.Width - 100, ClientSize.Height - 150);

            CreateGraphics().DrawImage(image, rectangle);
            actualImage = image as Bitmap;
            drawingCode = 0;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Title = "Save file";
            saveDialog.OverwritePrompt = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDialog.FileName + ".png";
                imageFileName = fileName;
                if (drawnImage)
                    actualImage.Save(fileName);
                else MessageBox.Show("No image found", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                actualImage.Save(imageFileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void newColorThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                backColor = colorDialog.Color;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                    marginColor = colorDialog.Color;
                Refresh();
            }

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            backColor = SystemColors.ControlDarkDark;
            marginColor = SystemColors.ControlDark;

            addPhotoLocation = new Point(50, 75);
        }

        private void defaultThemeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            backColor = SystemColors.ControlDarkDark;
            marginColor = SystemColors.ControlDark;
            Refresh();
        }

        private void whiteThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backColor = SystemColors.ScrollBar;
            marginColor = SystemColors.Window;
            Refresh();
        }

        private void blueThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backColor = SystemColors.ActiveCaption;
            marginColor = SystemColors.InactiveCaption;
            Refresh();
        }

        private void blackThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backColor = SystemColors.Desktop;
            marginColor = SystemColors.WindowFrame;
            Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
                     new float[] {.3f, .3f, .3f, 0, 0},
                     new float[] {.59f, .59f, .59f, 0, 0},
                     new float[] {.11f, .11f, .11f, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {0, 0, 0, 0, 1}
                 });
            ApplyFilter(colorMatrix);
        }

        private void ApplyFilter(ColorMatrix colorMatrix)
        {
            Rectangle rectangle = new Rectangle(50, 75, ClientSize.Width - 100, ClientSize.Height - 150);
            Bitmap image = new Bitmap(Image.FromFile(imageFileName), new Size(rectangle.Width, rectangle.Height));

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            Graphics gImage = Graphics.FromImage(image);
            gImage.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            CreateGraphics().DrawImage(image, rectangle);

            actualImage = image;
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawImage(imageFileName);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
                    new float[]{.393f, .349f, .272f, 0, 0},
                    new float[]{.769f, .686f, .534f, 0, 0},
                    new float[]{.189f, .168f, .131f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
            ApplyFilter(colorMatrix);
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
                    new float[]{-1, 0, 0, 0, 0},
                    new float[]{0, -1, 0, 0, 0},
                    new float[]{0, 0, -1, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{1, 1, 1, 1, 1}
                });
            ApplyFilter(colorMatrix);
        }

        private void drawPointsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            drawingCode = 1;
            ChooseDrawOptions();
        }

        private void stopDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingCode = 0;
        }

        private Point GetCursorPosition()
        {
            return PointToClient(Cursor.Position);
        }

        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingCode > 0) DrawWithCursor();
        }

        private void drawCirclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingCode = 2;
            ChooseDrawOptions();
        }

        private void DrawWithCursor()
        {
            Point cursorPosition = GetCursorPosition();
            Rectangle rectangle = new Rectangle(50, 75, ClientSize.Width - 100, ClientSize.Height - 150);

            if (actualImage == null) actualImage = new Bitmap(rectangle.Width, rectangle.Height);
            else actualImage = new Bitmap(actualImage, rectangle.Width, rectangle.Height);
            Graphics gImage = Graphics.FromImage(actualImage);

            if (drawingCode > 0) drawnImage = true;

            if (checkCursorPosition(cursorPosition) && keyDPressed)
            {
                switch (drawingCode)
                {
                    case 1:
                        gImage.FillRectangle(new SolidBrush(drawColor), new Rectangle(cursorPosition.X - rectangle.X, cursorPosition.Y - rectangle.Y, customSize, customSize));
                        CreateGraphics().DrawImage(actualImage, rectangle);
                        break;
                    case 2:
                        gImage.FillEllipse(new SolidBrush(drawColor), new Rectangle(cursorPosition.X - rectangle.X, cursorPosition.Y - rectangle.Y, customSize, customSize));
                        CreateGraphics().DrawImage(actualImage, rectangle);
                        break;
                    case 3:
                        Random random = new Random();
                        gImage.FillEllipse(new SolidBrush(Color.FromArgb(random.Next() % 256, random.Next() % 256, random.Next() % 256)), new Rectangle(cursorPosition.X - rectangle.X, cursorPosition.Y - rectangle.Y, customSize, customSize));
                        CreateGraphics().DrawImage(actualImage, rectangle);
                        break;
                    default:
                        break;
                }   
            }
        }

        private void drawMulticoloredCirclesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            drawingCode = 3;
            ChooseDrawOptions();
        }

        private void photoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Title = "Choose photo";
            openDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openDialog.FileName = "";
            openDialog.CheckFileExists = true;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                addImageFileName = openDialog.FileName;

                SizeDialog sizeDialog = new SizeDialog();
                if (sizeDialog.ShowDialog() == DialogResult.OK)
                    addPhotoSize = sizeDialog.Size;
            }

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem addPhotoMenu = new ToolStripMenuItem();

            contextMenu.Items.AddRange(new ToolStripItem[] { addPhotoMenu });
            contextMenu.Size = new System.Drawing.Size(150, 50);
            addPhotoMenu.Size = new System.Drawing.Size(150, 20);
            addPhotoMenu.Text = "Add photo here";
            addPhotoMenu.Click += new System.EventHandler(addPhotoMenu_Click);

            ContextMenuStrip = contextMenu;

            
        }

        private void addPhotoMenu_Click(object sender, EventArgs e)
        {
            if (addPhotoSize != 0)
            {
                Rectangle rectangle = new Rectangle(50, 75, ClientSize.Width - 100, ClientSize.Height - 150);

                if (actualImage == null) actualImage = new Bitmap(rectangle.Width, rectangle.Height);
                else actualImage = new Bitmap(actualImage, rectangle.Width, rectangle.Height);
                Graphics gImage = Graphics.FromImage(actualImage);

                Point cursorPosition = GetCursorPosition();
                if (checkCursorPosition(cursorPosition))
                    addPhotoLocation = cursorPosition;

                gImage.DrawImage(Image.FromFile(addImageFileName), addPhotoLocation.X - rectangle.X, addPhotoLocation.Y - rectangle.Y, addPhotoSize, addPhotoSize);
                
                added = true;
            }

            if (added)
            {
                Rectangle rectangle = new Rectangle(50, 75, ClientSize.Width - 100, ClientSize.Height - 150);
                CreateGraphics().DrawImage(actualImage, rectangle);
                added = false;
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) drawingCode = 0;
            if (e.KeyCode == Keys.D) keyDPressed = true;
        }

        private bool checkCursorPosition(Point cursorPosition)
        {
            Rectangle rectangle = new Rectangle(50, 75, ClientSize.Width - 100, ClientSize.Height - 150);

            if (cursorPosition.X < rectangle.X || cursorPosition.X + customSize > rectangle.X + rectangle.Width) return false;
            if (cursorPosition.Y < rectangle.Y || cursorPosition.Y + customSize > rectangle.Y + rectangle.Height) return false;

            return true;
        }

        private void ChooseDrawOptions()
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                drawColor = colorDialog.Color;
                SizeDialog sizeDialog = new SizeDialog();
                if (sizeDialog.ShowDialog() == DialogResult.OK)
                    customSize = sizeDialog.Size;
            }
        }
    }
}
