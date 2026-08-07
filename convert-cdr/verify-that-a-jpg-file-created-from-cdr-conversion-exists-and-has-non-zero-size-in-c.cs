using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.cdr";
        string outputPath = @"C:\temp\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image cdrImage = Image.Load(inputPath))
            {
                // Prepare JPEG save options
                var jpegOptions = new JpegOptions();

                // Save as JPEG
                cdrImage.Save(outputPath, jpegOptions);
            }

            // Verify the JPEG file was created and has non‑zero size
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"Output file not created: {outputPath}");
                return;
            }

            var info = new FileInfo(outputPath);
            if (info.Length == 0)
            {
                Console.Error.WriteLine($"Output file is empty: {outputPath}");
            }
            else
            {
                Console.WriteLine($"JPG file created successfully: {outputPath}, size: {info.Length} bytes");
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
 * 1. When a desktop application needs to batch‑convert CorelDRAW (.cdr) files to JPEG for web publishing and must confirm each output file was created and is not empty.
 * 2. When an automated build pipeline generates product catalog images from source CDR assets and requires a C# verification step that the resulting JPG files exist and have a non‑zero byte size before proceeding to the next stage.
 * 3. When a document management system imports legacy CDR graphics and stores them as JPEG thumbnails, the code ensures the conversion succeeded by checking file existence and size in .NET.
 * 4. When a Windows service monitors a folder for new CDR designs, converts them to JPEG using Aspose.Imaging, and needs to log an error if the saved JPG file is missing or zero bytes.
 * 5. When a QA test script validates that a third‑party plugin correctly exports CDR drawings to JPEG, using C# to load the source, save with JpegOptions, and assert the output file is present and contains data.
 */