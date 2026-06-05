using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string thumbnailPath = "thumbnail.jpg";

            // Ensure thumbnail exists
            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            // Ensure input and output directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Load the thumbnail once
            using (RasterImage thumbnailImage = (RasterImage)Image.Load(thumbnailPath))
            {
                // Process each JPEG file in the input directory
                foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.jpg"))
                {
                    // Validate input file existence
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                    // Ensure output directory exists before saving
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load JPEG image
                    using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
                    {
                        // Ensure EXIF container exists
                        if (jpegImage.ExifData == null)
                        {
                            jpegImage.ExifData = new Aspose.Imaging.Exif.JpegExifData();
                        }

                        // Assign the thumbnail
                        jpegImage.ExifData.Thumbnail = thumbnailImage;

                        // Save the modified image
                        jpegImage.Save(outputPath);
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
 * 1. When a photographer wants to embed a company logo as a thumbnail in all JPEG files before uploading them to an online portfolio, this batch EXIF thumbnail code automates the process.
 * 2. When an e‑commerce platform needs to add a small product preview image to the EXIF data of thousands of product photos so that catalog browsers load faster, the code provides a C# solution.
 * 3. When a digital archivist must standardize thumbnails across legacy JPEG archives to improve compatibility with media‑management software, the batch thumbnail insertion streamlines the task.
 * 4. When a mobile app developer wants to pre‑populate the EXIF thumbnail of user‑generated photos with a branded placeholder before distribution, this code handles the bulk update.
 * 5. When a batch‑processing script is required to attach a custom preview image to JPEGs exported from a CAD tool so that file explorers display the correct thumbnail, the example demonstrates how to do it in .NET.
 */