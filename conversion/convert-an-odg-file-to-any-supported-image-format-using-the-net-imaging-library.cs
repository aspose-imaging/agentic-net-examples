using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class OdgConversion
{
    static void Main()
    {
        // Path to the source ODG file
        string inputFile = @"C:\Images\sample.odg";

        // Desired output image path (PNG in this example)
        string outputFile = @"C:\Images\sample_converted.png";

        // Load the ODG image using the unified Image.Load method
        using (Image image = Image.Load(inputFile))
        {
            // Configure rasterization options for vector ODG content
            var rasterOptions = new OdgRasterizationOptions
            {
                // Set a background color for the rasterized image
                BackgroundColor = Color.White,
                // Preserve the original page size
                PageSize = image.Size
            };

            // Create PNG save options and attach the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the ODG as a PNG image
            image.Save(outputFile, pngOptions);
        }
    }
}