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
            // Prepare PNG save options (default settings are sufficient here).
            PngOptions pngOptions = new PngOptions();

            // Save the image into a memory stream.
            MemoryStream stream = new MemoryStream();
            image.Save(stream, pngOptions);

            // Reset the position so the caller can read from the beginning.
            stream.Position = 0;
            return stream;
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

            // Perform the conversion.
            MemoryStream pngStream = ConvertToPngMemoryStream(inputPath);
            Console.WriteLine($"PNG stream length: {pngStream.Length}");

            // Ensure the output directory exists before writing the file.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Write the memory stream to a physical PNG file (optional demonstration).
            using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                pngStream.CopyTo(file);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}