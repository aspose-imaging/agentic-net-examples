// HOW-TO: Convert CDR Stream To JPEG Directly In C# Without Temp Files (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths (relative)
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR file from a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                using (CdrImage cdrImage = (CdrImage)Image.Load(memoryStream))
                {
                    // Set up JPEG options with vector rasterization settings
                    var jpegOptions = new JpegOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdrImage.Width,
                            PageHeight = cdrImage.Height
                        }
                    };

                    // Save directly to JPEG without intermediate files
                    cdrImage.Save(outputPath, jpegOptions);
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
 * 1. When a web service receives a CorelDRAW (.cdr) file as a byte array and must return a JPEG preview without writing the file to disk.
 * 2. When an automated batch job processes uploaded design files in memory to generate thumbnail images for a gallery.
 * 3. When a desktop application needs to display a CDR document as a raster image while keeping the original file hidden from the user.
 * 4. When a cloud function converts user‑submitted vector graphics to JPEG for email attachments, avoiding temporary storage costs.
 * 5. When a mobile backend streams CDR data from a database and saves it as JPEG for fast client‑side rendering.
 */
