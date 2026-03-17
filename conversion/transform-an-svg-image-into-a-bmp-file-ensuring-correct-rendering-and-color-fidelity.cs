using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = "input.svg";
        // Output BMP file path
        string outputPath = "output.bmp";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure BMP save options with vector rasterization settings
            BmpOptions bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    // Preserve original SVG dimensions
                    PageSize = image.Size
                }
            };

            // Save the rendered image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}