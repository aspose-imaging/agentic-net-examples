using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Minify XML by disabling compression (svgz) and using default rasterization options
                    Compress = false,
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        // Preserve original size
                        PageSize = image.Size,
                        // Optional: improve minification by disabling smoothing and text rendering hints
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                    }
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}