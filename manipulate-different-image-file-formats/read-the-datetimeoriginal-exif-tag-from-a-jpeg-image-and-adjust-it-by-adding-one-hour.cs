using System;
using System.IO;
using System.Globalization;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        const string inputPath = "input.jpg";
        const string outputPath = "output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to JpegImage to access EXIF data
                JpegImage jpeg = image as JpegImage;
                if (jpeg != null && jpeg.ExifData != null)
                {
                    // Read the DateTimeOriginal tag
                    string original = jpeg.ExifData.DateTimeOriginal;
                    if (!string.IsNullOrEmpty(original))
                    {
                        // EXIF date format: "yyyy:MM:dd HH:mm:ss"
                        if (DateTime.TryParseExact(
                                original,
                                "yyyy:MM:dd HH:mm:ss",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime dt))
                        {
                            // Add one hour
                            dt = dt.AddHours(1);
                            // Write back the adjusted value
                            jpeg.ExifData.DateTimeOriginal = dt.ToString("yyyy:MM:dd HH:mm:ss");
                        }
                    }
                }

                // Save the modified image
                image.Save(outputPath);
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
 * 1. When a photographer needs to correct JPEG timestamps after a daylight‑saving‑time change by reading the EXIF DateTimeOriginal tag and adding one hour using C# and Aspose.Imaging.
 * 2. When a web application must adjust image capture times to a different time zone before displaying them in a gallery, by loading the JPEG, modifying the DateTimeOriginal EXIF value, and saving the file.
 * 3. When an archival system imports JPEG files and has to synchronize their original timestamps with a server clock that is one hour ahead, using Aspose.Imaging’s JpegImage.ExifData.
 * 4. When a mobile‑to‑desktop sync tool corrects the camera’s clock drift by adding an hour to the EXIF DateTimeOriginal of each uploaded JPEG image in a .NET workflow.
 * 5. When a digital forensics script validates and normalizes photo timestamps by reading the EXIF DateTimeOriginal tag and applying a one‑hour offset with Aspose.Imaging for .NET.
 */