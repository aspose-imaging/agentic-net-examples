using System;
using System.IO;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input raster image and output EMF paths
        string inputPath = "input.png";
        string outputPath = "output.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            int width = raster.Width;
            int height = raster.Height;

            // Convert pixel dimensions to millimeters (approx. 100 pixels per mm)
            int widthMm = (int)(width / 100f);
            int heightMm = (int)(height / 100f);

            // Define the EMF frame matching the raster size
            Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, width, height);

            // Create EMF graphics recorder
            var graphics = new EmfRecorderGraphics2D(
                frame,
                new Aspose.Imaging.Size(width, height),
                new Aspose.Imaging.Size(widthMm, heightMm));

            // Draw the raster image onto the EMF canvas, scaling to full size
            graphics.DrawImage(
                raster,
                new Aspose.Imaging.Rectangle(0, 0, width, height),   // destination rectangle
                new Aspose.Imaging.Rectangle(0, 0, width, height),   // source rectangle
                Aspose.Imaging.GraphicsUnit.Pixel);

            // Finalize recording and obtain the EMF image
            using (EmfImage emf = graphics.EndRecording())
            {
                // Save the EMF image to the specified path
                emf.Save(outputPath);
            }
        }
    }
}