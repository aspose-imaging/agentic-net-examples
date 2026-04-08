using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Configure BMP save options for 24‑bit color depth
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                // Rasterization options are required for vector sources like WMF
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = wmfImage.Size,
                    BackgroundColor = Color.White
                }
            };

            // Save as BMP with the specified options
            wmfImage.Save(outputPath, bmpOptions);
        }
    }
}