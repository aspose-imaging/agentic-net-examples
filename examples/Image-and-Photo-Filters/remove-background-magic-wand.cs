using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png; // Adjust based on your image format
using Aspose.Imaging.ImageOptions;

class RemoveBackgroundExample
{
    static void Main()
    {
        // Path to the source image
        string inputPath = @"C:\Temp\source_image.png";

        // Path where the result will be saved
        string outputPath = @"C:\Temp\source_image_no_bg.png";

        // Load the image. Cast to VectorImage because RemoveBackground is defined there.
        // If the image is not a vector format, this cast will fail; ensure you use a supported format.
        using (VectorImage image = (VectorImage)Image.Load(inputPath))
        {
            // Remove the background using the built‑in RemoveBackground method.
            // This internally uses a magic‑wand‑like algorithm to separate foreground from background.
            image.RemoveBackground();

            // Save the processed image to the desired location.
            // The same format as the source is used; you can change the options if needed.
            image.Save(outputPath);
        }

        Console.WriteLine("Background removal completed. Result saved to: " + outputPath);
    }
}