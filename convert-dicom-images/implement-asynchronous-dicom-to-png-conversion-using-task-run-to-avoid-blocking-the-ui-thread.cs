// HOW-TO: Asynchronously Convert DICOM To PNG In C# Using Task.Run (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            await Task.Run(() =>
            {
                using (Image image = Image.Load(inputPath))
                {
                    var options = new PngOptions();
                    image.Save(outputPath, options);
                }
            });

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to display DICOM scans as PNG thumbnails without freezing the UI.
 * 2. When a Windows Forms or WPF desktop tool must batch‑convert patient DICOM files to PNG for reporting while keeping the interface responsive.
 * 3. When a cloud‑based service processes uploaded DICOM images and wants to generate PNG previews on a background thread to improve throughput.
 * 4. When a diagnostic software integrates Aspose.Imaging to transform DICOM data into PNG for easy sharing with non‑medical stakeholders without blocking other operations.
 * 5. When a developer builds a mobile or tablet app that loads DICOM files and requires asynchronous conversion to PNG to maintain smooth user interactions.
 */
