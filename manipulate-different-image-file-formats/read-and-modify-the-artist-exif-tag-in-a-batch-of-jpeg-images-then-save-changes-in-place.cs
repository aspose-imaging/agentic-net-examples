using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input directory and list of JPEG files to process
        string inputDir = @"C:\Images\Input";
        string[] files = new string[]
        {
            Path.Combine(inputDir, "image1.jpg"),
            Path.Combine(inputDir, "image2.jpg"),
            // Add more file names as needed
        };

        // New value for the Artist EXIF tag
        string newArtist = "John Doe";

        foreach (string inputPath in files)
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (same as input directory)
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access JPEG-specific EXIF data
                JpegExifData jpegExif = image.ExifData as JpegExifData;
                if (jpegExif != null)
                {
                    // Modify the Artist tag
                    jpegExif.Artist = newArtist;
                }

                // Save changes back to the original file (in-place)
                image.Save(inputPath);
            }
        }
    }
}