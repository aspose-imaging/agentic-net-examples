// HOW-TO: Check If JPG Created From CDR Conversion Exists and Is Not Empty in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cdr";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions options = new JpegOptions();
                image.Save(outputPath, options);
            }

            if (File.Exists(outputPath) && new FileInfo(outputPath).Length > 0)
            {
                Console.WriteLine("JPG file created successfully and has non-zero size.");
            }
            else
            {
                Console.Error.WriteLine("Failed to create JPG file or file is empty.");
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
 * 1. When you need to programmatically confirm that a CorelDRAW file was successfully converted to a JPEG before further processing.
 * 2. When an automated batch job must verify that each generated JPEG has actual image data and is not a zero‑byte placeholder.
 * 3. When integrating Aspose.Imaging into a web service that returns a status message only after the output image file exists and contains data.
 * 4. When building a desktop application that alerts users if the conversion failed or produced an empty file, preventing downstream errors.
 * 5. When creating a CI/CD pipeline step that checks the integrity of image conversion artifacts to ensure build quality.
 */
