using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class OdgToImageConverter
{
    static void Main()
    {
        // Path to the source ODG file
        string inputFile = @"C:\Temp\sample.odg";

        // Desired output file (change extension to .png, .jpeg, .bmp, etc.)
        string outputFile = @"C:\Temp\sample.png";

        // Load the ODG image using the unified Image.Load method
        using (Image image = Image.Load(inputFile))
        {
            // Configure rasterization options required for vector formats like ODG
            var rasterOptions = new OdgRasterizationOptions
            {
                // Use the original image size for the rasterized page
                PageSize = image.Size,
                // Set a background color (optional, white is common)
                BackgroundColor = Color.White
            };

            // Choose the target format options (here PNG is used)
            var saveOptions = new PngOptions
            {
                // Attach the rasterization options so the vector ODG is rasterized correctly
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image to the desired format
            image.Save(outputFile, saveOptions);
        }
    }
}