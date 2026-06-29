using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Converts any supported image to PNG and returns the result in a MemoryStream.
    static MemoryStream ConvertToPngMemoryStream(string inputPath)
    {
        // Load the source image.
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options (default settings are sufficient for most cases).
            PngOptions pngOptions = new PngOptions();

            // Save the image into a memory stream.
            MemoryStream stream = new MemoryStream();
            image.Save(stream, pngOptions);

            // Reset the stream position so it can be read from the beginning by the caller.
            stream.Position = 0;
            return stream;
        }
    }

    static void Main()
    {
        // Hardcoded input and output paths.
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Perform the conversion.
            using (MemoryStream pngStream = ConvertToPngMemoryStream(inputPath))
            {
                // For demonstration, write the stream to the output file.
                using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    pngStream.CopyTo(file);
                }

                Console.WriteLine($"Conversion successful. PNG size: {pngStream.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web API receives an uploaded BMP file, it can convert the image to PNG in a MemoryStream and stream the result back to the client without creating temporary files on the server.
 * 2. When generating a PDF report that embeds various source images, a developer can use the PNG MemoryStream to insert the converted image directly into the PDF using Aspose.PDF.
 * 3. When an Azure Function is triggered by a blob storage event, converting each incoming image to PNG in memory allows the function to upload the PNG to another container without consuming local disk space.
 * 4. When a desktop application needs to preview a user‑selected image in a WPF Image control, converting the file to a PNG MemoryStream provides a fast, format‑agnostic source for rendering.
 * 5. When building a microservice that resizes and optimizes images for a mobile app, returning the optimized PNG as a MemoryStream enables the service to send the image as a byte array in the HTTP response.
 */