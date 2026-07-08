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
            // Define paths
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string thumbnailPath = "thumbnail.jpg";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Validate thumbnail file
            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            // Process each JPEG file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.jpg"))
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the thumbnail image
                using (RasterImage thumbnail = (RasterImage)Image.Load(thumbnailPath))
                {
                    // Load the target JPEG image
                    using (JpegImage jpeg = new JpegImage(inputPath))
                    {
                        // Assign the thumbnail to EXIF data
                        jpeg.ExifData.Thumbnail = thumbnail;

                        // Save the modified JPEG
                        jpeg.Save(outputPath);
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
 * 1. When a photographer wants to embed a company logo as a preview thumbnail in the EXIF data of all client‑delivery JPEGs before uploading to a portfolio website.
 * 2. When an e‑commerce platform needs to add a standardized product thumbnail to the EXIF segment of thousands of product photos to improve image previews in mobile apps.
 * 3. When a digital archivist must attach a low‑resolution preview image to the EXIF metadata of scanned historical photographs for quick browsing in catalog software.
 * 4. When a mobile app developer wants to pre‑populate the thumbnail field of user‑generated JPEGs with a custom placeholder image before syncing them to cloud storage.
 * 5. When a content management system automates the insertion of a brand‑specific thumbnail into the EXIF data of batch‑processed JPEG assets to ensure consistent visual identifiers across all media files.
 */