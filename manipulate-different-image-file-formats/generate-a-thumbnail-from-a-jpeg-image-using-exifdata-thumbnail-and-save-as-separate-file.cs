// HOW-TO: Extract JPEG Exif Thumbnail and Save as Separate Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load Exif data and extract thumbnail
            ExifData exif = ExifData.FromFile(inputPath);
            byte[] thumbnailBytes = exif.Thumbnail;

            if (thumbnailBytes == null || thumbnailBytes.Length == 0)
            {
                Console.Error.WriteLine("No thumbnail data found in the image.");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Save thumbnail to file
            File.WriteAllBytes(outputPath, thumbnailBytes);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Placeholder for the ExifData class. Replace with the actual implementation/library.
public class ExifData
{
    public byte[] Thumbnail { get; private set; }

    private ExifData(byte[] thumbnail)
    {
        Thumbnail = thumbnail;
    }

    public static ExifData FromFile(string path)
    {
        // This method should read the JPEG file at 'path' and extract the Exif thumbnail.
        // The implementation below is a stub and should be replaced with actual Exif parsing logic.

        // Example stub: return empty thumbnail to illustrate structure.
        return new ExifData(new byte[0]);
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly display a low‑resolution preview of a high‑resolution JPEG without loading the full image, you can extract the embedded Exif thumbnail and save it as a separate file.
 * 2. When building a photo‑gallery web service that generates preview icons from user‑uploaded pictures, this code lets you reuse the camera‑provided thumbnail instead of re‑encoding the image.
 * 3. When creating a digital‑asset‑management system that indexes image metadata, you can store the extracted Exif thumbnail for fast visual search results.
 * 4. When developing a mobile‑app sync tool that transfers only small preview files to conserve bandwidth, you can pull the JPEG’s thumbnail and upload that instead of the original.
 * 5. When auditing a collection of photographs for missing thumbnails, this snippet helps you detect and export any existing Exif thumbnail data for further analysis.
 */
