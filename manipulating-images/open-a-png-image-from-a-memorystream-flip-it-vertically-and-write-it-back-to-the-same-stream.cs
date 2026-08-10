// HOW-TO: Flip a PNG Vertically from MemoryStream and Save Back in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image into a memory stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream fileStream = File.OpenRead(inputPath))
                {
                    fileStream.CopyTo(memoryStream);
                }

                // Reset stream position for reading
                memoryStream.Position = 0;

                // Load image from the memory stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Flip the image vertically
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    // Prepare the stream for writing the modified image
                    memoryStream.SetLength(0);
                    memoryStream.Position = 0;

                    // Save the flipped image back to the same stream using default PNG options
                    image.Save(memoryStream, new PngOptions());
                }

                // Write the processed stream to the output file
                memoryStream.Position = 0;
                using (FileStream outFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.CopyTo(outFile);
                }
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
 * 1. When you need to vertically mirror a PNG received from a web API without writing temporary files.
 * 2. When processing uploaded user images in an ASP.NET service and you must flip them before storing.
 * 3. When generating thumbnails for a PDF where the source PNG must be inverted vertically in memory.
 * 4. When converting scanned documents that are upside‑down by loading them into a MemoryStream, flipping, and saving back.
 * 5. When performing batch image transformations in a background worker that reads, modifies, and rewrites PNGs using streams to reduce I/O overhead.
 */
