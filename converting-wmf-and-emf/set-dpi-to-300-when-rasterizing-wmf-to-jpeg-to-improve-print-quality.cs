using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample_300dpi.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for the WMF source
                var wmfRasterOptions = new WmfRasterizationOptions
                {
                    // Use the original image size as the page size
                    PageSize = image.Size
                };

                // Configure JPEG save options with 300 dpi resolution
                var jpegOptions = new JpegOptions
                {
                    // Set the desired DPI for the output JPEG
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    // Attach the vector rasterization options
                    VectorRasterizationOptions = wmfRasterOptions
                };

                // Save the rasterized image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}