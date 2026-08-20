// HOW-TO: Convert BMP to PNG and Return MemoryStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Convert the image to PNG and obtain a MemoryStream
            using (MemoryStream pngStream = ConvertToPng(inputPath))
            {
                // Write the MemoryStream contents to the output file
                using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    pngStream.Position = 0;
                    pngStream.CopyTo(file);
                }

                Console.WriteLine($"PNG saved to {outputPath}, stream length: {pngStream.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Loads an image, converts it to PNG format, and returns the result in a MemoryStream.
    static MemoryStream ConvertToPng(string inputPath)
    {
        using (Image image = Image.Load(inputPath))
        {
            PngOptions pngOptions = new PngOptions(); // Default PNG options
            MemoryStream stream = new MemoryStream();
            image.Save(stream, pngOptions); // Save image to the memory stream
            stream.Position = 0; // Reset position for reading
            return stream;
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a BMP file to a PNG image in memory for further processing or sending over a network.
 * 2. When an API endpoint must return an image as a stream without writing a temporary file to disk.
 * 3. When you want to generate a PNG thumbnail from a user‑uploaded bitmap and store it directly in a database BLOB.
 * 4. When a background service converts legacy bitmap assets to PNG for a web application while keeping the data in a MemoryStream for performance.
 * 5. When you need to validate or manipulate the PNG data in memory before saving it to a specific folder or cloud storage.
 */
