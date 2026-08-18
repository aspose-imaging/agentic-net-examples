// HOW-TO: Extract Embedded Images from SVG and Save to ZIP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\example.svg";
            string outputZipPath = "Output\\embedded_images.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (var zipStream = new FileStream(outputZipPath, FileMode.Create))
            using (var archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create))
            {
                using (Image image = Image.Load(inputPath))
                {
                    var vectorImage = (VectorImage)image;
                    var images = vectorImage.GetEmbeddedImages();
                    int i = 0;
                    foreach (var im in images)
                    {
                        string extension = GetExtension(im.Image.FileFormat);
                        string entryName = $"image{i}{extension}";
                        i++;

                        using (im)
                        {
                            using (var ms = new MemoryStream())
                            {
                                im.Image.Save(ms, new PngOptions());
                                ms.Position = 0;
                                var entry = archive.CreateEntry(entryName);
                                using (var entryStream = entry.Open())
                                {
                                    ms.CopyTo(entryStream);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static string GetExtension(FileFormat format)
    {
        switch (format)
        {
            case FileFormat.Jpeg: return ".jpg";
            case FileFormat.Png: return ".png";
            case FileFormat.Bmp: return ".bmp";
            default: return "." + format.ToString().ToLower();
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to pull raster graphics embedded in an SVG diagram and archive them for separate processing or distribution.
 * 2. When a web application must extract PNG or JPEG assets from user‑uploaded SVG files and store them in a compressed ZIP package.
 * 3. When converting vector artwork that contains linked images into a portable bundle for offline viewing or backup.
 * 4. When automating a workflow that gathers all embedded images from multiple SVG assets and packages them for batch editing in Photoshop.
 * 5. When preparing assets for a content management system that requires individual image files extracted from SVG icons and delivered as a ZIP download.
 */
