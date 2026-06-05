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
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image and save as BMP with 24‑bit depth
                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    BmpOptions exportOptions = new BmpOptions
                    {
                        BitsPerPixel = 24,
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        }
                    };

                    cdr.Save(outputPath, exportOptions);
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
 * 1. When a design studio needs to archive legacy CorelDRAW (.cdr) artwork as 24‑bit BMP files for compatibility with Windows imaging tools.
 * 2. When an automated build pipeline must convert a batch of CDR logos into BMP images for inclusion in a .NET desktop application.
 * 3. When a print shop wants to rasterize vector CDR files to 24‑bit BMPs with a white background to ensure consistent color depth before sending to a RIP.
 * 4. When a document management system imports multiple CDR drawings and stores them as BMP thumbnails for quick preview in web portals.
 * 5. When a migration script processes a folder of CDR assets and generates 24‑bit BMP files for use in legacy reporting software.
 */