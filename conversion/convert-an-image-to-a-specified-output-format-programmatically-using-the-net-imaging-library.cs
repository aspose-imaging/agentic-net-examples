using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageConversion
{
    static void Main()
    {
        // Path to the source image
        string inputPath = @"C:\Images\source.png";

        // Desired output path with the target format extension (e.g., .jpg, .bmp, .tiff)
        string outputPath = @"C:\Images\converted.jpg";

        // Load the image using Aspose.Imaging's built‑in Load method
        using (Image image = Image.Load(inputPath))
        {
            // Save the image to the specified output format.
            // The format is inferred from the file extension of outputPath.
            image.Save(outputPath);
        }

        Console.WriteLine("Image conversion completed.");
    }
}