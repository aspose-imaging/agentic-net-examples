using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input, output and fonts folder paths
            string inputPath = @"C:\Images\input.psd";
            string outputPath = @"C:\Images\output.png";
            string fontsFolder = @"C:\Fonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Register custom fonts folder and refresh the font cache
            FontSettings.SetFontsFolder(fontsFolder);
            FontSettings.UpdateFonts();

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options with vector rasterization to preserve text appearance
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}