using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // Process each DNG file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.dng"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output JPEG path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DNG image with default load options
                using (Image image = Image.Load(inputPath, new DngLoadOptions()))
                {
                    // Set JPEG save options with quality 85
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 85
                    };

                    // Save as JPEG
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
 * 1. When a photographer needs to quickly generate web‑ready JPEG previews from a folder of RAW DNG files while preserving a specific compression quality, they can use this C# batch conversion code with Aspose.Imaging.
 * 2. When an e‑commerce platform must convert product photos captured in DNG format to optimized JPEG images at 85 % quality for faster page loads, the code automates the process across the entire image directory.
 * 3. When a digital archiving system requires periodic conversion of newly uploaded DNG scans into JPEGs for compatibility with legacy viewers, the script provides a reliable C# solution using Aspose.Imaging’s load and save options.
 * 4. When a mobile app backend needs to preprocess incoming DNG uploads into JPEG thumbnails with a consistent quality setting before storing them in cloud storage, this batch conversion routine handles the file handling and quality control.
 * 5. When a scientific imaging workflow demands converting large batches of DNG microscope images to JPEG for inclusion in reports while controlling compression artifacts, the example demonstrates how to set the JPEG quality to 85 % in C#.
 */