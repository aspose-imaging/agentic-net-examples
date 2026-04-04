using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.tif";
        string outputPath = @"C:\Images\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image tiffImage = Image.Load(inputPath))
        {
            int width = tiffImage.Width;
            int height = tiffImage.Height;

            // Create an EMF recorder with the same size as the TIFF
            Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, width, height);
            Size deviceSize = new Size(width, height);
            Size deviceSizeMm = new Size(width / 100, height / 100); // approximate mm size

            EmfRecorderGraphics2D emfGraphics = new EmfRecorderGraphics2D(frame, deviceSize, deviceSizeMm);

            // Draw the TIFF onto the EMF canvas
            using (RasterImage raster = (RasterImage)tiffImage)
            {
                emfGraphics.DrawImage(
                    raster,
                    new Aspose.Imaging.Rectangle(0, 0, width, height),   // destination rectangle
                    new Aspose.Imaging.Rectangle(0, 0, width, height),   // source rectangle
                    GraphicsUnit.Pixel);
            }

            // Draw text as vector shapes onto the EMF
            Font textFont = new Font("Arial", 48, FontStyle.Regular);
            emfGraphics.DrawString("Sample Text", textFont, Color.DarkRed, 50, 50);

            // Finalize EMF recording
            using (EmfImage emfImage = emfGraphics.EndRecording())
            {
                // Prepare PNG options with vector rasterization to preserve vector text
                PngOptions pngOptions = new PngOptions();
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.White,
                    RenderMode = EmfRenderMode.Auto
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the EMF as PNG
                emfImage.Save(outputPath, pngOptions);
            }
        }
    }
}