using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.jpg";
        string customFontDir = @"C:\Fonts";

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

            // Set custom font folder for vector rendering
            FontSettings.SetFontsFolder(customFontDir);
            FontSettings.UpdateFonts();

            // Load WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for WMF
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    // Optional: improve text rendering quality
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                // JPEG save options with vector rasterization
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}