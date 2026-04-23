using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");
            string zipPath = Path.Combine(outputDirectory, "thumbnails.zip");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Ensure the directory for the zip file exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
            string[] allFiles = new string[files.Length + jpegFiles.Length];
            files.CopyTo(allFiles, 0);
            jpegFiles.CopyTo(allFiles, files.Length);

            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipToOpen, System.IO.Compression.ZipArchiveMode.Create))
            {
                foreach (string inputPath in allFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    using (JpegImage image = new JpegImage(inputPath))
                    {
                        if (!image.IsCached)
                            image.CacheData();

                        // Create a thumbnail of size 150x150 (preserving aspect ratio is not handled here for brevity)
                        image.Resize(150, 150);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            JpegOptions thumbOptions = new JpegOptions
                            {
                                Quality = 75,
                                Source = new FileCreateSource(Path.GetTempFileName(), false) // required source, will not be used for stream save
                            };

                            image.Save(ms, thumbOptions);
                            ms.Position = 0;

                            string entryName = Path.GetFileNameWithoutExtension(inputPath) + "_thumb.jpg";
                            System.IO.Compression.ZipArchiveEntry entry = archive.CreateEntry(entryName);
                            using (Stream entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Thumbnails have been saved to: {zipPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}