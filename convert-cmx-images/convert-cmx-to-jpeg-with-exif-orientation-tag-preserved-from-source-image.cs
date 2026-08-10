// HOW-TO: Convert CMX to JPEG While Preserving EXIF Orientation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image cmxImage = Aspose.Imaging.Image.Load(inputPath))
            {
                CmxImage cmx = cmxImage as CmxImage;
                if (cmx == null)
                {
                    Console.Error.WriteLine("Failed to load CMX image.");
                    return;
                }

                var jpegOptions = new JpegOptions
                {
                    KeepMetadata = true,
                    Source = new FileCreateSource(outputPath, false)
                };

                cmx.Save(outputPath, jpegOptions);
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
 * 1. When a design team needs to export CorelDRAW CMX artwork as JPEGs for web preview while keeping the original camera orientation metadata.
 * 2. When an automated batch process converts archived CMX files to JPEG for a digital asset management system and must retain EXIF tags for proper sorting.
 * 3. When a mobile app receives CMX drawings and must display them as JPEG thumbnails with correct orientation without losing metadata.
 * 4. When a migration script moves legacy CMX graphics to a JPEG‑based workflow and requires the EXIF orientation to stay intact for downstream processing.
 * 5. When a reporting tool generates JPEG images from CMX sources and needs to preserve metadata for compliance auditing.
 */
