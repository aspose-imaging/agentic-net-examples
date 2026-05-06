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
            // Hardcoded input, output and custom font directory paths
            string inputPath = @"C:\Images\input.wmf";
            string outputPath = @"C:\Images\output.jpg";
            string customFontDir = @"C:\CustomFonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set custom fonts folder for rendering the WMF
            FontSettings.SetFontsFolder(customFontDir);
            FontSettings.UpdateFonts();

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options based on the source image size
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // JPEG save options with vector rasterization
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}