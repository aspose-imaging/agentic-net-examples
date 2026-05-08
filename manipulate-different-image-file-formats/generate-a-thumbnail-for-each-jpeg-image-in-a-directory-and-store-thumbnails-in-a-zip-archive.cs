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
            // Hardcoded input directory and output zip file
            string inputDirectory = "InputImages";
            string outputZipPath = "Output/thumbnails.zip";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Get all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFilesUpper = Directory.GetFiles(inputDirectory, "*.jpeg");
            string[] allJpegFiles = new string[jpegFiles.Length + jpegFilesUpper.Length];
            jpegFiles.CopyTo(allJpegFiles, 0);
            jpegFilesUpper.CopyTo(allJpegFiles, jpegFiles.Length);

            // Open (or create) the zip archive for updating
            using (var zipStream = new FileStream(outputZipPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var zip = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Update))
            {
                foreach (string inputPath in allJpegFiles)
                {
                    // Validate input file existence
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Load the JPEG image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Determine thumbnail size (max dimension 100 pixels)
                        const int maxDim = 100;
                        int thumbWidth = image.Width;
                        int thumbHeight = image.Height;

                        if (thumbWidth > thumbHeight)
                        {
                            if (thumbWidth > maxDim)
                            {
                                thumbHeight = thumbHeight * maxDim / thumbWidth;
                                thumbWidth = maxDim;
                            }
                        }
                        else
                        {
                            if (thumbHeight > maxDim)
                            {
                                thumbWidth = thumbWidth * maxDim / thumbHeight;
                                thumbHeight = maxDim;
                            }
                        }

                        // Resize to thumbnail dimensions
                        image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                        // Prepare JPEG save options for the thumbnail
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 80
                        };

                        // Save thumbnail to a memory stream
                        using (var ms = new MemoryStream())
                        {
                            image.Save(ms, jpegOptions);
                            ms.Position = 0;

                            // Create a zip entry for the thumbnail
                            string entryName = Path.GetFileNameWithoutExtension(inputPath) + "_thumb.jpg";
                            var entry = zip.CreateEntry(entryName, System.IO.Compression.CompressionLevel.Optimal);
                            using (var entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
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
}