// HOW-TO: Batch Convert BMP Images to PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded source and destination folders
            string sourceFolder = @"C:\Images\Source";
            string destinationFolder = @"C:\Images\Output";

            // Get all BMP files in the source folder
            string[] bmpFiles = Directory.GetFiles(sourceFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path preserving the original filename
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(destinationFolder, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image and save it as PNG
                using (Image image = Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to migrate a folder of legacy BMP assets to web‑compatible PNG files while keeping the original filenames.
 * 2. When you want to reduce image file size for faster page loads by converting BMPs to lossless PNGs in an automated batch process.
 * 3. When you are preparing graphics for inclusion in a PDF report and must supply PNG images instead of BMP.
 * 4. When you have scanned BMP pictures that require transparency support, and you need to convert them to PNG in bulk.
 * 5. When you are building a CI/CD pipeline that must convert newly added BMP resources to PNG before deployment.
 */
