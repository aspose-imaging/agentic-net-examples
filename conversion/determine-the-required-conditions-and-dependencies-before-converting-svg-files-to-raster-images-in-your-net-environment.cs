using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Path to the source SVG file
        string inputPath = @"C:\Images\sample.svg";

        // Desired path for the rasterized output (PNG)
        string outputPath = @"C:\Images\output.png";

        // ------------------------------------------------------------
        // 1. Verify that the input SVG file exists
        // ------------------------------------------------------------
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Error: Input file not found -> {inputPath}");
            return;
        }

        // ------------------------------------------------------------
        // 2. Ensure the output directory exists
        // ------------------------------------------------------------
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // ------------------------------------------------------------
        // 3. Load the SVG image using the unified loader
        // ------------------------------------------------------------
        using (Image image = Image.Load(inputPath))
        {
            // --------------------------------------------------------
            // 4. Confirm that the loaded image is a vector image (SVG)
            // --------------------------------------------------------
            if (!(image is VectorImage))
            {
                Console.WriteLine("Error: Loaded image is not a vector image (SVG).");
                return;
            }

            // --------------------------------------------------------
            // 5. Configure rasterization options
            // --------------------------------------------------------
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Optional: set a background color (default is white)
                BackgroundColor = Color.White,

                // Preserve the original SVG dimensions
                PageSize = image.Size,

                // Enable antialiasing for smoother lines and curves
                SmoothingMode = SmoothingMode.AntiAlias,

                // Render text with antialiasing
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // --------------------------------------------------------
            // 6. Prepare PNG save options and attach rasterization settings
            // --------------------------------------------------------
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // --------------------------------------------------------
            // 7. Save the rasterized image to the target file
            // --------------------------------------------------------
            image.Save(outputPath, pngOptions);
        }

        Console.WriteLine("SVG to raster conversion completed successfully.");
    }
}