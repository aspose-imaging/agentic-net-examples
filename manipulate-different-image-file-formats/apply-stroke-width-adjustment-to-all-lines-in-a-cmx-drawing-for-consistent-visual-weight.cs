using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.cmx";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            // Get canvas size from CMX image
            int width = cmx.Width;
            int height = cmx.Height;

            // Create PNG options with a file source
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new raster image with the same dimensions as the CMX canvas
            using (Image rasterImage = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics for the raster image
                Graphics graphics = new Graphics(rasterImage);
                graphics.Clear(Color.White);

                // Draw the CMX content onto the raster canvas
                // This rasterizes the vector data; line widths become part of the bitmap
                graphics.DrawImage(cmx, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);

                // Save the rasterized image
                rasterImage.Save();
            }
        }
    }
}