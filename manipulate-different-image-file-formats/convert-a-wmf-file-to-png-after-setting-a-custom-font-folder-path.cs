using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Set a custom folder for font lookup
        string customFontFolder = @"C:\MyFonts";
        Aspose.Imaging.FontSettings.SetFontsFolder(customFontFolder);

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options for vector to raster conversion
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the image as PNG using the rasterization options
            image.Save(outputPath, new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            });
        }
    }
}