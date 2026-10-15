// HOW-TO: Batch Convert DICOM to BMP with Gaussian Blur and Resize in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DicomImage image = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(1, 1.0));
                    image.Resize(640, 480);
                    BmpOptions bmpOptions = new BmpOptions();
                    image.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application needs to preprocess DICOM scans by smoothing and resizing them before storing them as BMP files for legacy systems.
 * 2. When a radiology workflow requires converting a folder of DICOM files into a uniform bitmap format for quick thumbnail generation in a C# desktop viewer.
 * 3. When a research project must batch‑process CT or MRI images, applying a Gaussian blur to reduce noise and scaling them to 640×480 for machine‑learning model input.
 * 4. When a hospital IT system needs to export DICOM images to BMP for integration with third‑party reporting tools that only accept bitmap files.
 * 5. When a developer wants to automate the conversion of multiple DICOM files to BMP while applying consistent image filtering and size constraints in a .NET service.
 */
