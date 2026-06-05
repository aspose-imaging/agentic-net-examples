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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options with custom page size
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set desired width and height (in pixels). If set to 0, aspect ratio is preserved.
                    PageWidth = 800f,
                    PageHeight = 600f,
                    // Optional: set a background color
                    BackgroundColor = Color.White
                };

                // Prepare PNG save options and attach the rasterization options
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image
                svgImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}