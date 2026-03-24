using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input raster image and output EMF paths
        string inputImagePath = @"C:\temp\sample.bmp";
        string outputEmfPath = @"C:\temp\output.emf";

        // Verify input file exists
        if (!File.Exists(inputImagePath))
        {
            Console.Error.WriteLine($"File not found: {inputImagePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputEmfPath));

        // Define EMF canvas size (pixels) and size in millimeters
        int deviceWidth = 600;
        int deviceHeight = 400;
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Frame rectangle for the metafile
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Create EMF recorder graphics
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Draw a black border
        graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, deviceWidth, deviceHeight);

        // Fill background with light gray
        graphics.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(10, 10, 580, 380));

        // Load raster image and draw it onto the EMF canvas
        using (RasterImage raster = (RasterImage)Image.Load(inputImagePath))
        {
            graphics.DrawImage(
                raster,
                new Rectangle(200, 150, 200, 100),               // destination rectangle on EMF
                new Rectangle(0, 0, raster.Width, raster.Height), // source rectangle from raster
                GraphicsUnit.Pixel);
        }

        // Draw a diagonal line
        graphics.DrawLine(new Pen(Color.DarkGreen, 2), 0, 0, deviceWidth, deviceHeight);

        // Finish recording and obtain the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            // Save the EMF file
            emfImage.Save(outputEmfPath);
        }
    }
}