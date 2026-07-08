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
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image into a MemoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream fileStream = File.OpenRead(inputPath))
                {
                    fileStream.CopyTo(memoryStream);
                }

                // Reset position for loading the image
                memoryStream.Position = 0;

                // Load image from the stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Flip vertically
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    // Prepare stream for saving (clear previous data)
                    memoryStream.SetLength(0);
                    memoryStream.Position = 0;

                    // Save the modified image back into the same stream
                    PngOptions saveOptions = new PngOptions();
                    image.Save(memoryStream, saveOptions);
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
 * 1. When a web service receives a PNG upload from a user and needs to flip the image vertically in memory before saving it to storage, this code loads the PNG from a MemoryStream, applies RotateFlip, and writes it back without creating temporary files.
 * 2. When a desktop application processes scanned PNG documents that are upside down, it can use this code to load the image into a MemoryStream, flip it vertically, and save the corrected image back to the same stream for faster I/O.
 * 3. When a batch job reads PNG image blobs from a database, flips each image vertically, and writes the transformed data back into the original stream for downstream processing, this pattern provides an efficient in‑memory solution.
 * 4. When an image‑processing API receives a PNG image via a network stream and must return a vertically mirrored version, the code demonstrates how to load, rotate‑flip, and re‑save the image entirely within a MemoryStream.
 * 5. When writing unit tests to verify that Aspose.Imaging’s RotateFlipType.RotateNoneFlipY correctly flips PNG images, developers can use this code to load the image, apply the vertical flip, and save the result back to the same stream for assertion.
 */