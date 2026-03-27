using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\rawdata.bin";
        string outputPath = @"C:\temp\output.jp2";

        // Input file existence check (no exception throwing)
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Image parameters
        int width = 256;          // image width in pixels
        int height = 256;         // image height in pixels
        int bitsPerSample = 8;    // bits per sample (bits count)

        // Create a JPEG2000 image with the specified dimensions and bits per sample
        using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(width, height, bitsPerSample))
        {
            // OPTIONAL: Load raw pixel data from the input file.
            // For demonstration, we simply fill the image with a gradient.
            // In a real scenario you could read the raw bytes and write them into the image buffer.

            Graphics graphics = new Graphics(jpeg2000Image);
            var brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(width, height),
                Color.Blue,
                Color.Yellow);
            graphics.FillRectangle(brush, jpeg2000Image.Bounds);

            // Save the JPEG2000 image using default options (bits per sample already set)
            jpeg2000Image.Save(outputPath, new Jpeg2000Options());
        }
    }
}