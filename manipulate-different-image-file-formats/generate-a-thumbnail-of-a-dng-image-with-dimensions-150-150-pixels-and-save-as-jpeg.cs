using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.dng";
            string outputPath = "Output/thumbnail.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image, resize, and save as JPEG
            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                // Resize to 150x150 pixels
                dng.Resize(150, 150);

                // JPEG save options (default settings)
                JpegOptions jpegOptions = new JpegOptions();

                // Save the thumbnail
                dng.Save(outputPath, jpegOptions);
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
 * 1. When a photo‑sharing website needs to generate small preview images from raw DNG files for faster page loads, a developer can use this C# code to create 150×150 JPEG thumbnails.
 * 2. When a digital asset management system must display quick visual references of high‑resolution raw photos in a grid view, the code resizes DNG images to 150×150 pixels and saves them as JPEG thumbnails.
 * 3. When an e‑commerce platform wants to show product images captured in raw format on mobile devices, the developer can convert each DNG to a 150×150 JPEG thumbnail using Aspose.Imaging for .NET.
 * 4. When a desktop application that organizes photographers’ portfolios needs to generate preview icons for DNG files, this snippet loads the raw image, resizes it, and saves a JPEG thumbnail for the UI.
 * 5. When an automated batch‑processing script must prepare low‑resolution previews of raw camera files for email attachments, the code provides a simple C# solution to resize DNG images to 150×150 and output JPEG files.
 */