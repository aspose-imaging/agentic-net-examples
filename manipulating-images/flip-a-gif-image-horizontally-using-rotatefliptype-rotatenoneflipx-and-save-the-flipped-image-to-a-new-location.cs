using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output_flipped.gif";

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

            // Load the GIF image, flip horizontally, and save
            using (GifImage image = (GifImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                image.Save(outputPath);
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
 * 1. When creating a web gallery that mirrors animated GIFs for a right‑to‑left language layout, a developer can use this C# code with Aspose.Imaging to flip the GIF horizontally and store the result.
 * 2. When generating thumbnail previews that need to show the opposite orientation of a user‑uploaded GIF, the RotateFlipType.RotateNoneFlipX operation lets the developer produce a flipped copy without altering the original file.
 * 3. When building an e‑learning platform that reuses existing GIF animations but requires a mirrored version for a different UI theme, the code demonstrates how to load, flip, and save the GIF using Aspose.Imaging for .NET.
 * 4. When automating a batch process that corrects mistakenly reversed GIF assets in a content management system, the developer can apply this snippet to flip each image horizontally and write it to a new location.
 * 5. When implementing a custom image‑processing service that needs to provide a “mirror” effect for animated GIFs on demand, the example shows how to perform the flip operation and return the new file path in a C# application.
 */