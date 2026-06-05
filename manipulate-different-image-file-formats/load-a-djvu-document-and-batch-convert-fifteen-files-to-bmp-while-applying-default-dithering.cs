using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory and file names
            string inputDirectory = @"C:\Input\";
            string[] inputFiles = new string[]
            {
                "file1.djvu", "file2.djvu", "file3.djvu", "file4.djvu", "file5.djvu",
                "file6.djvu", "file7.djvu", "file8.djvu", "file9.djvu", "file10.djvu",
                "file11.djvu", "file12.djvu", "file13.djvu", "file14.djvu", "file15.djvu"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Output\";

            foreach (string fileName in inputFiles)
            {
                string inputPath = Path.Combine(inputDirectory, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path (same name with .bmp extension)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(fileName) + ".bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu document, apply default dithering, and save as BMP
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Apply default dithering (Floyd‑Steinberg, 8‑bit palette)
                    djvuImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                    // Save the image as BMP
                    djvuImage.Save(outputPath, new BmpOptions());
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
 * 1. When a C# application must migrate a legacy archive of DjVu scans into BMP files for compatibility with an older Windows imaging system, this batch conversion with default Floyd‑Steinberg dithering ensures the images retain visual fidelity.
 * 2. When a document management workflow needs to generate thumbnail previews of DjVu pages in BMP format for quick display in a web portal, the code can process multiple files at once while applying consistent 8‑bit dithering.
 * 3. When a digital preservation project requires converting a collection of DjVu technical drawings to BMP for inclusion in a CAD‑compatible repository, the Aspose.Imaging API provides a reliable way to batch convert and dither the images.
 * 4. When an automated ETL (extract‑transform‑load) pipeline for a publishing house must transform incoming DjVu manuscripts into BMP assets for downstream printing software, this snippet handles bulk loading, dithering, and saving in a single loop.
 * 5. When a Windows desktop utility needs to export DjVu e‑books as BMP images for offline viewing on devices that only support BMP, the code offers a straightforward C# solution to process fifteen files with default dithering in one run.
 */