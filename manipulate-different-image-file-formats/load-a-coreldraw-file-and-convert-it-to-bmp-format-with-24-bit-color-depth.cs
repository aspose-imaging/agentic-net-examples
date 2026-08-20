// HOW-TO: Convert CorelDRAW CDR to 24‑Bit BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP options for 24‑bit depth
                using (BmpOptions options = new BmpOptions())
                {
                    options.BitsPerPixel = 24;
                    // Save as BMP
                    image.Save(outputPath, options);
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
 * 1. When you need to display a CorelDRAW illustration in a Windows application that only supports BMP images with 24‑bit color.
 * 2. When a legacy printing system requires input files in BMP format and you must convert CDR files programmatically in C#.
 * 3. When automating a batch workflow to generate thumbnail previews of CDR designs as high‑quality BMP files for documentation.
 * 4. When integrating Aspose.Imaging into a .NET service that transforms client‑uploaded CDR artwork into BMP for further image analysis.
 * 5. When migrating assets from CorelDRAW to a format compatible with older graphics libraries that only read 24‑bit BMP files.
 */
