using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Image dimensions
        int width = 100;
        int height = 100;

        // Prepare pixel data (solid red ARGB)
        int[] pixelData = new int[width * height];
        int redArgb = unchecked((int)0xFFFF0000); // Alpha=255, Red=255, Green=0, Blue=0
        for (int i = 0; i < pixelData.Length; i++)
        {
            pixelData[i] = redArgb;
        }

        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP creation options
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions
        {
            Source = source,
            BitsPerPixel = 32
        };

        // Create a BMP canvas bound to the output file
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Write the pixel data to the canvas
            canvas.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixelData);

            // Save the bound image
            canvas.Save();
        }
    }
}