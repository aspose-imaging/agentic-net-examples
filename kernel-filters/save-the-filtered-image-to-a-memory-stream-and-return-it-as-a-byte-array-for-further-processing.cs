using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Process image and obtain byte array
            byte[] imageBytes = GetFilteredImageBytes(inputPath);

            // Example usage of the resulting byte array
            Console.WriteLine($"Filtered image byte array length: {imageBytes.Length}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Loads the image, applies a filter, saves to a MemoryStream and returns the bytes
    static byte[] GetFilteredImageBytes(string inputPath)
    {
        // Load the image from the specified file
        using (Image image = Image.Load(inputPath))
        {
            // If the image is a BMP, apply Otsu binarization as an example filter
            if (image is BmpImage bmpImage)
            {
                bmpImage.BinarizeOtsu();
            }

            // Prepare save options (PNG format in this example)
            PngOptions saveOptions = new PngOptions();

            // Save the filtered image to a memory stream
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, saveOptions);
                // Return the underlying byte array
                return stream.ToArray();
            }
        }
    }
}