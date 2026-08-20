// HOW-TO: Convert APNG to GIF and Add Custom Application Identifier in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG image
            using (Image apngImage = Image.Load(inputPath))
            {
                // Save as GIF (initial conversion)
                var gifOptions = new GifOptions();
                apngImage.Save(outputPath, gifOptions);
            }

            // Re-open the saved GIF to embed a custom application identifier
            using (GifImage gifImage = (GifImage)Image.Load(outputPath))
            {
                // Create an application extension block with a custom identifier
                // Authentication code and application data are left empty in this example
                var appExtension = new GifApplicationExtensionBlock(
                    "MyCustomApp",          // Application Identifier
                    new byte[0],            // Application Authentication Code
                    new byte[0]             // Application Data
                );

                // Add the block to the GIF image
                // The AddBlock method is part of the GifImage API for inserting custom blocks
                gifImage.AddBlock(appExtension);

                // Save the modified GIF (overwrites the previous file)
                gifImage.Save(outputPath);
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
 * 1. When you need to convert an animated PNG (APNG) to a widely supported GIF for web browsers while preserving animation frames.
 * 2. When you want to embed a custom application identifier into a GIF’s metadata so downstream tools can recognize the source application.
 * 3. When you are building a server‑side image pipeline that receives APNG uploads and must output GIFs with proprietary tags for tracking.
 * 4. When you need to add an application extension block to a GIF to comply with a proprietary file‑exchange specification.
 * 5. When you are automating batch processing of APNG files to GIFs and must include custom metadata for later analytics.
 */
