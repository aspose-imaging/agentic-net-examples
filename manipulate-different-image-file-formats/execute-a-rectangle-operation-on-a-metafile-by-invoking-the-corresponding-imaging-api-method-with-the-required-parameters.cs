using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main()
    {
        // Output file path (hardcoded)
        string outputPath = @"C:\Temp\output.emf";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define image dimensions (pixels) and size in millimeters
        int deviceWidth = 600;
        int deviceHeight = 400;
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Create the frame rectangle for the EMF image
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Initialize the EMF recorder graphics
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Draw a black rectangle covering the entire image area
        Pen pen = new Pen(Color.Black, 1);
        graphics.DrawRectangle(pen, 0, 0, deviceWidth, deviceHeight);

        // Finalize recording and save the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            emfImage.Save(outputPath);
        }
    }
}