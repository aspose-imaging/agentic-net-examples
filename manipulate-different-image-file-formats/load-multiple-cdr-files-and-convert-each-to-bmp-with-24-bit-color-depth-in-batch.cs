using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        try
        {
            // Ensure input directory exists; if not, create it and exit
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add CDR files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path with .bmp extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Configure BMP options with 24‑bit color depth
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        bmpOptions.BitsPerPixel = 24;

                        // Set vector rasterization options for proper conversion
                        bmpOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdrImage.Width,
                            PageHeight = cdrImage.Height
                        };

                        // Save the rasterized BMP image
                        cdrImage.Save(outputPath, bmpOptions);
                    }
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a graphic design studio needs to automate the batch conversion of multiple CorelDRAW (CDR) files to 24‑bit BMP images for legacy Windows applications, they can use this C# code with Aspose.Imaging for .NET.
 * 2. When a document management system must ingest vector CDR assets and store them as raster BMP files with full color fidelity for archival or printing pipelines, the example shows how to process the files in a folder.
 * 3. When a developer is building a server‑side image processing service that receives CDR uploads and returns BMP thumbnails at 24‑bit depth, the code demonstrates loading each CDR and saving it as BMP in bulk.
 * 4. When an automation script needs to prepare CDR artwork for a CNC machine that only accepts BMP format, this batch conversion routine ensures every file in the input directory is converted with the correct color depth.
 * 5. When a QA team wants to verify visual consistency by converting a set of CorelDRAW designs to BMP for pixel‑by‑pixel comparison against expected outputs, the sample provides a straightforward C# loop using Aspose.Imaging.
 */