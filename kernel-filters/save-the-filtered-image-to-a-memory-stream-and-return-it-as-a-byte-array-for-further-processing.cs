using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Process the image and obtain the filtered image as a byte array
            byte[] imageBytes = GetFilteredImageBytes(inputPath);

            // Example usage of the resulting byte array
            Console.WriteLine($"Filtered image byte array length: {imageBytes.Length}");
        }
        catch (Exception ex)
        {
            // Any unexpected error is reported without crashing the program
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads an image, applies a simple filter (BinarizeOtsu for BMP images),
    /// saves the result to a memory stream using PNG format, and returns the
    /// image data as a byte array.
    /// </summary>
    /// <param name="inputPath">Full path to the source image file.</param>
    /// <returns>Byte array containing the filtered image.</returns>
    static byte[] GetFilteredImageBytes(string inputPath)
    {
        // Load the image from the specified file
        using (Image image = Image.Load(inputPath))
        {
            // If the image is a BMP, apply a binarization filter
            if (image is BmpImage bmpImage)
            {
                bmpImage.BinarizeOtsu();
            }

            // Define PNG save options (default settings are sufficient here)
            PngOptions pngOptions = new PngOptions();

            // Save the processed image to a memory stream
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, pngOptions);
                // Return the stream contents as a byte array
                return stream.ToArray();
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web API receives a BMP file, applies Otsu binarization, and needs to return the processed PNG image as a byte array for client download.
 * 2. When a document management system generates on‑the‑fly thumbnails, it can filter the source BMP, convert it to PNG, and store the resulting byte array in a database BLOB.
 * 3. When a microservice sends a filtered image through a message queue, the method provides a PNG byte array that can be serialized and transmitted without creating temporary files.
 * 4. When an application composes an email with an inline image, it can embed the binarized PNG byte array directly as an attachment from memory.
 * 5. When a background worker prepares images for OCR, it uses the code to produce a PNG byte array of the binarized BMP, which the OCR engine consumes as an in‑memory stream.
 */