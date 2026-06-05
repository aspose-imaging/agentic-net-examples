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

            // Corresponding output JPEG files
            string[] outputFiles = new string[]
            {
                @"C:\Images\Output\image1.jpg",
                @"C:\Images\Output\image2.jpg",
                @"C:\Images\Output\image3.jpg"
            };

            // Ensure the arrays have the same length
            int count = Math.Min(inputFiles.Length, outputFiles.Length);

            for (int i = 0; i < count; i++)
            {
                string inputPath = inputFiles[i];
                string outputPath = outputFiles[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the JPEG2000 image and save as JPEG with quality 80
                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 80
                    };

                    image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to migrate a legacy archive of JPEG2000 medical images to standard JPEG files for compatibility with web browsers, they can use this code to batch convert the images while preserving visual quality at 80 % compression.
 * 2. When an e‑commerce platform wants to reduce storage costs by converting high‑resolution JPEG2000 product photos to smaller JPEG files before uploading them to a CDN, this snippet automates the batch conversion with a consistent quality setting.
 * 3. When a digital publishing workflow requires converting a set of scanned JPEG2000 pages into JPEG for inclusion in an online magazine, the code provides a quick C# solution to process multiple files and ensure each output uses the same 80 % quality level.
 * 4. When a GIS application needs to prepare satellite JPEG2000 tiles for display on mobile devices, developers can employ this batch conversion routine to generate JPEG tiles with uniform compression, simplifying the rendering pipeline.
 * 5. When a backup script must transform archived JPEG2000 assets into JPEG format for a client that only supports JPEG, this example shows how to verify file existence, create output directories, and save each image with a specified quality using Aspose.Imaging for .NET.
 */