using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string thumbOutputPath = @"C:\Images\thumbnail.jpg";
        string reportOutputPath = @"C:\Images\thumbnail_report.txt";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(thumbOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(reportOutputPath));

        // Load JPEG image
        using (JpegImage jpeg = new JpegImage(inputPath))
        {
            // Original image dimensions
            int originalWidth = jpeg.Width;
            int originalHeight = jpeg.Height;

            // Extract EXIF thumbnail
            RasterImage thumbnail = jpeg.ExifData?.Thumbnail;

            if (thumbnail == null)
            {
                Console.WriteLine("No EXIF thumbnail present in the image.");
                return;
            }

            // Use the thumbnail within a using block to ensure disposal
            using (thumbnail)
            {
                // Thumbnail dimensions
                int thumbWidth = thumbnail.Width;
                int thumbHeight = thumbnail.Height;

                // Compare dimensions
                bool sameSize = originalWidth == thumbWidth && originalHeight == thumbHeight;

                string report = $"Original: {originalWidth}x{originalHeight}, " +
                                $"Thumbnail: {thumbWidth}x{thumbHeight}, " +
                                $"Same size: {sameSize}";

                // Output comparison result
                Console.WriteLine(report);

                // Save the thumbnail as a separate JPEG file
                thumbnail.Save(thumbOutputPath);

                // Write the comparison report to a text file
                File.WriteAllText(reportOutputPath, report);
            }
        }
    }
}