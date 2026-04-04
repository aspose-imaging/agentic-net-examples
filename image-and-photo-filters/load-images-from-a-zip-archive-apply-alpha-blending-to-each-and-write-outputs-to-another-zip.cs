using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output ZIP paths
        string inputZipPath = "input.zip";
        string outputZipPath = "output.zip";

        // Verify input ZIP exists
        if (!File.Exists(inputZipPath))
        {
            Console.Error.WriteLine($"File not found: {inputZipPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

        // Open input ZIP for reading
        using (FileStream inputZipStream = new FileStream(inputZipPath, FileMode.Open, FileAccess.Read))
        using (System.IO.Compression.ZipArchive inputArchive = new System.IO.Compression.ZipArchive(inputZipStream, System.IO.Compression.ZipArchiveMode.Read))
        // Create output ZIP for writing
        using (FileStream outputZipStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.ReadWrite))
        using (System.IO.Compression.ZipArchive outputArchive = new System.IO.Compression.ZipArchive(outputZipStream, System.IO.Compression.ZipArchiveMode.Create))
        {
            foreach (var entry in inputArchive.Entries)
            {
                // Process only image files based on extension
                string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".bmp" && ext != ".gif" && ext != ".tif" && ext != ".tiff")
                    continue;

                // Load image from ZIP entry into memory
                using (Stream entryStream = entry.Open())
                using (MemoryStream imageData = new MemoryStream())
                {
                    entryStream.CopyTo(imageData);
                    imageData.Position = 0;

                    using (RasterImage sourceImage = (RasterImage)Image.Load(imageData))
                    {
                        int width = sourceImage.Width;
                        int height = sourceImage.Height;

                        // Create an in‑memory canvas (PNG) to hold the blended result
                        Stream canvasMemory = new MemoryStream();
                        StreamSource canvasSource = new StreamSource(canvasMemory);
                        PngOptions pngOptions = new PngOptions() { Source = canvasSource };

                        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
                        {
                            // Apply alpha blending with 50% opacity
                            canvas.Blend(new Point(0, 0), sourceImage, 128);

                            // Save the bound canvas to its stream
                            canvas.Save();

                            // Prepare the output ZIP entry
                            canvasMemory.Position = 0;
                            var outEntry = outputArchive.CreateEntry(entry.Name);
                            using (Stream outEntryStream = outEntry.Open())
                            {
                                canvasMemory.CopyTo(outEntryStream);
                            }
                        }
                    }
                }
            }
        }
    }
}