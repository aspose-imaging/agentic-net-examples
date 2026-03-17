using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class PngProcessingExample
{
    static void Main()
    {
        // Path to the source PNG file.
        string inputPath = @"C:\Images\source.png";

        // Path where the processed PNG will be saved.
        string outputPath = @"C:\Images\processed.png";

        // Load the PNG image using the constructor that accepts a file path.
        using (PngImage pngImage = new PngImage(inputPath))
        {
            // Convert the image to grayscale. The image remains a PNG.
            pngImage.Grayscale();

            // Resize the image to 50% of its original dimensions.
            // The Resize method keeps the image type unchanged.
            int newWidth = pngImage.Width / 2;
            int newHeight = pngImage.Height / 2;
            pngImage.Resize(newWidth, newHeight);

            // Rotate the image 45 degrees around its centre.
            // Rotation also preserves the PNG format.
            pngImage.Rotate(45);

            // Save the modified image back to PNG format.
            // Using Save(string) ensures the file is written as PNG.
            pngImage.Save(outputPath);
        }
    }
}