using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
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
        using (MemoryStream pngStream = ConvertToPngMemoryStream(inputPath))
        {
            // Write the MemoryStream to a file for demonstration purposes
            using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                pngStream.Position = 0;
                pngStream.CopyTo(file);
            }

            Console.WriteLine($"PNG saved to {outputPath}, stream length: {pngStream.Length}");
        }
    }

    // Loads an image, converts it to PNG format, saves it into a MemoryStream, and returns the stream.
    static MemoryStream ConvertToPngMemoryStream(string inputPath)
    {
        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Define PNG save options (default settings)
            PngOptions pngOptions = new PngOptions();

            // Save the image to a memory stream
            MemoryStream stream = new MemoryStream();
            image.Save(stream, pngOptions);
            stream.Position = 0; // Reset position for the caller
            return stream;
        }
    }
}