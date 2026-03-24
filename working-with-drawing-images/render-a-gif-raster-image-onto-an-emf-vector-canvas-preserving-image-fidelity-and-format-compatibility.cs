using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.gif";
        string outputPath = @"C:\Temp\output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF raster image
        using (RasterImage gifImage = (RasterImage)Image.Load(inputPath))
        {
            int gifWidth = gifImage.Width;
            int gifHeight = gifImage.Height;

            // Define device size for EMF (matching GIF size)
            int deviceWidth = gifWidth;
            int deviceHeight = gifHeight;
            int deviceWidthMm = (int)(deviceWidth / 100f);
            int deviceHeightMm = (int)(deviceHeight / 100f);

            // Create a frame rectangle for the EMF canvas
            Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, deviceWidth, deviceHeight);

            // Initialize EMF graphics recorder (do NOT wrap in using)
            EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
                frame,
                new Aspose.Imaging.Size(deviceWidth, deviceHeight),
                new Aspose.Imaging.Size(deviceWidthMm, deviceHeightMm));

            // Draw the GIF onto the EMF canvas, scaling to fit exactly
            graphics.DrawImage(
                gifImage,
                new Aspose.Imaging.Rectangle(0, 0, deviceWidth, deviceHeight),   // destination rectangle
                new Aspose.Imaging.Rectangle(0, 0, gifWidth, gifHeight),       // source rectangle
                GraphicsUnit.Pixel);

            // Finalize recording and obtain the EMF image
            using (EmfImage emfImage = graphics.EndRecording())
            {
                // Save the EMF file
                emfImage.Save(outputPath);
            }
        }
    }
}