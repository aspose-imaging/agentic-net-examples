using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageConversionExample
{
    static void Main()
    {
        // Path to the source image (any supported format)
        string sourcePath = @"c:\temp\source.jpg";

        // Desired output path with the target format extension (e.g., PNG)
        string targetPath = @"c:\temp\converted.png";

        // Load the image using Aspose.Imaging's factory method.
        // The returned object is of type Image, which works for all raster formats.
        using (Image image = Image.Load(sourcePath))
        {
            // If any additional processing is required, it can be done here.
            // For this example we directly save the image in the new format.

            // Create PNG-specific save options.
            PngOptions pngOptions = new PngOptions
            {
                // Example option: set the bit depth (optional)
                // BitDepth = PngBitDepth.Bit8
            };

            // Save the image to the target path using the PNG options.
            image.Save(targetPath, pngOptions);
        }

        Console.WriteLine("Image conversion completed successfully.");
    }
}