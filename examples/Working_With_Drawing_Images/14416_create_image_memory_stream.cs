using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source image file
        string inputPath = "sample.bmp";

        // Create a MemoryStream to hold the processed image data
        using (MemoryStream outputStream = new MemoryStream())
        {
            // Load the image from disk
            using (Image image = Image.Load(inputPath))
            {
                // Example processing: rotate the image 180 degrees
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Prepare PNG save options and bind the stream as the source
                PngOptions pngOptions = new PngOptions
                {
                    Source = new StreamSource(outputStream)
                };

                // Save the processed image into the memory stream
                image.Save(outputStream, pngOptions);
            }

            // Reset stream position before reading
            outputStream.Position = 0;

            // Write the memory stream contents to a file for verification
            using (FileStream file = new FileStream("output.png", FileMode.Create, FileAccess.Write))
            {
                outputStream.CopyTo(file);
            }
        }
    }
}