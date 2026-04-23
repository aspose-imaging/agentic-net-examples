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
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure font substitution:
            // Use a default font name that will be used when the original font is missing
            Aspose.Imaging.FontSettings.DefaultFontName = "Arial";

            // Optionally add system font folders so Aspose.Imaging can locate substitute fonts
            string[] systemFontFolders = Aspose.Imaging.FontSettings.GetDefaultFontsFolders();
            Aspose.Imaging.FontSettings.SetFontsFolders(systemFontFolders, true);

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for ODG conversion
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Prepare PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image, applying the font substitution settings
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}