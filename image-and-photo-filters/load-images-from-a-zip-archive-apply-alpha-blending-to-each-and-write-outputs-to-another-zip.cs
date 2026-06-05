using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = "input.zip";
            string outputZipPath = "output.zip";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (FileStream inputZipStream = File.OpenRead(inputZipPath))
            using (System.IO.Compression.ZipArchive inputZip = new System.IO.Compression.ZipArchive(inputZipStream, System.IO.Compression.ZipArchiveMode.Read))
            using (FileStream outputZipStream = new FileStream(outputZipPath, FileMode.Create))
            using (System.IO.Compression.ZipArchive outputZip = new System.IO.Compression.ZipArchive(outputZipStream, System.IO.Compression.ZipArchiveMode.Create))
            {
                foreach (var entry in inputZip.Entries)
                {
                    if (string.IsNullOrEmpty(entry.Name))
                        continue; // skip directories

                    string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                    if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".bmp" && ext != ".gif" && ext != ".tif" && ext != ".tiff")
                        continue; // skip non-image files

                    using (Stream entryStream = entry.Open())
                    using (RasterImage image = (RasterImage)Image.Load(entryStream))
                    {
                        // Create a semi‑transparent red overlay
                        FileCreateSource overlaySource = new FileCreateSource("overlay.tmp", false);
                        BmpOptions overlayOpts = new BmpOptions { Source = overlaySource };
                        using (RasterImage overlay = (RasterImage)Image.Create(overlayOpts, image.Width, image.Height))
                        {
                            Graphics overlayGraphics = new Graphics(overlay);
                            overlayGraphics.Clear(Aspose.Imaging.Color.FromArgb(128, 255, 0, 0));

                            // Alpha blend overlay onto the original image
                            image.Blend(new Point(0, 0), overlay, 128);
                        }

                        // Save blended image into the output zip as PNG
                        var outEntry = outputZip.CreateEntry(entry.FullName);
                        using (Stream outEntryStream = outEntry.Open())
                        {
                            PngOptions pngOpts = new PngOptions();
                            image.Save(outEntryStream, pngOpts);
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
}