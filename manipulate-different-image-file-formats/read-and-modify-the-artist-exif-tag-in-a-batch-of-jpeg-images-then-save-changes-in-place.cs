using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing JPEG files
            string inputDirectory = @"C:\Images\Input";

            // Retrieve all JPEG files in the directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            foreach (string inputPath in jpegFiles)
            {
                // Verify the file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the JPEG image
                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    // Access JPEG-specific EXIF data
                    JpegExifData jpegExif = image.ExifData as JpegExifData;
                    if (jpegExif != null)
                    {
                        // Modify the Artist tag
                        jpegExif.Artist = "New Artist";
                    }

                    // Output path is the same as input (in‑place modification)
                    string outputPath = inputPath;

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save changes back to the original file
                    image.Save(outputPath);
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
 * 1. When a photographer needs to batch‑update the Artist EXIF tag of thousands of JPEG images stored in a folder, this C# Aspose.Imaging code can read each file, set the Artist field, and save the changes in place.
 * 2. When a digital asset management system must ensure that all uploaded JPEG photos carry a consistent author name, developers can use this snippet to iterate over a directory, modify the JPEG ExifData.Artist property, and overwrite the original files.
 * 3. When a media workflow requires embedding copyright information by setting the Artist tag across a collection of JPEG pictures before publishing, the code provides a simple C# solution that reads, updates, and saves the metadata without creating new files.
 * 4. When an e‑commerce platform wants to standardize photographer credits on product images by programmatically editing the EXIF Artist tag of JPEG files on the server, this Aspose.Imaging example performs the batch modification and in‑place save.
 * 5. When a backup script needs to verify and correct the Artist metadata of archived JPEG images to improve searchability, developers can employ this C# loop to scan a directory, adjust the EXIF Artist field, and write the updates directly back to each image.
 */