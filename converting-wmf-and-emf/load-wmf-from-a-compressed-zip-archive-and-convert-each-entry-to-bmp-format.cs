// HOW-TO: Convert WMF Images Inside Zip to BMP Files Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input zip file and output directory
            string zipPath = @"C:\Input\images.zip";
            string outputDir = @"C:\Output\BmpImages";

            // Verify the zip file exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the zip archive for reading
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    // Process only WMF files
                    if (!entry.Name.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Build output BMP file path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(entry.Name);
                    string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load WMF image from the zip entry stream and save as BMP
                    using (Stream entryStream = entry.Open())
                    using (Image image = Image.Load(entryStream))
                    {
                        BmpOptions bmpOptions = new BmpOptions();
                        image.Save(outputPath, bmpOptions);
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
 * 1. When you need to batch‑convert legacy WMF drawings stored in a zip package to BMP for legacy Windows applications.
 * 2. When an automated import pipeline must extract vector icons from a compressed archive and save them as raster BMPs for printing.
 * 3. When a document management system receives zipped WMF assets and you must generate BMP thumbnails for preview.
 * 4. When migrating old CAD symbols packaged in zip files to a format supported by a .NET reporting engine that only accepts BMP.
 * 5. When creating a backup script that unpacks WMF files from archives and stores them as BMP to ensure compatibility with older image viewers.
 */
