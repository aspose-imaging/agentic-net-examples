using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string bmpPath = "input.bmp";
        string outputPath = "output.emf";

        int canvasWidth = 800;
        int canvasHeight = 600;

        int canvasWidthMm = (int)(canvasWidth / 100f);
        int canvasHeightMm = (int)(canvasHeight / 100f);

        Rectangle frame = new Rectangle(0, 0, canvasWidth, canvasHeight);

        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(canvasWidth, canvasHeight),
            new Size(canvasWidthMm, canvasHeightMm));

        using (RasterImage bmpImage = (RasterImage)Image.Load(bmpPath))
        {
            int margin = 50;
            Rectangle destRect = new Rectangle(margin, margin, canvasWidth - 2 * margin, canvasHeight - 2 * margin);
            Rectangle srcRect = new Rectangle(0, 0, bmpImage.Width, bmpImage.Height);

            graphics.DrawImage(bmpImage, destRect, srcRect, GraphicsUnit.Pixel);
        }

        graphics.DrawRectangle(new Pen(Color.Blue, 2), 0, 0, canvasWidth, canvasHeight);

        using (EmfImage emfImage = graphics.EndRecording())
        {
            emfImage.Save(outputPath);
        }
    }
}