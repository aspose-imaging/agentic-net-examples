using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output locations
            string inputDirectory = "Input";
            string outputZipPath = Path.Combine("Output", "thumbnails.zip");

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Get JPEG files (both .jpg and .jpeg)
            string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
            string[] allFiles = new string[jpgFiles.Length + jpegFiles.Length];
            jpgFiles.CopyTo(allFiles, 0);
            jpegFiles.CopyTo(allFiles, jpgFiles.Length);

            // Create the zip archive
            using (FileStream zipFileStream = new FileStream(outputZipPath, FileMode.Create))
            using (var zipArchive = new System.IO.Compression.ZipArchive(zipFileStream, System.IO.Compression.ZipArchiveMode.Create, true))
            {
                foreach (string inputPath in allFiles)
                {
                    // Validate each input file
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Load the JPEG image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Determine thumbnail size while preserving aspect ratio (max 100x100)
                        int maxSize = 100;
                        int thumbWidth = image.Width;
                        int thumbHeight = image.Height;

                        if (thumbWidth > thumbHeight)
                        {
                            if (thumbWidth > maxSize)
                            {
                                thumbHeight = thumbHeight * maxSize / thumbWidth;
                                thumbWidth = maxSize;
                            }
                        }
                        else
                        {
                            if (thumbHeight > maxSize)
                            {
                                thumbWidth = thumbWidth * maxSize / thumbHeight;
                                thumbHeight = maxSize;
                            }
                        }

                        // Resize to thumbnail dimensions
                        image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                        // Save thumbnail to a memory stream using JPEG options
                        using (var thumbStream = new MemoryStream())
                        {
                            var jpegOptions = new JpegOptions
                            {
                                Quality = 80
                            };
                            image.Save(thumbStream, jpegOptions);
                            thumbStream.Position = 0;

                            // Add thumbnail to zip archive
                            string entryName = Path.GetFileNameWithoutExtension(inputPath) + "_thumb.jpg";
                            var entry = zipArchive.CreateEntry(entryName);
                            using (var entryStream = entry.Open())
                            {
                                thumbStream.CopyTo(entryStream);
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Thumbnails have been saved to: {outputZipPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}