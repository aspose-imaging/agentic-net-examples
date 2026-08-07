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
        string inputPath = "input\\sample.png";
        string outputPath = "output\\result.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG file into a MemoryStream
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0; // reset for reading

                // Load image from the MemoryStream
                using (Image image = Image.Load(memoryStream))
                {
                    // Flip the image vertically
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    // Write the transformed image back to the same MemoryStream
                    memoryStream.SetLength(0);          // clear existing data
                    memoryStream.Position = 0;          // reset position
                    image.Save(memoryStream, new PngOptions());

                    // Save the resulting stream to the output file
                    memoryStream.Position = 0; // ensure we read from the beginning
                    using (FileStream outFile = File.Open(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.CopyTo(outFile);
                    }
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
 * 1. When a web service receives a PNG uploaded by a user and needs to display it upside‑down for a mirror‑effect preview without writing temporary files, a developer can load the image into a MemoryStream, flip it vertically with Aspose.Imaging, and return the modified stream.
 * 2. When generating printable labels that require the graphic to be inverted because the printer feeds paper from the opposite side, the code can read the PNG into a MemoryStream, apply a vertical flip, and save it back for the printing pipeline.
 * 3. When building a mobile app that captures screenshots, stores them in memory, and needs to correct orientation caused by device rotation, a developer can use this pattern to flip the PNG vertically in‑place before uploading.
 * 4. When creating an automated batch process that reads PNG assets from a database BLOB, applies a vertical mirror transformation, and writes the result back to the same BLOB field, the MemoryStream approach avoids extra disk I/O.
 * 5. When implementing a server‑side image‑editing API that accepts PNG data via a stream, performs a vertical flip for artistic effects, and streams the result back to the client, this code demonstrates the required C# and Aspose.Imaging steps.
 */