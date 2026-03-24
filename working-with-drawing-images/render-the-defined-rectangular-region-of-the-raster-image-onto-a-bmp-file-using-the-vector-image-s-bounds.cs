using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Define the rectangular region to render.
            // Here we use the full bounds of the image; modify as needed.
            Rectangle bounds = new Rectangle(0, 0, image.Width, image.Height);

            // Set up BMP save options (default options are sufficient for most cases)
            BmpOptions bmpOptions = new BmpOptions();

            // Save the defined region to a BMP file
            image.Save(outputPath, bmpOptions, bounds);
        }
    }
}