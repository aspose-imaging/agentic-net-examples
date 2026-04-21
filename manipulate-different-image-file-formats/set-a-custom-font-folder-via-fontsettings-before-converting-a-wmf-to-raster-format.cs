using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\sample.png";
            string fontFolder = "Fonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set custom font folder
            FontSettings.SetFontsFolders(new string[] { fontFolder }, true);

            // Load WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options
                var rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                // Set PNG save options with rasterization
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as raster PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}