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
        string inputPath = @"C:\temp\original.jpg";
        string outputPath = @"C:\temp\copy_output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Access EXIF data container
            JpegExifData exifData = jpegImage.ExifData as JpegExifData;
            if (exifData == null)
            {
                Console.WriteLine("No EXIF data found in the image.");
            }
            else
            {
                Console.WriteLine("EXIF tags and their values:");
                Console.WriteLine(new string('-', 40));

                // Iterate over all defined EXIF properties
                foreach (ExifProperties tag in Enum.GetValues(typeof(ExifProperties)))
                {
                    try
                    {
                        // Retrieve the tag value; returns null if the tag is not present
                        object value = exifData.GetTagValue(tag);
                        if (value != null)
                        {
                            Console.WriteLine($"{tag} (0x{((ushort)tag):X4}): {value}");
                        }
                    }
                    catch
                    {
                        // Ignore tags that cause exceptions (e.g., unsupported types)
                    }
                }
            }

            // Optionally save a copy of the image to demonstrate output handling
            jpegImage.Save(outputPath);
        }
    }
}