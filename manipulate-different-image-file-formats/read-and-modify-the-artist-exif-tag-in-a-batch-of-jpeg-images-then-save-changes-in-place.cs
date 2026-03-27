using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input directory containing JPEG files
        string inputDirectory = "C:\\Images";

        // Ensure the directory exists
        Directory.CreateDirectory(inputDirectory);

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

            // Ensure the output directory exists (same as input directory for in-place save)
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data; create if missing
                var exif = image.ExifData;
                if (exif == null)
                {
                    exif = new Aspose.Imaging.Exif.JpegExifData();
                    image.ExifData = exif;
                }

                // Modify the Artist tag
                exif.Artist = "New Artist";

                // Save changes back to the same file (in-place)
                image.Save(inputPath);
            }
        }
    }
}