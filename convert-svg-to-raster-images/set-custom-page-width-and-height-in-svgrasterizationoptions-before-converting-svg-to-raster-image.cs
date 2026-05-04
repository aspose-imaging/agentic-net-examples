using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage for access to Size if needed
                SvgImage svgImage = (SvgImage)image;

                // Configure rasterization options with custom page size
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set custom width and height (in pixels)
                    PageWidth = 800,   // custom width
                    PageHeight = 600,  // custom height

                    // Optional: preserve aspect ratio if one dimension is zero
                    // PageWidth = 0, // would preserve aspect ratio based on height
                    // PageHeight = 0 // would preserve aspect ratio based on width

                    // You can also set other options, e.g., background color
                    // BackgroundColor = Color.White
                };

                // Set up PNG save options and attach rasterization options
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}