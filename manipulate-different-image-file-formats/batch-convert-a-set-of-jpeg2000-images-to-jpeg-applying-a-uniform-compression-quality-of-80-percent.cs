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
            // Hardcoded list of JPEG2000 input files
            string[] inputFiles = new string[]
            {
                @"C:\Images\Input\image1.jp2",
                @"C:\Images\Input\image2.jp2",
                @"C:\Images\Input\image3.jp2"
            };

            // Process each file
            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .jpg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the JPEG2000 image
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG save options with quality 80%
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 80
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When a developer needs to migrate a legacy archive of high‑resolution JPEG2000 photographs to standard JPEG files for web publishing, they can use this C# Aspose.Imaging batch conversion with a uniform 80 % quality setting.
 * 2. When an automated image‑processing pipeline must down‑sample a collection of JP2 medical scans to smaller JPEGs for faster preview loading in a C# desktop application, this code provides the required format conversion and compression control.
 * 3. When a content‑management system needs to ingest user‑uploaded JPEG2000 assets and store them as JPEGs to ensure compatibility with browsers, the sample demonstrates how to loop through files, verify existence, and save with Aspose.Imaging’s JpegOptions.
 * 4. When a batch‑export tool for a digital asset management (DAM) solution has to convert selected JP2 files to JPEG with a consistent 80 % quality to meet client‑specified size limits, the code shows the necessary file‑system handling and image‑saving steps in C#.
 * 5. When a scheduled Windows service must regularly convert newly added JPEG2000 images in a folder to JPEG for downstream analytics, this example illustrates how to programmatically load each image, apply a fixed compression ratio, and write the output using Aspose.Imaging.
 */