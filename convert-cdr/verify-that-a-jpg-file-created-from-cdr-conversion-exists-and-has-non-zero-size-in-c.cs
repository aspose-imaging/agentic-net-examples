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
            using (Image image = Image.Load(inputPath))
            {
                // Set JPEG save options (default quality)
                var jpegOptions = new JpegOptions();

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }

            // Verify the JPEG file was created and has non‑zero size
            if (File.Exists(outputPath))
            {
                FileInfo info = new FileInfo(outputPath);
                if (info.Length > 0)
                {
                    Console.WriteLine($"Conversion succeeded. File size: {info.Length} bytes.");
                }
                else
                {
                    Console.Error.WriteLine("Conversion failed: output file has zero size.");
                }
            }
            else
            {
                Console.Error.WriteLine("Conversion failed: output file not found.");
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
 * 1. When integrating CorelDRAW (CDR) files into a web application that only supports JPEG images, a developer can use this code to convert the CDR to JPEG and confirm the output file exists and is not empty before serving it to users.
 * 2. In an automated document processing pipeline that extracts graphics from legacy design files, this snippet ensures each converted JPEG is successfully created and has a non‑zero size, preventing downstream errors.
 * 3. When building a desktop utility that allows users to batch‑convert CDR drawings to JPEG for printing or archiving, the code validates each conversion result so the UI can report success or failure accurately.
 * 4. For a cloud‑based image service that receives CorelDRAW files via API, the developer can employ this routine to save the image as JPEG with Aspose.Imaging and verify the file size before uploading it to storage.
 * 5. During continuous integration testing of a C# image conversion module, this example checks that the generated JPEG from a sample CDR file is present and contains data, ensuring the build does not regress.
 */