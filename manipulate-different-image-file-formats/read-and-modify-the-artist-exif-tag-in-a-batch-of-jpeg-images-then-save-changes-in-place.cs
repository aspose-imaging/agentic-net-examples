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
            string inputDirectory = @"C:\Images";

            // Get all JPEG files in the directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            foreach (string inputPath in jpegFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the JPEG image
                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    // Access JPEG EXIF data
                    JpegExifData jpegExif = image.ExifData as JpegExifData;
                    if (jpegExif != null)
                    {
                        // Modify the Artist tag
                        jpegExif.Artist = "New Artist";
                    }

                    // Ensure the output directory exists (in-place save)
                    Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

                    // Save changes back to the same file
                    image.Save(inputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}