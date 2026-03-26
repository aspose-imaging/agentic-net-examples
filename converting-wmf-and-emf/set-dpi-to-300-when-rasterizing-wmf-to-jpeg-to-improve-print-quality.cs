using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for the WMF vector data
            var wmfRasterOptions = new WmfRasterizationOptions
            {
                // Use the original size of the WMF image
                PageSize = wmfImage.Size
            };

            // Configure JPEG save options with 300 dpi resolution
            var jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = wmfRasterOptions,
                // Set both horizontal and vertical DPI to 300
                ResolutionSettings = new ResolutionSetting(300.0, 300.0)
            };

            // Save the rasterized image as JPEG
            wmfImage.Save(outputPath, jpegOptions);
        }
    }
}