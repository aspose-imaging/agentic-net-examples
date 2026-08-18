// HOW-TO: Batch Convert Multiple CDR Files to 24‑Bit BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input CDR files
            string[] inputPaths = new[]
            {
                @"C:\Images\sample1.cdr",
                @"C:\Images\sample2.cdr"
            };

            // Hard‑coded output directory
            string outputDirectory = @"C:\Images\Converted";

            // Ensure the output directory exists (will also work if GetDirectoryName returns null)
            Directory.CreateDirectory(outputDirectory);

            foreach (string inputPath in inputPaths)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output BMP path (same name, .bmp extension)
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Set BMP options to 24‑bit color depth
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };

                    // Save as BMP
                    cdrImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to migrate a collection of CorelDRAW (CDR) assets to 24‑bit BMP format for legacy Windows applications that only accept BMP images.
 * 2. When an automated build process must generate high‑color‑depth bitmap previews of multiple CDR designs for quality‑control reports.
 * 3. When a server‑side service has to batch‑convert client‑uploaded CDR files into BMPs to embed them in PDF documents that require raster images.
 * 4. When you are archiving graphic files and require a lossless 24‑bit BMP version of each CDR to ensure consistent rendering across different operating systems.
 * 5. When a desktop utility needs to read several CDR drawings and export them as BMPs for use in hardware‑accelerated printing pipelines that only support BMP input.
 */
