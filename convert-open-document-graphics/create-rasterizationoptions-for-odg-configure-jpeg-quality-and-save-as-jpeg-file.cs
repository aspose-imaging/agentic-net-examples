using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG vector image
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options specific to ODG
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,          // white background
                PageSize = image.Size                    // preserve original size
            };

            // Configure JPEG save options, including quality
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90,                           // JPEG quality (1‑100)
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}