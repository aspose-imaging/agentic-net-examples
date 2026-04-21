using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.jpg";
        string outputPath = "resolution.txt";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir);

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            JpegImage jpegImage = image as JpegImage;
            if (jpegImage == null)
            {
                Console.Error.WriteLine("The file is not a JPEG image.");
                return;
            }

            // Access EXIF data
            Aspose.Imaging.Exif.JpegExifData exif = jpegImage.ExifData;
            if (exif == null)
            {
                Console.Error.WriteLine("No EXIF data found.");
                return;
            }

            // Retrieve resolution tags
            var xResolution = exif.XResolution;
            var yResolution = exif.YResolution;
            var resolutionUnit = exif.ResolutionUnit;

            // Simulate storing in a database by writing to a file
            string record = $"XResolution: {xResolution}, YResolution: {yResolution}, Unit: {resolutionUnit}";
            File.WriteAllText(outputPath, record);
            Console.WriteLine("Resolution data saved.");
        }
    }
}