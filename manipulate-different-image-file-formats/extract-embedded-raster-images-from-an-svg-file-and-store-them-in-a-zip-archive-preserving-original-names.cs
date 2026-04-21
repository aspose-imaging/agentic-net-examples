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
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "embedded_images.zip";

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
                using (FileStream zipFileStream = new FileStream(outputPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                {
                    int index = 0;
                    foreach (var embedded in embeddedImages)
                    {
                        // Determine a name for the entry; preserve original if possible
                        string entryName = $"image{index}.png";
                        // Some EmbeddedImage implementations expose a Name property; use it if available
                        var nameProp = embedded.GetType().GetProperty("Name");
                        if (nameProp != null)
                        {
                            string originalName = nameProp.GetValue(embedded) as string;
                            if (!string.IsNullOrEmpty(originalName))
                            {
                                entryName = originalName;
                            }
                        }

                        // Save the embedded image to a memory stream as PNG
                        using (embedded)
                        {
                            var pngOptions = new PngOptions();
                            using (var ms = new MemoryStream())
                            {
                                embedded.Image.Save(ms, pngOptions);
                                ms.Position = 0;

                                // Add the image to the ZIP archive
                                var entry = archive.CreateEntry(entryName);
                                using (var entryStream = entry.Open())
                                {
                                    ms.CopyTo(entryStream);
                                }
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