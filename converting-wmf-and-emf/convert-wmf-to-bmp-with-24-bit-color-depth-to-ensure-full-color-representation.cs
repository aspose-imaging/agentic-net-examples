using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample_converted.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Save as BMP with 24‑bit color depth
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24 // Force 24‑bpp output
            };

            wmfImage.Save(outputPath, bmpOptions);
        }
    }
}