using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG and output ZIP paths
        string inputPath = "input.svg";
        string outputPath = "output.zip";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage to access embedded images
                var vectorImage = (VectorImage)image;
                EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

                // Create the ZIP archive
                using (FileStream zipStream = new FileStream(outputPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    int index = 0;
                    foreach (var embedded in embeddedImages)
                    {
                        // Determine a file name for the entry, preserving original name if available
                        string entryName = $"image{index}.png";
                        var nameProp = embedded.GetType().GetProperty("Name");
                        if (nameProp != null)
                        {
                            string originalName = nameProp.GetValue(embedded) as string;
                            if (!string.IsNullOrEmpty(originalName))
                            {
                                entryName = originalName;
                                if (!Path.HasExtension(entryName))
                                    entryName = $"{entryName}.png";
                            }
                        }

                        // Create a new entry in the ZIP archive
                        ZipArchiveEntry zipEntry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                        using (Stream entryStream = zipEntry.Open())
                        {
                            // Save the embedded image directly into the ZIP entry as PNG
                            using (embedded)
                            {
                                var pngOptions = new PngOptions();
                                embedded.Image.Save(entryStream, pngOptions);
                            }
                        }

                        index++;
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
 * 1. When a web application needs to generate a downloadable package of all raster assets embedded in an SVG logo for offline editing, a developer can use this code to extract the images and zip them with their original filenames.
 * 2. When a digital asset management system imports SVG files and must catalog each embedded PNG or JPEG separately, this code lets the developer pull out the raster images and store them in a ZIP archive while keeping their original names for indexing.
 * 3. When an e‑learning platform receives SVG diagrams containing embedded screenshots and wants to provide instructors with the raw images for reuse in presentations, the code can extract those images and bundle them into a ZIP file.
 * 4. When a CI/CD pipeline validates that all raster resources referenced in an SVG are present and correctly named before publishing a design system, developers can run this code to pull the embedded images into a ZIP for automated checks.
 * 5. When a mobile app needs to cache the raster components of an SVG illustration for faster rendering on low‑power devices, the code can extract the images and archive them, preserving filenames for later lookup.
 */