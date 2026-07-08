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

                // Create ZIP archive for output
                using (FileStream zipFileStream = new FileStream(outputPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                {
                    int index = 0;
                    foreach (var embedded in embeddedImages)
                    {
                        // Determine entry name – try to preserve original name if available
                        string entryName = $"image{index}.png";
                        var nameProp = embedded.GetType().GetProperty("Name");
                        if (nameProp != null)
                        {
                            string originalName = nameProp.GetValue(embedded) as string;
                            if (!string.IsNullOrEmpty(originalName))
                            {
                                entryName = Path.GetFileNameWithoutExtension(originalName) + ".png";
                            }
                        }

                        // Create entry in the ZIP archive
                        ZipArchiveEntry entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                        using (Stream entryStream = entry.Open())
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Save the embedded raster image as PNG into memory
                            using (embedded)
                            {
                                embedded.Image.Save(ms, new PngOptions());
                            }
                            ms.Position = 0;
                            ms.CopyTo(entryStream);
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
 * 1. When a web application needs to separate and archive raster assets embedded in an SVG logo for reuse in other design tools, a developer can use this code to extract the PNG images and zip them while keeping their original filenames.
 * 2. When an automated build pipeline processes SVG icons that contain embedded images and must deliver those raster files to a CDN, the code can pull out each image and package them into a ZIP archive for deployment.
 * 3. When a digital asset management system imports SVG files and wants to index each embedded bitmap separately, a developer can run this routine to extract the images and store them in a compressed archive preserving their source names.
 * 4. When a desktop utility converts legacy SVG documents into a portable package for archival, the code enables extraction of all embedded raster graphics and bundles them into a ZIP file for easy storage.
 * 5. When a reporting tool generates PDFs from SVG charts that include embedded pictures and must provide the original images as downloadable resources, this code can retrieve the images and zip them with their original filenames for end‑users.
 */