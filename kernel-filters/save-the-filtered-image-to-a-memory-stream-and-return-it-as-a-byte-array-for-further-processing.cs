using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Loads an image, saves it to a memory stream using PNG options,
    // and returns the resulting byte array.
    static byte[] GetImageBytes()
    {
        // Hard‑coded input and dummy output paths.
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.png";

        // Verify the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return null;
        }

        // Ensure the output directory exists (required before any save operation).
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, save it to a MemoryStream, and return the byte array.
        using (Image image = Image.Load(inputPath))
        {
            // Use default PNG options; can be customized if needed.
            PngOptions pngOptions = new PngOptions();

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, pngOptions);
                return ms.ToArray();
            }
        }
    }

    static void Main()
    {
        try
        {
            byte[] imageBytes = GetImageBytes();

            if (imageBytes != null)
            {
                Console.WriteLine($"Image saved to memory stream. Byte count: {imageBytes.Length}");
                // Further processing can be done with imageBytes here.
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}