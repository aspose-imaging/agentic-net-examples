// HOW-TO: Batch Add 64% Alpha Black Overlay to PNGs and Convert to JPEG C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (PngImage png = (PngImage)Image.Load(inputPath))
                {
                    // Create an overlay image of the same size
                    PngOptions overlayOptions = new PngOptions()
                    {
                        Source = new FileCreateSource(Path.Combine(outputDirectory, "overlay_temp.png"), false)
                    };
                    using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, png.Width, png.Height))
                    {
                        // Fill overlay with black color
                        Graphics overlayGraphics = new Graphics(overlay);
                        overlayGraphics.Clear(Aspose.Imaging.Color.Black);
                        // Blend overlay onto the original image with 64 alpha
                        png.Blend(new Point(0, 0), overlay, 64);
                    }

                    // Prepare output JPEG path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as JPEG with quality 90
                    JpegOptions jpegOptions = new JpegOptions()
                    {
                        Source = new FileCreateSource(outputPath, false),
                        Quality = 90
                    };
                    png.Save(outputPath, jpegOptions);
                }
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
 * 1. When you need to watermark a whole folder of transparent PNG icons with a semi‑transparent black shade before publishing them as JPEGs for web use.
 * 2. When an application must reduce file size by converting PNGs to JPEG while ensuring a consistent 64‑percent opacity overlay for visual consistency.
 * 3. When a batch script is required to prepare product images by darkening them uniformly and changing the format for a legacy e‑commerce platform.
 * 4. When you want to automate the process of applying a low‑opacity overlay to scanned PNG documents and saving them as JPEGs for archival storage.
 * 5. When a developer needs to programmatically process user‑uploaded PNG avatars, add a subtle dark overlay, and store them as JPEG thumbnails.
 */
