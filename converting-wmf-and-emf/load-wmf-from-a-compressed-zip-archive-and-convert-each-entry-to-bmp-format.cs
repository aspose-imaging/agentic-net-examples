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
            // Hardcoded input zip file containing WMF images
            string zipPath = @"C:\Input\wmf_files.zip";

            // Hardcoded output directory for BMP files
            string outputDirectory = @"C:\Output\BmpImages";

            // Verify input zip exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure the output directory exists (creates parent directories as needed)
            Directory.CreateDirectory(outputDirectory);

            // Open the zip archive for reading
            using (FileStream zipStream = new FileStream(zipPath, FileMode.Open, FileAccess.Read))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    // Process only WMF files
                    if (!entry.FullName.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Build output BMP file path
                    string outputPath = Path.Combine(outputDirectory,
                        Path.GetFileNameWithoutExtension(entry.Name) + ".bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Open the WMF entry as a stream and load it with Aspose.Imaging
                    using (Stream entryStream = entry.Open())
                    using (Image image = Image.Load(entryStream))
                    {
                        // Prepare rasterization options based on the source image size
                        var rasterOptions = new WmfRasterizationOptions
                        {
                            PageSize = image.Size
                        };

                        // BMP save options with vector rasterization
                        var bmpOptions = new BmpOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Save the image as BMP
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