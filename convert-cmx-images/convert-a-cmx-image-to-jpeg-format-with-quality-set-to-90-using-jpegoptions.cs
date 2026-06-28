using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CmxToJpegConverter
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.cmx";
            string outputPath = @"C:\temp\sample.jpg";

            try
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CMX image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure JPEG save options with quality 90
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save the image as JPEG
                    image.Save(outputPath, jpegOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a legacy CAD system exports drawings as CMX files and a web portal needs high‑quality JPEG thumbnails, a developer can use this C# code with Aspose.Imaging to convert the CMX to JPEG at quality 90.
 * 2. When an automated document‑management workflow receives CMX images from suppliers and must store them as JPEGs for quick preview, the code provides a simple way to load the CMX and save it with JpegOptions quality set to 90.
 * 3. When a Windows service processes incoming design assets and must generate web‑ready JPEG previews from CMX files without manual intervention, a developer can embed this conversion logic in a scheduled C# job.
 * 4. When a desktop utility lets users select a CMX file and instantly save a compressed JPEG version for email attachment, the example demonstrates the required file‑existence checks and JPEG quality configuration.
 * 5. When a batch‑processing script needs to convert a folder of CMX drawings to JPEG images with consistent visual fidelity for printing proofs, the code shows how to loop through files and apply JpegOptions quality 90 in .NET.
 */