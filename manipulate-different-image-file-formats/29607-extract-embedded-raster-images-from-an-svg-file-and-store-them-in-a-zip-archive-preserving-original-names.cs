using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG file and output ZIP archive paths
        string inputPath = @"C:\Temp\input.svg";
        string outputPath = @"C:\Temp\embedded_images.zip";

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
                // Cast to VectorImage to access embedded resources
                var vectorImage = image as VectorImage;
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a vector image.");
                    return;
                }

                // Retrieve embedded raster images
                EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();
                if (embeddedImages == null || embeddedImages.Length == 0)
                {
                    Console.Error.WriteLine("No embedded images found in the SVG.");
                    return;
                }

                // Create the ZIP archive
                using (FileStream zipStream = new FileStream(outputPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    for (int i = 0; i < embeddedImages.Length; i++)
                    {
                        var embedded = embeddedImages[i];
                        // Determine entry name: use original name if available, otherwise generate one
                        string entryName = "image" + i + ".png";
                        try
                        {
                            // Attempt to use a Name property if it exists via reflection
                            var nameProp = embedded.GetType().GetProperty("Name");
                            if (nameProp != null)
                            {
                                var nameValue = nameProp.GetValue(embedded) as string;
                                if (!string.IsNullOrEmpty(nameValue))
                                    entryName = nameValue;
                            }
                        }
                        catch { /* ignore reflection errors */ }

                        // Save the embedded image to a memory stream in PNG format
                        using (MemoryStream ms = new MemoryStream())
                        {
                            embedded.Image.Save(ms, new PngOptions());
                            ms.Position = 0;

                            // Add the image to the ZIP archive
                            ZipArchiveEntry entry = archive.CreateEntry(entryName);
                            using (Stream entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                        }

                        // Dispose the embedded image resource
                        embedded.Dispose();
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
 * 1. When a web application needs to separate and archive the original PNG or JPEG assets embedded in an SVG logo for reuse in a content management system.
 * 2. When a designer wants to extract all raster images from an SVG illustration to edit them individually in Photoshop while keeping their original filenames inside a zip file.
 * 3. When an automated build pipeline processes SVG assets and must package the embedded bitmap resources for distribution to mobile apps that require separate image files.
 * 4. When a compliance audit requires preserving the exact embedded image files from SVG diagrams and storing them in a zip archive for documentation purposes.
 * 5. When a migration tool converts legacy SVG files into a new format and needs to extract and archive the embedded raster images to ensure no visual data is lost.
 */