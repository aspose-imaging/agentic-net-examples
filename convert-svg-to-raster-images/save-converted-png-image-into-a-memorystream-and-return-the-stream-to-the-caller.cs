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
            // Prepare PNG save options (default settings).
            PngOptions pngOptions = new PngOptions();

            // Create a memory stream to hold the PNG data.
            MemoryStream pngStream = new MemoryStream();

            // Save the image as PNG into the memory stream.
            image.Save(pngStream, pngOptions);

            // Reset the stream position so it can be read from the beginning.
            pngStream.Position = 0;

            // Return the stream to the caller (caller is responsible for disposing it).
            return pngStream;
        }
    }

    static void Main()
    {
        // Hard‑coded input and output paths.
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
                // Write the PNG data from the memory stream to the output file.
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    pngStream.CopyTo(fileStream);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}