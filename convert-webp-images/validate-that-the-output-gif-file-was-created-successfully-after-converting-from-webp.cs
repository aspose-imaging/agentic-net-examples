// HOW-TO: Convert WebP To GIF And Verify Output File In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "C:\\temp\\input.webp";
            string outputPath = "C:\\temp\\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save the image as GIF using default GifOptions
                webPImage.Save(outputPath, new GifOptions());
            }

            // Validate that the GIF file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine($"GIF file created successfully: {outputPath}");
            }
            else
            {
                Console.Error.WriteLine($"Failed to create GIF file: {outputPath}");
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
 * 1. When you need to display a WebP image on platforms that only support GIF, you can convert it to GIF using Aspose.Imaging in C# and confirm the file was created.
 * 2. When automating a batch process that extracts WebP assets from a repository and generates GIF previews for a web gallery, this code ensures each conversion succeeds.
 * 3. When integrating image conversion into a .NET service that receives user‑uploaded WebP files and must store them as GIFs for email attachments, the validation step guarantees the output exists before sending.
 * 4. When migrating legacy content from a WebP‑based CMS to a GIF‑compatible system, the snippet provides a quick way to convert individual images and verify the conversion result.
 * 5. When writing unit tests for an image‑processing pipeline that transforms WebP to GIF, this example demonstrates how to programmatically check that the GIF file is generated successfully.
 */
