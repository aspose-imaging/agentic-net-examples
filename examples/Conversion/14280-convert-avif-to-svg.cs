using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class AvifToSvgConverter
{
    static void Main()
    {
        // Path to the source AVIF image
        string inputFile = @"C:\Images\sample.avif";

        // Desired output SVG file path
        string outputFile = @"C:\Images\sample.svg";

        // Load the AVIF image using Aspose.Imaging's load lifecycle method
        using (Image image = Image.Load(inputFile))
        {
            // Configure rasterization options for vector (SVG) output
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the original image dimensions
                PageSize = image.Size
            };

            // Set up SVG save options and attach the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Optional: keep metadata, set compression, etc.
                KeepMetadata = true,
                Compress = false
            };

            // Save the loaded AVIF image as an SVG file using the save lifecycle method
            image.Save(outputFile, svgOptions);
        }
    }
}