using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";
        string thumbnailPath = @"C:\Images\thumbnail.jpg";

        try
        {
            // Verify thumbnail exists
            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            // Load thumbnail once (as RasterImage)
            using (RasterImage thumbnailImage = (RasterImage)Image.Load(thumbnailPath))
            {
                // Ensure output directory exists for each file later
                Directory.CreateDirectory(outputDirectory);

                // Process each JPEG file in the input directory
                foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.jpg"))
                {
                    // Input file existence check (redundant but follows rule)
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Determine output path
                    string fileName = Path.GetFileName(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName);

                    // Ensure output directory exists (unconditional as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load JPEG, set thumbnail, and save
                    using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
                    {
                        // Assign the custom thumbnail to EXIF data
                        jpeg.ExifData.Thumbnail = thumbnailImage;

                        // Save the modified JPEG to the output path
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