using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Configure rasterization options with a solid background color
                CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
                {
                    // Example background color (white). Change as needed.
                    BackgroundColor = Color.White,
                    // Optional: set page size or resolution if required
                    // PageWidth = 800,
                    // PageHeight = 600,
                    // ResolutionSettings = new ResolutionSetting(300)
                };

                // Configure JPEG save options and attach rasterization options
                JpegOptions jpegOptions = new JpegOptions
                {
                    // Use default quality; adjust if needed
                    Quality = 90,
                    // Attach rasterization options for vector conversion
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as JPEG with the specified options
                cmxImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}