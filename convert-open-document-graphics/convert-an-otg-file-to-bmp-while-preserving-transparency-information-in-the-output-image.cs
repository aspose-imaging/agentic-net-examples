using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare BMP save options (default compression preserves transparency)
                BmpOptions bmpOptions = new BmpOptions();

                // Configure rasterization options for vector formats
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = otgImage.Size
                };
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Save as BMP
                otgImage.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}