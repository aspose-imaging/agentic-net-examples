// HOW-TO: Convert EPS to PSD and Verify File Creation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output/output.psd";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    PsdOptions options = new PsdOptions();
                    image.Save(outputPath, options);
                }

                if (File.Exists(outputPath))
                {
                    Console.WriteLine("PSD file created successfully.");
                }
                else
                {
                    Console.Error.WriteLine($"Failed to create PSD file: {outputPath}");
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
 * 1. When you need to programmatically convert vector EPS artwork to a Photoshop PSD file for further editing in a .NET application.
 * 2. When you must ensure that the converted PSD file was successfully written to disk before proceeding with downstream processing.
 * 3. When automating a batch workflow that reads EPS files from a source folder, creates output directories, and saves them as PSDs using Aspose.Imaging.
 * 4. When handling user‑uploaded EPS files in a web service and you want to validate the conversion result to avoid broken image links.
 * 5. When integrating image conversion into a CI/CD pipeline and you need to confirm the PSD output exists to trigger subsequent build steps.
 */
