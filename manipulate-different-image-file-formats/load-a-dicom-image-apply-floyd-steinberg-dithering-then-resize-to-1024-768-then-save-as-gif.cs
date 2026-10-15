// HOW-TO: Convert DICOM to GIF with Floyd Steinberg Dithering and Resize in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicom = image as DicomImage;
                if (dicom == null)
                {
                    Console.Error.WriteLine("Failed to load DICOM image.");
                    return;
                }

                dicom.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                dicom.Resize(1024, 768);

                var options = new GifOptions();
                dicom.Save(outputPath, options);
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
 * 1. When you need to display high‑contrast medical scans on a web page, you can convert DICOM files to GIF with Floyd‑Steinberg dithering and resize them to 1024×768 using C#.
 * 2. When integrating a radiology system with a legacy viewer that only supports GIF, you can programmatically transform DICOM images, apply dithering for better visual quality, and scale them to a standard size.
 * 3. When creating thumbnail previews of large DICOM studies for a mobile app, you can use Aspose.Imaging to dither, resize, and save the images as lightweight GIFs in C#.
 * 4. When exporting diagnostic images for patient reports that require a fixed resolution and limited color palette, you can convert DICOM to GIF with Floyd‑Steinberg dithering and resize them in a .NET application.
 * 5. When automating batch processing of DICOM files to generate animated GIF slideshows, you can apply dithering and uniform resizing before saving each frame with Aspose.Imaging in C#.
 */
