// HOW-TO: Batch Convert BMP Files to PNG with Parallel Processing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\BmpInput";
            string outputFolder = @"C:\Images\PngOutput";

            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp", SearchOption.TopDirectoryOnly);
            // Process files in parallel
            Parallel.ForEach(bmpFiles, bmpFilePath =>
            {
                // Preserve original file name
                string fileName = Path.GetFileName(bmpFilePath);
                string inputPath = Path.Combine(inputFolder, fileName);
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path with .png extension
                string outputPath = Path.Combine(outputFolder, Path.ChangeExtension(fileName, ".png"));
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly convert a large collection of legacy BMP assets to PNG for web delivery while keeping the original file names.
 * 2. When an automated build pipeline must generate optimized PNG thumbnails from BMP source images stored in a specific folder.
 * 3. When a desktop application processes user‑uploaded BMP pictures and must save them as PNG in a separate output directory using parallel threads for speed.
 * 4. When migrating a legacy imaging system to .NET and you require a simple script to batch‑convert BMP files to PNG without manual intervention.
 * 5. When performing a nightly batch job that transforms BMP scans into lossless PNG files, ensuring the output folder structure mirrors the input.
 */
