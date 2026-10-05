// HOW-TO: Extract All Frames From Multi-Page DICOM and Save As PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.dcm";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multiPage = image as IMultipageImage;
                if (multiPage == null)
                {
                    Console.Error.WriteLine("The image does not support multiple pages.");
                    return;
                }

                int pageIndex = 0;
                foreach (Image page in multiPage.Pages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"frame_{pageIndex}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    PngOptions pngOptions = new PngOptions();
                    page.Save(outputPath, pngOptions);
                    pageIndex++;
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
 * 1. When a radiology software needs to generate thumbnail previews of each slice in a DICOM series for a web viewer.
 * 2. When a medical research pipeline must convert every frame of a multi-frame DICOM into PNG files for machine-learning model training.
 * 3. When a hospital information system wants to archive individual DICOM frames as lossless PNGs for long-term storage compliance.
 * 4. When a developer builds a diagnostic reporting tool that extracts each DICOM image to embed them in PDF reports.
 * 5. When an imaging QA process requires batch conversion of all frames in a DICOM study to PNG to compare visual quality across modalities.
 */
