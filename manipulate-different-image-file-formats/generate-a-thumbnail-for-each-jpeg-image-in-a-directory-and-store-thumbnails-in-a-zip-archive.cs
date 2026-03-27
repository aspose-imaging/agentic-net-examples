using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input directory and output zip path
        string inputDirectory = @"C:\Images";
        string outputZipPath = @"C:\Thumbnails\thumbnails.zip";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

        // Create or overwrite the zip archive
        using (FileStream zipStream = new FileStream(outputZipPath, FileMode.Create))
        using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Update))
        {
            // Get all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFilesUpper = Directory.GetFiles(inputDirectory, "*.jpeg");
            string[] allFiles = new string[jpegFiles.Length + jpegFilesUpper.Length];
            jpegFiles.CopyTo(allFiles, 0);
            jpegFilesUpper.CopyTo(allFiles, jpegFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load JPEG image
                using (JpegImage image = new JpegImage(inputPath))
                {
                    // Create thumbnail (100x100) using nearest neighbour resample
                    image.Resize(100, 100, ResizeType.NearestNeighbourResample);

                    // Save thumbnail to a memory stream with default JPEG options
                    using (MemoryStream thumbStream = new MemoryStream())
                    {
                        JpegOptions jpegOptions = new JpegOptions();
                        image.Save(thumbStream, jpegOptions);
                        thumbStream.Position = 0;

                        // Add thumbnail to zip archive
                        string entryName = Path.GetFileNameWithoutExtension(inputPath) + "_thumb.jpg";
                        System.IO.Compression.ZipArchiveEntry entry = archive.CreateEntry(entryName);
                        using (Stream entryStream = entry.Open())
                        {
                            thumbStream.CopyTo(entryStream);
                        }
                    }
                }
            }
        }
    }
}