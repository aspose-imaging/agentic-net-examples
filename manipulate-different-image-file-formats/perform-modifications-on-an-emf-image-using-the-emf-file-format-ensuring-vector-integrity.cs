using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("C:\\Temp", "input.emf");
        string outputPath = Path.Combine("C:\\Temp", "output_modified.emf");

        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

            graphics.DrawRectangle(new Pen(Color.Red, 2), 0, 0, emfImage.Width, emfImage.Height);

            using (SolidBrush brush = new SolidBrush(Color.Yellow))
            {
                brush.Opacity = 50;
                int rectWidth = emfImage.Width / 2;
                int rectHeight = emfImage.Height / 2;
                int rectX = (emfImage.Width - rectWidth) / 2;
                int rectY = (emfImage.Height - rectHeight) / 2;
                graphics.FillRectangle(brush, new Rectangle(rectX, rectY, rectWidth, rectHeight));
            }

            Font watermarkFont = new Font("Arial", 36, FontStyle.Bold);
            graphics.DrawString("Modified", watermarkFont, Color.Blue, emfImage.Width - 200, emfImage.Height - 50);

            using (EmfImage modifiedEmf = graphics.EndRecording())
            {
                modifiedEmf.Save(outputPath);
            }
        }
    }
}