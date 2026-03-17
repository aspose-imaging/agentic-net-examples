using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ApngToSvgConverter
{
    static void Main()
    {
        // Path to the source APNG file
        string inputApngPath = @"C:\Images\animation.apng";

        // Desired output SVG file path
        string outputSvgPath = @"C:\Images\animation_converted.svg";

        // Load the APNG image (supports multi‑frame APNG)
        using (Image apngImage = Image.Load(inputApngPath))
        {
            // Configure rasterization options – use the original image size as the SVG page size
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = apngImage.Size
            };

            // Set up SVG save options with the rasterization settings
            var svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Optional: compress the SVG output (set to false for plain SVG)
                Compress = false
            };

            // Save the APNG as an SVG file
            apngImage.Save(outputSvgPath, svgSaveOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}