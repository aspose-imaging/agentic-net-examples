using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "input.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load TIFF image from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (Image image = Image.Load(inputStream))
            {
                // Cast to TiffImage to access TIFF-specific methods
                TiffImage tiffImage = (TiffImage)image;

                // Define a 200x200 rectangle starting at (0,0)
                Rectangle cropArea = new Rectangle(0, 0, 200, 200);

                // Perform cropping
                tiffImage.Crop(cropArea);

                // Save the cropped image to a memory stream (PNG format for demonstration)
                using (MemoryStream outputStream = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    tiffImage.Save(outputStream, pngOptions);

                    // The memory stream now contains the cropped image data
                    // Reset position if further processing is needed
                    outputStream.Position = 0;

                    // Example: write the size of the resulting stream
                    Console.WriteLine($"Cropped image size in memory: {outputStream.Length} bytes");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}