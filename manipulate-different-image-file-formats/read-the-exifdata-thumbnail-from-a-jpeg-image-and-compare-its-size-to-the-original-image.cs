// HOW-TO: Read JPEG EXIF Thumbnail and Compare Its Dimensions to Original Image in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
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
            // Hardcoded paths
            string inputPath = "input.jpg";
            string thumbnailOutputPath = "output\\thumbnail.jpg";
            string reportOutputPath = "output\\report.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                JpegImage jpeg = image as JpegImage;
                if (jpeg == null)
                {
                    Console.Error.WriteLine("The provided file is not a JPEG image.");
                    return;
                }

                // Access EXIF data
                ExifData exif = jpeg.ExifData;
                if (exif == null || exif.Thumbnail == null)
                {
                    Console.Error.WriteLine("No EXIF thumbnail found in the image.");
                    return;
                }

                // Get original and thumbnail dimensions
                int originalWidth = jpeg.Width;
                int originalHeight = jpeg.Height;
                Image thumbImage = exif.Thumbnail;
                int thumbWidth = thumbImage.Width;
                int thumbHeight = thumbImage.Height;

                // Build comparison report
                string report = $"Original Image Size: {originalWidth}x{originalHeight}{Environment.NewLine}" +
                                $"EXIF Thumbnail Size: {thumbWidth}x{thumbHeight}{Environment.NewLine}";

                if (thumbWidth < originalWidth && thumbHeight < originalHeight)
                {
                    report += "Thumbnail is smaller than the original image.";
                }
                else if (thumbWidth == originalWidth && thumbHeight == originalHeight)
                {
                    report += "Thumbnail size equals the original image.";
                }
                else
                {
                    report += "Thumbnail is larger than the original image.";
                }

                // Ensure output directories exist
                Directory.CreateDirectory(Path.GetDirectoryName(thumbnailOutputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(reportOutputPath));

                // Save thumbnail and report
                thumbImage.Save(thumbnailOutputPath);
                File.WriteAllText(reportOutputPath, report);

                // Output to console
                Console.WriteLine(report);
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
 * 1. When you need to verify that the embedded EXIF thumbnail is smaller than the full‑size JPEG for generating lightweight previews.
 * 2. When building a photo‑management tool that reports original and thumbnail dimensions to help users decide if thumbnails are sufficient for quick browsing.
 * 3. When creating a validation script that checks JPEG files for missing or incorrectly sized EXIF thumbnails before uploading to a web gallery.
 * 4. When extracting the EXIF thumbnail to a separate file and documenting the size difference for compliance with image‑archiving standards.
 * 5. When optimizing storage by comparing thumbnail and original image sizes to determine whether the thumbnail can replace the full image in low‑bandwidth scenarios.
 */
