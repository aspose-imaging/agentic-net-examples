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
            string zipPath = @"C:\Input\wmf_archive.zip";
            string outputDirectory = @"C:\Output\BmpImages";

            // Verify the zip file exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure the output directory exists (CreateDirectory works even if the directory already exists)
            Directory.CreateDirectory(outputDirectory);

            // Open the zip archive for reading
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    // Process only files with .wmf or .wmz extensions (case‑insensitive)
                    string extension = Path.GetExtension(entry.FullName);
                    if (!string.Equals(extension, ".wmf", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(extension, ".wmz", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    // Build the output BMP file path
                    string outputFileName = Path.GetFileNameWithoutExtension(entry.Name) + ".bmp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the WMF image from the zip entry stream
                    using (Stream entryStream = entry.Open())
                    {
                        // Aspose.Imaging.Image.Load can read from a stream
                        using (Image image = Image.Load(entryStream))
                        {
                            // Save as BMP using default BMP options
                            image.Save(outputPath, new BmpOptions());
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert legacy Windows Metafile (WMF/WMZ) graphics stored in a compressed zip archive into bitmap (BMP) files for use in older reporting systems.
 * 2. When an application must extract vector icons from a vendor‑supplied zip package and render them as BMP thumbnails for display in a Windows desktop UI.
 * 3. When a migration tool has to process archived design assets, loading each WMF entry from a zip file and saving them as BMP to ensure compatibility with legacy printing pipelines.
 * 4. When an automated build script has to unpack a zip of WMF diagrams, convert them to BMP, and place the results in a designated output folder for inclusion in documentation PDFs.
 * 5. When a cloud service receives user‑uploaded zip files containing WMF drawings and needs to quickly generate BMP previews without extracting the archive to disk.
 */