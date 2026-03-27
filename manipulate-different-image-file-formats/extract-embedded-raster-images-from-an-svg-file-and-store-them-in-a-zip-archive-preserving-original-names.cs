using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input SVG file path
        string inputPath = @"C:\Images\input.svg";

        // Hardcoded output ZIP file path
        string outputPath = @"C:\Images\embedded_images.zip";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to VectorImage to access embedded images
            var vectorImage = (VectorImage)image;
            var embeddedImages = vectorImage.GetEmbeddedImages();

            // Create ZIP archive for output
            using (FileStream zipStream = new FileStream(outputPath, FileMode.Create))
            using (System.IO.Compression.ZipArchive zip = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create))
            {
                int index = 0;
                foreach (var embedded in embeddedImages)
                {
                    using (embedded)
                    {
                        // Preserve original name if available, otherwise use indexed name
                        string entryName = $"image{index++}.png";

                        // Create entry in ZIP archive
                        var entry = zip.CreateEntry(entryName);
                        using (Stream entryStream = entry.Open())
                        {
                            // Save the embedded raster image as PNG into the ZIP entry
                            var pngOptions = new PngOptions();
                            embedded.Image.Save(entryStream, pngOptions);
                        }
                    }
                }
            }
        }
    }
}