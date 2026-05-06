using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG file and output ZIP file paths
        string inputPath = "input.svg";
        string outputPath = "output.zip";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
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
                using (FileStream zipFileStream = new FileStream(outputPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                {
                    int index = 0;
                    foreach (var embedded in embeddedImages)
                    {
                        // Determine a file name for the entry
                        string entryName;
                        // Try to preserve original name if available
                        // EmbeddedImage may expose a Name property; fallback to generated name
                        var nameProp = embedded.GetType().GetProperty("Name");
                        if (nameProp != null)
                        {
                            string originalName = nameProp.GetValue(embedded) as string;
                            entryName = !string.IsNullOrEmpty(originalName) ? originalName : $"image{index}.png";
                        }
                        else
                        {
                            entryName = $"image{index}.png";
                        }

                        // Save the embedded raster image to a memory stream in PNG format
                        using (var ms = new MemoryStream())
                        {
                            using (embedded)
                            {
                                // The embedded image is itself an Image instance
                                embedded.Image.Save(ms, new PngOptions());
                            }

                            ms.Position = 0;

                            // Add the image data to the ZIP archive
                            var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                            using (var entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
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